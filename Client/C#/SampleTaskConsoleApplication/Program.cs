using NDesk.Options;
using SampleTaskConsoleApplication.TaskDatabaseServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SampleTaskConsoleApplication
{
    /// <summary>
    /// How to run:
    /// 
    /// Register this client:
    /// SampleTaskConsoleApplication.exe -r => 8c3a75ed-5c06-4b36-bd6e-87b8c7f20452
    /// 
    /// Create user:
    /// SampleTaskConsoleApplication.exe -c -e test@test.com -p Password123 => 75b51cfc-b5de-415f-96e1-ecc44ebdcf63
    /// 
    /// Login user and list all tasks:
    /// SampleTaskConsoleApplication.exe -l -e test@test.com -p Password123 -cid 8c3a75ed-5c06-4b36-bd6e-87b8c7f20452
    /// 
    /// Login user and create a task:
    /// SampleTaskConsoleApplication.exe -s -ct Task1 -e test@test.com -p Password123 -cid 8c3a75ed-5c06-4b36-bd6e-87b8c7f20452 -eid 456
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Salted password hashing with PBKDF2-SHA1.
        /// Author: havoc AT defuse.ca
        /// www: http://crackstation.net/hashing-security.htm
        /// Compatibility: .NET 3.0 and later.
        /// </summary>
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        public static long DateTimeUtcNowOurTicks()
        {
            DateTime centuryBegin = new DateTime(2001, 1, 1).ToUniversalTime();
            DateTime currentDate = DateTime.UtcNow;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            return (long)elapsedSpan.TotalSeconds / 10;
        }

        public static string CreateHash1(string password, string salt2)
        {
            byte[] salt = Convert.FromBase64String(salt2);
            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        public static string CreateHash2(string hashedPassword1, string salt2)
        {
            byte[] salt = Convert.FromBase64String(salt2);
            hashedPassword1 += DateTimeUtcNowOurTicks();
            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(hashedPassword1, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: SimpleTaskConsoleApplication [OPTIONS]+");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        static void Main(string[] args)
        {
            bool show_help = false;
            List<string> names = new List<string>();
            bool registerClient = false;
            bool createUser = false;
            Guid clientId = Guid.Empty;
            string taskName = null;
            string externalId = null;
            bool listTasks = false;
            bool saveTask = false;
            string pwd = null;
            string email = null;

            var p = new OptionSet() {
            { "r|registerClient", "Register the client, print the Client Registration ID",
              v => { registerClient = (v != null); } },
            { "c|createUser", "Register the user, print the User ID",
              v => { createUser = (v != null); } },
            { "cid|clientId=", 
                "the Client Registration ID.\n" + 
                    "this must be Guid.",
              (Guid v) => clientId = v },
            { "eid|externalId=", 
                "External Task ID.\n",
              (string v) => externalId = v },
            { "e|email=", 
                "User email.\n",
              (string v) => email = v },
            { "p|password=", 
                "User password.\n",
              (string v) => pwd = v },
            { "ct|createTask=", 
                "Task name.\n",
              (string v) => taskName = v },
            { "l|list",  "show all tasks", 
              v => listTasks = v != null },
            { "s|save",  "save task", 
              v => saveTask = v != null },
            { "h|help",  "show this message and exit", 
              v => show_help = v != null },
        };

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("SimpleTaskConsoleApplication failed: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `SampleTaskConsoleApplication --help' for more information.");
                return;
            }

            if (show_help)
            {
                ShowHelp(p);
                return;
            }

            if (registerClient)
            {
                Console.WriteLine(RegisterClient.Do());
                return;
            }

            if (createUser)
            {
                Console.WriteLine(CreateUser.Do(email, pwd));
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowHelp(p);
                return;
            }                


            TaskDatabaseSoapClient wsdl = new TaskDatabaseSoapClient("TaskDatabaseSoap", "http://wsdl.sync.today/TaskDatabase.asmx");
            string salt = wsdl.GetUserSalt(email);
            Console.WriteLine(string.Format("salt:'{0}'", salt));
            string hashedPasword = CreateHash1(pwd, salt);
            Console.WriteLine(string.Format("hashedPasword:'{0}'", hashedPasword));
            string finalPassword = CreateHash2(hashedPasword, salt);
            Console.WriteLine(string.Format("finalPassword:'{0}'", finalPassword));
            var loggedUser = wsdl.LoginUser2(email, finalPassword);
            Console.WriteLine(string.Format("loggedUser.InternalId:'{0}'", loggedUser.InternalId));
            Account account = wsdl.GetAccountForClient(loggedUser.InternalId, clientId);
            Console.WriteLine(string.Format("account.InternalId:'{0}'", account.InternalId));

            if (listTasks)
            {
                NuTask[] tasks = wsdl.GetTasks(account, loggedUser);
                foreach (NuTask task in tasks)
                {
                    PrintTask(task);
                }

                return;
            }

            if (saveTask)
            {
                var task = new NuTask();
                task.Body = "TaskBody";
                task.Company = "Company ltd.";
                task.Completed = false;
                task.DueDate = DateTime.Now.AddDays(1.0);
                task.ExternalId = externalId;
                task.IsPrivate = false;
                task.LastModified = DateTime.Now;
                task.Reminder = task.DueDate.Value.AddHours(-1.0);
                task.StartDate = task.LastModified;
                task.Subject = taskName;

                NuTask task2 = wsdl.SaveTask(account, loggedUser, task);
                PrintTask(task2);
            }
        }

        private static void PrintTask(NuTask task)
        {
            Console.WriteLine("'{0}' ['{1}'] due on '{2}'", task.Subject, task.ExternalId, task.DueDate );
        }
    }
}

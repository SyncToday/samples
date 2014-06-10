using SampleTaskConsoleApplication.TaskDatabaseServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SampleTaskConsoleApplication
{
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

        static void Main(string[] args)
        {
            SampleTaskConsoleApplication.DataModelServiceReference.DataModelSoapClient wsdl2 = new SampleTaskConsoleApplication.DataModelServiceReference.DataModelSoapClient("DataModelSoap", "http://wsdl.sync.today/DataModel.asmx");
            string pwd = "Secu^#word23";
            Guid newid = Guid.NewGuid();
            SampleTaskConsoleApplication.DataModelServiceReference.User user = wsdl2.CreateUser2(newid.ToString(), 0, "aaa@hotmail.com", pwd, "John", "Doe");
            Console.WriteLine(string.Format("user.InternalId:'{0}'", user.InternalId));
            Console.WriteLine(string.Format("user.Email:'{0}'", user.Email));

            SampleTaskConsoleApplication.DataModelServiceReference.Account account = wsdl2.CreateAccount2(newid.ToString(), user.InternalId.ToString(), "user@name.com", "Pass_word1", "server", "naseukolycz.universalsync.communicator.inmemory.1");
            Console.WriteLine(string.Format("account.InternalId:'{0}'", account.InternalId));

            TaskDatabaseSoapClient wsdl = new TaskDatabaseSoapClient("TaskDatabaseSoap", "http://wsdl.sync.today/TaskDatabase.asmx");
            string salt = wsdl.GetUserSalt(user.Email);
            Console.WriteLine(string.Format("salt:'{0}'", salt));

            string hashedPasword = CreateHash1(pwd, salt);
            Console.WriteLine(string.Format("hashedPasword:'{0}'", hashedPasword));

            string finalPassword = CreateHash2(hashedPasword, salt);
            Console.WriteLine(string.Format("finalPassword:'{0}'", finalPassword));

            var loggedUser = wsdl.LoginUser2(user.Email, finalPassword);

            var task = new NuTask();
            task.Body = "TaskBody";
            task.Company = "Company ltd.";
            task.Completed = false;
            task.DueDate = DateTime.Now.AddDays(1.0);
            task.ExternalId = Guid.NewGuid().ToString();
            task.IsPrivate = false;
            task.LastModified = DateTime.Now;
            task.Reminder = task.DueDate.Value.AddHours(-1.0);
            task.StartDate = task.LastModified;
            task.Subject = "Task-" + task.LastModified.Ticks;

            NuTask task2 = wsdl.SaveTask(loggedUser, task);

            NuTask[] tasks = wsdl.GetTasks(loggedUser);
            Console.WriteLine(string.Format("tasks.Count():'{0}'", tasks.Count()));

            NuTask task3 = tasks[0];
            NuTask task4 = wsdl.GetTask(loggedUser, task2.ExternalId);

            Console.WriteLine(string.Format("task2.Subject:'{0}'", task2.Subject));
            Console.WriteLine(string.Format("task3.Subject:'{0}'", task3.Subject));
            Console.WriteLine(string.Format("task4.Subject:'{0}'", task4.Subject));

            task4.Subject += "-changed";

            NuTask task5 = wsdl.SaveTask(loggedUser, task4);
            Console.WriteLine(string.Format("task5.Subject:'{0}'", task5.Subject));

            task4.ExternalId += "-changed";
            NuTask task6 = wsdl.ChangeTaskExternalId(loggedUser, task5.ExternalId, task4);

            NuTask task7 = wsdl.GetTask(loggedUser, task4.ExternalId);
            Console.WriteLine(string.Format("task7.Subject:'{0}'", task7.Subject));

            NuTask task8 = wsdl.GetTask(loggedUser, task5.ExternalId);
            Console.WriteLine(string.Format("task8:'{0}'", task8));
        }
    }
}

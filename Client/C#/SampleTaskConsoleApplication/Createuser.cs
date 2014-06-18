using SampleTaskConsoleApplication.DataModelServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTaskConsoleApplication
{
    class CreateUser
    {
        public static Guid Do(string email, string pwd)
        {
            DataModelSoapClient wsdl2 = new DataModelSoapClient("DataModelSoap", "http://wsdl.sync.today/DataModel.asmx");
            Guid newid = Guid.NewGuid();
            User user = wsdl2.CreateUser2(newid.ToString(), 0, email, pwd, "John", "Doe");
            return user.InternalId;
        }
    }
}

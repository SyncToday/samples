using SampleTaskConsoleApplication.DataModelServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTaskConsoleApplication
{
    class RegisterClient
    {
        public static Guid Do()
        {
            DataModelSoapClient wsdl2 = new DataModelSoapClient("DataModelSoap", "http://wsdl.sync.today/DataModel.asmx");
            Guid newid = Guid.NewGuid();
            ClientRegistration clientRegistration = new ClientRegistration();
            clientRegistration.AccountTemplate = new AccountTemplate();
            clientRegistration.AccountTemplate.AccountAssemblyName = "naseukolycz.universalsync.communicator.inmemory.1";
            clientRegistration.Name = "SampleTaskConsoleApplication";
            clientRegistration = wsdl2.RegisterClient(clientRegistration);
            return clientRegistration.InternalId;
        }
    }
}

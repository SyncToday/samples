# PowerShell script to create Sync.Today users and create Exchange accounts for them
# Note this only works in Powershell 3+
# Copyright (C) Gassumo Ltd.

# change the server on the next line!
$server = "http://wsdl.sync.today"

# exchange server
# keep empty for AutoDiscover see http://msdn.microsoft.com/en-us/library/office/jj900169(v=exchg.150).aspx
$exchangeserver = ""

# define the user list
$users = 
@(
[pscustomobject]@{FirstName="Joe";LastName="Doe";Email="joe.doe@outlook.cc";Password="VerySecretPassword1";ExchangeEmail="joe.doe@company.com";ExchangePassword="EvenMoreComplexPwd1"},
[pscustomobject]@{FirstName="Gill";LastName="Sherman";Email="gill.sherman@outlook.cc";Password="VerySecretPassword2";ExchangeEmail="gill.sherman@company.com";ExchangePassword="EvenMoreComplexPwd2"},
[pscustomobject]@{FirstName="Dory";LastName="Blue";Email="dory.blue@outlook.cc";Password="VerySecretPassword3";ExchangeEmail="dory.blue@company.com";ExchangePassword="EvenMoreComplexPwd3"}
)

#exchange communicator assembly
$exchangecommassembly = "Sync.Today.Comm.Exchange"

$synctoday = New-WebServiceProxy -Uri ( $server + "/DataModel.asmx?WSDL" )

# iterate through users
foreach ( $user in $users ) 
{
    # create new user
    $createduser = $synctoday.CreateUser2([System.Guid]::NewGuid().ToString(), -1, $user.Email, $user.Password, $user.FirstName, $user.LastName )
    # assign him an account with exchange username and password
    $createdaccount = $synctoday.CreateAccount2([System.Guid]::NewGuid().ToString(), $createduser.InternalId, $user.ExchangeEmail, $user.ExchangePassword, $exchangeserver, $exchangecommassembly )
}

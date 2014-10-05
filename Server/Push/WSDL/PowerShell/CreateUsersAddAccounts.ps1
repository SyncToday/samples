# PowerShell script to create Sync.Today users and create accounts for them
# Copyright (C) Gassumo Ltd.

# change the server on the next line!
$server = "http://wsdl.sync.today"

# define the user list
$users = 
@([pscustomobject]@{FirstName="Joe";LastName="Doe";Email="joe.doe@outlook.cc";Password="VerySecretPassword1"},
[pscustomobject]@{FirstName="Gill";LastName="Sherman";Email="gill.sherman@outlook.cc";Password="VerySecretPassword2"},
[pscustomobject]@{FirstName="Dory";LastName="Blue";Email="dory.blue@outlook.cc";Password="VerySecretPassword3"})

$synctoday = New-WebServiceProxy -Uri ( $server + "/DataModel.asmx?WSDL" )

# iterate through users
foreach ( $user in $users ) 
{
    # create new user
    $createduser = $synctoday.CreateUser2([System.Guid]::NewGuid().ToString(), -1, $user.Email, $user.Password, $user.FirstName, $user.LastName )
}

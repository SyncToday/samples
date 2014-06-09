#New-WebServiceProxy -Uri http://wsdl.sync.today/DataModel.asmx?WSDL | Get-Member -Type Method -name createuser2 |fl

#Create new user
Write-Host -ForegroundColor Green "<<<Creating User>>>"

$synctoday = New-WebServiceProxy -Uri http://wsdl.sync.today/DataModel.asmx?WSDL
$userid = [System.Guid]::NewGuid().ToString()
$userName = Read-Host "First Name"
$userLast = Read-Host "Last Name"
$userEmail = Read-Host "Primary Email"
$userPassword = Read-Host "Password" -AsSecureString
$maint = "-1"
$synctoday.CreateUser2($userid, $maint, $userName, $userLast, $userEmail, $userPassword)

#Add Account1 to user
Write-Host -ForegroundColor Red "<<<GOOGLE ACCOUNT>>>"
$acctid1 =  [System.Guid]::NewGuid().ToString()
$accName1 = Read-Host "user@name.com"
$password1 = Read-Host "Password" -AsSecureString
$server1 = Read-Host "Server"
$AAN1 = "naseukolycz.universalsync.communicator.inmemory.1"
Write-Host -ForegroundColor Red "<<<Adding $accName1 to $userName $userLast>>>"
$synctoday.CreateAccount2($acctid1,$userid,$accName1,$password1,$server1,$AAN1)

#Add Account2 to user
Write-Host -ForegroundColor Cyan "<<<ATOLLON ACCOUNT>>>"
$acctid2 =  [System.Guid]::NewGuid().ToString()
$accName2 = Read-Host "user@name.com"
$password2 = Read-Host "Password" -AsSecureString
$server2 = Read-Host "Server"
$AAN2 = "naseukolycz.universalsync.communicator.inmemory.2"
Write-Host -ForegroundColor Cyan "<<<Adding $accName2 to $userName $userLast>>>"
$synctoday.CreateAccount2($acctid2,$userid,$accName2,$password2,$server2,$AAN2)

#Check
#$synctoday.GetAccounts($userid)

#Password Check
#Param(
#    [Parameter(Mandatory=$true, Position=0, HelpMessage="Password?")]
#     [SecureString]$password
#   )
#
#   $pw = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($password))
#
#   write-host $pw

#Creating Contact
Write-Host -ForegroundColor Green "<<<Creating Contact>>>"
$extid = [System.Guid]::NewGuid().ToString() 
$contactName = Read-Host "Full Name"
$PhoneNumberHome = Read-Host "Home Phone"
$PhoneNumberWork = Read-Host "Work Phone"
$EmailAddressHome = Read-host "Private Email"
$EmailAddressWork = Read-Host "Work Email"
$PhoneNumberCellPhone = Read-Host "Mobile"
$Address = Read-Host "Home Address"
$PhysicalAddressHomeStreet = Read-Host "Street"
$PhysicalAddressHomeCity = Read-Host "City"
$PhysicalAddressHomeCountry = Read-Host "Country"
$PhysicalAddressHomeState = Read-Host "State"
$PhysicalAddressHomePostalCode = Read-Host "Postal Code"
$PhysicalAddressWorkStreet = Read-Host "Work Street"
$PhysicalAddressWorkCity = Read-Host "Work City"
$PhysicalAddressWorkCountry = Read-Host "Work Country"
$PhysicalAddressWorkState = Read-Host "Work State"
$PhysicalAddressWorkPostalCode = Read-Host "Work Postal Code"
$JobPosition = Read-Host "Work Position"
$Company = Read-Host "Company"
$LastModified = ""
$belongsToAccount = $acctid1
$isOriginal = "true"
$isDeleted = "false"
$relationId = ""
Write-Host -ForegroundColor Green "<<<Creating Contact>>>"
$synctoday.CreateContact2($extid,$contactName,$PhoneNumberHome,$PhoneNumberWork,$PhoneNumberCellPhone,$EmailAddressHome,$EmailAddressWork,$Address,$PhysicalAddressHomeStreet,$PhysicalAddressHomeCity,
$PhysicalAddressHomeCountry,$PhysicalAddressHomeState,$PhysicalAddressHomePostalCode,$PhysicalAddressWorkStreet,$PhysicalAddressWorkCity,$PhysicalAddressWorkCountry,$PhysicalAddressWorkState,
$PhysicalAddressWorkPostalCode,$JobPosition,$Company,$LastModified,$belongsToAccount,$isOriginal,$isDeleted,$relationId)

#Sync Accounts
Write-Host -ForegroundColor Yellow "<<<Synchronizing>>>"
$synctoday.SynchronizeUser2($userid)
Write-Host -ForegroundColor DarkMagenta "<<<Done>>>"

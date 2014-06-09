#Dej metody
#New-WebServiceProxy -Uri http://wsdl.sync.today/DataModel.asmx?WSDL | Get-Member -Type Method -name createuser2 |fl

#Create new user
Write-Host -ForegroundColor Green "<<<VYTVARIM UZIVATELE>>>"

$synctoday = New-WebServiceProxy -Uri http://wsdl.sync.today/DataModel.asmx?WSDL
$userid = [System.Guid]::NewGuid().ToString()
$userName = Read-Host "First Name"
$userLast = Read-Host "Last Name"
$userEmail = Read-Host "Primary Email"
$userPassword = Read-Host "Password" -AsSecureString
$maint = "-1"
$synctoday.CreateUser2($userid, $maint, $userName, $userLast, $userEmail, $userPassword)

#Pridej Acc1 k uzivately
Write-Host -ForegroundColor Red "<<<UCET GOOGLE>>>"
$acctid1 =  [System.Guid]::NewGuid().ToString()
$accName1 = Read-Host "user@name.com"
$password1 = Read-Host "Heslo" -AsSecureString
$server1 = Read-Host "Server"
$AAN1 = "naseukolycz.universalsync.communicator.inmemory.1"
Write-Host -ForegroundColor Red "<<<PRIDAVAM UCET1 $accName1 K UZIVATELY $userid>>>"
$synctoday.CreateAccount2($acctid1,$userid,$accName1,$password1,$server1,$AAN1)

#Pridej Acc2 k uzivately
Write-Host -ForegroundColor Cyan "<<<UCET ATOLLON>>>"
$acctid2 =  [System.Guid]::NewGuid().ToString()
$accName2 = Read-Host "user@name.com"
$password2 = Read-Host "Heslo" -AsSecureString
$server2 = Read-Host "Server"
$AAN2 = "naseukolycz.universalsync.communicator.inmemory.2"
Write-Host -ForegroundColor Cyan "<<<PRIDAVAM UCET2 $accName2 K UZIVATELY $userid>>>"
$synctoday.CreateAccount2($acctid2,$userid,$accName2,$password2,$server2,$AAN2)

#kontrola
#$synctoday.GetAccounts($userid)

#Kontorla hesla
#Param(
#    [Parameter(Mandatory=$true, Position=0, HelpMessage="Password?")]
#     [SecureString]$password
#   )
#
#   $pw = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($password))
#
#   write-host $pw

#Vytvarim kontakt
Write-Host -ForegroundColor Green "<<<VYTVARIM KONTAKT>>>"
$extid = [System.Guid]::NewGuid().ToString() 
$contactName = Read-Host "Jmeno a prijmeni"
$PhoneNumberHome = Read-Host "Telefon domu"
$PhoneNumberWork = Read-Host "Telefon do prace"
$EmailAddressHome = Read-host "Email osobni"
$EmailAddressWork = Read-Host "Email do prace"
$PhoneNumberCellPhone = Read-Host "PhoneNumberCellPhone"
$Address = Read-Host "Adresa domu"
$PhysicalAddressHomeStreet = Read-Host "Ulice"
$PhysicalAddressHomeCity = Read-Host "Mesto"
$PhysicalAddressHomeCountry = Read-Host "Okres"
$PhysicalAddressHomeState = Read-Host "Stat"
$PhysicalAddressHomePostalCode = Read-Host "PSC"
$PhysicalAddressWorkStreet = Read-Host "Ulice firmy"
$PhysicalAddressWorkCity = Read-Host "Mesto firmy"
$PhysicalAddressWorkCountry = Read-Host "Oblast firmy"
$PhysicalAddressWorkState = Read-Host "Stat firmy"
$PhysicalAddressWorkPostalCode = Read-Host "PSC firmy"
$JobPosition = Read-Host "Pracovni pozice"
$Company = Read-Host "Spolecnost"
$LastModified = ""
$belongsToAccount = $acctid1
$isOriginal = "true"
$isDeleted = "false"
$relationId = ""
Write-Host -ForegroundColor Green "<<<ZAKLADAM KONTAKT>>>"
$synctoday.CreateContact2($extid,$contactName,$PhoneNumberHome,$PhoneNumberWork,$PhoneNumberCellPhone,$EmailAddressHome,$EmailAddressWork,$Address,$PhysicalAddressHomeStreet,$PhysicalAddressHomeCity,
$PhysicalAddressHomeCountry,$PhysicalAddressHomeState,$PhysicalAddressHomePostalCode,$PhysicalAddressWorkStreet,$PhysicalAddressWorkCity,$PhysicalAddressWorkCountry,$PhysicalAddressWorkState,
$PhysicalAddressWorkPostalCode,$JobPosition,$Company,$LastModified,$belongsToAccount,$isOriginal,$isDeleted,$relationId)

#Synchronizuj ucty
Write-Host -ForegroundColor Yellow "<<<SYNCHRONIZUJI>>>"
$synctoday.SynchronizeUser2($userid)
Write-Host -ForegroundColor DarkMagenta "<<<HOTOVO>>>"

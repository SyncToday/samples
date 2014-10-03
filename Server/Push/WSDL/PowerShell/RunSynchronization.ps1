# Synchronization PowerShell script to synchronize Sync.Today users
# Copyright (C) Gassumo Ltd.

# change the server on the next line!
$server = "http://naseukolycz.sync.today"

# get the user list
$synctoday = New-WebServiceProxy -Uri ( $server + "/DataModel.asmx?WSDL" )
$users = $synctoday.GetUsers2()
# iterate through users
foreach ( $user in $users ) 
{
    # spawn a new server thread for each user; use SynchronizeUser2 for the synchronous synchronization if needed (can timeout!)
    $synctoday.SynchronizeUser2A($user.InternalId)
}

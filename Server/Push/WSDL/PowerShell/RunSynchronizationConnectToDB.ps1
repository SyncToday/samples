# Synchronization PowerShell script to synchronize Sync.Today users
# Copyright (C) Gassumo Ltd.

# change the server on the next line!
$server = "http://naseukolycz.sync.today"

# change the database connection on the next lines!
# use $connectionString="Data Source=(localdb)\ProjectsV12;Initial Catalog=SyncToday; Trusted_Connection=True" for integrated authentication
$dataSource = "IP,PORT"
$user = "user"
$pwd = "pasword"
$database = "Sync.Today"
$connectionString = "Server=$dataSource;uid=$user; pwd=$pwd;Database=$database;Integrated Security=False;"
#$connectionString="Data Source=(localdb)\ProjectsV12;Initial Catalog=SyncToday; Trusted_Connection=True"

$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString

$connection.Open()

# get the user list
$synctoday = New-WebServiceProxy -Uri ( $server + "/DataModel.asmx?WSDL" )
$users = $synctoday.GetUsers2()
# iterate through users
foreach ( $user in $users ) 
{
    # spawn a new server thread for each user; use SynchronizeUser2 for the synchronous synchronization if needed (can timeout!)
    $synctoday.SynchronizeUser2A($user.InternalId)
}

$query = "SELECT * FROM Journal ORDER BY 1 DESC"

$command = $connection.CreateCommand()
$command.CommandText = $query

$result = $command.ExecuteReader()

$table = new-object "System.Data.DataTable"
$table.Load($result)

$format = @{Expression={$_.Id};Label=”Id”;width=10},@{Expression={$_.Level};Label=”Level”; width=10},@{Expression={$_.Message};Label=”Message”; width=50}

$table | format-table $format #| Out-File C:\Temp\journals.txt

$connection.Close()

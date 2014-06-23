<?php
include ('Util.php');
include ('Actions.php');

$util = new Util();

$paramsUser = array('InternalId' => $util->GetNewGuid(), 'Maintenance' => -1);

$account1params = array('InternalId' => $util->GetNewGuid(),
    				    'BelongsToUser' => $util->GetArrayValue($paramsUser, "InternalId", null),
    				    'Username' => "user@name.com",
    				    'Password' => "Pass_word1",
    				    'Server' => "server",
   		 			    'AccountAssemblyName' => "naseukolycz.universalsync.communicator.inmemory.1");

$account2params = array('InternalId' => $util->GetNewGuid(),
    				    'BelongsToUser' => $util->GetArrayValue($paramsUser, "InternalId", null),
    				    'Username' => "user@name.com",
    				    'Password' => "Pass_word1",
    				    'Server' => "server",
   		 			    'AccountAssemblyName' => "naseukolycz.universalsync.communicator.inmemory.2");

$contactParams = array(
   		 'ExternalId' => $util->GetNewGuid(),
      	 'FullName' => "Peter Forsberg",
         'PhoneNumberHome' => "111 111 111",
         'PhoneNumberWork' => "222 222 222",
         'PhoneNumberCellPhone'=> "333 333 333",
         'EmailAddressHome'=> "email@home.com",
         'EmailAddressWork'=> "email@work.com",
         'Address' => "Prague, Starometska 37",
         'PhysicalAddressHomeStreet'=>"Starometska 37", 
         'PhysicalAddressHomeCity'=>"Prague",
         'PhysicalAddressHomeCountry'=> "Czech Republic",
         'PhysicalAddressHomeState'=> "CZ",
         'PhysicalAddressHomePostalCode'=>"100 01",
         'PhysicalAddressWorkStreet'=>null,
   		 'PhysicalAddressWorkCountry'=>null,
   		 'PhysicalAddressWorkState'=>null,
   		 'PhysicalAddressWorkPostalCode'=> null,
   		 'JobPosition'=>"CEO",
   		 'Company'=>"Company s.r.o.",
   		 'LastModified'=> date("Y-m-d H:i:s"),
   		 'belongsToAccount'=>$util->GetArrayValue($account1params, "InternalId", null),
   		 'isOriginal'=>"true",
   		 'isDeleted'=>"false",
   		 'relationId'=> "",
);

try {
	$actions = new Actions();

	//create Client (from WSDL)
	$client = $actions->GetClient('http://wsdl.sync.today/DataModel.asmx?WSDL', array('trace' => 1));
	if($client==null) throw new Exception("Failed to create Client (WSDL).");

	//create user
	$user = $actions->CreateUser($client, $paramsUser);
	if($client==null) throw new Exception("Failed to create User.");
	echo "Created User.\n";

	//create Accounts
	$createdAccount1 = $actions->CreateAccount($client, $account1params);
	if($createdAccount1==null) throw new Exception("Failed to create Account1.");
	echo "Created Account1.\n";

	$createdAccount2 = $actions->CreateAccount($client, $account2params);
	if($createdAccount2==null) throw new Exception("Failed to create Account2.");
	echo "Created Account2.\n";

	//create contacts
	$createdContact = $actions->CreateContact($client, $contactParams);
	if($createdContact==null) throw new Exception("Failed to create Contact.");
	echo "Created Contact.\n";

	 //SynchronizeUser
	 $sync = $actions->SynchronizeUser($client, array('userId'=>$util->GetArrayValue($paramsUser, "InternalId", null)));
	 if($createdContact==null) throw new Exception("Failed to SynchronizeUser.");
	 echo "Execute SynchronizeUser method.\n";
	  
	 //GetContactsUpdatedSince
	 $time = new DateTime();
	 $time->modify("-10 hour");
	 $lessHourTime = $time->format('Y-m-d H:i');

	 $updatedSince = $actions->GetContactsUpdatedSince($client, array('accountId'=>$util->GetArrayValue($account1params, "InternalId", null), 'sinceDateTime'=>$lessHourTime));
	 if($updatedSince==null || $updatedSince->GetContactsUpdatedSince2Result == null) throw new Exception("Failed to GetContactsUpdatedSince.");
	 if($updatedSince->GetContactsUpdatedSince2Result->NuContact == null) throw new Exception("Didn't receive any NuContact.");
	 if(count($updatedSince->GetContactsUpdatedSince2Result->NuContact) != 1) throw new Exception("WSDL method GetContactsUpdatedSince2 must return 1 but returned " + count($updatedSince->GetContactsUpdatedSince2Result));
	 if($updatedSince->GetContactsUpdatedSince2Result->NuContact->Company != "Company s.r.o.") throw new Exception("Company in returned contact is xyz but expected was Company s.r.o.");
	 echo "Execute UpdatedSince method.\n";
	

} catch (SoapFault $e) {
	var_dump(libxml_get_last_error());
	var_dump($e);
}

?>
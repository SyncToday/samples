<?php
class Actions
{
	function CreateAccount($client, $params)
	{
		return $client->CreateAccount2($params);
	}

	function GetClient($input)
	{
		// this configuration is for Fiddler
		//return new SoapClient($input, array('proxy_host' => "localhost", 'proxy_port'=> 8887));
		return new SoapClient($input);
	}

	function CreateContact($client, $contactParams)
	{
		return $client->CreateContact2($contactParams);
	}

	function CreateUser($client, $params)
	{
		return $client->CreateUser2($params);
	}
	
	function SynchronizeUser($client, $userid)
	{
		return $client->SynchronizeUser2($userid);
	}
	
	function GetContactsUpdatedSince($client, $params)
	{
		return $client->GetContactsUpdatedSince2($params);
	}
}
?>
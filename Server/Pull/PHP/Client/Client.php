<?php
include 'Actions.php';
include_once 'Util\GeneratorData.php';
/**
 * This class is for Client create.
 */
class Client {

    private $client;
    private $user;
    private $actions;
    private $accounts = array();
    
    private $generatorData;
    
    /**
     * Creates Client.
     * @param type $wsdlUrl
     */
    function __construct($wsdlUrl) {
        $this->generatorData = new GeneratorData();
        try {
            //create Client (from WSDL)
            $this->actions = new Actions();
            $this->client = $this->actions->GetClient($wsdlUrl, array('trace' => 1, 'encoding'=>'UTF-8'));
        } catch (SoapFault $e) {
            echo var_dump(libxml_get_last_error());
            echo var_dump($e);
        }
    }
    
    function getCreatedUser()
    {
        return $this->user;
    }
    
    function getCreatedAccounts()
    {
        return $this->accounts;
    }
      
    function CreateAccount($params)
    {
        $account = $this->actions->CreateAccount($this->client, $params);
        array_push($this->accounts, $account);
    }
    
    function CreateUser($params)
    {
        $this->user = $this->actions->CreateUser($this->client, $params);
    }
    
    function CreateContact($contactParams)
    {
        return $this->actions->CreateContact($this->client, $contactParams);
    }
    
    function SynchronizeUser($userInternalId)
    {
        return $this->actions->SynchronizeUser($this->client, $userInternalId);
    }
    
    /**
     * We must set last sync of account
     * @param type $account
     * @param type $datetime
     */
    function SetAccountLastSync($account)
    {
        $params = array(
            'accountId' => $account->InternalId,
            'typeName' => $account->TypeName,
            'param' => $this->generatorData->getLastSyncDateTime()
        );
        
        return $this->actions->SetAccountLastSync($this->client, $params);
    }

}
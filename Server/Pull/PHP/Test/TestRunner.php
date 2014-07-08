<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
include_once 'MyCommunicator.php';
include_once 'Client\Client.php';
include_once 'Util\GeneratorData.php';
include_once 'Util\Util.php';
include_once 'Server\Server.php';

class TestRunner {

    private $client;
    private $generatorData;
    private $util;

    function __construct() {
        $this->util = new Util();
        $this->generatorData = new GeneratorData();

        try {
            echo "Creating SoapServer <br />";
            
            $server = new Server('http://localhost:22649/DataModelCallBack.asmx?WSDL');  
            $server->SetClass("MyCommunicator");
            $server->handle();
            
            echo "Creating SoapClient <br />";
            $this->client = new Client('http://localhost:22649/DataModel.asmx?WSDL');
        } catch (SoapFault $e) {
            echo var_dump(libxml_get_last_error());
            echo var_dump($e);
        }
    }

    function Run() {
        try {
            // 1st step: create user
            $this->client->CreateUser($this->generatorData->GetUserParams());
            // 2nd step: create accounts
            $this->client->CreateAccount($this->generatorData->GetAccount1Params());
            $this->client->CreateAccount($this->generatorData->GetAccount2Params());

            $this->accs = $this->client->getCreatedAccounts();
            // 3rd step: create contact
            //$createdContact = $this->CreateRandomContact("");
            //4th step: Synchronize
            $this->client->SynchronizeUser($this->client->getCreatedUser()->CreateUser2Result->InternalId);
        } catch (SoapFault $e) {
            echo var_dump(libxml_get_last_error());
            echo var_dump($e);
        }
    }

    function CreateRandomContact($relationId) {
        $params = $this->generatorData->GetRandomContactParams($this->client->getCreatedAccounts()[0], $relationId);
        $this->client->CreateContact($params);
    }

}

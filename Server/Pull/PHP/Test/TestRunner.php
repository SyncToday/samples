<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
include 'MyCommunicator.php';
include 'Client\Client.php';
include 'Util\GeneratorData.php';

class TestRuner {

    private $client;
    private $generatorData;

    function __construct() {
        $this->generatorData = new GeneratorData();

        $server = new SoapServer('http://wsdl.sync.today/DataModelCallback.asmx?WSDL', array('exceptions' => true));
        $server->setClass('MyCommunicator');
        $server->handle();

        $this->client = new Client('http://wsdl.sync.today/DataModel.asmx?WSDL');


        $this->accs = $this->client->getCreatedAccounts();
    }

    function Run() {
        // 1st step: create user
        $this->client->CreateUser($this->generatorData->GetUserParams());
        // 2nd step: create accounts
        $this->client->CreateAccount($this->generatorData->GetAccount1Params());
        $this->client->CreateAccount($this->generatorData->GetAccount2Params());
        // 3rd step: create contact
        CreateContact();       
    }
    
    function CreateContact()
    {
        $params = array();
        $this->client->CreateAccount($params);
    }

}

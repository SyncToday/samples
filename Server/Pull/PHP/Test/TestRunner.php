<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
include 'MyCommunicator.php';
include 'Client\Client.php';
include_once  'Util\GeneratorData.php';
include_once  'Util\Util.php';

class TestRunner {

    private $client;
    private $generatorData;
    private $util;

    function __construct() {
        $this->util = new Util();
        $this->generatorData = new GeneratorData();

        try {
            echo "Creating SoapServer <br />";
            $server = new SoapServer('http://wsdl.sync.today/DataModelCallback.asmx?WSDL', array('exceptions' => true));
            $server->setClass('MyCommunicator');
            $server->handle();

            echo "Creating SoapClient <br />";
            $this->client = new Client('http://wsdl.sync.today/DataModel.asmx?WSDL');

        } catch (SoapFault $e) {
            echo var_dump(libxml_get_last_error());
            echo var_dump($e);
        }
    }

    function Run() {
        try {
            // 1st step: create user
            $user = $this->client->CreateUser($this->generatorData->GetUserParams());
            // 2nd step: create accounts
            $this->client->CreateAccount($this->generatorData->GetAccount1Params());
            $this->client->CreateAccount($this->generatorData->GetAccount2Params());

            $this->accs = $this->client->getCreatedAccounts();
            // 3rd step: create contact
            $createdContact = CreateRandomContact("");

            //4th step: Synchronize
            $this->client->SynchronizeUser($this->util->GetArrayValue($user, 'InternalId', null));
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

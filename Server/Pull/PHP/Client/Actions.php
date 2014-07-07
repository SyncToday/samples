<?php

/**
 * This class for do actions.
 */
class Actions {

    /**
     * Creates SoapClient.
     * @param type $input is type of string (WSDL URL).
     * @return \SoapClient
     */
    function GetClient($input) {
        // this configuration is for Fiddler
        //return new SoapClient($input, array('proxy_host' => "localhost", 'proxy_port'=> 8887));
        return new SoapClient($input);
    }

    /**
     * Creates user.
     * @param type $client
     * @param type $params is array with params of user.
     * @return type
     */
    function CreateUser($client, $params) {
        return $client->CreateUser2($params);
    }

    /**
     * Creates account.
     * @param type $client
     * @param type $params is array with params of account
     * @return type
     */
    function CreateAccount($client, $params) {
        return $client->CreateAccount2($params);
    }

    /**
     * Creates contact.
     * @param type $client
     * @param type $contactParams
     * @return type
     */
    function CreateContact($client, $contactParams) {
        return $client->CreateContact2($contactParams);
    }

}
?>


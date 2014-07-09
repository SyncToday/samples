<?php

include_once 'MyCommunicator.php';
include_once 'Server\OverloadedSoapServer.php';

/**
 * This class is for SOAPServer create.
 */
class Server {

    private $server;

    /**
     * Creating SOAP Server.
     * @param type $wsdlUrl is type of string.
     */
    function __construct($wsdlUrl) {
        ini_set("soap.wsdl_cache_enabled", "0"); // disabling WSDL cache
        $this->server = new OverloadedSoapServer($wsdlUrl, array('soap_version' => SOAP_1_2));
    }

    function SetClass($nameOfClass) {
        $this->server->setClass($nameOfClass);
    }

    function handle() {
        $this->server->handle();
    }

    function getSOAPServer() {
        return $this->server;
    }

}

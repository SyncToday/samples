<?php

/**
 * This class is for SOAPServer create.
 */
class Server {

    /**
     * Creating SOAP Server.
     * @param type $wsdlUrl is type of string.
     */
    function __construct($wsdlUrl) {
        $server = new SoapServer($wsdlUrl, array('exceptions' => true));
        $server->setClass('MyCommunicator');
        $server->handle();
    }

}

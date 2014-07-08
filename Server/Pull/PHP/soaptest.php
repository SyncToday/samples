<?php

require_once 'MyCommunicator.php';

class soaptest {

    public function IsEntitySupported($typeDescriptor) {
        echo "jsem ve funkci ";
        return true;
    }
    
    public function GetEntityById() {
        return "My communicator";
    }

}

$server = new SoapServer("http://localhost:22649/DataModelCallBack.asmx?WSDL", array('soap_version' => SOAP_1_2));
$server->setClass("MyCommunicator");
//$server->setObject(new MyCommunicator());
$server->setPersistence(SOAP_PERSISTENCE_SESSION);
$server->handle();
?>


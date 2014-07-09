<?php
include_once 'Server\Server.php';
ob_start();
$server = new SoapServer("http://localhost:22649/DataModelCallBack.asmx?WSDL", array('soap_version' => SOAP_1_2));
$server->setClass("MyCommunicator");
$server->handle();
echo "before get contents";
$soapXml = ob_get_contents();
ob_end_clean();
$soapXml = preg_replace('/[^\x{0009}\x{000a}\x{000d}\x{0020}-\x{D7FF}\x{E000}-\x{FFFD}]+/u', ' ', $soapXml);


<?php

	class sampleserver {
	}

	$server = new SoapServer('http://wsdl.sync.today/DataModelCallback.asmx?WSDL');
	$server->setClass( 'sampleserver' );
	$server->handle(); 
?>
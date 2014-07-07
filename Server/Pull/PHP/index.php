<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
        <?php
        include 'MyCommunicator.php';
        include 'Client\Client.php';
        
       
        echo "creating soap server.<br />";
        echo "<br />";
        try {
            $server = new SoapServer('http://wsdl.sync.today/DataModelCallback.asmx?WSDL', array('exceptions' => true));
            $server->setClass('MyCommunicator');
            $server->handle();
            
            $clientClass = new Client('http://wsdl.sync.today/DataModel.asmx?WSDL');            
            $clientClass->RegisterUser($params);

            echo "FUNCTIONS";
            echo "<br />";
            foreach ($server->getFunctions() as $val) {
                echo $val;
                echo "<br />";
            }
        } catch (SoapFault $ex) {
            echo "ERROR message: <br />" + $e->faultcode;
            throw $ex;
        }
        
        echo "<br />";
        echo "created soap server.<br />";
        ?>
    </body>
</html>

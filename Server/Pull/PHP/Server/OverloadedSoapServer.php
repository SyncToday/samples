<?php
class OverloadedSoapServer extends SoapServer {

    public function handle($soap_request = null) {
        session_start();
        parent::handle();
        $responseFromParent = ob_get_contents();
        ob_end_clean();
        ob_start();
        
        /*
         * 1. ulozit si obsah 'ob' do promenne
         * 2. deserializovat soap zpatky na objekt
         * 3. serializovat do XML (pravdepodobne pres nejaky framework)
         *      a) Jak nastavit xmlns, type, atd?
         *      b) Jak vyresit pri serializaci hashmapy (item -> key, value)?
         */
        
        $_SESSION['data'] = $responseFromParent;
        echo $_SESSION['data'];
    }
}
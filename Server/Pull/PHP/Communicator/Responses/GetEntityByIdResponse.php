<?php

class GetEntityByIdResponse {

    private $GetEntityByIdResult;

    function setGetEntityByIdResult($param) {
        $this->GetEntityByIdResult = $param;
    }

}

class GetEntityByIdResult {

    private $ExternalId;
    private $LastModified;

    function setExternalId($param) {
        $this->ExternalId = $param;
    }

    function setLastModified($param) {
        $this->LastModified = $param;
    }

}
?>


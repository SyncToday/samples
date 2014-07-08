<?php

class CreateEntityResponse {

    private $CreateEntityResponse;

    function setCreateEntityResponse($param) {
        $this->$CreateEntityResponse = $param;
    }

}

class CreateEntityResult {

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


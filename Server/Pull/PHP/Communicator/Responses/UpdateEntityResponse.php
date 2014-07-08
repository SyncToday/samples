<?php

class UpdateEntityResponse {

    private $UpdateEntityResult;

    function setUpdateEntityResponse($param) {
        $this->UpdateEntityResult = $param;
    }

}

class UpdateEntityResult {

    private $ExternalId;
    private $LastModified;

    function setExternalId($param) {
        $this->ExternalId = $param;
    }

    function setLastModified($param) {
        $this->LastModified = $param;
    }

}

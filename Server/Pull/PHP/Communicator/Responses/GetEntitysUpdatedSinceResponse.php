<?php

class GetEntitysUpdatedSinceResponse {

    private $GetEntitysUpdatedSinceResult;

    function setGetEntitysUpdatedSinceResult($param) {
        $this->GetEntitysUpdatedSinceResult = $param;
    }

}

class GetEntitysUpdatedSinceResult {

    private $NuObject;

    function setNuObject($param) {
        $this->GetNuObject = $param;
    }

}

class NuObject {

    private $ExternalId;
    private $LastModified;

    function setExternalId($param) {
        $this->ExternalId = $param;
    }

    function setLastModified($param) {
        $this->LastModified = $param;
    }

}

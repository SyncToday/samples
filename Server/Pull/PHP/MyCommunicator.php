<?php

/**
 * This class simulate your communicator.
 */
class MyCommunicator {

    public function __construct() {
    }
    
    public function AreEntityMethodsSupported()
    {
        /*
         * If you supported then CreateEntity method is working.
         */
        return true;
    }
    
    /**
     * This method creates the contact.
     * @param type $param is Contact entity.
     */
    public function CreateContact($param)
    {}
    
    /**
     * This method creates the general entity (contact, event, task etc.).
     * @param type $param is general entity
     */
    public function CreateEntity($param)
    {}
    
    /**
     * This method deletes the contact by its ExternalId.
     * @param type $externalId
     * @param type $expectedLastDate
     */
    public function DeleteEntity($externalId, $expectedLastDate)
    {}
   
    /**
     * Returns entity by its ExternalId.
     * @param type $externalId
     */
    public function GetEntityById($externalId)
    {}

    /**
     * Returns last update time parameter from entity with ExternalId.
     * @param type $externalId
     * @param type $isMaintenance
     */
    public function GetEntityLastUpdateTime($externalId, $isMaintenance)
    {}
    
    /**
     * Returns all entities which has later than datetime from parameter.
     * @param type $datetime
     */
    public function GetEntitysUpdatedSince($datetime)
    {}
    
    /**
     * Returns friendly name of communicator.
     */
    public function GetFriendlyName()
    {
        return "My communicator";
    }

    /**
     * Returns boolean whether support this entity type.
     * @param type $typeDescriptor is type of integer
     */
    public function IsEntitySupported($typeDescriptor)
    {}
    
    /**
     * This method finds entity by ExternalId (param->externalId) and update it.
     * @param type $param is type of contact
     */
    public function UpdateContact($param, $expectedLastDate)
    {}
    
    
    public function UpdateEntity()
    {}
}
?>


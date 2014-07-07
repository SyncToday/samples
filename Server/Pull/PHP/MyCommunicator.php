<?php

include_once  'Util\GeneratorData.php';
include_once  'Util\Util.php';

/**
 * This class simulate your communicator.
 */
class MyCommunicator {

    // this variable simulate all contacts in your system
    private $allContacts;
    private $createdContacts;
    
    private $util;

    public function __construct() {
        $util = new Util();
        $generatorData = new GeneratorData();
        $this->allContacts = $generatorData->CreateRandomContacts(100);
    }

    public function AreEntityMethodsSupported() {
        /*
         * If you supported then CreateEntity method is working.
         */
        return false;
    }

    /**
     * This method creates the contact.
     * @param type $param is Contact entity.
     */
    public function CreateContact($param) {
        echo "my communicator - create contact"; 
        array_push($this->createdContacts, $param);
    }

    /**
     * This method creates the general entity (contact, event, task etc.).
     * @param type $param is general entity
     */
    public function CreateEntity($param) {
        echo "my communicator - create entity"; 
        array_push($this->createdContacts, $param);
    }

    /**
     * This method deletes the contact by its ExternalId.
     * @param type $externalId
     * @param type $expectedLastDate
     */
    public function DeleteEntity($externalId, $expectedLastDate) {
       echo "my communicator - delete entity";     
//find and pull contact from array
        /*
        foreach (createdContacts as $val) {
            if($this->util->)
            array_pull($this->createdContacts);
        }
         * */
    }

    /**
     * Returns entity by its ExternalId.
     * @param type $externalId
     */
    public function GetEntityById($externalId) {
        echo "my communicator - get entity by id"; 
    }

    /**
     * Returns last update time parameter from entity with ExternalId.
     * @param type $externalId
     * @param type $isMaintenance
     */
    public function GetEntityLastUpdateTime($externalId, $isMaintenance) {
        echo "my communicator - get entity last modified"; 
    }

    /**
     * Returns all entities which has later than datetime from parameter.
     * @param type $datetime
     */
    public function GetEntitysUpdatedSince($datetime) {
        echo "my communicator - updated since"; 
    }

    /**
     * Returns friendly name of communicator.
     */
    public function GetFriendlyName() {
        return "My communicator";
    }

    /**
     * Returns boolean whether support this entity type.
     * @param type $typeDescriptor is type of integer
     */
    public function IsEntitySupported($typeDescriptor) {
        return true;
    }

    /**
     * This method finds entity by ExternalId (param->externalId) and update it.
     * @param type $param is type of contact
     */
    public function UpdateContact($param, $expectedLastDate) {
        echo "my communicator - update contact"; 
    }

    public function UpdateEntity() {
        echo "my communicator - update entity"; 
    }

}
?>


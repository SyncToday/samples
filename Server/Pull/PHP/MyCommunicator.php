<?php
include_once 'Util\GeneratorData.php';
include_once 'Util\Util.php';
include_once 'Communicator\Responses\IsEntitySupportedResponse.php';
/**
 * This class simulate your communicator.
 */
class MyCommunicator {

    // this variable simulate all contacts in your system
    private $allContacts;
    private $createdContacts;
    private $util;

    public function __construct() {

        $this->util = new Util();
        $this->generatorData = new GeneratorData();
        $this->allContacts = $this->generatorData->CreateRandomContacts(100);
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
        array_push($this->createdContacts, $param);
    }

    /**
     * This method creates the general entity (contact, event, task etc.).
     * @param type $param is general entity
     */
    public function CreateEntity($param) {
        array_push($this->createdContacts, $param);
    }

    /**
     * This method deletes the contact by its ExternalId.
     * @param type $externalId
     * @param type $expectedLastDate
     */
    public function DeleteEntity($externalId, $expectedLastDate) {
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
        
    }

    /**
     * Returns last update time parameter from entity with ExternalId.
     * @param type $externalId
     * @param type $isMaintenance
     */
    public function GetEntityLastUpdateTime($externalId, $isMaintenance) {
        
    }

    /**
     * Returns all entities which has later than datetime from parameter.
     * @param type $datetime
     */
    public function GetEntitysUpdatedSince($datetime) {
        
    }

    /**
     * Returns friendly name of communicator.
     */
    public function GetFriendlyName() {
        
    }

    /**
     * Returns boolean whether support this entity type.
     * @param type $typeDescriptor is type of integer
     */
    function IsEntitySupported($typeDescriptor) {

        $formdata = get_object_vars($typeDescriptor); // Pull parameters from SOAP connection
        $descriptor = $formdata['typeDescriptor'];
        
        $isEntitySupportedResponse = new IsEntitySupportedResponse();
        $isEntitySupportedResponse->setIsEntitySupportedResult(false);
                   
        return $isEntitySupportedResponse;
    }

    /**
     * This method finds entity by ExternalId (param->externalId) and update it.
     * @param type $param is type of contact
     */
    public function UpdateContact($param, $expectedLastDate) {
        
    }

    public function UpdateEntity() {
        
    }

}

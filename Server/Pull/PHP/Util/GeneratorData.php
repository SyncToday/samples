<?php

include ('Util.php');

/**
 * This class is only for generate random data for simulate synchronization.
 */
class GeneratorData {

    private $util;
    private $userparams;
    private $firstname;
    private $surname;
    private $phonenumber;
    private $street;
    private $city;
    private $postalcode;
    private $state;
    private $jobposition;
    private $company;

    public function __construct() {
        $this->util = new Util();
        InitialData();
    }

    function InitialData() {
        $this->firstname = array(
            "Peter",
            "Jane",
            "Alexander",
            "Suzane",
            "Christopher"
        );

        $this->surname = array(
            "Smith",
            "Abraham",
            "Adkins",
            "Booner",
            "Boyce"
        );

        $this->phonenumber = array(
            "554 552 113",
            "487 552 777",
            "554 822 113",
            "554 558 558",
            "282 552 778",
            "332 747 772",
            "827 272 422",
            "554 000 113",
            "787 552 521",
            "554 552 141",
            "102 552 113",
            "999 552 154"
        );

        $this->street = array(
            "North and South Walnut Street",
            "Palafox Street",
            "Kalakaua Avenue",
            "C Street",
            "Bridge Street",
            "Market Street",
            "Broadway",
            "Benjamin Franklin Parkway",
            "The Strand (Avenue B)",
            "West Beverley Street"
        );

        $this->state = array(
            "New York",
            "California",
            "Illinois",
            "Texas",
            "Pennsylvania",
            "Arizona",
            "Florida",
            "Ohio",
            "Michigan",
            "Tennessee"
        );

        $this->postalcode = array(
            "90003 Broadway Manchester (323) ",
            "90009 Los Angeles International Airport (310/424)",
            "90009 Los Angls AFB (310/424)",
            "90010 Sanford (213)",
            "90023 Lugo (323)",
            "90034 Palms (310/424)",
            "90045 Westchester (310/424)",
            "90058 Vernon (323)"
        );

        $this->city = array(
            "Chicago",
            "Detroit",
            "El Paso",
            "Memphis",
            "Boston",
            "Seattle",
            "Denver",
            "Washington",
            "Baltimore"
        );

        $this->jobposition = array(
            "aerospace engineer jobs",
            "admitting clerk jobs",
            "administrative executive assistant jobs",
            "adjudicate specialist jobs",
            "accounts receivable clerk jobs",
            "accounts receivable collection specialist jobs",
            "animal officer jobs"
        );

        $this->company = array(
            "Wal-mart",
            "Royal Dutch Shell",
            "Exxon Mobil Corporation",
            "China National Petroleum Corporation",
            "Sinopec Group",
            "Saudi Aramco",
            "Vitol"
        );
    }

    function getRandomPhoneNumber() {
        return $this->phonenumber[array_rand($this->phonenumber)];
    }

    function getRandomJobPosition() {
        return $this->jobposition[array_rand($this->jobposition)];
    }

    function getRandomCity() {
        return $this->city[array_rand($this->city)];
    }

    function getRandomPostalCode() {
        return $this->postalcode[array_rand($this->postalcode)];
    }

    function getRandomState() {
        return $this->State[array_rand($this->state)];
    }

    function getRandomStreet() {
        return $this->street[array_rand($this->street)];
    }

    function getRandomEmail() {
        return $this->getRandomFirstName() + "@" + $this->getRandomSurname() + ".com";
    }

    function getEmail($firstname, $surname) {
        return $firstname + "@" + $surname + ".com";
    }

    function getRandomFullName() {
        return getRandomFirstName() + " " + getRandomSurname();
    }

    function getRandomFirstName() {
        return $this->firstname[array_rand($this->firstname)];
    }

    function getRandomSurname() {
        return $this->surname[array_rand($this->surname)];
    }

    function getRandomAddress() {
        return $this->getRandomStreet() + ", " + $this->getRandomCity() + ", " + $this->getRandomPostalCode();
    }

    function GetUserParams() {
        $this->userparams = array('InternalId' => $this->util->GetNewGuid(), 'Maintenance' => -1, 'Email' => getRandomEmail(),
            'Password' => 'Pass_word_xyz');
        return $this->userparams;
    }

    function getDateBetween($start_date, $end_date) {
        // Convert to timetamps
        $min = strtotime($start_date);
        $max = strtotime($end_date);

        // Generate random number using above bounds
        $val = rand($min, $max);

        // Convert back to desired date format
        return date('Y-m-d H:i:s', $val);
    }

    function GetRandomContactParams() {
        $now = date("Y-m-d H:i:s");
        $params =  array('ExternalId' => $this->util->GetNewGuid(),
            'FullName' => $this->getRandomFullName(),
            'PhoneNumberHome' => $this->getRandomPhoneNumber(),
            'PhoneNumberWork' => $this->getRandomPhoneNumber(),
            'PhoneNumberCellPhone' => $this->getRandomPhoneNumber(),
            'EmailAddressHome' => $this->getRandomEmail(),
            'EmailAddressWork' => $this->getRandomEmail(),
            'Address' => $this->getRandomAddress(),
            'PhysicalAddressHomeStreet' => $this->getRandomStreet(),
            'PhysicalAddressHomeCity' => $this->getRandomCity(),
            'PhysicalAddressHomeCountry' => $this->getRandomState(),
            'PhysicalAddressHomeState' => $this->getRandomState(),
            'PhysicalAddressHomePostalCode' => $this->getRandomPostalCode(),
            'PhysicalAddressWorkStreet' => $this->getRandomStreet(),
            'PhysicalAddressWorkCountry' => $this->getRandomCity(),
            'PhysicalAddressWorkState' => $this->getRandomCity(),
            'PhysicalAddressWorkPostalCode' => $this->getRandomPostalCode(),
            'JobPosition' => $this->getRandomJobPosition(),
            'Company' => $this->getRandomCompany(),
            'LastModified' => $this->getDateBetween(date_sub($now, date_interval_create_from_date_string('10 days')), $now),
            'belongsToAccount' => $this->util->GetArrayValue($account1params, "InternalId", null),
            'isOriginal' => "true",
            'isDeleted' => "false",
            'relationId' => "");
        return $params;
    }

    /**
     * Your communicator.
     * @return type
     */
    function GetAccount1Params() {
        return array('InternalId' => $this->util->GetNewGuid(),
            'BelongsToUser' => $this->util->GetArrayValue($this->userparams, "InternalId", null),
            'Username' => "user@name.com",
            'Password' => "Pass_word1",
            'Server' => "http://localhost:81/syncToday.server.pull/MyCommunicator.php",
            'AccountAssemblyName' => "Sync.Today.Comm.DataModelCallback");
    }

    /**
     * Other communicator.
     * @return type
     */
    function GetAccount2Params() {
        return array('InternalId' => $this->util->GetNewGuid(),
            'BelongsToUser' => $this->util->GetArrayValue($this->userparams, "InternalId", null),
            'Username' => "user@name.com",
            'Password' => "Pass_word1",
            'Server' => "server",
            'AccountAssemblyName' => "naseukolycz.universalsync.communicator.inmemory.1");
    }

}
?>


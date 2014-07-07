<?php
/**
 * This class is only for generate random data for simulate synchronization.
 */
class GeneratorData
{
    private $firstname = array(
        "Peter",
        "Jane",
        "Alexander",
        "Suzane",
        "Christopher"
    );
    
    private $surname = array(
        "Smith",
        "Abraham",
        "Adkins",
        "Booner",
        "Boyce"
    );
    
    public function __construct() {
        
    }

    public function getRandomFullName()
    {
        return $this->$firstname[array_rand($firstname)] + " " + $this->$surname[array_rand($surname)];
    }
}
?>


<?php
include 'Test\TestRunner.php';
try {
    $tests = new TestRunner();
    header('Content-Type: text/xml; charset=utf-8');
    //$tests->Run();
} catch (Exception $ex) {
    echo $ex;
    throw $ex;
}
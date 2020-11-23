
# Overview
This is a project to validate the Punk API.
You can find the documentation for the Punk API at " https://punkapi.com/documentation/v2".


In this test project, it covers mainly the testing of four stories:
1. Get All Beers
1. Get all Beers brewed before a certain date
1. Get All Beers which abv > 6
1. Verify if pagination is working as expected

# How to run the tests
To run the tests, we need to add the environment variable "env" with value "qa". 

The tests are tagged as Smoke tests and Regression tests.
When we run from the IDE, we can run all the tests together or we can go to the traits and select which one we want to run.
I have selected the ExecutionScope as "MethodLevel" so that the tests will be run parallelly.


Feature: SF_Car_Drive
	I want to work with SpecFlow

@Car
Scenario: Drive a Car
	Given I enter the speed that I am driving which is over the speed limit
	When I Drive the car
	Then I am prompted to slow down

Feature: SF_Car_Drive
	I want to work with SpecFlow

@Car
Scenario: Drive a Car Too Fast
	Given I enter the speed that I am driving which is over the speed limit
	When I Drive the car
	Then I am prompted to slow down   

@Car
Scenario: Drive a Car Under the Speed Limit
	Given I enter the speed that I am driving which is under the speed limit
	When I Drive the car
	Then I am prompted to Speed Up   

@Car
Scenario: Drive a Car Exactly the Speed Limit
	Given I enter the speed that I am driving which is exactly the speed limit
	When I Drive the car
	Then I am prompted to remain constant
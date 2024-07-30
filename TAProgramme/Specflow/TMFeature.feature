Feature: TMFeature

As a TurUp portal admin user
I would like to create, edit and delete time and material records
So that I can manage employees time and materials successfully

@regression
Scenario: Create time record with valid data
	Given I logged in to TurUp portal successfully
	When I Navigate to time and Material Page
	When I create a time record
	Then The time record should be created successfully

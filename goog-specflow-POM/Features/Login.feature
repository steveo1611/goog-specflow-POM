Feature: Login
	In order to test login functionality is working fine

Background:
	Given I am on "Gmail" website


@Login
Scenario: Check if user is able to login successfully
	Given I enter a valid username
	And I enter a valid password
	When I click on Login button
	Then I verify i am logged in successfully 

Feature: SignUp
	As a user I want to access sign up module
  So that I can add new user accounts 

@SignUp @UI
Scenario: Create new user account
	Given User on home page
	When User clicks Sign in button
	Then User should be navigated to authentication page
	When User enters a valid Email on Email Address field of create an account section 
    And User clicks Create an account button
	Then User should be navigated to Account creation page
	When User fills account creation form 
	Then Form fields should be filled correctly
	When User clicks Register button
	Then User should be navigated to My Account page
	And Account welcome message should be shown






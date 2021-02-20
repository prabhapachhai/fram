Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: try to login to amazon  with incorrect password
	Given i am navigate to url "https://www.amazon.com"
	And i have clicked on sign in link
	When when i enter email or phone number 214-403-4141
	And i click on continue button 
	And i entered password
	And i click on sign button
	Then i should get error message " your password is incorrect"



	Scenario: try to login to amazon with incorrect username
	Given i am navigate to url "https://www.amazon.com"
	And  i have clicked on sign in link 
	When i enter email or phone number 214-403-515
	And i click on continue button 
	Then i should get error message "your mobile number is not valid"
Feature: WebinarExample
	In order to see beautiful SpecFlow reports on TestProject Cloud
	As a TestProject user
	I want to run SpecFlow scenarios supported by the SDK

	Scenario Outline: User tries to log in to the TestProject demo application
		Given <firstname> wants to use the TestProject demo application
		When he logs in with username <username> and password <password>
		Then he gains access to the secure part of the application
		Examples:
			| testcase-id | firstname | username   | password |
			| TC001       | Alex      | John Smith | 12345    |
			| TC002       | Bernard   | John Smith | 98765    |
			| TC003       |Claire    | John Smith | 12345    |
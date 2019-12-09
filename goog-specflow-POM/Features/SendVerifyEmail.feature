Feature: SendandVerifyEmail
	Testing logging into GMail sending email to self and verifying email.

@mytag
Scenario: Verify GMail send email function
	Given I connect to gmail website
	And I verify I successfully log into GMail account
	Then I verify I am on the Inbox page
	When I compose new email
	And Send email to myself
	Then I will vefify the sent email will be shown in inbox
	And The email content can be validated
	And I will logout

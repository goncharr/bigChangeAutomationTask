Feature: WebFeature
	

Scenario: LogIn to twitter using valid account
	Given I have a twitter account
	When  I login in using my "correctUserName" and "correctPassword" values
	Then I should see my twitter feed

Scenario: LogIn to twitter using invalid account
	Given I have a twitter account
	When  I login in using my "correctUserName" and "incorectPassword" values
	Then I should see error "The username and password that you entered did not match our records. Please double-check and try again." message

Scenario: Post a tweet
	Given I'm logged in to twitter
	And I type any random text
	When I click "Tweet" button
	Then I should see my tweet in "Profile"

Scenario: LogOut
	Given I'm logged in to twitter
	When  I login click LogOut button
	Then I should see my twitter timeline
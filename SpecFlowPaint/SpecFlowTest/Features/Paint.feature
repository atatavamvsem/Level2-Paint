Feature: Paint

@mytag
Scenario: Paint test with various view
	Given The Paint is opened
	When I open a picture
		And I click Select All
		And I click Cut
		And I close The Paint
	Then Save dialog appears
	When I click Don't Save
	Then Picture hasn't changed
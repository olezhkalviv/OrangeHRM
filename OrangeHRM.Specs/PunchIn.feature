Feature: Employee Records Punch In
	In order to make the app better
	As a manager
	I want to be able to set Punch In

@mytag
Scenario: Verifying that Punch In is empty by default and user can set in
	Given I logged in to the 'https://orangehrm-demo-6x.orangehrmlive.com/auth/login' hrm using 'admin' / 'admin123' credentials
	And I navigated to View Attendance Record page
	And I set 'Andrew Keller' as employee name
	And I selected '15' day
	And I clicked View button
	And 'No attendance records to display' value is shown in Pinch In cell
	When I click Add button
	And I set '00:15' as attendance time
	And I click In button twice
	Then '2018-10-15 00:15:00 GMT 3.0' value should be shown in Pinch In cell

Feature: Calculator HTML Layout and Interaction

  As a user
  I want to see a functional calculator layout in the web UI
  So that I can perform basic arithmetic operations using buttons or keyboard

Background:
	Given the calculator web page is loaded

Scenario: Numbers must be visible on screen
	Then I should see buttons labeled "0" to "9"

Scenario: Basic operations must be present
	Then I should see a button labeled <Operation>

Examples:
	| Operation |
	| +         |
	| -         |
	| *         |
	| /         |
	| =         |
	| AC        |
	| +/-       |

Scenario: Toggle between Dark and Light mode
  Given the calculator web page is loaded
  When I click the mode toggle button
  Then the page should switch to light mode

  When I click the mode toggle button again
  Then the page should switch to dark mode

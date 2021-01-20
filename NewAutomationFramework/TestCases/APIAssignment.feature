Feature: Backend API assignment

@API @Backend @TestCaseID @FunctionalityName @ReleaseName
Scenario Outline: Validate the JSON response with valid key.
	Given I call promotion API with key '<APIKey>'
	Then  I validate status '200'
	And   I verify response properties for valid request

	# Not parameterzing properties to verify here but can be done to make above step generic
	Examples:
		| APIKey                  |
		| GDMSTGExy0sVDlZMzNDdUyZ |

Scenario Outline: Validate the JSON response with invalid key.
	Given I call promotion API with key '<APIKey>'
	Then  I validate status '403'
	And   I verify response properties for invalid request

	# Not parameterzing properties to verify here but can be done to make above step generic
	Examples:
		| APIKey                  |
		| GDMSTGExy0sVDlZMzNDdU |
Feature: Dish Resource

Admins can Add dishes and fetch those Dishes

Scenario: Get All Dishes
	Given I am a client
	When I make GET Request '/dishes'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Samosa"},{"id":2,"name":"Curd"},{"id":3,"name":"Chicken"}]'

Scenario Outline: Get Dish By Id
	Given I am a client
	When I make GET Request '<request>'
	Then response code must be '<statusCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request   | statusCode | responseBody             |
	| /dishes/1 | 200        | {"id":1,"name":"Samosa"} |
	@InvalidData
	Examples: 
	| request    | statusCode | responseBody                                     |
	| /dishes/24 | 404        | Dish Not Found!                                  |
	| /dishes/6y | 400        | {  "id": [    "The value '6y' is not valid."  ]} |
	| /dishes/0  | 400        | Id should not be zero                            |

Scenario Outline: Create Dish
	Given I am a client
	When I make POST Request '<request>' with following data '<requestBody>'
	Then response code must be '<responseCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request | requestBody     | responseBody | responseCode |
	| /dishes | {"name":"Curd"} | 4            | 201          |
	@InvalidData
	Examples: 
	| request | requestBody | responseBody              | responseCode |
	| /dishes | {"name":""} | Name Should Not be Empty! | 400          |

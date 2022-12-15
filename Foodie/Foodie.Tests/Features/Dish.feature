Feature: Dish Resource

Admins can Add dishes and fetch those Dishes

Scenario: Get All Dishes
	Given I am a client
	When I make GET Request '/dishes'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Veg Biryani"},{"id":2,"name":"Chicken Curry"},{"id":3,"name":"Roti"}]'

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
	| request | requestBody  | responseBody              | responseCode |
	| /dishes | {"name":"",} | Name Should Not be Empty! | 400          |

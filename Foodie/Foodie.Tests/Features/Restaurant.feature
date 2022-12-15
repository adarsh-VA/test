Feature: Restaurant Resource

Admins can Add Restaurants and fetch those Restaurants

Scenario: Get All Restaurants
	Given I am a client
	When I make GET Request '/restaurants'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Amara","dishes":[{"id":1,"name":"Veg Biryani"},{"id":3,"name":"Roti"}]},{"id":2,"name":"Mekong","Dishes":[{"id":1,"name":"Veg Biryani"},{"id":2,"name":"Chicken Curry"}]}]'

Scenario Outline: Create Restaurant
	Given I am a client
	When I make POST Request '<request>' with following data '<requestBody>'
	Then response code must be '<responseCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request      | requestBody                           | responseBody | responseCode |
	| /restaurants | {"name":"Famous Cafe","dishes":"1,2"} | 3            | 201          |
	@InvalidData
	Examples: 
	| request      | requestBody                             | responseBody                | responseCode |
	| /restaurants | {"name":"","dishes":"1,2"}              | Name Should Not be Empty!   | 400          |
	| /restaurants | {"name":"Famous Cafe","dishes":""}      | Dishes Should Not be Empty! | 400          |
	| /restaurants | {"name":"Famous Cafe","dishes":"1,45"}  | Dish Not Found!             | 404          |
	| /restaurants | {"name":"Famous Cafe","dishes":"1,4er"} | Dish Format Error!          | 400          |

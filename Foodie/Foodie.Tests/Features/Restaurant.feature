Feature: Restaurant Resource

Admins can Add Restaurants and fetch those Restaurants

Scenario: Get All Restaurants
	Given I am a client
	When I make GET Request '/restaurants'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"ABC","dishes":[{"id":1,"name":"Samosa","avgRating":4},{"id":2,"name":"Curd","avgRating":3.5}],"rating":3.75},{"id":2,"name":"EFG","dishes":[{"id":1,"name":"Samosa","avgRating":4},{"id":3,"name":"Chicken","avgRating":5}],"rating":4.5}]'

Scenario Outline: Get Restaurant By Id
	Given I am a client
	When I make GET Request '<request>'
	Then response code must be '<statusCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request        | statusCode | responseBody                                                                                                                 |
	| /restaurants/1 | 200        | {"id":1,"name":"ABC","dishes":[{"id":1,"name":"Samosa","avgRating":4},{"id":2,"name":"Curd","avgRating":3.5}],"rating":3.75} |
	@InvalidData
	Examples: 
	| request         | statusCode | responseBody                                     |
	| /restaurants/24 | 404        | Restaurant Not Found!                            |
	| /restaurants/0  | 400        | Id should not be Zero                            |

Scenario Outline: Create Restaurant
	Given I am a client
	When I make POST Request '<request>' with following data '<requestBody>'
	Then response code must be '<responseCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request      | requestBody                           | responseBody | responseCode |
	| /restaurants | {"name":"Famous Cafe","dishIds":"1,2"} | 3            | 201          |
	@InvalidData
	Examples: 
	| request      | requestBody                             | responseBody                | responseCode |
	| /restaurants | {"name":"","dishIds":"1,2"}              | Name Should Not be Empty!   | 400          |
	| /restaurants | {"name":"Famous Cafe","dishIds":""}      | DishIds Should Not be Empty! | 400          |
	| /restaurants | {"name":"Famous Cafe","dishIds":"1,45"}  | Dish Not Found!             | 404          |
	| /restaurants | {"name":"Famous Cafe","dishIds":"1,4er"} | Dish Id Format Error!          | 400          |

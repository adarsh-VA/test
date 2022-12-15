Feature: Rating Resource

Users can Rate dishes and fetch those details

Scenario Outline: Get Ratings
	Given I am a client
	When I make GET Request '<request>'
	Then response code must be '<statusCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request                        | statusCode | responseBody                                                                                                         |
	| /restaurants/1/users/1/ratings | 200        | [{"id":1,"name":"Veg Biryani","MyRating":4.0,"AvgRating":4.0},{"id":3,"name":"Roti","MyRating":3.0,"AvgRating":3.0}] |
	@InvalidData
	Examples: 
	| request                         | statusCode | responseBody          |
	| /restaurants/19/users/1/ratings | 404        | Restaurant Not Found! |
	| /restaurants/1/users/15/ratings | 404        | User Not Found!       |
	| /restaurants/0/users/1/ratings  | 400        | Id should not be Zero |

Scenario Outline: Create Rating
	Given I am a client
	When I make POST Request '<request>' with following data '<requestBody>'
	Then response code must be '<responseCode>'
	And response data must look like '<responseBody>'
	@ValidData
	Examples: 
	| request                                 | requestBody    | responseBody  | responseCode |
	| /restaurants/1/Users/1/Dishes/1/ratings | {"Rating":5.0} | You Rated 5.0 | 201          |
	@InvalidData
	Examples: 
	| request                                  | requestBody    | responseBody               | responseCode |
	| /restaurants/1/Users/1/Dishes/1/ratings  | {"Rating":6.0} | Rating Should be in 1 to 5 | 400          |
	| /restaurants/1/Users/1/Dishes/1/ratings  | {"Rating": 0}  | Rating Should Not be 0     | 400          |
	| /restaurants/10/Users/1/Dishes/1/ratings | {"Rating":5.0} | Restaurant Not Found!      | 404          |
	| /restaurants/1/Users/14/Dishes/1/ratings | {"Rating":5.0} | User Not Found!            | 404          |
	| /restaurants/1/Users/1/Dishes/16/ratings | {"Rating":5.0} | Dish Not Found!            | 404          |
	| /restaurants/0/Users/1/Dishes/1/ratings  | {"Rating":5.0} | Id should not be Zero      | 400          |
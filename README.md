# Rhenus Special Delivery Coding Challenge

It's a simple bet game.

## Author

* Fady Amir 
* F.fadyamir@gmail.com
* +20 1283848066

## Description

- Game of chance in which a random number between 0 - 9 is to be generated.
- The player has a starting account of 10,000 points and can use this to bet any amount on the
  randomly generated number.
- If they are correct, they win 9 times their stake.

## Getting Started

### About The Code

* DotNET core was used to implement this game.
* An in-memory db was used initially to store players' info (to be changed based on the scope).
* Swagger.
* N-unit for the test coverage.
* This service was considered to be a microservice so that's why the structure contains only one project under the solution including (db access, models, logic, and unit tests).

### Future Work

* This solution was made for a small scope of our game, so it was designed to work as an independent service, but if for any reason the requirements were changed we will need to add multiple layers to handle 
 each part of it ex(one layer(proj) for each of the following(db access, service, unit tests,API controllers(as a backend for frontend layer))).
* Might need to have a SQL DB to store the players' data rather than the in-memory DB.
* DockerFile would be needed in the future to make it easier to capsulate our service with its dependencies.
* Adding more unit tests to cover the rest of our logic.

### How To Run

* Just cloning the application and running it locally will open the swagger page where the API can be tested.


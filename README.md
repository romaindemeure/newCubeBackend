# CubeBackend


## What is this project ?

This application is developed in school. We are the group 4: Romain (me), Tanguy, Nathan, Wayan.
On this Project the goal it's to create an API in C# and we have chose dotnet 6.
We need to uses relation database, so we chose MySql with PhpMyAdmin. 
We use Docker, more specifically docker-compose.yml because it's possible to use it on MacOs, Windows, Linux so it's more easy for all.

## How to uses this project ?

You can clone the project and download "MySql.Data" with `dotnet add package MySql.Data`.
[Download Docker](https://www.docker.com/products/docker-desktop/) if you don't have and use `docker compose up -d` at the root of the project. Argument -d it is to initialize in background
After you have do this you can run the application with `dotnet watch`. Argument `watch` it's for rebuild the bin and commit your change without having to restart the application
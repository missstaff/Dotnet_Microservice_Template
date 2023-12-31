# Dotnet MicroService Template

## Prerequisites ⚙

Before you begin, ensure you have the following tools installed on your development environment:

- Visual Studio Code (VSCode)
- .NET SDK 8.0 (Command Line Interface, CLI)
- Docker for Desktop
- DBeaver (recommended for managing PostgreSQL)

## Getting Started 🏃‍♂️
Follow the steps below to build and run the project on your local machine.

## Dockerized Development 🐳

1. Open a terminal and run:

   ```bash
   docker-compose up --build
   ```

- Api address: localhost:8088/
- App address: localhost:8089/
- Swagger address: localhost:8089/swagger


## Local Development 🚀

1. Open a terminal and navigate to the `Api` directory:

   ```bash
   cd Api
   ```

2. Build and run the .NET Web API:

   ```bash
   dotnet build
   dotnet run
   ```

3. Open another terminal and navigate to the `App` directory:

   ```bash
   cd App
   ```

4. Build and run the .NET Web App:

   ```bash
   dotnet build
   dotnet run
   ```

- The connection string in Api/appsettings.json needs to be changed:
    - "User ID=postgres;Password=postgres;Server=localhost;Port=5433;Database=apidb;"

- Api address: http://localhost:5261/
- App address: http://localhost:5020/
- Swagger address: http://localhost:5261/swagger/index.html

**Note** 📝
The application is set up to use the postgres db in Docker you will either need to run `docker-compose up --build` and then go to docker and ensure the servives for the databases are running, no other containers need to be running or built you can optionally just build pull postgres and build the postgres server conatiners naming them "auth_db__container" and "api_db__container". You can also install postgres on your host machine and eliminate docker altogether.


## Database 📊

- The project uses PostgreSQL as the database.
- It is containerized in Docker.
- To access postgres shell:
  - open a postgres bash shell open terminal and run:
  ```
  docker exec -it api_db__container psql -U postgres
  ```
  or
   ```
  docker exec -it auth_db__container psql -U postgres
  ```
- The postgres container must be running.

## Notes 📝

- This project is built with Visual Studio Code. While it might work with other IDEs, it is recommended to use VSCode for a smoother development experience.

- Example urls for fetching the data from the api
   - `string apiUrl = "http://localhost:5261/api/Customers/all";` //localhost
   - `string customersUrl = "http://api/Customers/all";` //docker
The base of the url is the same as the service name, if renaming the api service in the docker-compose.yml the base of the url will be that value.

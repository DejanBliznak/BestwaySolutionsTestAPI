# BestwaySolutionsTestAPI
This project is a .NET 6 Web API that interacts with the Fruityvice API to fetch and manage information about various fruits. The API provides endpoints to get fruit details by name, add metadata to fruits, update existing metadata, and remove metadata.

## Features

- Fetch fruit details by name from the Fruityvice API.
- Add, update, and remove metadata associated with fruits.
- Simple REST API interface with JSON responses.
- In-memory caching to reduce redundant API calls for frequently requested fruits.
- Basic error handling for scenarios such as invalid fruit names or API connectivity issues.

## Technologies Used

- .NET 6
- ASP.NET Core Web API
- Fruityvice API
- In-Memory Caching
- Dependency Injection
- Newtonsoft.Json for JSON serialization/deserialization

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022 or Visual Studio Code (or any preferred C# IDE)

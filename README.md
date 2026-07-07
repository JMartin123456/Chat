Configuration

Before running the application, configure the following files with your local environment settings:
- `ChatServer/appsettings.json`
  - Update the `DefaultConnection` string with your local MySQL server, database name, username and password.
- `ChatServer/Properties/launchSettings.json`
  - Configure the local application URLs if necessary.
- `ChatClient/ChatService.cs`
  - Set the SignalR server URL to match your local server configuration.
- `ChatServer.http`
  - Update the local API endpoint if you want to use the HTTP request examples.
> **Note:** Local connection strings, endpoints and development URLs have been intentionally removed from this public repository.

Database Setup

Create a local MySQL database:

sql

CREATE DATABASE chatdb;

USE chatdb;

CREATE TABLE Messages
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Text VARCHAR(500) NOT NULL,
    Created DATETIME NOT NULL
);

Update the `DefaultConnection` value in `ChatServer/appsettings.json` with your local MySQL server address, database credentials, and other required connection settings before running the application.

For security reasons, sensitive information such as:
database credentials,
connection strings,
local endpoints,
are not included in this repository.

How It Works
1. Client sends message via SignalR hub method (`SendMessage`)
2. Server receives message in `ChatHub`
3. Message is stored in MySQL database
4. Server broadcasts message to all connected clients
5. All clients update UI instantly

How It Works
1. Client sends message via SignalR hub method (`SendMessage`)
2. Server receives message in `ChatHub`
3. Message is stored in MySQL database
4. Server broadcasts message to all connected clients
5. All clients update UI instantly

For security reasons, sensitive information such as:

database credentials
connection strings
local endpoints

are not included in this repository.

Developed as a learning project.

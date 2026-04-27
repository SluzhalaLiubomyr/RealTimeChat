# ChatApp – Real-time Chat with Sentiment Analysis

A real-time chat application built with ASP.NET Core, SignalR, and Angular, enhanced with Azure Cognitive Services (Text Analytics) for sentiment analysis.

---

## Features

-  Real-time messaging using SignalR
-  Sentiment analysis (Positive / Negative / Neutral )
-  Azure SignalR Service integration
-  Azure Text Analytics API integration
-  Angular standalone frontend
-  Message timestamps (CreatedAt)
-  Live UI updates without refresh


## Architecture

Frontend (Angular)
↓
ASP.NET Core API
↓
SignalR Hub
↓
Azure SignalR Service
↓
Azure Cognitive Services (Text Analytics)
↓
SQL Database (Messages)


## Project Structure

ChatApp.API → Web API + SignalR Hub
ChatApp.Application → Business logic (services, DTOs)
ChatApp.Domain → Entities + Enums
ChatApp.Infrastructure → Azure + DB + external services
ChatApp.SignalR → ChatHub implementation
ChatApp.UI → Angular frontend

## Sentiment Analysis

Each message is analyzed using Azure Text Analytics API.

Possible sentiment values:

- Positive 😊
- Negative 😡
- Neutral 😐

## Technologies Used

### Backend
- ASP.NET Core 8
- SignalR
- Entity Framework Core
- Azure SignalR Service
- Azure Cognitive Services (Text Analytics)

### Frontend
- Angular
- RxJS
- SignalR Client (@microsoft/signalr)

### Database
- SQL Server

## Setup & Run Locally
1. Clone repository
git clone https://github.com/SluzhalaLiubomyr/RealTimeChat.git
2. Update appsettings.json
3. Run backend:
dotnet run
4. Frontend setup
git clone https://github.com/SluzhalaLiubomyr/RealTimeChat-frontend.git
cd ChatApp.UI
npm install
ng serve

Swagger runs on:http://localhost:5070/swagger/

 
App runs on: http://localhost:4200

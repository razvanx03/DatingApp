# Dating App

A modern dating application built with ASP.NET Core backend and Angular frontend, featuring real-time messaging, user matching, and profile management.

## 🚀 Features

- **User Authentication & Authorization**
- **Profile Management**
- **Photo Upload & Management**
- **Real-time Messaging** (using SignalR)
- **User Matching System**
- **Like/Dislike Functionality**
- **Member Search & Filtering**
- **Responsive Design**

## 🛠️ Tech Stack

### Backend
- ASP.NET Core
- Entity Framework Core
- SQLite Database
- SignalR for real-time communication
- JWT Authentication
- AutoMapper for DTO mapping

### Frontend
- Angular
- TypeScript
- Bootstrap
- Font Awesome
- ngx-bootstrap

## 📁 Project Structure

```
DatingApp/
├── API/                    # Backend ASP.NET Core project
│   ├── Controllers/        # API endpoints
│   ├── Data/              # Database context and migrations
│   ├── DTOs/              # Data Transfer Objects
│   ├── Entities/          # Domain models
│   ├── Helpers/           # Helper classes and extensions
│   ├── Interfaces/        # Service interfaces
│   ├── Middleware/        # Custom middleware
│   ├── Services/          # Business logic implementation
│   └── SingalR/           # Real-time messaging hub
│
└── client/                # Frontend Angular project
    ├── src/
    │   ├── app/          # Angular components and services
    │   ├── assets/       # Static assets
    │   └── environments/ # Environment configurations
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK
- Node.js (LTS version)
- Angular CLI

### Backend Setup
1. Navigate to the API directory
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

### Frontend Setup
1. Navigate to the client directory
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   ng serve
   ```

## 🔒 Environment Variables

Create the following files with appropriate values:

### Backend (API/appsettings.Development.json)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=datingapp.db"
  },
  "TokenKey": "your-secret-key-here"
}
```
# Tech Conference 2026 — Registration Website

A fully responsive conference registration web app where attendees can RSVP for **Tech Conference 2026**. Built with Angular on the frontend and ASP.NET Core on the backend.

---

## Tech Stack

| Layer | Technologies |
|---|---|
| Frontend | Angular 17, TypeScript, HTML, CSS |
| Backend | ASP.NET Core (.NET 9), C# |
| Communication | REST API, HTTP Client |

---

## Prerequisites

Make sure you have the following installed before running the project:

- [Node.js] (v18 or higher)
- [Angular CLI] — `npm install -g @angular/cli`
- [.NET SDK] (v9 or higher)

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/biba77/Tech-Conference-2026.git
cd Tech-Conference-2026
```

### 2. Run the backend

```bash
cd server
dotnet run
```

The API will be available at `http://localhost:5177`

### 3. Run the frontend

Open a **new terminal** and run:

```bash
cd client
npm install
ng serve
```

The app will be available at `http://localhost:4200`

> **Note:** Both the backend and frontend must be running at the same time for form submission to work.

---

## ✨ Features

- Responsive RSVP registration form
- Frontend validation — required fields, email format, phone number pattern
- Backend validation with descriptive error messages
- Stores registrations in memory and logs them to the console
- Mobile-friendly layout with hamburger navigation menu
- Smooth hover effects and accessible form labels

---

## Project Structure

```
Tech-Conference-2026/
├── client/                       # Angular frontend
│   ├── src/
│   │   ├── app/
│   │   │   ├── app.component.html    # Main template
│   │   │   ├── app.component.css     # Component styles
│   │   │   ├── app.component.ts      # Component logic
│   │   │   ├── app.config.ts         # App-level providers
│   │   │   └── app.routes.ts         # Route definitions
│   │   ├── assets/
│   │   │   ├── icons/                # Icon images
│   │   │   └── images/               # Venue photo
│   │   └── index.html                # Root HTML file
│   └── package.json
│
└── server/                       # ASP.NET Core backend
    └── Program.cs                # API endpoints and validation logic
```

---

## 🔌 API Endpoints

### `POST /register`
Registers a new attendee.

### `GET /registrations`
Returns all submitted registrations as a JSON array.

---

## Author

Developed by **Habiba Hassouna**
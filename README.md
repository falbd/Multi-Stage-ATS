# 🗂️ Multi-Stage ATS

A **Multi-Stage Applicant Tracking System (ATS)** built with:

✅ **ASP.NET Core Web API**  
✅ **SQL Server + EF Core**  
✅ **Repository & Unit of Work pattern**  
✅ **Swagger** for interactive API testing

designed for clean, scalable **backend architecture** to manage applicants, applications, and stage transitions efficiently.

---

## 🚀 Features

- Manage **Applicants, Stages, and Applications**.
- Multi-stage workflow:
  - Applied ➔ Screening ➔ Interview ➔ Offer ➔ Hired
- SQL Server database with **clean normalized structure**.
- Uses **stored procedures** for advanced reporting and workflow transitions.
- Swagger UI for testing and exploring API endpoints.
- Designed for **learning, production adaptation, and clean architecture reference**.

---

## 🛠️ Tech Stack

- **.NET 9 / .NET 8**
- **ASP.NET Core Web API**
- **SQL Server**
- **Entity Framework Core**
- **Swagger (Swashbuckle)**

---

## ⚙️ Setup Instructions

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/falbd/Multi-Stage-ATS.git
cd Multi-Stage-ATS

Database Setup
✅ Using SQL Server in Visual Studio
Open SQL Server Object Explorer (View ➔ SQL Server Object Explorer).

Connect to your local SQL Server instance (localhost, localhost\SQLEXPRESS, or your instance).

Create a new database:

ATS_DB
Execute the SQL scripts in the Scripts/ folder:

Create_Tables.sql

Seed_Data.sql

StoredProcedures.sql

✅ Using CLI (sqlcmd)

sqlcmd -S localhost -d ATS_DB -i Scripts/Create_Tables.sql
sqlcmd -S localhost -d ATS_DB -i Scripts/Seed_Data.sql
sqlcmd -S localhost -d ATS_DB -i Scripts/StoredProcedures.sql

Configure the Backend
Ensure your connection string in appsettings.json points to your local SQL Server:

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ATS_DB;Trusted_Connection=True;TrustServerCertificate=True;"
}

Run the Backend
Using Visual Studio:
Build and run (F5).

Using CLI:
dotnet build
dotnet run
5️⃣ Test Using Swagger
Navigate to:


https://localhost:{PORT}/swagger
✅ You will see your ATS API documentation and be able to test endpoints directly.

📡 API Endpoints
Applicants
POST /api/applicants ➔ Add a new applicant.

GET /api/applicants ➔ List all applicants.

Stages
GET /api/stages ➔ List all stages.

Applications
POST /api/applications ➔ Create a new application.

GET /api/applications ➔ List all applications with applicant and stage info.

PUT /api/applications/{id}/move-stage ➔ Move an application to a new stage.

🗄️ Folder Structure
Multi-Stage-ATS/
├── Controllers/          // API endpoints
├── Data/                 // DbContext, Repositories, Unit of Work
├── DTOs/                 // Request & Response Models
├── Models/               // Entity Models
├── Scripts/              // SQL Scripts (Tables, Seed Data, Stored Procedures)
├── Program.cs            // Entry point
├── appsettings.json      // Configurations
└── README.md             // This file

✅ Future Enhancements
Authentication and Role Management.

Email notifications on stage changes.

Dashboard and analytics.

Frontend with Blazor/React for user interaction.

Dockerization for clean deployment.

🤝 Contributions
Pull requests are welcome. For significant changes, open an issue first to discuss what you would like to change.

📜 License
MIT License (or your chosen license).

## 📧 Contact

For questions, suggestions, or collaborations:

- ✉️ Email: albedahfahad12@gmail.com
- 💼 [LinkedIn](https://www.linkedin.com/in/fahad-albedah-a087b8220/)
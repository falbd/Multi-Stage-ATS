🗂️ Multi-Stage ATS

A Multi-Stage Applicant Tracking System (ATS) built with:

✅ ASP.NET Core Web API

✅ SQL Server + EF Core

✅ Repository & Unit of Work pattern

✅ Swagger for interactive API testing

✅ Docker + GitHub Actions CI/CD (build, test, publish, and Docker image creation)

Designed for clean, scalable backend architecture to manage applicants, applications, and stage transitions efficiently, aligned with production-ready practices.

🚀 Features

✅ Manage Applicants, Stages, and Applications

✅ Multi-stage workflow:

Applied ➔ Screening ➔ Interview ➔ Offer ➔ Hired

✅ Clean, normalized SQL Server database structure

✅ Uses stored procedures for advanced reporting and workflows

✅ Swagger UI for API exploration and testing

✅ Dockerized for consistent environment delivery

✅ Automated builds, tests, and Docker image builds with GitHub Actions CI/CD

🛠️ Tech Stack

.NET 9 / .NET 8

ASP.NET Core Web API

SQL Server

Entity Framework Core

Swagger (Swashbuckle)

Docker

GitHub Actions

⚙️ Setup Instructions

1️⃣ Clone the Repository

git clone https://github.com/falbd/Multi-Stage-ATS.git
cd Multi-Stage-ATS

2️⃣ Database Setup

✅ Using SQL Server in Visual Studio:

Open SQL Server Object Explorer

Connect to localhost or your SQL instance

Create a database:

ATS_DB

Execute SQL scripts in Scripts/:

Create_Tables.sql

Seed_Data.sql

StoredProcedures.sql

✅ Using CLI:

sqlcmd -S localhost -d ATS_DB -i Scripts/Create_Tables.sql

sqlcmd -S localhost -d ATS_DB -i Scripts/Seed_Data.sql

sqlcmd -S localhost -d ATS_DB -i Scripts/StoredProcedures.sql

3️⃣ Configure the Backend

In appsettings.json:
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ATS_DB;Trusted_Connection=True;TrustServerCertificate=True;"
}

4️⃣ Run the Backend

✅ Using Visual Studio:

Build and Run (F5)

✅ Using CLI:
dotnet build
dotnet run

✅ Using Docker:
docker build -t multistage-ats .
docker run -p 8080:80 multistage-ats

5️⃣ Test Using Swagger

Navigate to:
https://localhost:{PORT}/swagger
✅ Interactively test and explore API endpoints.

📡 API Endpoints

Applicants

POST /api/applicants ➔ Add a new applicant

GET /api/applicants ➔ List all applicants

Stages

GET /api/stages ➔ List all stages

Applications

POST /api/applications ➔ Create a new application

GET /api/applications ➔ List all applications with applicant and stage info

PUT /api/applications/{id}/move-stage ➔ Move an application to a new stage

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

Authentication and Role Management

Email notifications on stage changes

Dashboard and analytics

Frontend with Blazor/React for user interaction

CI/CD deployment to Azure/AWS using GitHub Actions and Docker

🤝 Contributions

Pull requests are welcome. For significant changes, open an issue first to discuss what you would like to change.

📜 License

MIT License (or your chosen license).

## 📧 Contact

For questions, suggestions, or collaborations:

- ✉️ Email: albedahfahad12@gmail.com
- 💼 [LinkedIn](https://www.linkedin.com/in/fahad-albedah-a087b8220/)

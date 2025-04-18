# Charity Helpy - Backend

**Charity Helpy** is a full-stack charity web platform developed as part of an internship at **Tahaluf UAE** 🇦🇪.  
This backend project is built with **ASP.NET Core**, connected to an **Oracle database**, and includes third-party **Stripe API** integration for secure online payments.

## 📦 Project Overview

This RESTful API powers the Charity Helpy platform, providing secure and scalable endpoints for managing users, charities, transactions, and reports. It also handles authentication, PDF invoice generation, and admin-level operations.

## 🛠 Tech Stack

- **Language**: C#  
- **Framework**: ASP.NET Core Web API  
- **Database**: Oracle DB (PL/SQL)  
- **ORM**: Entity Framework Core  
- **Payment**: Stripe API  
- **PDF Generation**: iTextSharp or similar library  
- **Tools**: Visual Studio 2022, SQL Developer

## 🔗 Frontend Repository

👉 [Charity Helpy - Frontend (Angular)](https://github.com/Aseel-Alnaami/Charity-Helpy-Frontend)

## 🌟 Key Features

- 🔐 **Authentication & Authorization**  
  Role-based system (Admin, User, Guest)

- 🗂️ **Charity Management**  
  CRUD operations for charities, approval status, and publishing flow

- 🗺️ **Location Handling**  
  Store charity locations for frontend mapping via Leaflet

- 💳 **Stripe Payment Integration**  
  Secure checkout for posting charities, with webhook support

- 📧 **PDF Invoice Generation & Emailing**  
  Automatic PDF invoice generation after successful payments

- 📊 **Admin Reporting**  
  Monthly and annual PDF reports (users, charities, revenue)

## 🚀 Getting Started

### Prerequisites

- Oracle Database (local or cloud)
- Visual Studio 2022
- .NET 6 SDK or later
- SQL Developer (for DB setup)
- Stripe Developer Account

### Setup Instructions

```bash
# 1. Clone the repository
git clone https://github.com/your-username/charity-helpy-backend.git

# 2. Open the solution in Visual Studio 2022

# 3. Set your connection string in appsettings.json
# Example:
"ConnectionStrings": {
  "DefaultConnection": "User Id=your_user;Password=your_pass;Data Source=your_oracle_db"
}

# 4. Update Stripe keys and email SMTP settings as needed

# 5. Run the API (F5 or via terminal)

<h1 align="center">📝 SimpleBlog</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9-blue?logo=.net&logoColor=white" />
  <img src="https://img.shields.io/badge/License-MIT-green" />
  <img src="https://img.shields.io/badge/EFCore-9-red" />
</p>

<p align="center">
<b>SimpleBlog</b> is a simple blogging platform built with <b>ASP.NET Core MVC</b>.  
It supports user management, post creation, commenting, liking, and <b>Google Authentication</b>.  
Designed with a clean and minimal <b>UI/UX</b> using <b>Bootstrap</b>.
</p>

---
<p align="center">
  <a href="https://your-live-demo-url.com" target="_blank">
    <img src="https://via.placeholder.com/900x450/0078D7/FFFFFF?text=SimpleBlog+Live+Demo" alt="Live Demo Preview" width="80%">
  </a>
</p>

<p align="center">
  <a href="https://your-live-demo-url.com" target="_blank">
    🔗 <b>Live Demo</b>
  </a>
</p>

---
## 📚 Table of Contents

- [✨ Features](#-features)
- [🛠️ Technologies Used](#️-technologies-used)
- [⚙️ Prerequisites](#️-prerequisites)
- [🚀 Getting Started](#-getting-started)
- [📂 Project Structure](#-project-structure)
- [🔒 Security Tips](#-security-tips)
- [🤝 Contributing](#-contributing)
- [📞 Contact](#-contact)
---
## ✨ Features

- 📝 View posts and post details
- 👤 User registration and login
- 🔒 User profile management
- ❤️ Like and comment on posts
- 🌐 Authentication via **ASP.NET Identity** and **Google OAuth**
- 📸 Image storage with **Cloudinary**
- 🎨 Minimalist and clean design with **Bootstrap**
- 🏗️ Follows **SOLID principles** in project structure

---

## 🛠️ Technologies Used

- **Backend:** ASP.NET Core MVC  
- **Authentication:** ASP.NET Identity + Google OAuth  
- **Database:** SQLite (for development)  
- **Frontend:** Razor Views + Bootstrap  
- **Storage:** Cloudinary for images  
- **Design Patterns:** Dependency Injection, Repository Pattern

---

## ⚙️ Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)  
- SQLite  
- Google account for OAuth (Client ID & Client Secret)  
- Cloudinary account for image storage  

---

## 🚀 Getting Started

### 1️⃣ Clone the repository

```bash
git clone https://github.com/MehfCodes/SimpleBlog.git
cd SimpleBlog
```
### 2️⃣ Restore packages
```bash
dotnet restore
```

### 3️⃣ Configure secrets in .env
Create a .env file in the project root:
```GOOGLE_CLIENT_ID=your_google_client_id
GOOGLE_CLIENT_SECRET=your_google_client_secret
Cloudinary_CloudName=your_cloud_name
Cloudinary_ApiKey=your_api_key
Cloudinary_ApiSecret=your_api_secret
DB_SOURCE=Db_source
```
⚠️ Important: Do NOT commit this file to Git.

### 4️⃣ Apply migrations and create the database
```
dotnet ef database update
```
### 5️⃣ Run the project
```
dotnet run
```
The application will run at: http://localhost:5295

## 📝 Usage

- User registration and login

- Create, edit, delete posts

- Like and comment on posts

- Login with Google using the Google Login button

- Manage user profile

## 📂 Project Structure
- **Controllers**      → MVC Controllers
- **Models**            → Domain Models & ViewModels
- **Views**             → Razor Views
- **Data**              → DbContext & SeedData
- **DependencyInjection** → DI & configuration
- **wwwroot**           → Static files (CSS, JS, images)

## 🔐 Security Tips

Never store secrets (Google, Cloudinary, DB) in Git

Use .env or Secret Manager for sensitive values

For production, use appsettings.Production.json or secure secret storage

## 🫱🏻‍🫲🏻Contributing

- Feel free to fork this repository and submit pull requests.
- Please adhere to SOLID principles and Clean Architecture practices when contributing.

## 📞Contact

For questions and business inqueries you can reach me at

<p align="left">
  <a href="https://github.com/MehfCodes" target="_blank">
        <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg" width="40" height="40" alt="GitHub" />
  </a>
   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
  <a href="https://www.linkedin.com/in/erfan-firouzabadi-09183119a/" target="_blank">
    <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg" width="40" height="40" alt="LinkedIn" />
  </a>
   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
  <a href="mailto:mehfdev@gmail.com" target="_blank">
    <img src="https://upload.wikimedia.org/wikipedia/commons/7/7e/Gmail_icon_%282020%29.svg" width="40" height="40" alt="Email" />
  </a>
</p>

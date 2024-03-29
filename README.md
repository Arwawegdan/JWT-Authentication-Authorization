JWT Authentication and Authorization
This project is an implementation of JSON Web Token (JWT) based authentication and authorization in a web application, using ASP.NET Core and Entity Framework Core. It provides endpoints for user registration, email verification, login, and retrieving user information. The project utilizes the Microsoft.AspNetCore.Identity package for managing user accounts and roles.

**Table of Contents
Introduction
Features
Prerequisites
Installation
Usage
Endpoints


Introduction
JSON Web Tokens (JWT) are an open standard (RFC 7519) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object. This project demonstrates how to implement JWT-based authentication and authorization in a web application built with ASP.NET Core, a cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications.

Features
User Registration: Users can register by providing basic information such as email, username, password, and phone number. Upon successful registration, users receive a confirmation email.
Email Verification: Registered users must verify their email addresses before they can sign in. Verification emails contain a unique token for confirmation.
Login: Registered users can log in using their email and password. Upon successful login, users receive a JWT token, which they can use for subsequent authenticated requests.
Access Control: JWT tokens contain user claims, including roles, which are used for access control to various parts of the application.
User Information Retrieval: Endpoints are provided for retrieving user information by email or phone number.

Prerequisites
.NET SDK installed on your machine
Understanding of ASP.NET Core and Entity Framework Core concepts
Basic knowledge of JWT and authentication mechanisms

Installation
Clone this repository to your local machine.
Open the solution in Visual Studio or your preferred IDE.
Restore NuGet packages if necessary.
Build the solution to ensure all dependencies are resolved.

Usage
Configure your database connection string in the appsettings.json file.
Run Entity Framework migrations to create the necessary database schema.

Start the application.
Utilize the provided endpoints for user registration, login, email verification, and user information retrieval.
Endpoints
POST /api/SeedUserRoles: Seed user roles in the database.
POST /api/RegisterAspUser: Register a new user with ASP.NET Identity.
POST /api/VerifyEmail: Resend email verification link or verify user's email.
POST /api/Login: Authenticate user and generate JWT token.
GET /api/ConfirmEmail: Confirm user's email address.

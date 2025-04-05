# CoffeeShop.API

A high-performance, scalable backend for a Coffee Shop website, built with .NET 9.0 and MySQL. Provides all core features via RESTful APIs.

## Tech Stack
- **.NET 9.0** – fast, cross-platform framework  
- **Entity Framework Core** – MySQL ORM  
- **MySQL** – reliable relational database  
- **Stripe** – secure payment processing  
- **SMTP** – email delivery (password reset, contact form)  
- **JWT** – token‑based authentication  
- **SignalR** – real‑time admin notifications  

## Key Features

### 1. User Management
- **Register** & **Login**  
- **Forgot Password** & **Reset Password** via email  

### 2. Product Catalog
- CRUD operations for **Products**, **Categories**, **Tags**, **Zodiac Signs**  
- **Slider**, **Header Banner**, **Logo**, **Slogan**, **Social Media Links** management  

### 3. Promo Code System
- Create, activate, and apply promo codes  
- Track used and available promo codes in user dashboard  

### 4. User Dashboard
- View **Order History**  
- Manage **Active Promo Codes**  
- “Favorites” list  

### 5. Cart & Checkout
- Add/update/remove items in **Basket**  
- **Stripe** integration for checkout  

### 6. Contact & Notifications
- **Contact Form** with SMTP email delivery  
- Real‑time **admin panel** notifications via SignalR  
- **Comments** section  

### 7. Spotify Integration
- Fetch playlists and track data via Spotify API  

## Getting Started

1. **Clone the repo**  
   ```bash
   git clone https://github.com/your-username/CoffeeShop.API.git
   cd CoffeeShop.API


SubBoard ist eine moderne Full‑Stack‑Anwendung zur Verwaltung, Analyse und Visualisierung von Abonnements.  
Das Projekt besteht aus zwei klar getrennten Teilen:

- **Backend:** ASP.NET Core **REST API**
- **Frontend:** **Blazor Server** Anwendung
##  Verwendete Technologien & Tools

### 🔹 Backend (API)
- **ASP.NET Core Web API** – Bereitstellung aller Endpunkte
- **Entity Framework Core** – ORM für Datenbankzugriffe
- **AutoMapper** – Mapping zwischen Entities und DTOs
- **Dependency Injection (DI)** – Saubere Entkopplung der Services
- **Repository Pattern** – Strukturierte Datenzugriffsschicht
- **LINQ** – Datenabfragen und Aggregationen
- **SQL Server – Persistenzschicht
- **Data Transfer Objects (DTOs)** – Klare API‑Verträge

### 🔹 Frontend (Blazor)
- **Blazor Server** – Interaktive Weboberfläche ohne JavaScript
- **Radzen Charts** – Moderne Diagramme (Bar, Donut, etc.)
- **Bootstrap 5** – Layout, Grid-System, UI-Komponenten
- **Custom CSS** – KPI Cards, Chart Cards, modernes SaaS‑Design
- **HttpClient** – Kommunikation mit der API
- **Dependency Injection** – Service‑basierte Architektur

### 🔹 Architektur & Struktur
- **Clean Architecture** – Trennung von Domain, Application, Infrastructure, API, UI
- **DTO‑Mapping** – Saubere Trennung zwischen API‑Modellen und Domain‑Modellen
- **Asynchrone Programmierung (async/await)** – Performante API‑Aufrufe
- **REST‑Konventionen** – Klare, standardisierte Endpunkte

### 🔹 Entwicklung & Tools
- **.NET 8**
- **C# 12**
- **EF Core Migrations**
- **Swagger (optional)** – API‑Dokumentation
- **Git / GitHub**

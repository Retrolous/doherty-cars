# Doherty Cars: Dealership Management System

A Windows desktop app replacing a family-run car dealership's manuscript notes and spreadsheets with one role-secured digital system for service scheduling, staff, stock, reporting and audit logging. Built solo as my A2 coursework, from requirements through to testing and evaluation.

## Highlights
- **Drag-and-drop scheduler:** a custom-drawn WinForms control for mechanics' timetables, with live validation and automatic duration and cost from services, parts and vehicle complexity
- **Role-based access control:** PBKDF2-hashed passwords, with menus and permissions driven by each user's role
- **Audit logging:** every login, access, create, update and delete is recorded with user and timestamp
- **Data integrity:** central validation, soft deletes and enforced referential rules across a normalised SQL Server database

## Tech used

C# · Windows Forms (.NET 8) · Microsoft SQL Server · ReportViewer · Visual Studio

## Process

Waterfall methodology with 32 documented requirements, Gantt and PERT planning, full design documentation, white-box, unit, integration, system and acceptance testing, and a written evaluation. The full write-up and user guide are in the PDFs in the repo. 

*Note that version management was done internally, so no previous commits will be visible in the repository. Regardless, constant back-ups and incremental saves were conducted throughout the lifecycle to ensure no loss of data and/or broken code.*

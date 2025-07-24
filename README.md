# AuditTrail API - .NET Core

A standalone .NET Core Web API for tracking and logging changes to objects with detailed audit metadata. This API is designed to be integrated into enterprise applications and services.
Features
- Track only the changed columns during updates.
- Supports audit action types: Created, Updated, Deleted.
- Returns structured metadata:
  - Timestamp
  - User ID
  - Entity Name
  - Changed Fields with old and new values
- Clean separation of layers: Controllers, Services, Models.
- Easily integrable into any .NET Core solution.


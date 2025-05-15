# Here is resource for Restore Solution.

> [!NOTE]
> For BE

```bash
-cd API:
nuget:
microsoft.entityframeworkcore.design
microsoft.entityframeworkcore.sqlserver

-cmd of API:
-- dotnet tool install --global dotnet-ef --version 9.0.4
-- dotnet ef
-- dotnet ef migrations add InitialCreate -o Data/Migrations
-- dotnet ef database update

-want to restore all database?
-- dotnet ef database drop
```

> [!NOTE]
> For FE

```bash
-cd Restore
-- npm create vite@latest
-cd client
-- npm i vite-plugin-mkcert -D
-- npm install @mui/material @emotion/react @emotion/styled
-- npm install @fontsource/roboto
-- npm install @mui/icons-material
```

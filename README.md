<h1 align="center">Sistema Escolar 🏫</h1>
<p align="center">School system with dashboard for administrators to manage grades of enrolled students, classes and teachers.</p>

## Setup
- C# (_ASP.NET_)
- SQL Server
- Entity Framework

## Install
1. Clone the repository
```
$ git clone  https://github.com/MarcosOlvr/sistema-escolar.git
```

2. Access the folder
```
$ cd sistema-escolar
```

3. Install .NET libraries
```
$ dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```
```
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
```
$ dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## Migrations
1. Running seeders
```
$ dotnet ef migrations add m1 -o Data/Migrations
```

2. Update database
```
$ dotnet ef database update
```

## Run the app
```
$ dotnet watch run
```

## Login with an administrator account
On the login page, use:
    admin@admin.com
    P@ssword
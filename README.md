# Jabil - Test

## Demo
[jabil.luischavezb.com](http://jabil.luischavezb.com)

## Configuration

### Database
- Create appsettings.<env>.json (appsetings.Development.json) in root project folder.
- Configure Materials connection string in appsettings.
- Import 'schema.sql', 'test_data.sql' and 'procedures.sql' scripts directly in sql server, 
or run 'dotnet ef database update' command to generate database migrations.
- run 'dotnet run'.

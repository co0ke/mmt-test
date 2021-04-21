# Intro
Hello! I've tried to keep things clean and simple. Database scripts are under the 'Database Scripts' folder and the application source code is under the 'Source' folder. The database connection string can be configured in appSettings.json of the MMT.API project. The integration tests currently require the DB tables to be populated. The SLN will need to be configured to launch the MMT.API and MMT.ConsoleApp projects.

# Potential Future TODOs
- Split Src project into Data and Service projects
- Create interface for DbContext to allow unit testing of repositories
- Code first EF Core with migrations and seeding
- Replace execution of stored procedures inside repository classes with operations on DbContext collections 
- Allow configuration of stored procedure names
- Write generic interface or base class for repositories
- Use secrets for connection string
- Integration tests to seed and destroy DB data as opposed to relying on preexisting data
- Make WebApplicationFactory used in integration tests static
- Unit tests for API project
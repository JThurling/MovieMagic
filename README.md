# Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 9.1.4.

## Development server

Run `ng serve` with the client directory for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files. Run `npm install` for the node_modules to download. Also, node.js needs to be install on your computer, otherwise the angular app won't run.

## Troubleshooting

When Developing the program, I implemented .Net Core Identity, but unfortunately it negatively affected my program. So, I implemented a manual Authentication system for demo purposes. 

## To Run Program

Within the `WebApplication-Movie` file just run `dotnet watch run` for the application API to run. If the database isn't there the program will seed the movie data, but unfortunately not a ADMIN user. If there is no database, register a new user with the register page, go into the database file and change the role column from `visitor` to `admin`.
The Admin account details: username - `digital@caninfinity.co.za`, password - `12345`. Database provider is SQLite.

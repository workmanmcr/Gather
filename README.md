# _Gathering, the Magic Event Planner_

#### _C# Team Week Project, 08/24/2023_

#### By _**Mike Workman, Joshua Khan, and Erik Zambrano**_

## Description

_Web application that allows users to create events, invite guests and vendors, plan activities, and create a list of items to be brought to the event_

## Setup/Installation Requirements
  
  Software Requirements:
1. Internet browser
2. A code editor like VSCode or Atom to view or edit the codebase.
3. MySQL

  Setup:
1. Click on this [link to the project repository](https://github.com/Khanjo/Gather) on GitHub.   
2. Click on the "Clone or download" button to copy the project.     
3. If you know how to use the command line and Github, clone the project with `git clone`. Use "**Download ZIP**" if not.
4. Extract the Zip to a folder of your choice and open with a code editor (i.e. vscode)
5. Use a SQL Manager Database such as mySQL Workbench.
6. Create an appsettings.json file in **Your Filepath/**`Gather` and copy/paste this code:  
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Port=3306;database=`Name Your Database`;uid=root;pwd=`Your Password`;"
        }
    }
7. Navigate to the Gather directory by entering `cd` **Your Filepath/**`Gather`. Then enter `dotnet restore`, `dotnet build`, `dotnet ef database update` then `dotnet run` into the terminal.

## Stretch Goals

1. Make it so event creator can have a list of items for guests to bring that removes items as they're selected by guests.
2. Have vendors

## Known Bugs

_No known bugs_

## Support and contact details

_https://github.com/khanjo_
_https://github.com/workmanmcr_
_https://github.com/Molagg92_

## Technologies Used

* C#
* .NET-Core 2.2
* ASP.NET Core MVC
* Entity Framework Core
* MySql
* Visual Studio Code
* GitHub

### License

[MIT License.](https://opensource.org/license/mit/)

Copyright (c) 2023 **_Mike Workman, Joshua Khan, Erik Zambrano_**
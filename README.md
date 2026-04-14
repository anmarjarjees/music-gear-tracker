# ASP.NET Core MVC - Music Gear Tracker *"(Updated Part1 - Part2 to be added soon)"*"
A beginner-friendly ASP.NET Core MVC CRUD application demonstrating Entity Framework Core through a music gear tracking example.

The goal of this repository is to show how to build a complete MVC web application from scratch while following Microsoft best practices and official documentation.

This project is intended as a learning resource for beginners who want to understand the inner workings of **"ASP.NET Core MVC CURD Applications"*.

## Project Idea
This application manages a list of music instruments.

Users can:
- Add new instruments
- View a list of instruments
- Edit instrument information, including:
   - Description
   - Price
   - Delete instruments

The application stores instrument details such as:
- Instrument Name
- Brand
- Price
- Description

Example instruments:
- Piano
- Guitar
- Keyboard
- Bass
- Violin

## Technologies Used
- ASP.NET Core 8 MVC
- C#
- Entity Framework Core
- Razor Views
- In-Memory Database (for learning purposes)

## Learning Goals
This project demonstrates key ASP.NET Core concepts:
- MVC architecture (Model - View - Controller)
- Routing and URL patterns
- Controllers and Action methods
- Razor Views for dynamic HTML generation
- Dependency Injection (DI)
- Entity Framework Core integration
- CRUD operations (Create, Read, Update, Delete)
- Model validation and error handling

## Project Structure:
The project follows the standard ASP.NET Core MVC structure:
- Controllers/ => Handles HTTP requests and defines actions
- Models/ => Defines the data structures and validation rules
- Views/ => Contains Razor pages to render HTML
- Data/ => Contains DbContext and database initialization
- wwwroot/ => Static files (CSS, JS, images)

# Creating Your Project:
You can refer to this repository; the project name is MusicGearTracker.
This project uses .NET 8.0 (Long Term Support).

   **Tip:** If your Visual Studio window looks different or panels are shifted, you can reset it to the original default layout:
   - Go to "Window" menu => "Reset Window Layout"

Below is an image about the project structure:

!["Project Folder Structure"]("./repo-img/project-structure-solution.jpg")
```
**The repo folder structure:**
-  music-gear-tracker <==> "Main Repo Folder"
   - README.md
   - MusicGearTracker <==> "Project  Folder":
      - Controllers/
      - Models/
      - Views/
      - wwwroot/
      - Program.cs
      - MusicGearTracker.csproj
```
   This structure follows the standard ASP.NET Core MVC convention.

# Application Components:
We need to create our Model to represent the main entity of our application, which is Instrument.

**In MVC architecture:**
- Model: Represents the data our application manages
- Controller: Handles HTTP requests and manages application logic
- Views: Displays the data to the user

**In our current tutorial app:**
|Layer|Example|
|-|-|
|Model|Models/Instrument|
|Controller|Controllers/InstrumentController|
|Views|Views/Instrument/|

**Building the Project:**
Now we can build our project starting with the default folders and files:

```bash
Controllers
   HomeController.cs

Views
   Home
      Index.cshtml

      // Then adding our views:
      Instruments.cshtml
```
**NOTE:**
*For learning purposes and clear demonstration, we create a dedicated controller (InstrumentController) instead of placing all logic inside HomeController. This follows the standard architecture used in ASP.NET Core MVC applications where each domain entity typically has its own controller and views.
It's strongly recommend creating a new controller and a matching Views folder instead of using HomeController for everything as shown below:*

Then, add your domain-specific controller and views:
```bash
Controllers
   InstrumentController.cs # Adding our Controller file => Handles instruments logic

Models
   Instrument.cs # Adding our Model file => "Instrument" class model

Views
   Instrument # Adding our View sub-folder to contains our view files => View folder for instruments
      Index.cshtml
      Create.cshtml
      Edit.cshtml
```

**TIP:**
*Each controller usually manages a collection of resources, so we use plural names for controllers.
Recommended name: InstrumentsController (not InstrumentController).*

### The MVC relationship:
|Component|Responsibility|
|-|-|
|Model|Instrument|
|Controller|InstrumentController|
|Views|Views/Instrument/|

   This setup follows the standard MVC pattern, where each entity has its own controller and views.

The final folder should look like this:
```bash
Controllers/
   HomeController.cs
   InstrumentController.cs

Models/
   Instrument.cs

Views/
   Home/
       Index.cshtml
       Privacy.cshtml

   Instruments/
       Index.cshtml
       Create.cshtml
       Edit.cshtml
```

# Standard ASP.NET MVC Naming Pattern:
|Component|Naming Convention|
|-|-|
|Model|Singular|
|Controller|Plural|
|Database Table|Usually plural|

**To summarize:**
- Always use singular names for models and plural for controllers, because controllers typically manage a collection of entities.
- Keeping consistent naming helps ASP.NET Core MVC conventions work automatically, avoiding unnecessary configuration.

### Example:
|Layer|Name|
|-|-|
|Model|`Instrument`|
|Controller|`InstrumentsController`|
|View folder|`Views/Instruments`|

# Professional MVC Structure:
In real applications we organize controllers by domain or feature.

**Example project:**
- Controllers
   - HomeController.cs
   - InstrumentsController.cs
   - OrdersController.cs
   - UsersController.cs
   - AdminsController.cs

**Each controller manages one logical area.**

Example:

The controller "InstrumentsController" handles:
   - GET: /Instruments
   - GET: /Instruments/Create
   - POST: /Instruments/Create
   - GET: /Instruments/Edit/7
   - POST: /Instruments/Edit/7
   - POST: /Instruments/Delete/7  (triggered via form submission)

# The _Layout.cshtml
The "_Layout.cshtml" file:
 - `_Layout.cshtml` is the master layout of our web application.
 - It contains shared HTML used across all pages, such as:
   ```bash
    - `<head>` section (CSS, meta tags, scripts)
   - Header / navigation menu
   - Footer
   - Common scripts at the bottom
   ```
- Each view (like `Index.cshtml`, `Create.cshtml`) uses `_Layout.cshtml` by default unless explicitly overridden.

# Standard MVC structure:
```bash
- Views
   -Home
      - Index.cshtml
      -Privacy.cshtml
   - Instruments
│    - Index.cshtml
│    - Create.cshtml
│    - Edit.cshtml
   - Shared
     - _Layout.cshtml
     - _ValidationScriptsPartial.cshtml
```
- `_Layout.cshtml` goes in `Views/Shared/`.
- All controllers and views use this shared layout by default.
- We do not need a separate layout per controller unless a different design is required.

Remember that in larger applications, multiple layouts can be used (for example: Admin layout vs User layout), but a shared layout is the standard starting point.

# The Controller
We added our custom controller `InstrumentsController`, which contains the default action method for loading the `Index.cshtml` view:
```
  public IActionResult Index()
  {
      return View();
  }
```

# The Views
ASP.NET Core MVC follows a convention-based view lookup system.

**1. ASP.NET Core MVC Knows Which View to Load**
When our controller action returns:
```C#
public IActionResult Index()
{
    return View();
}
```

**MVC interprets this using two conventions:**
- Controller name
- Action method name

**2. View Navigation**
For example, when navigating to: 
```bash
https://localhost:xxxx/Instruments
```

ASP.NET MVC routing resolves to:

|Component|Value|
|-|-|
|Controller|`InstrumentsController`|
|Action|`Index`|

**3. Default View Lookup Convention**
When **return View();** is executed, MVC searches for the view using this pattern:

```bash
Views/{ControllerNameWithoutController}/{ActionName}.cshtml
```
In our case this pattern resolves to:
|Value|Result|
| - | - |
| Controller| `InstrumentsController` |
|Folder| `Views/Instruments`|
|Action| `Index`|
|View file| `Index.cshtml`|


**Final path:**
```
Views/Instruments/Index.cshtml
```

**4. Why ASP.NET Core MVC doesn't load the Home view**
The HomeController maps to:
```bash
Views/Home/
```
So its Index() method loads:
```
Views/Home/Index.cshtml
```

The table below simplifies the idea:

|Controller|Action|View Loaded|
|-|-|-|
|**Home**Controller|Index()|Views/**Home**/Index.cshtml|
|**Instruments**Controller|Index()|Views/**Instruments**/Index.cshtml|

**5. Loading a different view:
We can explicitly specify a view:
```C#
return View("Create");
```

MVC will look for:
```C#
Views/Instruments/Create.cshtml
```

Or even a different folder:
```C#
return View("~/Views/Home/Index.cshtml");
```
However, it's considered to be rare because the convention already works well.


To summarize, Frameworks like ASP.NET Core MVC follow the principle:

   > **Convention over configuration**

So if we follow the expected naming and folder structure, the framework automatically connects everything. This is why MVC projects stay clean and predictable.

**6. What happens if the view folder has a different name?**
In our example:
 - The controller name is **"InstrumentsController.cs"**
 - ASP assumes that the view folder named **"Instruments"**
 - The Index() method returns the Index.cshtml view inside the "Instruments" view folder
 - If the folder is renamed to **"Devices"**, ASP.NET Core MVC will throw an `InvalidOperationException`:
   ```bash
      An unhandled exception occurred while processing the request. 
      InvalidOperationException: The view 'Index' was not found.
   ```
   - MVC strictly follows its view lookup conventions

Since our controller is named **`InstrumentsController`**, MVC automatically searches for the view using this convention:
```bash
/Views/{ControllerNameWithoutController}/{ActionName}.cshtml
```

This emphasizes the principle of "Convention over Configuration".

Additionally, MVC also checks::
```bash
Views/Shared/
```
because shared views can be reused across multiple controllers..
```bash
Views/Shared/Error.cshtml
Views/Shared/_Layout.cshtml
```

**NOTE TO REMEMBER:**
If a view is not found in the expected locations, ASP.NET Core MVC throws an `InvalidOperationException`, indicating that the view could not be located.

# Partial Views in ASP.NET Core MVC:
In our application, both **Create** and **Edit** pages will contain the same form fields:
```bash
Name
Description
Price
```

Without reuse, you would write the same code twice:

**Create.cshtml**
```bash
Name
Description
Price
```

**Edit.cshtml**
```bash
Name
Description
Price
```

That means duplicate code. As professional developers, we avoid duplication by using a "partial view".

A **Partial View** is a reusable Razor view fragment that can be embedded inside other views.

Think of it like a UI component. To learn more, check ["Partial views in ASP.NET Core"](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-10.0)

Example of a file that contains only the form fields:
```bash
_InstrumentForm.cshtml
```

Notice that by convention, the file starts with **_**. In ASP.NET Core MVC and Razor:
```bash
_Example.cshtml
```
This is a partial view, not a full page.

Examples of what we already have by default when starting a new ASP.NET app:
```bash
_Layout.cshtml
_ViewImports.cshtml
_ViewStart.cshtml
```
All start with `_` because they are not full standalone views, but reusable or shared components.

Partial View(s) should be placed inside your feature folder:
```bash
- Views:
   - Instruments
      - Index.cshtml
      - Create.cshtml
      - Edit.cshtml
      - _InstrumentForm.cshtml
```

Example structure for Create and Edit views:
```bash
Create.cshtml
    <form>
        _InstrumentForm partial
        Create button
    </form>

Edit.cshtml
    <form>
        _InstrumentForm partial
        Save button
    </form>
```

# Working with Forms:

Typical MVC convention prefers:
|Action|HTTP|Purpose|
|-|-|-|
|Create|GET|display form|
|Create|POST|process form|

Some instructors may use different method names to make the flow easier for beginners to understand.

Example beginner logic:
```bash
CreateInstrument() // show the form
CreateForm() // handle submission
```
This makes the flow very explicit. But experienced developers usually prefer the same name with different HTTP methods.

Coding Example - Standard MVC Convention (Recommended):
```C#
public IActionResult Create()
{
    return View();
}

[HttpPost]
public IActionResult Create(Instrument instrument)
{
    return RedirectToAction("Instruments");
}
```

From the user's perspective, both approaches behave similarly.

However, the actual URLs depend on the action method names and routing configuration.

For example:
```bash
GET  /CreateInstrument
POST /CreateForm
```
OR:
```bash
GET  /Create
POST /Create
```
So the user experience (UX) remains the same, even though the internal implementation differs.

### Naming Convention Summary:
|Approach|Professional?|Typical?|
|-|-|-|
|CreateInstrument + CreateForm|Valid|Less common|
|Create + Create (GET/POST)|Best practice|Very common|

You can learn more in the [MVC official documentation](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/actions)

# Entity Framework Required Tools:
For more details about using EF in .NET, refer to my repository ["Entity Framework Intro"](https://github.com/anmarjarjees/entity-framework-intro).

For simplicity, we will use an **In-Memory database**. This allows us to focus on learning the Entity Framework workflow without configuring a real SQL database server.

### Microsoft.EntityFrameworkCore:
- This is the **core Entity Framework Core library**.
- It provides the main APIs used for:
  - working with DbContext
  - defining DbSet entities
  - querying and saving data
- It is required by most EF Core providers.

You can learn more by visiting [Entity Framework](https://learn.microsoft.com/ef/core/).

---
### Microsoft.EntityFrameworkCore.InMemory
- This package provides the **InMemory database provider** for Entity Framework Core.
- It allows the application to store data **temporarily in memory (RAM)** instead of using a real database server.

**Advantages for learning:**

- No need to install SQL Server or another database system
- No connection string configuration
- Faster setup for demos and tutorials

**Important behavior:**
- Data is stored **only in the application's memory**
- All data **is lost when the application stops**

Notice that even though the data is temporary, the **Entity Framework coding workflow remains the same**, so the learning experience is identical to using a real database.

> **Warning:** The EF Core In-Memory database provider is intended for **testing and learning only**.  
> It is **not designed for production** because it is not robust, and all data is lost when the application stops.

You can learn more by visiting ["Entity Framework InMemory"](https://learn.microsoft.com/ef/core/providers/in-memory/).  

# Working with NuGet Package Manager:
There are two common ways to install NuGet packages for an ASP.NET Core project:

### Using NuGet Package Manager (Visual Studio):
1. Right-click on the project in Solution Explorer => Manage NuGet Packages…
2. Or use the "Project" menu => Manage NuGet Packages…
3. Browse for and install the following packages:
   - Microsoft.EntityFrameworkCore: the core Entity Framework library
      - https://learn.microsoft.com/en-us/ef/core/
   - Microsoft.EntityFrameworkCore.InMemory: InMemory database provider for testing and demos
      - https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli

### Using .NET CLI (Command Line Interface):
1. Open the terminal (either Visual Studio embedded terminal or your system terminal).
2. Run the following commands:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

**Reminder:**
- This is for learning, demos, or tests only. Data is lost when the app closes. For production, use SQL Server, PostgreSQL, or SQLite.
- Make sure to install compatible versions based on the .NET version installed on your system.

# The "Data" Folder and "DBContext" File:
Adding the Database Context CS file to our project. The DbContext file can be placed in two common locations:
**1) In the Models folder:**
   - Folder: Models/InstrumentDbContext.cs
   - This is common practice for small/learning projects

**2) In separate folder or project like Data:**
   - Folder: Data/InstrumentDbContext.cs
   - This is common practice for larger projects (apps) as recommended by Microsoft

However, to imitate a real project, we can create a folder named **"Data"** as we did in the JavaScript Framework course. This folder will contain the class file for the important database operations (DbContext, Migrations, Seed data).
To learn more, check ["DbContext Lifetime, Configuration, and Initialization"](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/).

The naming convention is to use **PascalCase** also, a descriptive name ending with **DbContext**.
Examples based on our current project:
- InstrumentDbContext => Valid for small or focused applications, but less scalable if the project grows to include multiple entities
- MusicGearDbContext => Slightly changes the name of the application. Good if we have a very long project name.
- MusicGearTrackerDbContext => Descriptive, follows Microsoft samples

The most widely used convention is:
```C#
<ApplicationName>DbContext
```

Many Microsoft samples follow this pattern (from Microsoft's official tutorials):
```C#
ContosoUniversityDbContext
```

Example:
```C#
public class MusicGearTrackerDbContext : DbContext
```
This class inherits the DbContext which is the core EF Core class that manages entities and database connections. **Think of DbContext as the "bridge" between our C# application and the database.** For more details, check ["DbContext Class"](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-10.0).

**Our Project Folder Summary:**
```bash
- MusicGearTracker:
   - Controllers => InstrumentsController.cs
   - Models => Instrument.cs
   - Data => MusicGearTrackerDbContext.cs
   - Views => Razor view files (UI templates)
   - Program.cs => The entrypoint to run/launch our program
```

**The next logical tutorial step will be:**
   1- Register DbContext in Program.cs
   2- Inject it into InstrumentsController
   3- Start performing CRUD operations

**1- Register DbContext in Program.cs:**

Please remember that defining (creating) the DbContext does not automatically register it in the application.
```C#
builder.Services.AddDbContext<MusicGearTrackerDbContext>(options =>
    options.UseInMemoryDatabase("MusicGearTrackerDB"));
```

**2- Inject it into InstrumentsController**

Refer to the controller file for detailed code and comments.


---
# Credits, References, and Resources:
- [What is ASP.NET Core?](https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet-core)
- [Develop ASP.NET Core MVC apps](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/develop-asp-net-core-mvc-apps)
- [Get started with ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-10.0&tabs=visual-studio)
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Introduction to Razor Pages in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/?view=aspnetcore-10.0)
- [My Bootstrap Website Code Demo](https://github.com/anmarjarjees/bootstrap5-website-sample)
- [Bootstrap docs](https://getbootstrap.com/docs/5.3/getting-started/introduction/)
- My Other .NET Stack Repos:
   - .NET and C# Intro:
      - https://github.com/anmarjarjees/dotnet-csharp-intro
   - C# Essentials:
      - https://github.com/anmarjarjees/csharp-essentials
   - C# Intro:
      - https://github.com/anmarjarjees/csharp-intro
   - Entity Framework Demo:
      - https://github.com/anmarjarjees/entity-framework-intro
   - CoolCraft ASP.NET API Demo:
      - https://github.com/anmarjarjees/CoolCrafts
   - ASP.NET Core DataBase Demo:
      - https://github.com/anmarjarjees/ASPCoreDB
   - ASP.NET Core MVC Demo:
      - https://github.com/anmarjarjees/MovieMVC
   - C# - Windows Presentation Foundation (WPF) Advanced:
      - https://github.com/anmarjarjees/A8WpfConcertTickets
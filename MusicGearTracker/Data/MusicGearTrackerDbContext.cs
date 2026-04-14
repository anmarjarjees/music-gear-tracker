using Microsoft.EntityFrameworkCore; // Required for using "DbContext" base class
using MusicGearTracker.Models; // Required for "DbContext" to see/access the "Instrument" model
/*
 * IMPORTANT NOTE:
 * ***************
 * Importing the Models namespace "MusicGearTracker.Models" is a MUST,
 * so this DbContext can reference the "Instrument" entity class,
 * 
 * Otherwise:
 * CS0246: The type or namespace name could not be found 
 * (are you missing a using directive or an assembly reference?)
 */
namespace MusicGearTracker.Data
{
    /*
     * The "MusicGearTrackerDbContext" class:
     * **************************************
     * This class represents the "Entity Framework Core" database context
     * for our Music Gear Tracker application.
     *
     * The DbContext is one of the most important classes in Entity Framework Core.
     * It is responsible for:
     *  - Managing entity classes (models)
     *  - Communicating with the database
     *  - Tracking changes to entities
     *  - Executing queries
     *  - Saving changes (Insert, Update, Delete)
     *
     * Remember: 
     * In this application we are using the EF Core InMemory database provider
     * for learning purposes.
     *
     * Link: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
     *
     * Naming conventions:
     * *******************
     * PascalCase naming is used in C#.
     * A common professional convention is: ProjectNameDbContext
     *
     * Example: MusicGearTrackerDbContext
     */

    public class MusicGearTrackerDbContext : DbContext
    {
        /*
         * Working with DbSet<T>:
         * **********************
         * 1) DbSet<Instrument>:
         * Represents a table (or collection of entities) in the database.
         *
         * 2) Each "DbSet" property tells Entity Framework Core 
         * that we want to store and manage that entity type in the database.
         *
         * 3) EF Core will automatically map this entity to a table.
         *
         * 4) DbSet provides many useful methods such as:
         *      > Add() => Insert a new entity
         *      > Find() => Search by primary key
         *      > Update() => Modify an existing entity
         *      > Remove() => Delete an entity
         *      > LINQ Queries => Query the database using LINQ
         *
         * Example property: DbSet<Instrument> Instruments
         *
         * Naming conventions:
         * *******************
         * - Entity class name is singular (Instrument):
         *      => represents our model class "Instrument"
         * - DbSet property name is plural (Instruments):
         *      => represents the collection of Instrument entities that EF Core maps to the "Instruments" table in the database
         *
         * In Entity Framework Core:
         * *************************
         *  - Instrument => Entity type
         *  - DbSet<Instrument> => Collection used to query/update entities
         *  - EF Core => maps that entity to a table
         *  
         * This follows common database and EF Core conventions.
         *
         * Link: https://learn.microsoft.com/en-us/ef/core/modeling/entity-types
         * Link: https://learn.microsoft.com/en-us/ef/core/modeling/
         */

        // Adding the property to store our entities in the database as a table
        public DbSet<Instrument> Instruments { get; set; }

        /*
         * Reminder:
         * Each DbSet property represents a table (or collection of entities)
         * that EF Core will manage in the database.
         */

        /*
         * Finally, Adding our custom constructor:
         * ****************************************
         *
         * This constructor allows ASP.NET Core Dependency Injection (DI)
         * to provide the database configuration options to the DbContext.
         *
         * DbContextOptions<TContext> contains configuration information such as:
         *      
         *      > Which database provider to use (InMemory, SQL Server, SQLite, etc.)
         *      > Connection strings
         *      > Database behavior settings
         *
         * By convention, the parameter name is usually called "options".
         *
         * TContext here refers to our DbContext class: "MusicGearTrackerDbContext"
         *
         * The base(options) call passes these options to the parent DbContext class.
         *
         * Link: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
         */
        
        // Constructor with dependency injection of DbContextOptions:
        public MusicGearTrackerDbContext(DbContextOptions<MusicGearTrackerDbContext> options)
            : base(options)
        {
        }
    }
}

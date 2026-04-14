using System.ComponentModel.DataAnnotations;

namespace MusicGearTracker.Models
{

    /*
     * In the MVC architecture, the Model represents the data that our application manages.
     * 
     * Application Domain:
     * Tutorial App => "Music Gear Tracker"
     * Model Entity => "Instrument"
     *
     * Each instance of this class represents one music instrument stored
     * in our application (for example: a guitar, keyboard, or piano).
     */
    public class Instrument
    {
        /*
         * Primary key Convention:
         * **********************
         * When using "Entity Framework Core", 
         * the "Id" property becomes the primary key and is auto-incremented by the database
         * so a property named "Id" is automatically recognized as the primary key "By Convention"
         * 
         * The property "Id" is the primary key for the Instrument entity:
         * 
         * NOTE: 
         * By convention, Entity Framework Core treats "Id" as the "primary key"
         * and configures it as an auto-increment column.
         * The database will automatically generate the value
         * when a new record is inserted.
         * 
         * Link: https://learn.microsoft.com/en-us/ef/core/
         * Link: https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
         */
        public int Id { get; set; } // the primary unique key
        /*
           * Notice that the C# compiler may produce:
           *    > "Non-nullable property must contain a non-null value" warning
           * when working with "reference types" like "string".
           *
           * We can resolve this in several ways:
           * ************************************
           *
           * 1) Initialize the property with a default value:
           *      public string Name { get; set; } = string.Empty;
           *
           * 2) Allow the property to be nullable:
           *      public string? Name { get; set; }
           *
           * 3) Disable nullable reference type warnings in the project settings (not recommended).
           *
           * In this project, we initialize the property with string.Empty
           * to ensure it always has a valid value.
           *
           * Link: https://learn.microsoft.com/dotnet/csharp/nullable-references
         */


        /*
         * Data Annotations (Built-in Attributes):
         * ***************************************
         * A common approach for decorating model properties with built-in attributes,
         * these attributes are from "System.ComponentModel.DataAnnotations" namespace.
         * 
         * Data Annotation: [Required]:
         * ****************************
         * This attribute tells ASP.NET Core MVC that this field MUST have a value.
         *
         * It is used during "Model Validation" when the form is submitted.
         * 
         * Model Validation: Occurs after model binding to verify the data against specified rules.
         *
         * Link:
         * https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation
         *
         * IMPORTANT CONCEPT:
         * ******************
         * We do NOT use "string?" here, as we did/learnt in C# course, because:
         * - "string?" allows null values
         * - "[Required]" means the value must NOT be null
         *
         * Mixing nullable reference types with [Required] can create confusion :-(
         *
         * Recommended practice:
         * - Using "non-nullable" string
         * - Initializing the property with "string.Empty" to avoid null reference issues
         *
         * Link: https://learn.microsoft.com/dotnet/csharp/nullable-references
         */
        [Required]
        public string Name { get; set; } = string.Empty;

        /*
         * Description field:
         * ******************
         * We mark it as [Required] so the user must provide a value (description for the instrument).
         *
         * We also avoid using "string?" here for the same reason explained above:
         * - Required fields should not allow null values
         *
         * string.Empty ensures the property is always initialized with a safe default value.
         */
        [Required]
        public string Description { get; set; } = string.Empty;

        /*
         * Price of the instrument:
         * ************************
         * The "decimal" data type is commonly used for monetary values 
         * to avoid floating-point precision issues.
         * 
         * This property is NOT marked with [Required], because:
         *      - It is a value type (decimal)
         *      - Value types in C# cannot be null (unless declared as nullable: decimal?)
         *      - If no value is provided, it will default to 0
         * 
         * IMPORTANT NOTE:
         * ***************
         * Even though this field is not marked as [Required],
         * the user must still enter a valid numeric value in the form.
         * 
         * Why?
         * ****
         * During form submission, 
         * ASP.NET Core MVC attempts to convert the input value into a decimal.
         * 
         * If the input is empty or has invalid value like text instead of a number,
         * model binding will fail and "ModelState" will become invalid.
         * 
         * This means:
         *      - The form will NOT be processed
         *      - The controller will return the same view instead of redirecting (as coded)
         * 
         * To allow truly optional input, we would use:
         *      public decimal? Price { get; set; }
         * 
         * Link: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding
         */
        public decimal Price { get; set; }
    }
}

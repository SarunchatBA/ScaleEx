namespace ScaleEx
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class ToDoEntities : DbContext
    {
        // Your context has been configured to use a 'ToDoModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ScaleEx.ToDoModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ToDoModel' 
        // connection string in the application configuration file.
        public ToDoEntities()
            : base("name=ToDoModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<ToDo> ToDoData { get; set; }
    }

    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
    }
}
namespace CodeFirstFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelF")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

    }
}
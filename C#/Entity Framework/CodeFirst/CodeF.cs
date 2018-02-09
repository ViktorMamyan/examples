namespace CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CodeF : DbContext
    {

        public CodeF()
            : base("name=CodeF")
        {
        }

        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
namespace sessiontest.Context
{
    using sessiontest.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EduContext : DbContext
    {
        public EduContext()
            : base("Server = DESKTOP-5P45H04\\SQLEXPRESS; Database = EduContext; Trusted_Connection = True;")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TryEF.Models;

namespace TryEF.DBctrl
{
    public class DBmain : DbContext
    {
        public DBmain() : base("EFbase")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
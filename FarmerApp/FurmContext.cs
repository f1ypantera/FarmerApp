using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FarmerApp.Model;

namespace FarmerApp
{
    class FurmContext : DbContext
    {
        public FurmContext()
       : base("DefaultConnection")
        { }

        public DbSet<FarmModel> FarmModels { get; set; }
    }
}

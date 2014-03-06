using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prjCurriculum.Models
{
    public class RecommendDB: DbContext
    {
        public RecommendDB()
            : base("DefaultConnection")
        {
        }
        public DbSet<Recommend> Recommends { get; set; }
    }
}
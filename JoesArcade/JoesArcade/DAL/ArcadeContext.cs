using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoesArcade.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JoesArcade.DAL
{
    //Arcade context to inherit from DbContext (from system.data.entity)
    public class ArcadeContext : DbContext
    {
        //here the connection string (added to the Web.config file) is passed into the constructor
        public ArcadeContext() : base("ArcadeContext")
        {
        }
        //This code creates a DbSet (from system.data.entity) property for the entity set.
        public DbSet<VideoGame> VideoGames { get; set; }

        //This method prevents the table names from becoming plural
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

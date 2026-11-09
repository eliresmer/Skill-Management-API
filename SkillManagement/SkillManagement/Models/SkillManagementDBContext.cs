using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace SkillManagement.Models
{
    public class SkillManagementDBContext : DbContext
    {
        public SkillManagementDBContext() : base("MyConnectionString"){
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SkillManagementDBContext, SkillManagement.Migrations.Configuration>());

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Descriptions> Descriptions { get; set; }
        public DbSet<Keywords> Keywords { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }


    }
}
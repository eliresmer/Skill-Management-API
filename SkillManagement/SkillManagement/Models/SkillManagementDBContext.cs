using System.Data.Entity;

namespace SkillManagement.Models
{
    public class SkillManagementDBContext : DbContext
    {
	public SkillManagementDBContext() : base("groupC_db")
	{
	    Database.SetInitializer(new MigrateDatabaseToLatestVersion<SkillManagementDBContext, SkillManagement.Migrations.Configuration>());

	}

	public DbSet<User> Users { get; set; }
	public DbSet<Skill> Skills { get; set; }
	public DbSet<Keyword> Keywords { get; set; }


    }
}
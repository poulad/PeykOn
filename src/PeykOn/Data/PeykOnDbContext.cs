using Microsoft.EntityFrameworkCore;
using PeykOn.Models;

namespace PeykOn.Data
{
    public class PeykOnDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<AccessToken> AccessTokens { get; set; }

        public PeykOnDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SnakeCaseEntityNames(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }

        private void SnakeCaseEntityNames(ModelBuilder modelBuilder)
        {
            var mapper = new Npgsql.NpgsqlSnakeCaseNameTranslator();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // modify column names
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = mapper.TranslateMemberName(property.Relational().ColumnName);
                }

                // modify table name
                entity.Relational().TableName = mapper.TranslateMemberName(entity.Relational().TableName);

                // move asp_net tables into schema 'identity'
                if (entity.Relational().TableName.StartsWith("asp_net_"))
                {
                    entity.Relational().TableName = entity.Relational().TableName.Replace("asp_net_", string.Empty);
                    entity.Relational().Schema = "identity";
                }
            }
        }
    }
}

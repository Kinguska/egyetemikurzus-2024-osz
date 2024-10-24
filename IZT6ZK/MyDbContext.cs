using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace IZT6ZK
{
    internal class MyDbContext : DbContext
    {
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<TopicEntity> Topics { get; set; }

        public MyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=questions.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionEntity>(entity =>
            {

                entity.ToTable("Questions");
                entity.HasKey(p => p.QuestionId);
            });

            modelBuilder.Entity<TopicEntity>(entity =>
            {

                entity.ToTable("Topics");
                entity.HasKey(p => p.TopicId);
            });


        }


    }
}

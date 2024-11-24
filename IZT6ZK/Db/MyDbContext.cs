using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using IZT6ZK.Models;
using Microsoft.EntityFrameworkCore;

namespace IZT6ZK.Db;

internal class MyDbContext : DbContext
{
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<TopicEntity> Topics { get; set; }

    public MyDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
            .UseSqlite($"Data Source=questions.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionEntity>(entity =>
        {

            entity.ToTable("Questions");
            entity.HasKey(p => p.QuestionId);

            entity.HasOne(p => p.Topic)
                .WithMany(p => p.Questions)
                .HasForeignKey(p => p.TopicId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<TopicEntity>(entity =>
        {
            entity.ToTable("Topics");
            entity.HasKey(p => p.TopicId);
        });


    }


}

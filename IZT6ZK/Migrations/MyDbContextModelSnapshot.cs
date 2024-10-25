﻿// <auto-generated />
using System;

using IZT6ZK.Db;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IZT6ZK.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("IZT6ZK.QuestionEntity", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestionId");

                    b.HasIndex("TopicId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("IZT6ZK.TopicEntity", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TopicId");

                    b.ToTable("Topics", (string)null);
                });

            modelBuilder.Entity("IZT6ZK.QuestionEntity", b =>
                {
                    b.HasOne("IZT6ZK.TopicEntity", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");

                    b.Navigation("Topic");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Litemir_CouseWork_DataBase_Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Litemir_CouseWork_DataBase_Postgres.Migrations
{
    [DbContext(typeof(LearningDbContext))]
    [Migration("20250110161844_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.ChapterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.WorkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.ChapterEntity", b =>
                {
                    b.HasOne("Litemir_CouseWork_DataBase_Postgres.Models.WorkEntity", "Work")
                        .WithMany("Chapters")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Work");
                });

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.WorkEntity", b =>
                {
                    b.HasOne("Litemir_CouseWork_DataBase_Postgres.Models.UserEntity", "User")
                        .WithMany("Works")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.UserEntity", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("Litemir_CouseWork_DataBase_Postgres.Models.WorkEntity", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}

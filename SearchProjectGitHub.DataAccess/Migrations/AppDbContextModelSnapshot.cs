﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SearchProjectGitHub.DataAccess;

#nullable disable

namespace SearchProjectGitHub.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SearchProjectGitHub.DataAccess.Models.SearchResult", b =>
                {
                    b.Property<Guid>("SearchResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ResultJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SearchString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SearchResultId");

                    b.ToTable("SearchResults");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using AA.FinTechBank.Infrastructure.DbContextApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AA.FinTechBank.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240513040222_UpdateDb")]
    partial class UpdateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AA.FinTechBank.Domain.Entities.EClient", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClientBalance")
                        .HasColumnType("integer");

                    b.Property<int>("ClientCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ClientDateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientGenre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClientIdentificationId")
                        .HasColumnType("integer");

                    b.Property<string>("ClientLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientMaritalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientNationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientOccupation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}

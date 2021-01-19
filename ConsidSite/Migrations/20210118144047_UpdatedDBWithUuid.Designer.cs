﻿// <auto-generated />
using System;
using ConsidSite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConsidSite.Migrations
{
    [DbContext(typeof(ConsidDBContext))]
    [Migration("20210118144047_UpdatedDBWithUuid")]
    partial class UpdatedDBWithUuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ConsidSite.Companies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("OrganizationNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ConsidSite.Stores", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("character varying(512)")
                        .HasMaxLength(512);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("character varying(512)")
                        .HasMaxLength(512);

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Latitude")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Longitude")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("character varying(16)")
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ConsidSite.Stores", b =>
                {
                    b.HasOne("ConsidSite.Companies", "Company")
                        .WithMany("Stores")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("CompanyId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ConsilioServices.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsilioServices.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ConsilioContext))]
    [Migration("20190508195747_correcao_many-to-many-profile-access")]
    partial class correcao_manytomanyprofileaccess
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsilioServices.Domain.Entities.MenuAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("MenuAccesses");
                });

            modelBuilder.Entity("ConsilioServices.Domain.Entities.SystemProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasAdmin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SystemProfiles");
                });

            modelBuilder.Entity("ConsilioServices.Domain.Entities.SystemProfileMenuAccess", b =>
                {
                    b.Property<int>("SystemProfileId");

                    b.Property<int>("MenuAccessId");

                    b.Property<bool>("Access");

                    b.HasKey("SystemProfileId", "MenuAccessId");

                    b.HasIndex("MenuAccessId");

                    b.ToTable("SystemProfileMenuAccesses");
                });

            modelBuilder.Entity("ConsilioServices.Domain.Entities.SystemUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<bool>("Status");

                    b.Property<int>("SystemProfileId");

                    b.HasKey("Id");

                    b.HasIndex("SystemProfileId");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("ConsilioServices.Domain.Entities.SystemProfileMenuAccess", b =>
                {
                    b.HasOne("ConsilioServices.Domain.Entities.MenuAccess", "MenuAccess")
                        .WithMany("SystemProfileMenuAccesses")
                        .HasForeignKey("MenuAccessId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsilioServices.Domain.Entities.SystemProfile", "SystemProfile")
                        .WithMany("SystemProfileMenuAccesses")
                        .HasForeignKey("SystemProfileId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsilioServices.Domain.Entities.SystemUser", b =>
                {
                    b.HasOne("ConsilioServices.Domain.Entities.SystemProfile", "SystemProfile")
                        .WithMany("SystemUsers")
                        .HasForeignKey("SystemProfileId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

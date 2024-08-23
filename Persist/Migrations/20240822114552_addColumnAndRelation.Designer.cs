﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persist;

#nullable disable

namespace Persist.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240822114552_addColumnAndRelation")]
    partial class addColumnAndRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Persist.Entities.ApplicationDeployedOnServerEntity", b =>
                {
                    b.Property<string>("ServerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApplicationPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ServerId", "ApplicationId");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ApplicationDeployedOnServer");
                });

            modelBuilder.Entity("Persist.Entities.ApplicationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Internal")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Persist.Entities.BookEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Persist.Entities.CustomerEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FirstInteraction")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FiscalIdentification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastInteraction")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Persist.Entities.CustomerHaveLicenceToApplicationEntity", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("BeginingSupport")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EndingSupport")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("cost")
                        .HasColumnType("double");

                    b.HasKey("CustomerId", "ApplicationId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("CustomerHaveLicenceToApplications");
                });

            modelBuilder.Entity("Persist.Entities.ServerEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double?>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("HasToMakeSupportSince")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("HostedSince")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("StopHost")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Server");
                });

            modelBuilder.Entity("Persist.Entities.ApplicationDeployedOnServerEntity", b =>
                {
                    b.HasOne("Persist.Entities.ApplicationEntity", "Application")
                        .WithMany("ApplicationDeployedOnServers")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persist.Entities.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Persist.Entities.ServerEntity", "Server")
                        .WithMany("ApplicationDeployedOnServers")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Customer");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Persist.Entities.CustomerHaveLicenceToApplicationEntity", b =>
                {
                    b.HasOne("Persist.Entities.ApplicationEntity", "Application")
                        .WithMany("CustomerHaveLicenceToApplication")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persist.Entities.CustomerEntity", "Customer")
                        .WithMany("CustomerHaveLicenceToApplication")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Persist.Entities.ApplicationEntity", b =>
                {
                    b.Navigation("ApplicationDeployedOnServers");

                    b.Navigation("CustomerHaveLicenceToApplication");
                });

            modelBuilder.Entity("Persist.Entities.CustomerEntity", b =>
                {
                    b.Navigation("CustomerHaveLicenceToApplication");
                });

            modelBuilder.Entity("Persist.Entities.ServerEntity", b =>
                {
                    b.Navigation("ApplicationDeployedOnServers");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persist;

#nullable disable

namespace Persist.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240726103950_applicationDeployedOnServerForCustommer")]
    partial class applicationDeployedOnServerForCustommer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Persist.Entities.ApplicationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Persist.Entities.DeployedApplicationEntity", b =>
                {
                    b.Property<string>("ServerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ServerId", "ApplicationId", "CustomerId");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("deployedApplicationEntities");
                });

            modelBuilder.Entity("Persist.Entities.ServerEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Server");
                });

            modelBuilder.Entity("Persist.Entities.DeployedApplicationEntity", b =>
                {
                    b.HasOne("Persist.Entities.ApplicationEntity", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persist.Entities.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persist.Entities.ServerEntity", "Entry")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Customer");

                    b.Navigation("Entry");
                });
#pragma warning restore 612, 618
        }
    }
}

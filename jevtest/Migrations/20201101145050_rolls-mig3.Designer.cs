﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jevtest.Models;

namespace jevtest.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201101145050_rolls-mig3")]
    partial class rollsmig3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("jevtest.Models.UserRolls", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Roll");

                    b.HasKey("id");

                    b.ToTable("UserRolls");
                });

            modelBuilder.Entity("jevtest.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Rollid");

                    b.Property<string>("SureName");

                    b.Property<string>("companey");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("UserId");

                    b.HasIndex("Rollid");

                    b.ToTable("MyUsers");
                });

            modelBuilder.Entity("jevtest.Models.Users", b =>
                {
                    b.HasOne("jevtest.Models.UserRolls", "Roll")
                        .WithMany("users")
                        .HasForeignKey("Rollid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Entity;

namespace WebApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190117060259_011701")]
    partial class _011701
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2019, 1, 17, 14, 2, 59, 550, DateTimeKind.Local));

                    b.Property<int>("IsValid")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(1);

                    b.Property<string>("RoleName");

                    b.Property<DateTime>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2019, 1, 17, 14, 2, 59, 550, DateTimeKind.Local));

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WebApp.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2019, 1, 17, 14, 2, 59, 547, DateTimeKind.Local));

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<int>("IsValid")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(1);

                    b.Property<string>("LoginName");

                    b.Property<string>("Phone");

                    b.Property<string>("Pwd");

                    b.Property<DateTime>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2019, 1, 17, 14, 2, 59, 549, DateTimeKind.Local));

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApp.Entity.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2019, 1, 17, 14, 2, 59, 550, DateTimeKind.Local));

                    b.Property<int>("IsValid")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(1);

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValue(new DateTime(2019, 1, 17, 14, 2, 59, 550, DateTimeKind.Local));

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}

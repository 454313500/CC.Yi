﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yi.Framework.Model;

namespace Yi.Framework.Model.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211017105828_yi-2")]
    partial class yi2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("icon")
                        .HasColumnType("TEXT");

                    b.Property<int>("is_delete")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("is_show")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("is_top")
                        .HasColumnType("INTEGER");

                    b.Property<string>("menu_name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("menuid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("mouldid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("router")
                        .HasColumnType("TEXT");

                    b.Property<int?>("sort")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("menuid");

                    b.HasIndex("mouldid");

                    b.ToTable("menu");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.mould", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("is_delete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("mould_name")
                        .HasColumnType("TEXT");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("mould");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("introduce")
                        .HasColumnType("TEXT");

                    b.Property<int>("is_delete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("role_name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.user", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("icon")
                        .HasColumnType("TEXT");

                    b.Property<string>("introduction")
                        .HasColumnType("TEXT");

                    b.Property<string>("ip")
                        .HasColumnType("TEXT");

                    b.Property<int>("is_delete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nick")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("menurole", b =>
                {
                    b.Property<int>("menusid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("rolesid")
                        .HasColumnType("INTEGER");

                    b.HasKey("menusid", "rolesid");

                    b.HasIndex("rolesid");

                    b.ToTable("menurole");
                });

            modelBuilder.Entity("roleuser", b =>
                {
                    b.Property<int>("rolesid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("usersid")
                        .HasColumnType("INTEGER");

                    b.HasKey("rolesid", "usersid");

                    b.HasIndex("usersid");

                    b.ToTable("roleuser");
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.menu", null)
                        .WithMany("children")
                        .HasForeignKey("menuid");

                    b.HasOne("Yi.Framework.Model.Models.mould", "mould")
                        .WithMany()
                        .HasForeignKey("mouldid");

                    b.Navigation("mould");
                });

            modelBuilder.Entity("menurole", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.menu", null)
                        .WithMany()
                        .HasForeignKey("menusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yi.Framework.Model.Models.role", null)
                        .WithMany()
                        .HasForeignKey("rolesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("roleuser", b =>
                {
                    b.HasOne("Yi.Framework.Model.Models.role", null)
                        .WithMany()
                        .HasForeignKey("rolesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yi.Framework.Model.Models.user", null)
                        .WithMany()
                        .HasForeignKey("usersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yi.Framework.Model.Models.menu", b =>
                {
                    b.Navigation("children");
                });
#pragma warning restore 612, 618
        }
    }
}

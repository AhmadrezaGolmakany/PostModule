﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostModule.Infrastracture.EF;

#nullable disable

namespace PostModule.Infrastracture.EF.Migrations
{
    [DbContext(typeof(Post_Context))]
    [Migration("20241221100214_1232")]
    partial class _1232
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PostModule.Domain.CityEntity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("Statuse")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("PostModule.Domain.PostEntity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CityPricePlus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InsideCity")
                        .HasColumnType("bit");

                    b.Property<int>("InsideStatePricePlus")
                        .HasColumnType("int");

                    b.Property<bool>("OutSideCity")
                        .HasColumnType("bit");

                    b.Property<int>("StateCenterPricePlus")
                        .HasColumnType("int");

                    b.Property<int>("StateClosePricePlus")
                        .HasColumnType("int");

                    b.Property<int>("StateNonClosePricePlus")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TehranPricePlus")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("PostModule.Domain.PostEntity.PostPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<int>("InsideStatePrice")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.Property<int>("StateCenterPrice")
                        .HasColumnType("int");

                    b.Property<int>("StateClosePrice")
                        .HasColumnType("int");

                    b.Property<int>("StateNonClosePrice")
                        .HasColumnType("int");

                    b.Property<int>("TehranPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostPrices");
                });

            modelBuilder.Entity("PostModule.Domain.StateEntity.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CloseStates")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("states", (string)null);
                });

            modelBuilder.Entity("PostModule.Domain.CityEntity.City", b =>
                {
                    b.HasOne("PostModule.Domain.StateEntity.State", "state")
                        .WithMany("cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("state");
                });

            modelBuilder.Entity("PostModule.Domain.PostEntity.PostPrice", b =>
                {
                    b.HasOne("PostModule.Domain.PostEntity.Post", "Post")
                        .WithMany("PostPrices")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("PostModule.Domain.PostEntity.Post", b =>
                {
                    b.Navigation("PostPrices");
                });

            modelBuilder.Entity("PostModule.Domain.StateEntity.State", b =>
                {
                    b.Navigation("cities");
                });
#pragma warning restore 612, 618
        }
    }
}

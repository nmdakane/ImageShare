﻿// <auto-generated />
using System;
using ImageShare.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImageShare.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211122115012_final2")]
    partial class final2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageShare.Models.ImageUploaded", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Image_id");

                    b.Property<Guid?>("Person")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("captured_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_capturedBy");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_captured");

                    b.Property<string>("geolocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_geolocation");

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<string>("imageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image_name");

                    b.Property<string>("tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_tag");

                    b.HasKey("id");

                    b.HasIndex("Person");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ImageShare.Models.Person", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("User_id");

                    b.Property<string>("contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User_Contact");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User_Email");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("User_Name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User_Password");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("User_Surname");

                    b.HasKey("id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ImageShare.Models.Shared", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("share_with");

                    b.Property<Guid?>("image_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("image_id");

                    b.HasIndex("user_id");

                    b.ToTable("sharedmages");
                });

            modelBuilder.Entity("ImageShare.Models.ImageUploaded", b =>
                {
                    b.HasOne("ImageShare.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("Person");

                    b.Navigation("person");
                });

            modelBuilder.Entity("ImageShare.Models.Shared", b =>
                {
                    b.HasOne("ImageShare.Models.ImageUploaded", "image")
                        .WithMany()
                        .HasForeignKey("image_id");

                    b.HasOne("ImageShare.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("image");

                    b.Navigation("person");
                });
#pragma warning restore 612, 618
        }
    }
}
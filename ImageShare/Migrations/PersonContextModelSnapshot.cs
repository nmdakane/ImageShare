﻿// <auto-generated />
using System;
using ImageShare.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImageShare.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("Person")
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

            modelBuilder.Entity("ImageShare.Models.ImageUploaded", b =>
                {
                    b.HasOne("ImageShare.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });
#pragma warning restore 612, 618
        }
    }
}

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

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_uploaded");

                    b.Property<int>("height")
                        .HasColumnType("int")
                        .HasColumnName("Image_height");

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<string>("imageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image_name");

                    b.Property<int>("width")
                        .HasColumnType("int")
                        .HasColumnName("Image_width");

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

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2")
                        .HasColumnName("User_DOB");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User_Email");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("User_Name");

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

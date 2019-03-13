using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FamilyPhotos.Data;

namespace FamilyPhotos.Migrations
{
    [DbContext(typeof(FamilyPhotosContext))]
    partial class FamilyPhotosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyPhotos.Models.PhotoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte[]>("Picture");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });
        }
    }
}

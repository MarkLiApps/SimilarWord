﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistance.EfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250121104548_Add LastUpdatedUtc column")]
    partial class AddLastUpdatedUtccolumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.WordStudy.Word", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Example")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExampleSoundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("MeaningLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeaningShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pronounciation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PronounciationAm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimilarWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Words", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.WordStudy.WordStudyModel", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("WordName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DaysToStudy")
                        .HasColumnType("int");

                    b.Property<string>("DaysToStudyHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastStudyTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudyCount")
                        .HasColumnType("int");

                    b.HasKey("UserName", "WordName");

                    b.HasIndex("WordName");

                    b.ToTable("WordStudies", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.WordStudy.WordStudyModel", b =>
                {
                    b.HasOne("ApplicationCore.WordStudy.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });
#pragma warning restore 612, 618
        }
    }
}

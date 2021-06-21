﻿// <auto-generated />
using GeneticalSelection.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeneticalSelection.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Class", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ClassId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("SubphylumId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SubphylumId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Group of verteble animals.",
                            LatinName = "Mamma",
                            Name = "Mammal",
                            SubphylumId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Are one of the two groups into which all the flowering plants or angiosperms were formerly divided.",
                            LatinName = "Dicotyledon",
                            Name = "Dicotyledonae",
                            SubphylumId = 2L
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Family", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("FamilyId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Families");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Dog-like carnivorans.",
                            LatinName = "Canidae",
                            Name = "Canidae",
                            OrderId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Description = "One of the largest families of dicotyledonous plants.",
                            LatinName = "Asceraceae",
                            Name = "Asceraceae",
                            OrderId = 2L
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Genus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("GenusId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("FamilyId")
                        .HasColumnType("bigint");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Genuses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Genus of the Caninae containing multiple extant species.",
                            FamilyId = 1L,
                            LatinName = "Canis",
                            Name = "Canis"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Genus comprising about 70 species of annual and perennial flowering plants.",
                            FamilyId = 2L,
                            LatinName = "Helianthus",
                            Name = "Helianthus"
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Kingdom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("KingdomId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Kingdoms");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Multicellular eukaryotic organisms.",
                            LatinName = "Animalia",
                            Name = "Animals"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Mainly multicellular organisms, predominantly photosynthetic aukaryotes.",
                            LatinName = "Plantae",
                            Name = "Plants"
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("OrderId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ClassId = 1L,
                            Description = "Specialized in primary eating flesh.",
                            LatinName = "Carnivora",
                            Name = "Carnivora"
                        },
                        new
                        {
                            Id = 2L,
                            ClassId = 2L,
                            Description = "Composite flowers made of florets.",
                            LatinName = "Asterales",
                            Name = "Asterales"
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Phylum", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PhylumId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("KingdomId")
                        .HasColumnType("bigint");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("KingdomId");

                    b.ToTable("Phylums");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Has chorda.",
                            KingdomId = 1L,
                            LatinName = "Chordata",
                            Name = "Chordate"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Land plants with lignified tissues.",
                            KingdomId = 2L,
                            LatinName = "Vasculum",
                            Name = "Vascular plant"
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Species", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("SpeciesId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("GenusId")
                        .HasColumnType("bigint");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Is a large canine native to Eurasia and North America.",
                            GenusId = 1L,
                            LatinName = "Canis lupus",
                            Name = "Gray Wolf"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "The common names sunflower and common sunflower typically refer to the popular annual species Helianthus annuus.",
                            GenusId = 2L,
                            LatinName = "Helianthus",
                            Name = "Sunflower"
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Subphylum", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("SubphylumId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LatinName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("PhylumId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PhylumId");

                    b.ToTable("Subphylums");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Chordates with backbones.",
                            LatinName = "Vertebrata",
                            Name = "Vertebrates",
                            PhylumId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Most diverse group of land plants.",
                            LatinName = "Angiospermae",
                            Name = "Flowering plant",
                            PhylumId = 2L
                        });
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Class", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Subphylum", "Subphylum")
                        .WithMany("Classes")
                        .HasForeignKey("SubphylumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subphylum");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Family", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Order", "Order")
                        .WithMany("Families")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Genus", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Family", "Family")
                        .WithMany("Genuses")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Order", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Class", "Class")
                        .WithMany("Orders")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Phylum", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Kingdom", "Kingdom")
                        .WithMany("Phylums")
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Species", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Genus", "Genus")
                        .WithMany("Species")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genus");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Subphylum", b =>
                {
                    b.HasOne("GeneticalSelection.Models.Entities.Phylum", "Phylum")
                        .WithMany("Subphylums")
                        .HasForeignKey("PhylumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phylum");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Class", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Family", b =>
                {
                    b.Navigation("Genuses");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Genus", b =>
                {
                    b.Navigation("Species");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Kingdom", b =>
                {
                    b.Navigation("Phylums");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Order", b =>
                {
                    b.Navigation("Families");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Phylum", b =>
                {
                    b.Navigation("Subphylums");
                });

            modelBuilder.Entity("GeneticalSelection.Models.Entities.Subphylum", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}

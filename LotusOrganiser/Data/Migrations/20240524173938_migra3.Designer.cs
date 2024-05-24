﻿// <auto-generated />
using LotusOrganiser.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LotusOrganiser.Migrations
{
    [DbContext(typeof(LotusOrganiserDbContext))]
    [Migration("20240524173938_migra3")]
    partial class migra3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LotusOrganiser.Entities.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PersonId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.Team", b =>
                {
                    b.Property<long>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeamId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.TeamMember", b =>
                {
                    b.Property<long>("TeamMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeamMemberId"));

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.HasKey("TeamMemberId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.ToDoListItem", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ItemId"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.HasKey("ItemId");

                    b.HasIndex("TeamId");

                    b.ToTable("ToDoListItems");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.TeamMember", b =>
                {
                    b.HasOne("LotusOrganiser.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LotusOrganiser.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("LotusOrganiser.Entities.ToDoListItem", b =>
                {
                    b.HasOne("LotusOrganiser.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
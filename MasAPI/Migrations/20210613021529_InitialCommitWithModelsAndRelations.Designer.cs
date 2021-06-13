﻿// <auto-generated />
using System;
using MasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MasAPI.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210613021529_InitialCommitWithModelsAndRelations")]
    partial class InitialCommitWithModelsAndRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("AccessoryTraining", b =>
                {
                    b.Property<int>("AccessoriesAccessoryId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingsTrainingId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingsTeamId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingsFieldId")
                        .HasColumnType("int");

                    b.HasKey("AccessoriesAccessoryId", "TrainingsTrainingId", "TrainingsTeamId", "TrainingsFieldId");

                    b.HasIndex("TrainingsTrainingId", "TrainingsTeamId", "TrainingsFieldId");

                    b.ToTable("AccessoryTraining");
                });

            modelBuilder.Entity("MasAPI.Models.Accessory", b =>
                {
                    b.Property<int>("AccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("AccessoryId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("MasAPI.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MasAPI.Models.Coach", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<float>("HourlyRate")
                        .HasColumnType("float");

                    b.HasKey("PersonId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("MasAPI.Models.Fan", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("FanCardId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PersonId");

                    b.ToTable("Fans");
                });

            modelBuilder.Entity("MasAPI.Models.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("SeatQuantity")
                        .HasColumnType("int");

                    b.HasKey("FieldId");

                    b.HasIndex("AddressId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("MasAPI.Models.Match", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSince")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUntil")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("RefereePersonId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "FieldId", "MatchId");

                    b.HasIndex("FieldId");

                    b.HasIndex("RefereePersonId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("MasAPI.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MasAPI.Models.Player", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("BetterLeg")
                        .HasColumnType("int");

                    b.Property<int?>("Speed")
                        .HasColumnType("int");

                    b.Property<int?>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("PersonId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MasAPI.Models.Referee", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("PersonId");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("MasAPI.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("League")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MasAPI.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("FanPersonId")
                        .HasColumnType("int");

                    b.Property<int>("MatchFieldId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId1")
                        .HasColumnType("int");

                    b.Property<int>("MatchTeamId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("TicketId", "MatchId");

                    b.HasIndex("FanPersonId");

                    b.HasIndex("MatchTeamId", "MatchFieldId", "MatchId1");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MasAPI.Models.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSince")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUntil")
                        .HasColumnType("datetime(6)");

                    b.HasKey("TrainingId", "TeamId", "FieldId");

                    b.HasIndex("FieldId");

                    b.HasIndex("TeamId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("AccessoryTraining", b =>
                {
                    b.HasOne("MasAPI.Models.Accessory", null)
                        .WithMany()
                        .HasForeignKey("AccessoriesAccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasAPI.Models.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingsTrainingId", "TrainingsTeamId", "TrainingsFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasAPI.Models.Coach", b =>
                {
                    b.HasOne("MasAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MasAPI.Models.Fan", b =>
                {
                    b.HasOne("MasAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MasAPI.Models.Field", b =>
                {
                    b.HasOne("MasAPI.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MasAPI.Models.Match", b =>
                {
                    b.HasOne("MasAPI.Models.Field", "Field")
                        .WithMany("Matches")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasAPI.Models.Referee", "Referee")
                        .WithMany()
                        .HasForeignKey("RefereePersonId");

                    b.HasOne("MasAPI.Models.Team", "Team")
                        .WithMany("Matches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Referee");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MasAPI.Models.Person", b =>
                {
                    b.HasOne("MasAPI.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MasAPI.Models.Player", b =>
                {
                    b.HasOne("MasAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasAPI.Models.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MasAPI.Models.Referee", b =>
                {
                    b.HasOne("MasAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MasAPI.Models.Ticket", b =>
                {
                    b.HasOne("MasAPI.Models.Fan", null)
                        .WithMany("Tickets")
                        .HasForeignKey("FanPersonId");

                    b.HasOne("MasAPI.Models.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchTeamId", "MatchFieldId", "MatchId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("MasAPI.Models.Training", b =>
                {
                    b.HasOne("MasAPI.Models.Field", "Field")
                        .WithMany("Trainings")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasAPI.Models.Team", "Team")
                        .WithMany("Trainings")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MasAPI.Models.Fan", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MasAPI.Models.Field", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("MasAPI.Models.Team", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Players");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
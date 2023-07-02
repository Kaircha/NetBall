﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetBallAPI.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetBallAPI.Migrations
{
    [DbContext(typeof(NetBallDbContext))]
    [Migration("20230629175347_OwnedPokemonRename")]
    partial class OwnedPokemonRename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NetBallAPI.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CatcherId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CatcherId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("NetBallAPI.Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Money")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("NetBallAPI.Models.Pokemon", b =>
                {
                    b.HasOne("NetBallAPI.Models.Trainer", "Catcher")
                        .WithMany("CaughtPokemon")
                        .HasForeignKey("CatcherId");

                    b.HasOne("NetBallAPI.Models.Trainer", "Trainer")
                        .WithMany("OwnedPokemon")
                        .HasForeignKey("TrainerId");

                    b.Navigation("Catcher");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("NetBallAPI.Models.Trainer", b =>
                {
                    b.Navigation("CaughtPokemon");

                    b.Navigation("OwnedPokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
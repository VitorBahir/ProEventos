﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEventos.Persistence.Contexts;

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(ProEventosContext))]
    partial class ProEventosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ProEventos.Domain.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("ProEventos.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountPeople")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Place")
                        .HasColumnType("TEXT");

                    b.Property<string>("Theme")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ProEventos.Domain.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SpeakerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("ProEventos.Domain.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Curriculo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("ProEventos.Domain.SpeakerEvent", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeakerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId", "SpeakerId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SpeakerEvent");
                });

            modelBuilder.Entity("ProEventos.Domain.Batch", b =>
                {
                    b.HasOne("ProEventos.Domain.Event", "Evento")
                        .WithMany("Batches")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProEventos.Domain.SocialMedia", b =>
                {
                    b.HasOne("ProEventos.Domain.Event", "Event")
                        .WithMany("SocialMedias")
                        .HasForeignKey("EventId");

                    b.HasOne("ProEventos.Domain.Speaker", "Speaker")
                        .WithMany("SocialMedias")
                        .HasForeignKey("SpeakerId");

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("ProEventos.Domain.SpeakerEvent", b =>
                {
                    b.HasOne("ProEventos.Domain.Event", "Event")
                        .WithMany("SpeakersEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Speaker", "Speaker")
                        .WithMany("SpeakersEvents")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("ProEventos.Domain.Event", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("SocialMedias");

                    b.Navigation("SpeakersEvents");
                });

            modelBuilder.Entity("ProEventos.Domain.Speaker", b =>
                {
                    b.Navigation("SocialMedias");

                    b.Navigation("SpeakersEvents");
                });
#pragma warning restore 612, 618
        }
    }
}

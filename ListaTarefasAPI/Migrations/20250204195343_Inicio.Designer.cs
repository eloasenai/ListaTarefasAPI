﻿// <auto-generated />
using ListaTarefasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListaTarefasAPI.Migrations
{
    [DbContext(typeof(ListaTarefasContext))]
    [Migration("20250204195343_Inicio")]
    partial class Inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ListaTarefasAPI.Models.Tarefa", b =>
                {
                    b.Property<int>("Tarefaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tarefaid"));

                    b.Property<bool>("Concluida")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipotarefaid")
                        .HasColumnType("int");

                    b.HasKey("Tarefaid");

                    b.HasIndex("Tipotarefaid");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("ListaTarefasAPI.Models.Tipotarefa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tipotarefas");
                });

            modelBuilder.Entity("ListaTarefasAPI.Models.Tarefa", b =>
                {
                    b.HasOne("ListaTarefasAPI.Models.Tipotarefa", "Tipotarefa")
                        .WithMany()
                        .HasForeignKey("Tipotarefaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipotarefa");
                });
#pragma warning restore 612, 618
        }
    }
}

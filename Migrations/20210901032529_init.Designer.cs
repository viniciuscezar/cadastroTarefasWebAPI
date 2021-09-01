﻿// <auto-generated />
using CadstrarTarefasWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadstrarTarefasWebAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210901032529_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CadstrarTarefasWebAPI.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("CadstrarTarefasWebAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CadstrarTarefasWebAPI.Models.Usuario", b =>
                {
                    b.HasOne("CadstrarTarefasWebAPI.Models.Tarefa", "Tarefa")
                        .WithMany()
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });
#pragma warning restore 612, 618
        }
    }
}

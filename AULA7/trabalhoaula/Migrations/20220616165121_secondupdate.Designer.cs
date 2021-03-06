// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using trabalhoaula;

#nullable disable

namespace trabalhoaula.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220616165121_secondupdate")]
    partial class secondupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("trabalhoaula.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("Valor")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("trabalhoaula.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("trabalhoaula.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BillingId")
                        .HasColumnType("integer");

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Fone")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.HasIndex("CityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("trabalhoaula.Person", b =>
                {
                    b.HasOne("trabalhoaula.Billing", "Billing")
                        .WithMany()
                        .HasForeignKey("BillingId");

                    b.HasOne("trabalhoaula.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("Billing");

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}

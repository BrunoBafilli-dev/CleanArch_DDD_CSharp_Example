﻿// <auto-generated />
using System;
using Infrastructure.Request.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240716200219_FirstCommit4")]
    partial class FirstCommit4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Client.ClientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Item.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Request.RequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasMaxLength(80)
                        .HasColumnType("INTEGER")
                        .HasColumnName("ClientId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Request", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Request.RequestItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80)
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<int>("RequestEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("RequestEntityId");

                    b.ToTable("RequestItem", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Client.ClientEntity", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ClientEntityId")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Address_Number");

                            b1.Property<string>("Road")
                                .IsRequired()
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Address_Road");

                            b1.HasKey("ClientEntityId");

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientEntityId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Item.ItemEntity", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.PriceItem", "PriceItem", b1 =>
                        {
                            b1.Property<int>("ItemEntityId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Price")
                                .HasColumnType("DECIMAL(18,2)")
                                .HasColumnName("PriceItem");

                            b1.HasKey("ItemEntityId");

                            b1.ToTable("Item");

                            b1.WithOwner()
                                .HasForeignKey("ItemEntityId");
                        });

                    b.OwnsOne("Domain.ValueObjects.QuantityItem", "QuantityItemStock", b1 =>
                        {
                            b1.Property<int>("ItemEntityId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasColumnType("INTEGER")
                                .HasColumnName("QuantityItem");

                            b1.HasKey("ItemEntityId");

                            b1.ToTable("Item");

                            b1.WithOwner()
                                .HasForeignKey("ItemEntityId");
                        });

                    b.Navigation("PriceItem")
                        .IsRequired();

                    b.Navigation("QuantityItemStock")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Request.RequestItemEntity", b =>
                {
                    b.HasOne("Domain.Entities.Request.RequestEntity", "RequestEntity")
                        .WithMany("RequestItensEntities")
                        .HasForeignKey("RequestEntityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.PriceItem", "PriceItem", b1 =>
                        {
                            b1.Property<int>("RequestItemEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Price")
                                .HasColumnType("DECIMAL(18,2)")
                                .HasColumnName("Price");

                            b1.HasKey("RequestItemEntityId");

                            b1.ToTable("RequestItem");

                            b1.WithOwner()
                                .HasForeignKey("RequestItemEntityId");
                        });

                    b.OwnsOne("Domain.ValueObjects.QuantityItem", "QuantityItem", b1 =>
                        {
                            b1.Property<int>("RequestItemEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Quantity")
                                .HasColumnType("INTEGER")
                                .HasColumnName("QuantityItem");

                            b1.HasKey("RequestItemEntityId");

                            b1.ToTable("RequestItem");

                            b1.WithOwner()
                                .HasForeignKey("RequestItemEntityId");
                        });

                    b.Navigation("PriceItem")
                        .IsRequired();

                    b.Navigation("QuantityItem")
                        .IsRequired();

                    b.Navigation("RequestEntity");
                });

            modelBuilder.Entity("Domain.Entities.Request.RequestEntity", b =>
                {
                    b.Navigation("RequestItensEntities");
                });
#pragma warning restore 612, 618
        }
    }
}

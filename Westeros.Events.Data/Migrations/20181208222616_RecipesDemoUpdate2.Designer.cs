﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Data.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20181208222616_RecipesDemoUpdate2")]
    partial class RecipesDemoUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Westeros.Events.Data.Model.IMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("From")
                        .IsRequired();

                    b.Property<bool>("ReadFlag");

                    b.Property<string>("To")
                        .IsRequired();

                    b.Property<string>("Topic");

                    b.HasKey("Id");

                    b.ToTable("MailDB");
                });

            modelBuilder.Entity("Westeros.Events.Data.Model.LogRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MessageId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("LogDb");
                });

            modelBuilder.Entity("Westeros.Events.Data.Model.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("NickName")
                        .IsRequired();

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.HasAlternateKey("NickName");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Westeros.Events.Data.Model.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNew");

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.ToTable("RecipeDb");
                });

            modelBuilder.Entity("Westeros.Events.Data.Model.LogRecord", b =>
                {
                    b.HasOne("Westeros.Events.Data.Model.IMessage", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");
                });
#pragma warning restore 612, 618
        }
    }
}

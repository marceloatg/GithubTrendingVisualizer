﻿// <auto-generated />
using GithubTrendingVisualizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GithubTrendingVisualizer.Web.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170918030335_RepositoryProtectedPropertiesMadePublic")]
    partial class RepositoryProtectedPropertiesMadePublic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GithubTrendingVisualizer.Data.Models.Repository", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("ForksCount");

                    b.Property<long>("GithubId");

                    b.Property<string>("HtmlUrl");

                    b.Property<string>("Language");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerAvatarUrl");

                    b.Property<string>("OwnerHtmlUrl");

                    b.Property<string>("OwnerName");

                    b.Property<int>("StargazersCount");

                    b.HasKey("Id");

                    b.ToTable("Repository");
                });

            modelBuilder.Entity("GithubTrendingVisualizer.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

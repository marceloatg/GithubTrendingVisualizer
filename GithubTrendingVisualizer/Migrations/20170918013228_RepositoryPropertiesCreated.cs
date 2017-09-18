using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GithubTrendingVisualizer.Web.Migrations
{
    public partial class RepositoryPropertiesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForksCount",
                table: "Repository",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "GithubId",
                table: "Repository",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "HtmlUrl",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerAvatarUrl",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerHtmlUrl",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StargazersCount",
                table: "Repository",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "ForksCount",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "GithubId",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "HtmlUrl",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "OwnerAvatarUrl",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "OwnerHtmlUrl",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "StargazersCount",
                table: "Repository");
        }
    }
}

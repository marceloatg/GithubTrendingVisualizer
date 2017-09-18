using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GithubTrendingVisualizer.Web.Migrations
{
    public partial class RepositoryUniqueKeyGithubId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "UniqueKey_GithubId",
                table: "Repository",
                column: "GithubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UniqueKey_GithubId",
                table: "Repository");
        }
    }
}

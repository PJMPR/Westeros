using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Westeros.UserProfile.Data.Migrations
{
    public partial class CreateUserDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "weight",
                table: "User",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "height",
                table: "User",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "height",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "weight",
                table: "User",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

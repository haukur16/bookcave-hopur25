using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations.AuthenticationDb
{
    public partial class ExtendingAspNetUserWithCustomProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Avatar",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZIP",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookReviewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    BookReview = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReviewModel");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "AspNetUsers");
        }
    }
}

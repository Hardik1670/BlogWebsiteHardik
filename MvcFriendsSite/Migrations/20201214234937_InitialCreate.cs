using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcFriendsSite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AuthorEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(maxLength: 60, nullable: false),
                    gender = table.Column<string>(maxLength: 15, nullable: false),
                    alias = table.Column<string>(maxLength: 60, nullable: false),
                    website = table.Column<string>(maxLength: 60, nullable: false),
                    socialWebsite = table.Column<string>(maxLength: 60, nullable: false),
                    email = table.Column<string>(nullable: false),
                    dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(maxLength: 60, nullable: false),
                    email = table.Column<string>(nullable: false),
                    profilePicUrl = table.Column<string>(nullable: true),
                    friendsEmail = table.Column<string>(nullable: false),
                    UserModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialModel_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialModel_UserModelId",
                table: "SocialModel",
                column: "UserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "SocialModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}

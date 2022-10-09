using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemberRegister.Data.Migrations
{
    public partial class Initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postaladdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Address", "CreationDate", "Firstname", "LastUpdatedDate", "Lastname", "Postaladdress", "Postcode" },
                values: new object[] { 1, "Adress 1", new DateTime(2022, 10, 7, 18, 59, 29, 384, DateTimeKind.Local).AddTicks(757), "Fornamn 1", new DateTime(2022, 10, 7, 18, 59, 29, 384, DateTimeKind.Local).AddTicks(757), "Efternamn 1", "Postort 1", "111111" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Address", "CreationDate", "Firstname", "LastUpdatedDate", "Lastname", "Postaladdress", "Postcode" },
                values: new object[] { 2, "Adress 2", new DateTime(2022, 10, 7, 18, 59, 29, 384, DateTimeKind.Local).AddTicks(757), "Fornamn 2", new DateTime(2022, 10, 7, 18, 59, 29, 384, DateTimeKind.Local).AddTicks(757), "Efternamn 2", "Postort 2", "222222" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Address", "CreationDate", "Firstname", "LastUpdatedDate", "Lastname", "Postaladdress", "Postcode" },
                values: new object[] { 3, "Adress 3", new DateTime(2022, 10, 7, 18, 59, 29, 384, DateTimeKind.Local).AddTicks(757), "Fornamn 3", new DateTime(2022, 10, 7, 18, 59, 29, 384, DateTimeKind.Local).AddTicks(757), "Efternamn 3", "Postort 3", "333333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}

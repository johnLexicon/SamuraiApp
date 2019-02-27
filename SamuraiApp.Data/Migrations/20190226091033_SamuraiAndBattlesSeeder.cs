using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class SamuraiAndBattlesSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { -1, new DateTime(1560, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle of Okehazama", new DateTime(1560, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, new DateTime(1877, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battle of Shiroyama", new DateTime(1877, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, new DateTime(1615, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siege of Osaka", new DateTime(1614, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -4, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boshin War", new DateTime(1868, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Samurais",
                columns: new[] { "Id", "Name", "SwordLength" },
                values: new object[,]
                {
                    { -1, "Kikuchiyo", 0 },
                    { -2, "Kambei Shimada", 0 },
                    { -3, "Shichirōji ", 0 },
                    { -4, "Katsushirō Okamoto", 0 },
                    { -5, "Heihachi Hayashida", 0 },
                    { -6, "Kyūzō", 0 },
                    { -7, "Gorōbei Katayama", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}

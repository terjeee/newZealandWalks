using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace newZealandWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedPopulateDifficultyandRegiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4003444c-5939-4920-88f0-e7f122d6d168"), "Easy" },
                    { new Guid("8e716e7c-9018-4e57-bfa4-aef9b1d8c6ce"), "Hard" },
                    { new Guid("d1d455a9-4b90-4eab-9380-1996a5fc6d35"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("3893d6b8-f8f1-4e50-85d2-bfeb4a880a3f"), "AKL", "Auckland", "https://dummyUrl.com/auckland" },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://dummyUrl.com/nelson" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://dummyUrl.com/wellington" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4003444c-5939-4920-88f0-e7f122d6d168"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8e716e7c-9018-4e57-bfa4-aef9b1d8c6ce"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d1d455a9-4b90-4eab-9380-1996a5fc6d35"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3893d6b8-f8f1-4e50-85d2-bfeb4a880a3f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

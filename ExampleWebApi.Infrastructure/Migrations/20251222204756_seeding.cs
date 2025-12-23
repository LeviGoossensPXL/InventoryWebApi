using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExampleWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Items used for work, office tasks, or professional activities", "work" },
                    { 2, "Everyday items used around the house", "home" },
                    { 3, "Groceries, pantry items, and consumable food products", "food" },
                    { 4, "Electronic devices, gadgets, and accessories", "electronics" },
                    { 5, "Items that do not fit into any specific category", "other" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Image", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Prusa", "https://localhost:7027/images/items/b95db868-ecb5-41f1-8f82-5a8bf520ad66.jpg", "3d printer", 1500.00m, "CoreOne" },
                    { 2, "iFixIt", "https://localhost:7027/images/items/c82af8a4-3662-4734-8453-a4e08197efc6.jpg", "repair toolkit", 77.41m, "pro tech toolkit" },
                    { 3, "Alberenz", "https://localhost:7027/images/items/45690b8f-3173-4e74-be8f-c773612046bb.jpg", "monitor arm", 99.00m, "single monitorarm Donkergrijs" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "leds in de vorm van een kubus om mooie effect te tonen door programmatie", "led cube" },
                    { 2, "een kubus die zich zelf kan balanceren op zijn punt", "self balancing cube" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("52a28510-1ef3-4e2c-b4ee-3ea66a0f8200"), 0, "8b858d39-af54-4a73-a3da-ed192d3e065e", "levigoossens17@gmail.com", false, false, null, null, null, "password1", null, false, null, false, null },
                    { new Guid("5ef92990-dacb-44b5-8d1e-c6ca68d703fb"), 0, "6a05a6af-00ff-4a2c-a233-d4450a8b2056", "luca33@gmail.com", false, false, null, null, null, "password3", null, false, null, false, null },
                    { new Guid("6c4a1ab1-343e-4e7d-b02d-c06783554445"), 0, "f86199dc-4ad3-4840-bfe5-f2fc868e9998", "alex22@gmail.com", false, false, null, null, null, "password2", null, false, null, false, null },
                    { new Guid("f4fdc5c1-bc32-4768-90b5-644ebc069962"), 0, "652af972-0d95-4363-9c17-da758bc598e9", "tom44@gmail.com", false, false, null, null, null, "password4", null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "NickName", "UserId" },
                values: new object[,]
                {
                    { new Guid("481333cf-028e-4b80-8b96-b5f8dac74805"), "lord", new Guid("f4fdc5c1-bc32-4768-90b5-644ebc069962") },
                    { new Guid("54aed1e7-4e36-4d89-afd9-b8d6dba592bb"), "dragon", new Guid("52a28510-1ef3-4e2c-b4ee-3ea66a0f8200") },
                    { new Guid("722a7f79-4c4c-472d-886d-8e106dc68571"), "loren", new Guid("6c4a1ab1-343e-4e7d-b02d-c06783554445") },
                    { new Guid("b462bda4-17c6-49fd-bcb2-a0b5600c0dad"), "cyber", new Guid("5ef92990-dacb-44b5-8d1e-c6ca68d703fb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52a28510-1ef3-4e2c-b4ee-3ea66a0f8200"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5ef92990-dacb-44b5-8d1e-c6ca68d703fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c4a1ab1-343e-4e7d-b02d-c06783554445"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4fdc5c1-bc32-4768-90b5-644ebc069962"));

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

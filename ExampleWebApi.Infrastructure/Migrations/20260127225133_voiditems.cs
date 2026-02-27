using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class voiditems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedItems_Items_ItemId",
                table: "OwnedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Items_ItemId",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishedItems_Items_ItemId",
                table: "WishedItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_WishedItems_ItemId",
                table: "WishedItems");

            migrationBuilder.DropIndex(
                name: "IX_OwnedItems_ItemId",
                table: "OwnedItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "WishedItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "OwnedItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ProjectItems",
                newName: "VoidItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItems_ItemId",
                table: "ProjectItems",
                newName: "IX_ProjectItems_VoidItemId");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "WishedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WishedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WishedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "WishedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "OwnedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OwnedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OwnedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "OwnedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VoidItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoidItems", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_VoidItems_VoidItemId",
                table: "ProjectItems",
                column: "VoidItemId",
                principalTable: "VoidItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_VoidItems_VoidItemId",
                table: "ProjectItems");

            migrationBuilder.DropTable(
                name: "VoidItems");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "WishedItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WishedItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WishedItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "WishedItems");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "OwnedItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OwnedItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OwnedItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "OwnedItems");

            migrationBuilder.RenameColumn(
                name: "VoidItemId",
                table: "ProjectItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItems_VoidItemId",
                table: "ProjectItems",
                newName: "IX_ProjectItems_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "WishedItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "OwnedItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishedItems_ItemId",
                table: "WishedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedItems_ItemId",
                table: "OwnedItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedItems_Items_ItemId",
                table: "OwnedItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Items_ItemId",
                table: "ProjectItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishedItems_Items_ItemId",
                table: "WishedItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

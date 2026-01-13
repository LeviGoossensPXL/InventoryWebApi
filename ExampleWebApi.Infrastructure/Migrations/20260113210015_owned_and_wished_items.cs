using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class owned_and_wished_items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "GroupProject",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    ProjectsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProject", x => new { x.GroupsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_GroupProject_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    AcquiredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedItems_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupOwnedItem",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    OwnedItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOwnedItem", x => new { x.GroupsId, x.OwnedItemsId });
                    table.ForeignKey(
                        name: "FK_GroupOwnedItem_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOwnedItem_OwnedItems_OwnedItemsId",
                        column: x => x.OwnedItemsId,
                        principalTable: "OwnedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupOwnedItems",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    OwnedItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOwnedItems", x => new { x.GroupId, x.OwnedItemId });
                    table.ForeignKey(
                        name: "FK_GroupOwnedItems_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOwnedItems_OwnedItems_OwnedItemId",
                        column: x => x.OwnedItemId,
                        principalTable: "OwnedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupWishedItem",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    WishedItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWishedItem", x => new { x.GroupsId, x.WishedItemsId });
                    table.ForeignKey(
                        name: "FK_GroupWishedItem_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupWishedItem_WishedItems_WishedItemsId",
                        column: x => x.WishedItemsId,
                        principalTable: "WishedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupWishedItems",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    WishedItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWishedItems", x => new { x.GroupId, x.WishedItemId });
                    table.ForeignKey(
                        name: "FK_GroupWishedItems_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupWishedItems_WishedItems_WishedItemId",
                        column: x => x.WishedItemId,
                        principalTable: "WishedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupOwnedItem_OwnedItemsId",
                table: "GroupOwnedItem",
                column: "OwnedItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOwnedItems_OwnedItemId",
                table: "GroupOwnedItems",
                column: "OwnedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProject_ProjectsId",
                table: "GroupProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWishedItem_WishedItemsId",
                table: "GroupWishedItem",
                column: "WishedItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWishedItems_WishedItemId",
                table: "GroupWishedItems",
                column: "WishedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedItems_ItemId",
                table: "OwnedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedItems_OwnerId",
                table: "OwnedItems",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishedItems_ItemId",
                table: "WishedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WishedItems_UserId",
                table: "WishedItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupOwnedItem");

            migrationBuilder.DropTable(
                name: "GroupOwnedItems");

            migrationBuilder.DropTable(
                name: "GroupProject");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "GroupWishedItem");

            migrationBuilder.DropTable(
                name: "GroupWishedItems");

            migrationBuilder.DropTable(
                name: "OwnedItems");

            migrationBuilder.DropTable(
                name: "WishedItems");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "GroupItems",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupItems", x => new { x.GroupId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_GroupItems_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupItems_ItemId",
                table: "GroupItems",
                column: "ItemId");
        }
    }
}

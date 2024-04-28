using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataBase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreAndItem_Items_Item_Id",
                table: "StoreAndItem");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreAndItem_Stores_Store_Id",
                table: "StoreAndItem");

            migrationBuilder.DropTable(
                name: "ItemStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreAndItem",
                table: "StoreAndItem");

            migrationBuilder.RenameTable(
                name: "StoreAndItem",
                newName: "StoresAndItems");

            migrationBuilder.RenameIndex(
                name: "IX_StoreAndItem_Store_Id",
                table: "StoresAndItems",
                newName: "IX_StoresAndItems_Store_Id");

            migrationBuilder.RenameIndex(
                name: "IX_StoreAndItem_Item_Id",
                table: "StoresAndItems",
                newName: "IX_StoresAndItems_Item_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoresAndItems",
                table: "StoresAndItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoresAndItems_Items_Item_Id",
                table: "StoresAndItems",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoresAndItems_Stores_Store_Id",
                table: "StoresAndItems",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoresAndItems_Items_Item_Id",
                table: "StoresAndItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StoresAndItems_Stores_Store_Id",
                table: "StoresAndItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoresAndItems",
                table: "StoresAndItems");

            migrationBuilder.RenameTable(
                name: "StoresAndItems",
                newName: "StoreAndItem");

            migrationBuilder.RenameIndex(
                name: "IX_StoresAndItems_Store_Id",
                table: "StoreAndItem",
                newName: "IX_StoreAndItem_Store_Id");

            migrationBuilder.RenameIndex(
                name: "IX_StoresAndItems_Item_Id",
                table: "StoreAndItem",
                newName: "IX_StoreAndItem_Item_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreAndItem",
                table: "StoreAndItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemStore",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStore", x => new { x.ItemsId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_ItemStore_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStore_Stores_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemStore_StoresId",
                table: "ItemStore",
                column: "StoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreAndItem_Items_Item_Id",
                table: "StoreAndItem",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreAndItem_Stores_Store_Id",
                table: "StoreAndItem",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

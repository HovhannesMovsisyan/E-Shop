using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class addDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsOnSale = table.Column<bool>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_Goods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCardItems",
                columns: table => new
                {
                    ShoppingCardItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCardId = table.Column<string>(nullable: true),
                    SportsGoodGoodsId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCardItems", x => x.ShoppingCardItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCardItems_Goods_SportsGoodGoodsId",
                        column: x => x.SportsGoodGoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, null, "Football" },
                    { 2, null, "Basketball" },
                    { 3, null, "Tennis" },
                    { 4, null, "Voleyball" },
                    { 5, null, "Boxing" }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "GoodsId", "CategoryId", "Description", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit", "\\Images\\thumbnails\\ball-small.png", "\\Images\\ball.png", false, true, "Ball for Football", 2.87m },
                    { 2, 1, "Venenatis tellus in metus vulputate eu scelerisque felis imperdiet proin. Quisque egestas diam in arcu cursus. Sed viverra tellus in hac. Quis commodo odio aenean sed adipiscing diam donec adipiscing.", "\\Images\\thumbnails\\gloves-small.png", "\\Images\\gloves.png", true, true, "Football Gloves", 3.95m },
                    { 3, 1, "Turpis egestas pretium aenean pharetra magna ac placerat vestibulum. Sed faucibus turpis in eu mi bibendum neque egestas. At in tellus integer feugiat scelerisque. Elementum integer enim neque volutpat ac tincidunt.", "\\Images\\thumbnails\\shoes-small.png", "\\Images\\shoes.png", true, false, "Football Shoes", 5.75m },
                    { 4, 2, "Vitae congue eu consequat ac felis donec et. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit. Vel eros donec ac odio. A lacus vestibulum sed arcu non odio euismod lacinia at. Nisl suscipit adipiscing bibendum est ultricies integer. Nec tincidunt praesent semper feugiat nibh.", "\\Images\\thumbnails\\basketball-small.png", "\\Images\\basketball.png", true, true, "Basketball Ball", 3.95m },
                    { 5, 2, "Purus sit amet luctus venenatis lectus magna fringilla. Consectetur lorem donec massa sapien faucibus et molestie ac. Sagittis nisl rhoncus mattis rhoncus urna neque viverra.", "\\Images\\thumbnails\\basketballshirt-small.png", "\\Images\\basketballshirt.png", true, false, "T-Shirt for Basketball", 7.00m },
                    { 6, 2, "Ultrices vitae auctor eu augue ut. Leo vel fringilla est ullamcorper eget. A diam maecenas sed enim ut. Massa tincidunt dui ut ornare lectus. Nullam non nisi est sit amet facilisis magna. ", "\\Images\\thumbnails\\basketballshoes-small.png", "\\Images\\basketballshoes.png", true, true, "Shoes for Basketball", 11.25m },
                    { 7, 3, "Diam sit amet nisl suscipit adipiscing bibendum est ultricies integer. Molestie at elementum eu facilisis sed odio morbi quis commodo. Odio facilisis mauris sit amet massa vitae tortor condimentum lacinia. Urna porttitor rhoncus dolor purus non enim praesent elementum facilisis.", "\\Images\\thumbnails\\tennisball-small.png", "\\Images\\tennisball.png", true, true, "Ball for Tennis", 3.95m },
                    { 8, 3, "Posuere ac ut consequat semper viverra nam libero justo laoreet. Ultrices dui sapien eget mi proin sed libero enim. Etiam non quam lacus suspendisse faucibus interdum. Amet nisl suscipit adipiscing bibendum est ultricies integer quis.", "\\Images\\thumbnails\\tennisdress-small.png", "\\Images\\tennisdress.png", true, false, "Dress for Tennis Players", 1.95m },
                    { 9, 3, "Ut ornare lectus sit amet est placerat in egestas. Iaculis nunc sed augue lacus viverra vitae. Bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida. Accumsan tortor posuere ac ut consequat semper viverra.", "\\Images\\thumbnails\\tennisraket-small.png", "\\Images\\tennisraket.png", true, true, "Rocket for Tennis Players", 13.95m },
                    { 10, 4, "Vitae congue eu consequat ac felis donec et odio. Tellus orci ac auctor augue mauris augue. Feugiat sed lectus vestibulum mattis ullamcorper velit sed. Sit amet consectetur adipiscing elit pellentesque habitant morbi tristique senectus. Sed pulvinar proin gravida hendrerit lectus a.", "\\Images\\thumbnails\\voleyballcanc-small.png", "\\Images\\voleyballcanc.png", true, true, "For Voleyball", 1.95m },
                    { 11, 4, "Hac habitasse platea dictumst quisque sagittis purus sit. Dui nunc mattis enim ut. Mauris commodo quis imperdiet massa tincidunt nunc pulvinar sapien et.", "\\Images\\thumbnails\\voleyballkneepad-small.png", "\\Images\\voleyballkneepad.png", true, true, "Kneepad For Voleyball", 12.95m },
                    { 12, 4, "Pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. Ultrices vitae auctor eu augue ut lectus arcu bibendum at. Vulputate eu scelerisque felis imperdiet proin fermentum.", "\\Images\\thumbnails\\voleyball-small.png", "\\Images\\voleyball.png", true, true, "Ball For Voleyball", 21.95m },
                    { 13, 5, "Vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa. Arcu cursus euismod quis viverra.", "\\Images\\thumbnails\\boxgloves-small.png", "\\Images\\boxgloves.png", true, false, "Boxing Gloves", 6.95m },
                    { 14, 5, "Blandit massa enim nec dui nunc mattis enim ut tellus. Duis at consectetur lorem donec massa sapien faucibus et. At auctor urna nunc id cursus metus. Ut enim blandit volutpat maecenas volutpat blandit.", "\\Images\\thumbnails\\boxinghelmet-small.png", "\\Images\\boxinghelmet.png", true, true, "Helmet For Boxing", 2.95m },
                    { 15, 5, "Nisi lacus sed viverra tellus in. Morbi non arcu risus quis varius quam quisque id. Cras adipiscing enim eu turpis egestas. Tristique nulla aliquet enim tortor. Quisque id diam vel quam. Id faucibus nisl tincidunt eget nullam.", "\\Images\\thumbnails\\boxingshorts-small.png", "\\Images\\boxingshorts.png", true, false, "Boxing Shorts", 16.95m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCardItems_SportsGoodGoodsId",
                table: "ShoppingCardItems",
                column: "SportsGoodGoodsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCardItems");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

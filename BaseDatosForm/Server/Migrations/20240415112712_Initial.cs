using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatosForm.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Square Cubes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Triangular Cubes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Special Cubes" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The Rubik's Cube is a three-dimensional mechanical puzzle created by Hungarian sculptor and architecture professor Ernő Rubik in 1974.", 9.99m, "Classic Rubik's Cube" },
                    { 2, 2, "The Pyraminx is a mechanical puzzle shaped like a tetrahedron similar to a Rubik's cube. It was invented by Uwe Meffert in 1970.", 7.99m, "Pyraminx" },
                    { 3, 3, "The Skewb is a three-dimensional mechanical puzzle like a Rubik's cube, made up of pieces that can rotate and change position.", 9.99m, "Skewb" },
                    { 4, 3, "The Megaminx, or \"Magic Dodecahedron\", was invented by several people simultaneously and produced by different manufacturing companies with slightly different designs.\r\nThe Megaminx has the shape of a dodecahedron, it has 12 central pieces, one on each face; 20 corners and 30 edges.", 20.99m, "Megaminx" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

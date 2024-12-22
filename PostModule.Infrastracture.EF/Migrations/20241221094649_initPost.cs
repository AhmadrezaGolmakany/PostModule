using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostModule.Infrastracture.EF.Migrations
{
    /// <inheritdoc />
    public partial class initPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TehranPricePlus = table.Column<int>(type: "int", nullable: false),
                    StateCenterPricePlus = table.Column<int>(type: "int", nullable: false),
                    CityPricePlus = table.Column<int>(type: "int", nullable: false),
                    InsideStatePricePlus = table.Column<int>(type: "int", nullable: false),
                    StateClosePricePlus = table.Column<int>(type: "int", nullable: false),
                    StateNonClosePricePlus = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    InsideCity = table.Column<bool>(type: "bit", nullable: false),
                    OutSideCity = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    TehranPrice = table.Column<int>(type: "int", nullable: false),
                    StateCenterPrice = table.Column<int>(type: "int", nullable: false),
                    CityPrice = table.Column<int>(type: "int", nullable: false),
                    InsideStatePrice = table.Column<int>(type: "int", nullable: false),
                    StateClosePrice = table.Column<int>(type: "int", nullable: false),
                    StateNonClosePrice = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPrices_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostPrices_PostId",
                table: "PostPrices",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostPrices");

            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}

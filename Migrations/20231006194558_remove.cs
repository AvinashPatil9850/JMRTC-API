using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace msrtc_api.Migrations
{
    /// <inheritdoc />
    public partial class remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDaysModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekDaysModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusID = table.Column<int>(type: "int", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDaysModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeekDaysModel_Bussess_BusID",
                        column: x => x.BusID,
                        principalTable: "Bussess",
                        principalColumn: "BusID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekDaysModel_BusID",
                table: "WeekDaysModel",
                column: "BusID");
        }
    }
}

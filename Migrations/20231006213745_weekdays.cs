using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace msrtc_api.Migrations
{
    /// <inheritdoc />
    public partial class weekdays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusID = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeekDays_Bussess_BusID",
                        column: x => x.BusID,
                        principalTable: "Bussess",
                        principalColumn: "BusID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_BusID",
                table: "WeekDays",
                column: "BusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDays");
        }
    }
}

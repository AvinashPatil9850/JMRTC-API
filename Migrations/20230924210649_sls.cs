using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace msrtc_api.Migrations
{
    /// <inheritdoc />
    public partial class sls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bussess",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusDepo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bussess", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "DestinationModal",
                columns: table => new
                {
                    DepoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusDepo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationModal", x => x.DepoID);
                });

            migrationBuilder.CreateTable(
                name: "StopsListModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusDepo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopsListModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusStopsModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusID = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BussessModelBusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStopsModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusStopsModel_Bussess_BussessModelBusID",
                        column: x => x.BussessModelBusID,
                        principalTable: "Bussess",
                        principalColumn: "BusID");
                });

            migrationBuilder.CreateTable(
                name: "WeekDaysModel",
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
                    table.PrimaryKey("PK_WeekDaysModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeekDaysModel_Bussess_BusID",
                        column: x => x.BusID,
                        principalTable: "Bussess",
                        principalColumn: "BusID");
                });

            migrationBuilder.CreateTable(
                name: "DestinationArr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepoID = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationArr", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DestinationArr_DestinationModal_DepoID",
                        column: x => x.DepoID,
                        principalTable: "DestinationModal",
                        principalColumn: "DepoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StopDetail",
                columns: table => new
                {
                    StopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: true),
                    StopName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopDetail", x => x.StopID);
                    table.ForeignKey(
                        name: "FK_StopDetail_StopsListModel_ID",
                        column: x => x.ID,
                        principalTable: "StopsListModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusStopsModel_BussessModelBusID",
                table: "BusStopsModel",
                column: "BussessModelBusID");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationArr_DepoID",
                table: "DestinationArr",
                column: "DepoID");

            migrationBuilder.CreateIndex(
                name: "IX_StopDetail_ID",
                table: "StopDetail",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDaysModel_BusID",
                table: "WeekDaysModel",
                column: "BusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusStopsModel");

            migrationBuilder.DropTable(
                name: "DestinationArr");

            migrationBuilder.DropTable(
                name: "StopDetail");

            migrationBuilder.DropTable(
                name: "WeekDaysModel");

            migrationBuilder.DropTable(
                name: "DestinationModal");

            migrationBuilder.DropTable(
                name: "StopsListModel");

            migrationBuilder.DropTable(
                name: "Bussess");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace msrtc_api.Migrations
{
    /// <inheritdoc />
    public partial class sequesnce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StopDetail_StopsListModel_ID",
                table: "StopDetail");

            migrationBuilder.DropIndex(
                name: "IX_StopDetail_ID",
                table: "StopDetail");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "StopDetail");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StopsListModel",
                newName: "RouteID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DestinationArr",
                newName: "DestinationID");

            migrationBuilder.AddColumn<int>(
                name: "RouteID",
                table: "StopDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StopDetail_RouteID",
                table: "StopDetail",
                column: "RouteID");

            migrationBuilder.AddForeignKey(
                name: "FK_StopDetail_StopsListModel_RouteID",
                table: "StopDetail",
                column: "RouteID",
                principalTable: "StopsListModel",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StopDetail_StopsListModel_RouteID",
                table: "StopDetail");

            migrationBuilder.DropIndex(
                name: "IX_StopDetail_RouteID",
                table: "StopDetail");

            migrationBuilder.DropColumn(
                name: "RouteID",
                table: "StopDetail");

            migrationBuilder.RenameColumn(
                name: "RouteID",
                table: "StopsListModel",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "DestinationArr",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "StopDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StopDetail_ID",
                table: "StopDetail",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StopDetail_StopsListModel_ID",
                table: "StopDetail",
                column: "ID",
                principalTable: "StopsListModel",
                principalColumn: "ID");
        }
    }
}

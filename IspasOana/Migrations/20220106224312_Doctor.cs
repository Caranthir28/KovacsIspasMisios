using Microsoft.EntityFrameworkCore.Migrations;

namespace MedsWebApp.Migrations
{
    public partial class Doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointment",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Appointment");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleApp.Data.Migrations
{
    public partial class update_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassroomName",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "Lessons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Lessons");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomName",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

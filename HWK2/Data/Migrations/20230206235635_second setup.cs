using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HWK2.Data.Migrations
{
    public partial class secondsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "avg",
                table: "steps",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avg",
                table: "steps");
        }
    }
}

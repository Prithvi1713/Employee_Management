using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Management.Migrations
{
    /// <inheritdoc />
    public partial class DesignationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "designationMaster",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DesignationName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designationMaster", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_designationMaster_departmentMasters_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departmentMasters",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_designationMaster_DepartmentId",
                table: "designationMaster",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "designationMaster");
        }
    }
}

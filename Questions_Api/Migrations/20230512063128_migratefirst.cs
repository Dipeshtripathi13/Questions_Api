using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questions_Api.Migrations
{
    /// <inheritdoc />
    public partial class migratefirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}

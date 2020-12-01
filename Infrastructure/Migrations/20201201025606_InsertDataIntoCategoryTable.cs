using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InsertDataIntoCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values('Eletronics', 'https://eletronics.xpto')");
            migrationBuilder.Sql("Insert into Category(Name, ImageUrl) Values('Courses', 'https://courses.xpto')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Category");
        }
    }
}

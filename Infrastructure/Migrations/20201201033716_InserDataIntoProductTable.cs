using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InserDataIntoProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Product(Name, Description, Price, Stock, DateRegister, CategoryId) Values('Computer', 'ComputerGamer', 4.500, 50, getdate(), (Select CategoryId from Category Where Name='Eletronics'))");
            migrationBuilder.Sql("Insert into Product(Name, Description, Price, Stock, DateRegister, CategoryId) Values('.NETCORE', 'WEBAPI', 40.50, 50, getdate(), (Select CategoryId from Category Where Name='Courses'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Product");
        }
    }
}

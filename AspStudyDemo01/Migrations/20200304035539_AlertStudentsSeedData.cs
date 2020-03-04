using Microsoft.EntityFrameworkCore.Migrations;

namespace AspStudyDemo01.Migrations
{
    public partial class AlertStudentsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassName", "Email", "Name" },
                values: new object[] { 2, 3, "zhubajie@qq.com", "猪八戒" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

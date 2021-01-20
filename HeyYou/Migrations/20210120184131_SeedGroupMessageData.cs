using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyYou.Migrations
{
    public partial class SeedGroupMessageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupMessage",
                columns: new[] { "GroupMessageId", "GroupId", "MessageId" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "GroupMessage",
                columns: new[] { "GroupMessageId", "GroupId", "MessageId" },
                values: new object[] { 2, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupMessage",
                keyColumn: "GroupMessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroupMessage",
                keyColumn: "GroupMessageId",
                keyValue: 2);
        }
    }
}

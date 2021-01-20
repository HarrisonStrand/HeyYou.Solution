using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyYou.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupDescription", "GroupName" },
                values: new object[,]
                {
                    { 1, "Best I can do is 600", "Pawn Stars" },
                    { 2, "Life isn't all diamonds and rose, but it should be.", "Real Housewives" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "MessageAuthor", "MessageBody", "MessageDate", "MessageTitle" },
                values: new object[,]
                {
                    { 1, "Chuck Palahniuk", "The first rule of fight club is you don't talk about fight club", new DateTime(2020, 5, 1, 8, 30, 53, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { 2, "William S Burroughs", "Drugs", new DateTime(2020, 5, 1, 8, 30, 53, 0, DateTimeKind.Unspecified), "Naked Lunch" },
                    { 3, "Janet Fitch", "prisons and mommy issues", new DateTime(2020, 5, 1, 8, 30, 53, 0, DateTimeKind.Unspecified), "White Oleander" },
                    { 4, "Hemingway", "seas", new DateTime(2020, 5, 1, 8, 30, 53, 0, DateTimeKind.Unspecified), "oldmen" },
                    { 5, "H.P. Lovecraft", "lets get weird", new DateTime(2020, 5, 1, 8, 30, 53, 0, DateTimeKind.Unspecified), "lets get dark" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5);
        }
    }
}

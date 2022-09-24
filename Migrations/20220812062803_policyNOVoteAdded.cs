using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVoting.Migrations
{
    public partial class policyNOVoteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyNoVote",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyNoVote",
                table: "Policies");
        }
    }
}

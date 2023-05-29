using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFinal2.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_User_UserId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_realestate_realestateId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_User_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_realestate_realestateId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_realestate_realestateId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_realestate_Owner_ownerId",
                table: "realestate");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_User_UserId",
                table: "Bill",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_realestate_realestateId",
                table: "Bill",
                column: "realestateId",
                principalTable: "realestate",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_User_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_realestate_realestateId",
                table: "Feedback",
                column: "realestateId",
                principalTable: "realestate",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_realestate_realestateId",
                table: "Images",
                column: "realestateId",
                principalTable: "realestate",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_realestate_Owner_ownerId",
                table: "realestate",
                column: "ownerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_User_UserId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_realestate_realestateId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_User_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_realestate_realestateId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_realestate_realestateId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_realestate_Owner_ownerId",
                table: "realestate");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_User_UserId",
                table: "Bill",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_realestate_realestateId",
                table: "Bill",
                column: "realestateId",
                principalTable: "realestate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_User_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_realestate_realestateId",
                table: "Feedback",
                column: "realestateId",
                principalTable: "realestate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_realestate_realestateId",
                table: "Images",
                column: "realestateId",
                principalTable: "realestate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_realestate_Owner_ownerId",
                table: "realestate",
                column: "ownerId",
                principalTable: "Owner",
                principalColumn: "Id");
        }
    }
}

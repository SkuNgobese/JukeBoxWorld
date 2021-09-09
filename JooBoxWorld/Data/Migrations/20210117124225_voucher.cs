using Microsoft.EntityFrameworkCore.Migrations;

namespace JooBoxWorld.Data.Migrations
{
    public partial class voucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_FieldManagers_FieldManagerId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_AspNetUsers_Id",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Agent_AgentId",
                table: "Vouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_FieldManagers_FieldManagerId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_AgentId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_FieldManagerId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "FieldManagerId",
                table: "Vouchers");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "Agents");

            migrationBuilder.RenameIndex(
                name: "IX_Agent_FieldManagerId",
                table: "Agents",
                newName: "IX_Agents_FieldManagerId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Vouchers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_ApplicationUserId",
                table: "Vouchers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_FieldManagers_FieldManagerId",
                table: "Agents",
                column: "FieldManagerId",
                principalTable: "FieldManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_Id",
                table: "Agents",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_AspNetUsers_ApplicationUserId",
                table: "Vouchers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_FieldManagers_FieldManagerId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_Id",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_AspNetUsers_ApplicationUserId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_ApplicationUserId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Vouchers");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "Agent");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_FieldManagerId",
                table: "Agent",
                newName: "IX_Agent_FieldManagerId");

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "Vouchers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldManagerId",
                table: "Vouchers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_AgentId",
                table: "Vouchers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_FieldManagerId",
                table: "Vouchers",
                column: "FieldManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_FieldManagers_FieldManagerId",
                table: "Agent",
                column: "FieldManagerId",
                principalTable: "FieldManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_AspNetUsers_Id",
                table: "Agent",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Agent_AgentId",
                table: "Vouchers",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_FieldManagers_FieldManagerId",
                table: "Vouchers",
                column: "FieldManagerId",
                principalTable: "FieldManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

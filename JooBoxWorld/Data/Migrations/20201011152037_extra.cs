using Microsoft.EntityFrameworkCore.Migrations;

namespace JooBoxWorld.Data.Migrations
{
    public partial class extra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_FieldManager_FieldManagerId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_AspNetUsers_Id",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldManager_AspNetUsers_Id",
                table: "FieldManager");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Agent_AgentId",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_FieldManager_FieldManagerId",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldManager",
                table: "FieldManager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Voucher",
                newName: "Vouchers");

            migrationBuilder.RenameTable(
                name: "FieldManager",
                newName: "FieldManagers");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Voucher_FieldManagerId",
                table: "Vouchers",
                newName: "IX_Vouchers_FieldManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Voucher_AgentId",
                table: "Vouchers",
                newName: "IX_Vouchers_AgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldManagers",
                table: "FieldManagers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_Id",
                table: "Addresses",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_FieldManagers_FieldManagerId",
                table: "Agent",
                column: "FieldManagerId",
                principalTable: "FieldManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_Id",
                table: "Contacts",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldManagers_AspNetUsers_Id",
                table: "FieldManagers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_Id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_FieldManagers_FieldManagerId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_Id",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldManagers_AspNetUsers_Id",
                table: "FieldManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Agent_AgentId",
                table: "Vouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_FieldManagers_FieldManagerId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldManagers",
                table: "FieldManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "Voucher");

            migrationBuilder.RenameTable(
                name: "FieldManagers",
                newName: "FieldManager");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_FieldManagerId",
                table: "Voucher",
                newName: "IX_Voucher_FieldManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_AgentId",
                table: "Voucher",
                newName: "IX_Voucher_AgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldManager",
                table: "FieldManager",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_Id",
                table: "Address",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_FieldManager_FieldManagerId",
                table: "Agent",
                column: "FieldManagerId",
                principalTable: "FieldManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_AspNetUsers_Id",
                table: "Contact",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldManager_AspNetUsers_Id",
                table: "FieldManager",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Agent_AgentId",
                table: "Voucher",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_FieldManager_FieldManagerId",
                table: "Voucher",
                column: "FieldManagerId",
                principalTable: "FieldManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

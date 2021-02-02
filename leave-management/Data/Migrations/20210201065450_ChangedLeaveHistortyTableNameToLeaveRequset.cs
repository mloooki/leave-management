using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class ChangedLeaveHistortyTableNameToLeaveRequset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_ApprovedById",
                table: "LeaveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistories_LeaveTypes_LeaveTypeId",
                table: "LeaveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_RequestingEmployeeId",
                table: "LeaveHistories");

            migrationBuilder.DropTable(
                name: "DetailsLeaveTypeVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveHistories",
                table: "LeaveHistories");

            migrationBuilder.RenameTable(
                name: "LeaveHistories",
                newName: "LeaveRequest");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistories_RequestingEmployeeId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_RequestingEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistories_LeaveTypeId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistories_ApprovedById",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_ApprovedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedById",
                table: "LeaveRequest",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_LeaveTypes_LeaveTypeId",
                table: "LeaveRequest",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_RequestingEmployeeId",
                table: "LeaveRequest",
                column: "RequestingEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedById",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_LeaveTypes_LeaveTypeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_RequestingEmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest");

            migrationBuilder.RenameTable(
                name: "LeaveRequest",
                newName: "LeaveHistories");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_RequestingEmployeeId",
                table: "LeaveHistories",
                newName: "IX_LeaveHistories_RequestingEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_LeaveTypeId",
                table: "LeaveHistories",
                newName: "IX_LeaveHistories_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_ApprovedById",
                table: "LeaveHistories",
                newName: "IX_LeaveHistories_ApprovedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveHistories",
                table: "LeaveHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DetailsLeaveTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsLeaveTypeVM", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_ApprovedById",
                table: "LeaveHistories",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistories_LeaveTypes_LeaveTypeId",
                table: "LeaveHistories",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_RequestingEmployeeId",
                table: "LeaveHistories",
                column: "RequestingEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

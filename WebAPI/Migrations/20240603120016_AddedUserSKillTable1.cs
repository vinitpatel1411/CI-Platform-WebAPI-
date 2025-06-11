using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class AddedUserSKillTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER_SKILL",
                columns: table => new
                {
                    USER_SKILL_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKILL_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SKILL", x => x.USER_SKILL_ID);
                    table.ForeignKey(
                        name: "FK__USER_S__MISSI__693CA210",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__USER_S__SKILL__6A30C649",
                        column: x => x.SKILL_ID,
                        principalTable: "SKILL",
                        principalColumn: "SKILL_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_SKILL_SKILL_ID",
                table: "USER_SKILL",
                column: "SKILL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SKILL_USER_ID",
                table: "USER_SKILL",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_SKILL");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class IntialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    ADMIN_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LAST_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.ADMIN_ID);
                });

            migrationBuilder.CreateTable(
                name: "BANNER",
                columns: table => new
                {
                    BANNER_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGE = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    TEXT = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    SORT_ORDER = table.Column<int>(type: "int", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNER", x => x.BANNER_ID);
                });

            migrationBuilder.CreateTable(
                name: "CMS_PAGE",
                columns: table => new
                {
                    CMS_PAGE_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    SLUG = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS_PAGE", x => x.CMS_PAGE_ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ISO = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.COUNTRY_ID);
                });

            migrationBuilder.CreateTable(
                name: "MISSION_THEME",
                columns: table => new
                {
                    MISSION_THEME_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MISSION_THEME", x => x.MISSION_THEME_ID);
                });

            migrationBuilder.CreateTable(
                name: "SKILL",
                columns: table => new
                {
                    SKILL_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKILL_NAME = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKILL", x => x.SKILL_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PHONENUMBER = table.Column<long>(type: "bigint", nullable: false),
                    AVATAR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WHYIVOLUNTEER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMPLOYEEID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DEPARTMENT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CITYID = table.Column<int>(type: "int", nullable: true),
                    COUNTRYID = table.Column<int>(type: "int", nullable: true),
                    PROFILETEXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LINKEDINURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETEDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    ROLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    CITY_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUNTRY_ID = table.Column<long>(type: "bigint", nullable: false),
                    NAME = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.CITY_ID);
                    table.ForeignKey(
                        name: "FK__CITY__COUNTRY_ID__5812160E",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRY",
                        principalColumn: "COUNTRY_ID");
                });

            migrationBuilder.CreateTable(
                name: "ResetPassword",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ResetPass__UserI__4BAC3F29",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MISSION",
                columns: table => new
                {
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THEME_ID = table.Column<long>(type: "bigint", nullable: false),
                    CITY_ID = table.Column<long>(type: "bigint", nullable: false),
                    COUNTRY_ID = table.Column<long>(type: "bigint", nullable: false),
                    TITLE = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    SHORT_DESCRIPTION = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    MISSION_TYPE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    ORGANIZATION_NAME = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AVAILABILITY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MISSION", x => x.MISSION_ID);
                    table.ForeignKey(
                        name: "FK__MISSION__CITY_ID__6477ECF3",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "CITY_ID");
                    table.ForeignKey(
                        name: "FK__MISSION__COUNTRY__656C112C",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRY",
                        principalColumn: "COUNTRY_ID");
                    table.ForeignKey(
                        name: "FK__MISSION__THEME_I__6383C8BA",
                        column: x => x.THEME_ID,
                        principalTable: "MISSION_THEME",
                        principalColumn: "MISSION_THEME_ID");
                });

            migrationBuilder.CreateTable(
                name: "COMMENT",
                columns: table => new
                {
                    COMMENT_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: true),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: true),
                    APPROVAL_STATUS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMMENT_MESSAGE = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENT", x => x.COMMENT_ID);
                    table.ForeignKey(
                        name: "FK__COMMENT__MISSION__0D7A0286",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                    table.ForeignKey(
                        name: "FK__COMMENT__USER_ID__0E6E26BF",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FAVOURITE_MISSION",
                columns: table => new
                {
                    FAVOURITE_MISSION_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVOURITE_MISSION", x => x.FAVOURITE_MISSION_ID);
                    table.ForeignKey(
                        name: "FK__FAVOURITE__MISSI__08B54D69",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                    table.ForeignKey(
                        name: "FK__FAVOURITE__USER___09A971A2",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GOAL_MISSION",
                columns: table => new
                {
                    GOAL_MISSION_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false),
                    GOAL_OBJECTIVE_TEXT = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    GOAL_VALUE = table.Column<int>(type: "int", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOAL_MISSION", x => x.GOAL_MISSION_ID);
                    table.ForeignKey(
                        name: "FK__GOAL_MISS__MISSI__00200768",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                });

            migrationBuilder.CreateTable(
                name: "MISSION_APPLICATION",
                columns: table => new
                {
                    MISSION_APPLICATION_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    APPLIED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    APPROVAL_STATUS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MISSION_APPLICATION", x => x.MISSION_APPLICATION_ID);
                    table.ForeignKey(
                        name: "FK__MISSION_A__MISSI__7B5B524B",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                    table.ForeignKey(
                        name: "FK__MISSION_A__USER___7C4F7684",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MISSION_MEDIA",
                columns: table => new
                {
                    MISSION_MEDIA_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false),
                    MEDIA_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MEDIA_TYPE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MEDIA_PATH = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MISSION___E70AA8B7FA9E09E3", x => x.MISSION_MEDIA_ID);
                    table.ForeignKey(
                        name: "FK__MISSION_M__MISSI__72C60C4A",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                });

            migrationBuilder.CreateTable(
                name: "MISSION_RATING",
                columns: table => new
                {
                    MISSION_RATING_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false),
                    RATING = table.Column<int>(type: "int", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MISSION_RATING", x => x.MISSION_RATING_ID);
                    table.ForeignKey(
                        name: "FK__MISSION_R__MISSI__6E01572D",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                    table.ForeignKey(
                        name: "FK__MISSION_R__USER___6EF57B66",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MISSION_SKILL",
                columns: table => new
                {
                    MISSION_SKILL_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKILL_ID = table.Column<long>(type: "bigint", nullable: false),
                    MISSION_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DELETED_AT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MISSION_SKILL", x => x.MISSION_SKILL_ID);
                    table.ForeignKey(
                        name: "FK__MISSION_S__MISSI__693CA210",
                        column: x => x.MISSION_ID,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                    table.ForeignKey(
                        name: "FK__MISSION_S__SKILL__6A30C649",
                        column: x => x.SKILL_ID,
                        principalTable: "SKILL",
                        principalColumn: "SKILL_ID");
                });

            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    StoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MissionId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_Story_Mission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "MISSION",
                        principalColumn: "MISSION_ID");
                    table.ForeignKey(
                        name: "FK_Story_User_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StoryInvite",
                columns: table => new
                {
                    StoryInviteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<long>(type: "bigint", nullable: false),
                    FromUserId = table.Column<long>(type: "bigint", nullable: false),
                    ToUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryInvite", x => x.StoryInviteId);
                    table.ForeignKey(
                        name: "FK_StoryInvite_Story_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Story",
                        principalColumn: "StoryId");
                });

            migrationBuilder.CreateTable(
                name: "StoryMedia",
                columns: table => new
                {
                    StoryMediaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryMedia", x => x.StoryMediaId);
                    table.ForeignKey(
                        name: "FK_StoryMedia_Story_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Story",
                        principalColumn: "StoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CITY_COUNTRY_ID",
                table: "CITY",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_MISSION_ID",
                table: "COMMENT",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_USER_ID",
                table: "COMMENT",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVOURITE_MISSION_MISSION_ID",
                table: "FAVOURITE_MISSION",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVOURITE_MISSION_USER_ID",
                table: "FAVOURITE_MISSION",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GOAL_MISSION_MISSION_ID",
                table: "GOAL_MISSION",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_CITY_ID",
                table: "MISSION",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_COUNTRY_ID",
                table: "MISSION",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_THEME_ID",
                table: "MISSION",
                column: "THEME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_APPLICATION_MISSION_ID",
                table: "MISSION_APPLICATION",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_APPLICATION_USER_ID",
                table: "MISSION_APPLICATION",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_MEDIA_MISSION_ID",
                table: "MISSION_MEDIA",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_RATING_MISSION_ID",
                table: "MISSION_RATING",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_RATING_USER_ID",
                table: "MISSION_RATING",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_SKILL_MISSION_ID",
                table: "MISSION_SKILL",
                column: "MISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MISSION_SKILL_SKILL_ID",
                table: "MISSION_SKILL",
                column: "SKILL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPassword_UserId",
                table: "ResetPassword",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Story_MissionId",
                table: "Story",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Story_UserId",
                table: "Story",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryInvite_StoryId",
                table: "StoryInvite",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryMedia_StoryId",
                table: "StoryMedia",
                column: "StoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "BANNER");

            migrationBuilder.DropTable(
                name: "CMS_PAGE");

            migrationBuilder.DropTable(
                name: "COMMENT");

            migrationBuilder.DropTable(
                name: "FAVOURITE_MISSION");

            migrationBuilder.DropTable(
                name: "GOAL_MISSION");

            migrationBuilder.DropTable(
                name: "MISSION_APPLICATION");

            migrationBuilder.DropTable(
                name: "MISSION_MEDIA");

            migrationBuilder.DropTable(
                name: "MISSION_RATING");

            migrationBuilder.DropTable(
                name: "MISSION_SKILL");

            migrationBuilder.DropTable(
                name: "ResetPassword");

            migrationBuilder.DropTable(
                name: "StoryInvite");

            migrationBuilder.DropTable(
                name: "StoryMedia");

            migrationBuilder.DropTable(
                name: "SKILL");

            migrationBuilder.DropTable(
                name: "Story");

            migrationBuilder.DropTable(
                name: "MISSION");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "MISSION_THEME");

            migrationBuilder.DropTable(
                name: "COUNTRY");
        }
    }
}

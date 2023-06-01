using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourismo.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false),
                    MinimalPrice = table.Column<double>(type: "double", nullable: false),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Phone = table.Column<string>(type: "longtext", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DateRange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TravelId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateRange_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    TravelId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arrangements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TravelerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TravelId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PeriodId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    ArrangementStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrangements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrangements_DateRange_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "DateRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arrangements_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arrangements_Users_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Location_Address = table.Column<string>(type: "longtext", nullable: false),
                    Location_Latitude = table.Column<double>(type: "double", nullable: false),
                    Location_Longitude = table.Column<double>(type: "double", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ArrangementId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SectionId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Arrangements_ArrangementId",
                        column: x => x.ArrangementId,
                        principalTable: "Arrangements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accommodations_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TouristAttractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Location_Address = table.Column<string>(type: "longtext", nullable: false),
                    Location_Latitude = table.Column<double>(type: "double", nullable: false),
                    Location_Longitude = table.Column<double>(type: "double", nullable: false),
                    ArrangementId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SectionId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SectionId1 = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristAttractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristAttractions_Arrangements_ArrangementId",
                        column: x => x.ArrangementId,
                        principalTable: "Arrangements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TouristAttractions_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TouristAttractions_Sections_SectionId1",
                        column: x => x.SectionId1,
                        principalTable: "Sections",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_ArrangementId",
                table: "Accommodations",
                column: "ArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_SectionId",
                table: "Accommodations",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrangements_PeriodId",
                table: "Arrangements",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrangements_TravelerId",
                table: "Arrangements",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrangements_TravelId",
                table: "Arrangements",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_DateRange_TravelId",
                table: "DateRange",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TravelId",
                table: "Sections",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristAttractions_ArrangementId",
                table: "TouristAttractions",
                column: "ArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristAttractions_SectionId",
                table: "TouristAttractions",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristAttractions_SectionId1",
                table: "TouristAttractions",
                column: "SectionId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "TouristAttractions");

            migrationBuilder.DropTable(
                name: "Arrangements");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "DateRange");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Travels");
        }
    }
}

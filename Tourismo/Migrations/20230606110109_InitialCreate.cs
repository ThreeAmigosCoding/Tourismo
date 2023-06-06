using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourismo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Location_Address = table.Column<string>(type: "longtext", nullable: false),
                    Location_Latitude = table.Column<double>(type: "double", nullable: false),
                    Location_Longitude = table.Column<double>(type: "double", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristAttractions", x => x.Id);
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
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    AccommodationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false),
                    MinimalPrice = table.Column<double>(type: "double", nullable: false),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditionalAttractionTravels",
                columns: table => new
                {
                    AdditionalAttractionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TravelId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAttractionTravels", x => new { x.AdditionalAttractionId, x.TravelId });
                    table.ForeignKey(
                        name: "FK_AdditionalAttractionTravels_TouristAttractions_AdditionalAtt~",
                        column: x => x.AdditionalAttractionId,
                        principalTable: "TouristAttractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalAttractionTravels_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "DefaultAttractionTravels",
                columns: table => new
                {
                    DefaultAttractionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TravelId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAttractionTravels", x => new { x.DefaultAttractionId, x.TravelId });
                    table.ForeignKey(
                        name: "FK_DefaultAttractionTravels_TouristAttractions_DefaultAttractio~",
                        column: x => x.DefaultAttractionId,
                        principalTable: "TouristAttractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultAttractionTravels_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AdditionalAttractionArrangements",
                columns: table => new
                {
                    AdditionalAttractionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ArrangementId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAttractionArrangements", x => new { x.AdditionalAttractionId, x.ArrangementId });
                    table.ForeignKey(
                        name: "FK_AdditionalAttractionArrangements_Arrangements_ArrangementId",
                        column: x => x.ArrangementId,
                        principalTable: "Arrangements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalAttractionArrangements_TouristAttractions_Addition~",
                        column: x => x.AdditionalAttractionId,
                        principalTable: "TouristAttractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAttractionArrangements_ArrangementId",
                table: "AdditionalAttractionArrangements",
                column: "ArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAttractionTravels_TravelId",
                table: "AdditionalAttractionTravels",
                column: "TravelId");

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
                name: "IX_DefaultAttractionTravels_TravelId",
                table: "DefaultAttractionTravels",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_AccommodationId",
                table: "Travels",
                column: "AccommodationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalAttractionArrangements");

            migrationBuilder.DropTable(
                name: "AdditionalAttractionTravels");

            migrationBuilder.DropTable(
                name: "DefaultAttractionTravels");

            migrationBuilder.DropTable(
                name: "Arrangements");

            migrationBuilder.DropTable(
                name: "TouristAttractions");

            migrationBuilder.DropTable(
                name: "DateRange");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Accommodations");
        }
    }
}

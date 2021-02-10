using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventPlusLTD.Data.Migrations
{
    public partial class PreScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActType",
                columns: table => new
                {
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActType", x => x.Genre);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentType",
                columns: table => new
                {
                    EquipmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentType", x => x.EquipmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerInformation",
                columns: table => new
                {
                    OrganizerInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ContactNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerInformation", x => x.OrganizerInfoID);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerRole",
                columns: table => new
                {
                    OrganizerRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerRole", x => x.OrganizerRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    PerformersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    ActTypeGenre = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.PerformersID);
                    table.ForeignKey(
                        name: "FK_Performers_ActType_ActTypeGenre",
                        column: x => x.ActTypeGenre,
                        principalTable: "ActType",
                        principalColumn: "Genre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeID = table.Column<int>(type: "int", nullable: false),
                    Equipment_Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentID);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentType_EquipmentTypeID",
                        column: x => x.EquipmentTypeID,
                        principalTable: "EquipmentType",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLocation",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Location_Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocation", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_EventLocation_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    PerformanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    PerformanceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSlotStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.PerformanceID);
                    table.ForeignKey(
                        name: "FK_Performance_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerRoleID = table.Column<int>(type: "int", nullable: false),
                    OrganizerInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.OrganizerID);
                    table.ForeignKey(
                        name: "FK_Organizer_OrganizerInformation_OrganizerInfoID",
                        column: x => x.OrganizerInfoID,
                        principalTable: "OrganizerInformation",
                        principalColumn: "OrganizerInfoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizer_OrganizerRole_OrganizerRoleID",
                        column: x => x.OrganizerRoleID,
                        principalTable: "OrganizerRole",
                        principalColumn: "OrganizerRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsNeeded",
                columns: table => new
                {
                    AssetsNeededID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    EquipmentID = table.Column<int>(type: "int", nullable: false),
                    EstimatedCosts = table.Column<decimal>(type: "Money", nullable: false),
                    ActualCosts = table.Column<decimal>(type: "Money", nullable: false),
                    AmountNeeded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsNeeded", x => x.AssetsNeededID);
                    table.ForeignKey(
                        name: "FK_AssetsNeeded_Equipment_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsNeeded_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "PerformanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    PerformersID = table.Column<int>(type: "int", nullable: false),
                    TimeSlotStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedCosts = table.Column<decimal>(type: "Money", nullable: false),
                    ActualCosts = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantID);
                    table.ForeignKey(
                        name: "FK_Participants_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "PerformanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Performers_PerformersID",
                        column: x => x.PerformersID,
                        principalTable: "Performers",
                        principalColumn: "PerformersID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizersOccupied",
                columns: table => new
                {
                    OrganizersOccupiedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    OrganizerID = table.Column<int>(type: "int", nullable: false),
                    TimeSlotStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizersOccupied", x => x.OrganizersOccupiedID);
                    table.ForeignKey(
                        name: "FK_OrganizersOccupied_Organizer_OrganizerID",
                        column: x => x.OrganizerID,
                        principalTable: "Organizer",
                        principalColumn: "OrganizerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizersOccupied_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "PerformanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetsNeeded_EquipmentID",
                table: "AssetsNeeded",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsNeeded_PerformanceID",
                table: "AssetsNeeded",
                column: "PerformanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EventID",
                table: "Customer",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeID",
                table: "Equipment",
                column: "EquipmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLocation_EventID",
                table: "EventLocation",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_OrganizerInfoID",
                table: "Organizer",
                column: "OrganizerInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_OrganizerRoleID",
                table: "Organizer",
                column: "OrganizerRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizersOccupied_OrganizerID",
                table: "OrganizersOccupied",
                column: "OrganizerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizersOccupied_PerformanceID",
                table: "OrganizersOccupied",
                column: "PerformanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PerformanceID",
                table: "Participants",
                column: "PerformanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PerformersID",
                table: "Participants",
                column: "PerformersID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_EventID",
                table: "Performance",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_ActTypeGenre",
                table: "Performers",
                column: "ActTypeGenre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetsNeeded");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "EventLocation");

            migrationBuilder.DropTable(
                name: "OrganizersOccupied");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Organizer");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "OrganizerInformation");

            migrationBuilder.DropTable(
                name: "OrganizerRole");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ActType");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class PreScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActType",
                columns: table => new
                {
                    ActTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActType", x => x.ActTypeID);
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
                name: "OrganizerInformation",
                columns: table => new
                {
                    OrganizerInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                name: "TypeOfEvent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfEvent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    ActTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformerID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ActTypeID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.ActTypeID);
                    table.ForeignKey(
                        name: "FK_Performers_ActType_ActTypeID1",
                        column: x => x.ActTypeID1,
                        principalTable: "ActType",
                        principalColumn: "ActTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentID = table.Column<int>(type: "int", nullable: false),
                    Equipment_Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    EquipmentTypeID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentTypeID);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentType_EquipmentTypeID1",
                        column: x => x.EquipmentTypeID1,
                        principalTable: "EquipmentType",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    OrganizerInfoID = table.Column<int>(type: "int", nullable: false),
                    OrganizerRoleID = table.Column<int>(type: "int", nullable: false),
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => new { x.OrganizerInfoID, x.OrganizerRoleID });
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
                name: "Event",
                columns: table => new
                {
                    TypeOfEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    Event_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Event_Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfEventID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.TypeOfEventID);
                    table.ForeignKey(
                        name: "FK_Event_TypeOfEvent_TypeOfEventID1",
                        column: x => x.TypeOfEventID1,
                        principalTable: "TypeOfEvent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    EventsTypeOfEventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Customer_Event_EventsTypeOfEventID",
                        column: x => x.EventsTypeOfEventID,
                        principalTable: "Event",
                        principalColumn: "TypeOfEventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLocation",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventLocationID = table.Column<int>(type: "int", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Location_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventsTypeOfEventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocation", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_EventLocation_Event_EventsTypeOfEventID",
                        column: x => x.EventsTypeOfEventID,
                        principalTable: "Event",
                        principalColumn: "TypeOfEventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    Performance_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Performance_Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventsTypeOfEventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Performance_Event_EventsTypeOfEventID",
                        column: x => x.EventsTypeOfEventID,
                        principalTable: "Event",
                        principalColumn: "TypeOfEventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsNeeded",
                columns: table => new
                {
                    EquipmentID = table.Column<int>(type: "int", nullable: false),
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    AN_ID = table.Column<int>(type: "int", nullable: false),
                    Estimated_Costs = table.Column<decimal>(type: "Money", nullable: false),
                    Actual_Costs = table.Column<decimal>(type: "Money", nullable: true),
                    Amount_Needed = table.Column<int>(type: "int", nullable: false),
                    EquipmentsEquipmentTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsNeeded", x => new { x.PerformanceID, x.EquipmentID });
                    table.ForeignKey(
                        name: "FK_AssetsNeeded_Equipment_EquipmentsEquipmentTypeID",
                        column: x => x.EquipmentsEquipmentTypeID,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsNeeded_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizersOccupied",
                columns: table => new
                {
                    OrganizerID = table.Column<int>(type: "int", nullable: false),
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    OrganizersOccupiedID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizersOrganizerInfoID = table.Column<int>(type: "int", nullable: false),
                    OrganizersOrganizerRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizersOccupied", x => new { x.OrganizerID, x.PerformanceID });
                    table.ForeignKey(
                        name: "FK_OrganizersOccupied_Organizer_OrganizersOrganizerInfoID_OrganizersOrganizerRoleID",
                        columns: x => new { x.OrganizersOrganizerInfoID, x.OrganizersOrganizerRoleID },
                        principalTable: "Organizer",
                        principalColumns: new[] { "OrganizerInfoID", "OrganizerRoleID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizersOccupied_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    PerformanceID = table.Column<int>(type: "int", nullable: false),
                    PerformerID = table.Column<int>(type: "int", nullable: false),
                    ParticipantID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estimated_Costs = table.Column<decimal>(type: "Money", nullable: false),
                    Actual_Costs = table.Column<decimal>(type: "Money", nullable: true),
                    PerformersActTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => new { x.PerformanceID, x.PerformerID });
                    table.ForeignKey(
                        name: "FK_Participants_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Performers_PerformersActTypeID",
                        column: x => x.PerformersActTypeID,
                        principalTable: "Performers",
                        principalColumn: "ActTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetsNeeded_EquipmentsEquipmentTypeID",
                table: "AssetsNeeded",
                column: "EquipmentsEquipmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EventsTypeOfEventID",
                table: "Customer",
                column: "EventsTypeOfEventID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeID1",
                table: "Equipment",
                column: "EquipmentTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TypeOfEventID1",
                table: "Event",
                column: "TypeOfEventID1");

            migrationBuilder.CreateIndex(
                name: "IX_EventLocation_EventsTypeOfEventID",
                table: "EventLocation",
                column: "EventsTypeOfEventID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_OrganizerRoleID",
                table: "Organizer",
                column: "OrganizerRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizersOccupied_OrganizersOrganizerInfoID_OrganizersOrganizerRoleID",
                table: "OrganizersOccupied",
                columns: new[] { "OrganizersOrganizerInfoID", "OrganizersOrganizerRoleID" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizersOccupied_PerformanceID",
                table: "OrganizersOccupied",
                column: "PerformanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PerformersActTypeID",
                table: "Participants",
                column: "PerformersActTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_EventsTypeOfEventID",
                table: "Performance",
                column: "EventsTypeOfEventID");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_ActTypeID1",
                table: "Performers",
                column: "ActTypeID1");
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

            migrationBuilder.DropTable(
                name: "TypeOfEvent");
        }
    }
}

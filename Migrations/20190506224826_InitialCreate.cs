using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jabil_test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    PKBuilding = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Building = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.PKBuilding);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PKCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customer = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Prefix = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    FKBuilding = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PKCustomer);
                    table.ForeignKey(
                        name: "FK_Customers_Buildings",
                        column: x => x.FKBuilding,
                        principalTable: "Buildings",
                        principalColumn: "PKBuilding",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartNumbers",
                columns: table => new
                {
                    PKPartNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FKCustomer = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartNumbers", x => x.PKPartNumber);
                    table.ForeignKey(
                        name: "FK_PartNumbers_Customers",
                        column: x => x.FKCustomer,
                        principalTable: "Customers",
                        principalColumn: "PKCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "PKBuilding", "Available", "Building" },
                values: new object[] { 1, true, "Building1" });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "PKBuilding", "Available", "Building" },
                values: new object[] { 2, true, "Building2" });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "PKBuilding", "Available", "Building" },
                values: new object[] { 3, false, "Building3" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "PKCustomer", "Available", "FKBuilding", "Customer", "Prefix" },
                values: new object[] { 1, true, 1, "Luis", "cust1" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "PKCustomer", "Available", "FKBuilding", "Customer", "Prefix" },
                values: new object[] { 2, true, 2, "Pedro", "cust2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "PKCustomer", "Available", "FKBuilding", "Customer", "Prefix" },
                values: new object[] { 3, false, 2, "Juan", "cust3" });

            migrationBuilder.InsertData(
                table: "PartNumbers",
                columns: new[] { "PKPartNumber", "Available", "FKCustomer", "PartNumber" },
                values: new object[] { 1, true, 1, "P1231" });

            migrationBuilder.InsertData(
                table: "PartNumbers",
                columns: new[] { "PKPartNumber", "Available", "FKCustomer", "PartNumber" },
                values: new object[] { 2, true, 2, "P5322" });

            migrationBuilder.InsertData(
                table: "PartNumbers",
                columns: new[] { "PKPartNumber", "Available", "FKCustomer", "PartNumber" },
                values: new object[] { 3, false, 2, "P5232" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FKBuilding",
                table: "Customers",
                column: "FKBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_PartNumbers_FKCustomer",
                table: "PartNumbers",
                column: "FKCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartNumbers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}

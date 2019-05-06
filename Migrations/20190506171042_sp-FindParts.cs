using Microsoft.EntityFrameworkCore.Migrations;

namespace jabil_test.Migrations
{
    public partial class spFindParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
            CREATE PROCEDURE [dbo].[FindParts]
                @PKPartNumber INT = NULL,
                @PartNumber VARCHAR(50) = NULL,
                @PKCustomer INT = NULL,
                @Customer VARCHAR(100) = NULL,
                @Available BIT = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT
                        P.PKPartNumber AS Id,
                        P.PKPartNumber, P.PartNumber, P.Available,
                        C.PKCustomer, C.Customer,
                        B.PKBuilding, B.Building
                    FROM PartNumbers P
                    JOIN Customers C on P.FKCustomer = C.PKCustomer
                    JOIN Buildings B on C.FKBuilding = B.PKBuilding
                    WHERE (@Available IS NULL OR P.Available = @Available)
                        AND (
                            (@PKCustomer IS NOT NULL AND C.PKCustomer = @PKCustomer)
                            OR (@Customer IS NOT NULL AND C.Customer LIKE '%' + @Customer + '%')
                            OR (@PKPartNumber IS NOT NULL AND P.PKPartNumber = @PKPartNumber)
                            OR (@PartNumber IS NOT NULL AND P.PartNumber LIKE '%' + @PartNumber + '%')
                            OR (
                                @PKPartNumber IS NULL
                                AND @PartNumber IS NULL
                                AND @PKCustomer IS NULL
                                AND @Customer IS NULL
                            )
                        );
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[FindParts];");
        }
    }
}

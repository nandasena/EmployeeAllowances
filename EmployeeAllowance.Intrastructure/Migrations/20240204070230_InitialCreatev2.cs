using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAllowance.Intrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

			migrationBuilder.CreateTable(
				name: "EmployeeAllowances",
				columns: table => new
				{
					EmployeeID = table.Column<double>(type: "float", nullable: false),
					DepartmentID = table.Column<double>(type: "float", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: true),
					Amount = table.Column<double>(type: "float", nullable: true),
					Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EmployeeAllowances", x => x.EmployeeID);
				});


			var sp = @"CREATE OR ALTER PROCEDURE [ManageEmployeeAllowancesData] 
					(
						@EmployeeID AS INT,
						@DepartmentID AS INT,
						@Date AS DATETIME = NULL,
						@Amount AS INT = NULL,
						@Status AS VARCHAR(50)
	
					) AS
					BEGIN
    

						IF NOT EXISTS(SELECT 'X' FROM [dbo].[EmployeeAllowances] WHERE EmployeeID = @EmployeeID )
						BEGIN
							INSERT INTO 
								[dbo].[EmployeeAllowances] 
								(
									[EmployeeID]
									,[DepartmentID]
									,[Date]
									,[Amount]
									,[Status]
										)
							VALUES
								(
									@EmployeeID
									,@DepartmentID
									,@Date
									,@Amount
									,@Status

								)
						END
						ELSE
						BEGIN
							UPDATE 	[dbo].[EmployeeAllowances] 
							SET
									[DepartmentID] = @DepartmentID
									,[Date] = @Date
									,[Amount] = @Amount
									,[Status] = @Status
							WHERE 
								[EmployeeID] = @EmployeeID
						END
					END

					GO ";

            migrationBuilder.Sql(sp);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAllowances");
        }
    }
}

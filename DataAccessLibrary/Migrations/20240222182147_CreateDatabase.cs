using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLibrary.Migrations
{
	public partial class CreateDatabase : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			_ = migrationBuilder.CreateTable(
				name: "Employers",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CompanyName = table.Column<string>(maxLength: 200, nullable: false)
				},
				constraints: table => table.PrimaryKey("PK_Employers", x => x.Id));

			_ = migrationBuilder.CreateTable(
				name: "People",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(maxLength: 50, nullable: false),
					LastName = table.Column<string>(maxLength: 50, nullable: false),
					IsActive = table.Column<bool>(nullable: true),
					EmployerId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					_ = table.PrimaryKey("PK_People", x => x.Id);
					_ = table.ForeignKey(
						name: "FK_People_Employers_EmployerId",
						column: x => x.EmployerId,
						principalTable: "Employers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			_ = migrationBuilder.CreateTable(
				name: "Addresses",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StreetAddress = table.Column<string>(maxLength: 200, nullable: false),
					City = table.Column<string>(maxLength: 50, nullable: false),
					State = table.Column<string>(maxLength: 10, nullable: false),
					ZipCode = table.Column<string>(maxLength: 10, nullable: false),
					EmployerId = table.Column<int>(nullable: true),
					PersonId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					_ = table.PrimaryKey("PK_Addresses", x => x.Id);
					_ = table.ForeignKey(
						name: "FK_Addresses_Employers_EmployerId",
						column: x => x.EmployerId,
						principalTable: "Employers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					_ = table.ForeignKey(
						name: "FK_Addresses_People_PersonId",
						column: x => x.PersonId,
						principalTable: "People",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			_ = migrationBuilder.CreateIndex(
				name: "IX_Addresses_EmployerId",
				table: "Addresses",
				column: "EmployerId");

			_ = migrationBuilder.CreateIndex(
				name: "IX_Addresses_PersonId",
				table: "Addresses",
				column: "PersonId");

			_ = migrationBuilder.CreateIndex(
				name: "IX_People_EmployerId",
				table: "People",
				column: "EmployerId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			_ = migrationBuilder.DropTable(
				name: "Addresses");

			_ = migrationBuilder.DropTable(
				name: "People");

			_ = migrationBuilder.DropTable(
				name: "Employers");
		}
	}
}

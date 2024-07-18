using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class skdksdka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Hospitals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Hospitals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "HospitalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "HospitalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "HospitalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "HospitalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "HospitalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "HospitalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "BranchName",
                value: "Urology");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "BranchName",
                value: "Gynecology and Obstetrics");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "BranchName",
                value: "Brain surgery");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "BranchName",
                value: "Psychiatry");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "BranchName",
                value: "Internal Medicine Specialist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "BranchName",
                value: "ENT Diseases Specialist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "BranchName",
                value: "Child Health and Diseases Specialist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "BranchName",
                value: "Eye Health and Diseases Specialist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "BranchName",
                value: "Clinical Psychologist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "BranchName",
                value: "Child Health and Diseases Specialist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "BranchName",
                value: "Anesthesia and Reanimation");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "BranchName",
                value: "Child Health and Diseases");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "BranchName",
                value: "Nutrition and Diet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "BranchName",
                value: "Urologist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "BranchName",
                value: "Gastroenterology");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "BranchName",
                value: "Eye Diseases");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "BranchName",
                value: "Urologist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "BranchName",
                value: "Boys Urologist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "BranchName",
                value: "Urologist");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "BranchName",
                value: "Ear Nose Throat Diseases");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "BranchName",
                value: "General Surgery");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "BranchName",
                value: "Eye Health and Diseases");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "BranchName",
                value: "Emergency room");

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "centralPass", "centralAdmin" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "deltaPass", "deltaAdmin" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Username" },
                values: new object[] { "ibniPass", "ibniAdmin" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Username" },
                values: new object[] { "onkolojiPass", "onkolojiAdmin" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Username" },
                values: new object[] { "ersoyPass", "ersoyAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "BranchName",
                value: "Urolog");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "BranchName",
                value: "Kadin Hastaliklari ve Dogum");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "BranchName",
                value: "Beyin Cerrahisi");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "BranchName",
                value: "Psikiyatri");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "BranchName",
                value: "Iç Hastaliklari Uzmani");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "BranchName",
                value: "KBB Hastaliklari Uzmani");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "BranchName",
                value: "Cocuk Sagligi Ve Hastaliklari Uzmani");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                column: "BranchName",
                value: "Goz Sagligi ve Hastaliklari Uzmani");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                column: "BranchName",
                value: "Klinik Psikolog");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "BranchName",
                value: "Cocuk Sagligi ve Hastaliklari Uzmani");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "BranchName",
                value: "Anestezi ve Reanimasyon");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "BranchName",
                value: "Cocuk Sagligi ve Hastaliklari");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "BranchName",
                value: "Beslenme ve Diyet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15,
                column: "BranchName",
                value: "Urolog");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16,
                column: "BranchName",
                value: "Gastroenteroloji");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                column: "BranchName",
                value: "Goz Hastaliklari");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "BranchName",
                value: "Urolog");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "BranchName",
                value: "Boys Urolog");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "BranchName",
                value: "Urolog");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                column: "BranchName",
                value: "Kulak Burun Bogaz Hastaliklar");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                column: "BranchName",
                value: "Genel Cerrahi");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                column: "BranchName",
                value: "Goz Sagligi ve Hastaliklari");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 25,
                column: "BranchName",
                value: "Acil Servis");
        }
    }
}

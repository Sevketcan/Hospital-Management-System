using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_Management_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TcNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrescriptionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Usage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Password", "UserName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin123", "admin1" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Adress", "CreatedDate", "IsDeleted", "Mail", "Name", "Password", "PhoneNumber", "Surname", "TcNumber", "Username" },
                values: new object[,]
                {
                    { 1, "Main Street 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "jane.smith1@example.com", "Jane", "password1", "987654321", "Smith", "12345678901", "janesmith1" },
                    { 2, "Main Street 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "john.doe@example.com", "John", "password2", "987654322", "Doe", "12345678902", "johndoe" },
                    { 3, "Main Street 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "alice.johnson@example.com", "Alice", "password3", "987654323", "Johnson", "12345678903", "alicejohnson" },
                    { 4, "Main Street 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "bob.brown@example.com", "Bob", "password4", "987654324", "Brown", "12345678904", "bobbrown" },
                    { 5, "Main Street 6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "charlie.davis@example.com", "Charlie", "password5", "987654325", "Davis", "12345678905", "charliedavis" },
                    { 6, "Main Street 7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "david.wilson@example.com", "David", "password6", "987654326", "Wilson", "12345678906", "davidwilson" },
                    { 7, "Main Street 8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "emma.moore@example.com", "Emma", "password7", "987654327", "Moore", "12345678907", "emmamoore" },
                    { 8, "Main Street 9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "frank.taylor@example.com", "Frank", "password8", "987654328", "Taylor", "12345678908", "franktaylor" },
                    { 9, "Main Street 10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "grace.anderson@example.com", "Grace", "password9", "987654329", "Anderson", "12345678909", "graceanderson" },
                    { 10, "Main Street 11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "henry.thomas@example.com", "Henry", "password10", "987654330", "Thomas", "12345678910", "henrythomas" },
                    { 11, "Main Street 12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ivy.jackson@example.com", "Ivy", "password11", "987654331", "Jackson", "12345678911", "ivyjackson" },
                    { 12, "Main Street 13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "jack.white@example.com", "Jack", "password12", "987654332", "White", "12345678912", "jackwhite" },
                    { 13, "Main Street 14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "kathy.harris@example.com", "Kathy", "password13", "987654333", "Harris", "12345678913", "kathyharris" },
                    { 14, "Main Street 15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "liam.martin@example.com", "Liam", "password14", "987654334", "Martin", "12345678914", "liammartin" },
                    { 15, "Main Street 16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "mia.lee@example.com", "Mia", "password15", "987654335", "Lee", "12345678915", "mialee" },
                    { 16, "Main Street 17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "nathan.clark@example.com", "Nathan", "password16", "987654336", "Clark", "12345678916", "nathanclark" },
                    { 17, "Main Street 18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "olivia.robinson@example.com", "Olivia", "password17", "987654337", "Robinson", "12345678917", "oliviarobinson" },
                    { 18, "Main Street 19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "paul.lewis@example.com", "Paul", "password18", "987654338", "Lewis", "12345678918", "paullewis" },
                    { 19, "Main Street 20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "quinn.walker@example.com", "Quinn", "password19", "987654339", "Walker", "12345678919", "quinnwalker" },
                    { 20, "Main Street 21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "rachel.hall@example.com", "Rachel", "password20", "987654340", "Hall", "12345678920", "rachelhall" },
                    { 21, "Main Street 22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "steve.young@example.com", "Steve", "password21", "987654341", "Young", "12345678921", "steveyoung" },
                    { 22, "Main Street 23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "tina.king@example.com", "Tina", "password22", "987654342", "King", "12345678922", "tinaking" },
                    { 23, "Main Street 24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ursula.scott@example.com", "Ursula", "password23", "987654343", "Scott", "12345678923", "ursulascott" },
                    { 24, "Main Street 25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "victor.adams@example.com", "Victor", "password24", "987654344", "Adams", "12345678924", "victoradams" },
                    { 25, "Main Street 26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "wendy.evans@example.com", "Wendy", "password25", "987654345", "Evans", "12345678925", "wendyevans" },
                    { 26, "Main Street 27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "xavier.baker@example.com", "Xavier", "password26", "987654346", "Baker", "12345678926", "xavierbaker" },
                    { 27, "Main Street 28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "yara.parker@example.com", "Yara", "password27", "987654347", "Parker", "12345678927", "yaraparker" },
                    { 28, "Main Street 29", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "zach.cook@example.com", "Zach", "password28", "987654348", "Cook", "12345678928", "zachcook" },
                    { 29, "Main Street 30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "adam.reed@example.com", "Adam", "password29", "987654349", "Reed", "12345678929", "adamreed" },
                    { 30, "Main Street 31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "bella.wright@example.com", "Bella", "password30", "987654350", "Wright", "12345678930", "bellawright" },
                    { 31, "Main Street 32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "chris.green@example.com", "Chris", "password31", "987654351", "Green", "12345678931", "chrisgreen" },
                    { 32, "Main Street 33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "diana.hill@example.com", "Diana", "password32", "987654352", "Hill", "12345678932", "dianahill" },
                    { 33, "Main Street 34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ethan.scott@example.com", "Ethan", "password33", "987654353", "Scott", "12345678933", "ethanscott" },
                    { 34, "Main Street 35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "fiona.morris@example.com", "Fiona", "password34", "987654354", "Morris", "12345678934", "fionamorris" },
                    { 35, "Main Street 36", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "george.cooper@example.com", "George", "password35", "987654355", "Cooper", "12345678935", "georgecooper" },
                    { 36, "Main Street 37", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "hannah.nelson@example.com", "Hannah", "password36", "987654356", "Nelson", "12345678936", "hannahnelson" },
                    { 37, "Main Street 38", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ian.mitchell@example.com", "Ian", "password37", "987654357", "Mitchell", "12345678937", "ianmitchell" },
                    { 38, "Main Street 39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "jenna.perez@example.com", "Jenna", "password38", "987654358", "Perez", "12345678938", "jennaperez" },
                    { 39, "Main Street 40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "kyle.roberts@example.com", "Kyle", "password39", "987654359", "Roberts", "12345678939", "kyleroberts" },
                    { 40, "Main Street 41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "laura.phillips@example.com", "Laura", "password40", "987654360", "Phillips", "12345678940", "lauraphillips" },
                    { 41, "Main Street 42", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "mark.campbell@example.com", "Mark", "password41", "987654361", "Campbell", "12345678941", "markcampbell" },
                    { 42, "Main Street 43", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "nina.parker@example.com", "Nina", "password42", "987654362", "Parker", "12345678942", "ninaparker" },
                    { 43, "Main Street 44", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "oscar.bennett@example.com", "Oscar", "password43", "987654363", "Bennett", "12345678943", "oscarbennett" },
                    { 44, "Main Street 45", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "paula.carter@example.com", "Paula", "password44", "987654364", "Carter", "12345678944", "paulacarter" },
                    { 45, "Main Street 46", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "quincy.morgan@example.com", "Quincy", "password45", "987654365", "Morgan", "12345678945", "quincymorgan" },
                    { 46, "Main Street 47", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "rebecca.reed@example.com", "Rebecca", "password46", "987654366", "Reed", "12345678946", "rebeccareed" },
                    { 47, "Main Street 48", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "samuel.ward@example.com", "Samuel", "password47", "987654367", "Ward", "12345678947", "samuelward" },
                    { 48, "Main Street 49", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "tara.james@example.com", "Tara", "password48", "987654368", "James", "12345678948", "tarajames" },
                    { 49, "Main Street 50", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "uma.henderson@example.com", "Uma", "password49", "987654369", "Henderson", "12345678949", "umahenderson" },
                    { 50, "Main Street 51", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "violet.brooks@example.com", "Violet", "password50", "987654370", "Brooks", "12345678950", "violetbrooks" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "AdminId", "Adress", "CreatedDate", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Kozyatağı, Kocayol Cd. No:19, 34742 Kadıköy/Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Central Hospital", "0216 4447799" },
                    { 2, 1, "İdealtepe, Akgüvercin Sk. No:4, 34841 Maltepe/Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delta Hospital", "02163889999" },
                    { 3, 1, "Küçükyalı, Merkez Mh, Talat Bey Sok. No:28/B, 34840 Maltepe/Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ibni Sina Hospital", "02165180900" },
                    { 4, 1, "Cevizli, Talatpaşa Cd No:75, 34846 Maltepe/Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Istanbul Onkoloji Hospital", "02164573737" },
                    { 5, 1, "Altayçeşme, Varna Sk. No:16, 34843 Maltepe/Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Maltepe Ersoy Hospital", "085081186007" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "BranchName", "HospitalId", "Name", "Password", "PhoneNumber", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, "Urolog", 1, "Sevket Can", "kalyancisevket", "123456789", "Kalyancioglu", "onlysevk" },
                    { 2, "Cardiology", 1, "John", "password", "123456789", "Doe", "johndoe" },
                    { 3, "Kadin Hastaliklari ve Dogum", 1, "Esmer", "hasanesmr", "456123789", "HASANOVA", "smerhasan" },
                    { 4, "Beyin Cerrahisi", 1, "Sinem", "rivakkayariv", "127834569", "AKAY", "aksikinem" },
                    { 5, "Psikiyatri", 1, "Faruk", "faruk3131", "561278349", "TUFEKCI", "hellokityfaruk" },
                    { 6, "Iç Hastaliklari Uzmani", 2, "Museyip", "muss03169", "527613849", "HAKKO", "museyipp" },
                    { 7, "KBB Hastaliklari Uzmani", 2, "Osman", "613127", "561382749", "Ozkeles", "usmankeles" },
                    { 8, "Cocuk Sagligi Ve Hastaliklari Uzmani", 2, "Cezmi", "8521613", "527496138", "Tuncer", "tuncercezmi" },
                    { 9, "Goz Sagligi ve Hastaliklari Uzmani", 2, "Zerrin", "631271", "561749382", "Goksin", "gokzerrin" },
                    { 10, "Klinik Psikolog", 2, "Leyla", "131267", "527461389", "Sonmez", "sonmezreis" },
                    { 11, "Cocuk Sagligi ve Hastaliklari Uzmani", 3, "Denizmen", "131267", "527461389", "Aygün", "sonmezreis" },
                    { 12, "Anestezi ve Reanimasyon", 3, "Altay", "112367", "574612389", "Iskender", "sikender" },
                    { 13, "Cocuk Sagligi ve Hastaliklari", 3, "Alaattin", "167312", "523874619", "Ersoy", "ersoyyy" },
                    { 14, "Beslenme ve Diyet", 3, "Aleyna", "213167", "538274619", "Ergul", "ergulaleyna" },
                    { 15, "Urolog", 3, "Ali", "261317", "513827469", "Kadayifci", "alikadayifci" },
                    { 16, "Gastroenteroloji", 4, "Emre", "261731", "518274369", "YILDIRIM", "emreyildirim" },
                    { 17, "Goz Hastaliklari", 4, "Abdullah", "231617", "582137469", "OZKAYA", "abdullahockaya" },
                    { 18, "Urolog", 4, "Abdulmuttalip", "276131", "382751469", "SIMSEK", "abulsimsek" },
                    { 19, "Boys Urolog", 4, "Abdurrahman", "261371", "274695138", "ONEN", "onenabd" },
                    { 20, "Patology", 4, "Furkan", "616161", "5316678637", "Keles", "kelesfurkan" },
                    { 21, "Urolog", 5, "Mete Oguz", "271361", "138274659", "Ekinci", "meteoguz" },
                    { 22, "Kulak Burun Bogaz Hastaliklar", 5, "Ekrem", "26117", "513898927469", "Aytac", "ekerrmm" },
                    { 23, "Genel Cerrahi", 5, "Ozer", "456875", "51386527469", "Celik", "ozercelik" },
                    { 24, "Goz Sagligi ve Hastaliklari", 5, "Bahri", "26178317", "51382437469", "Muftuoglu", "bahri" },
                    { 25, "Acil Servis", 5, "Mehmet", "26212341317", "51382712469", "Beyli", "memetbeyli" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreatedDate", "DateTime", "DoctorId", "IsDeleted", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, false, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), 4, false, 4 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, false, 5 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 6, false, 6 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, false, 7 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, false, 8 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), 9, false, 9 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 10, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "IsDeleted", "MedicationName", "PatientId", "PrescriptionDate", "Usage" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Aspirin", 1, new DateOnly(2023, 1, 1), "Twice a day" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Ibuprofen", 2, new DateOnly(2023, 2, 15), "Once a day" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Paracetamol", 3, new DateOnly(2023, 3, 10), "Three times a day" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "Metformin", 4, new DateOnly(2023, 4, 5), "Twice a day" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, "Amoxicillin", 5, new DateOnly(2023, 5, 20), "Once a day" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, "Atorvastatin", 6, new DateOnly(2023, 6, 25), "Once a day" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, false, "Lisinopril", 7, new DateOnly(2023, 7, 30), "Twice a day" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, false, "Levothyroxine", 8, new DateOnly(2023, 8, 12), "Once a day" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, false, "Omeprazole", 9, new DateOnly(2023, 9, 18), "Once a day" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false, "Simvastatin", 10, new DateOnly(2023, 10, 22), "Twice a day" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalId",
                table: "Doctors",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}

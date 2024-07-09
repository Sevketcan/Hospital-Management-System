using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class asdksd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Password", "Surname" },
                values: new object[] { "Sevket Can", "kalyancisevket", "Kalyancioglu" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "BranchName",
                value: "Kadin Hastaliklari ve Dogum");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Surname",
                value: "TUFEKCI");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BranchName", "Name", "Password" },
                values: new object[] { "Iç Hastaliklari Uzmani", "Museyip", "muss03169" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "KBB Hastaliklari Uzmani", "Ozkeles" });

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
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Goz Sagligi ve Hastaliklari Uzmani", "Goksin" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Surname", "Username" },
                values: new object[] { "Sonmez", "sonmezreis" });

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
                column: "Surname",
                value: "Iskender");

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
                column: "Surname",
                value: "Ergul");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Goz Hastaliklari", "OZKAYA" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Surname",
                value: "SIMSEK");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Surname",
                value: "ONEN");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Surname",
                value: "Keles");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Mete Oguz");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Kulak Burun Bogaz Hastaliklar", "Aytac" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Ozer", "Celik" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Goz Sagligi ve Hastaliklari", "Muftuoglu" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Adress",
                value: "Kozyatağı, Kocayol Cd. No:19, 34742 Kadıköy/Istanbul");

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Adress",
                value: "İdealtepe, Akgüvercin Sk. No:4, 34841 Maltepe/Istanbul");

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Adress", "Name" },
                values: new object[] { "Küçükyalı, Merkez Mh, Talat Bey Sok. No:28/B, 34840 Maltepe/Istanbul", "Ibni Sina Hospital" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Adress", "Name" },
                values: new object[] { "Cevizli, Talatpaşa Cd No:75, 34846 Maltepe/Istanbul", "Istanbul Onkoloji Hospital" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5,
                column: "Adress",
                value: "Altayçeşme, Varna Sk. No:16, 34843 Maltepe/Istanbul");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Password", "Surname" },
                values: new object[] { "ŞevketCan", "kalyancısevket", "Kalyancıoğlu" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "BranchName",
                value: "Kadın Hastalıkları ve Doğum");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Surname",
                value: "TÜFEKÇİ");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BranchName", "Name", "Password" },
                values: new object[] { "İç Hastalıkları Uzmanı", "Müseyip", "müsso3169" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "KBB Hastalıkları Uzmanı", "Özkeleş" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "BranchName",
                value: "Çocuk Sağlığı Ve Hastalıkları Uzmanı");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Göz Sağlığı ve Hastalıkları Uzmanı", "Gökşin" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Surname", "Username" },
                values: new object[] { "Sönmez", "sönmezreis" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "BranchName",
                value: "Çocuk Sağlığı ve Hastalıkları Uzmanı");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Surname",
                value: "İskender");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13,
                column: "BranchName",
                value: "Çocuk Sağlığı ve Hastalıkları");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Surname",
                value: "Ergül");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Göz Hastalıkları", "ÖZKAYA" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 18,
                column: "Surname",
                value: "ŞİMŞEK");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 19,
                column: "Surname",
                value: "ÖNEN");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 20,
                column: "Surname",
                value: "Keleş");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Mete Oğuz");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Kulak Burun Boğaz Hastalıklar", "Aytaç" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Özer", "Çelik" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BranchName", "Surname" },
                values: new object[] { "Göz Sağlığı ve Hastalıkları", "Müftüoğlu" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Adress",
                value: "Kozyatağı, Kocayol Cd. No:19, 34742 Kadıköy/İstanbul");

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Adress",
                value: "İdealtepe, Akgüvercin Sk. No:4, 34841 Maltepe/İstanbul");

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Adress", "Name" },
                values: new object[] { "Küçükyalı, Merkez Mh, Talat Bey Sok. No:28/B, 34840 Maltepe/İstanbul", "İbni Sina  Hospital" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Adress", "Name" },
                values: new object[] { "Cevizli, Talatpaşa Cd No:75, 34846 Maltepe/İstanbull", "İstanbul Onkoloji Hospital" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5,
                column: "Adress",
                value: "Altayçeşme, Varna Sk. No:16, 34843 Maltepe/İstanbul");

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "AdminId", "Adress", "CreatedDate", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[] { 6, 1, "Küçükbakkalköy, Vedat Günyol Cd. No:28-30, 34750 Ataşehir/İstanbull", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Memorial Ataşehir Hospital", "02165706666" });
        }
    }
}

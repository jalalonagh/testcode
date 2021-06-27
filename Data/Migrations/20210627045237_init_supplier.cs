using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init_supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateDs",
                table: "ChairToUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValue: "1400/04/06",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "1400/04/05");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDm",
                table: "ChairToUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 27, 9, 22, 36, 834, DateTimeKind.Local).AddTicks(2041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 26, 17, 30, 55, 553, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    AccountingSystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLat = table.Column<double>(type: "float", nullable: false),
                    LocationLng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutDoorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InDoorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionX = table.Column<int>(type: "int", nullable: false),
                    DimensionY = table.Column<int>(type: "int", nullable: false),
                    DimensionZ = table.Column<int>(type: "int", nullable: false),
                    CapacityCBM = table.Column<double>(type: "float", nullable: false),
                    MaximumCapacityCBM = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActiveToSale = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierBarecodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Barecode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierBarecodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierBarecodes_SupplierStores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "SupplierStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierStoreActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    TargetProfileId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierStoreActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierStoreActivities_SupplierStores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "SupplierStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierSupplyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDoneTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalPackingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalDelayTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PackingStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackingFinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierSupplyRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierSupplyRequests_SupplierStores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "SupplierStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierBarecodes_StoreId",
                table: "SupplierBarecodes",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierStoreActivities_StoreId",
                table: "SupplierStoreActivities",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierSupplyRequests_StoreId",
                table: "SupplierSupplyRequests",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "SupplierBarecodes");

            migrationBuilder.DropTable(
                name: "SupplierStoreActivities");

            migrationBuilder.DropTable(
                name: "SupplierSupplyRequests");

            migrationBuilder.DropTable(
                name: "SupplierStores");

            migrationBuilder.AlterColumn<string>(
                name: "DateDs",
                table: "ChairToUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValue: "1400/04/05",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "1400/04/06");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDm",
                table: "ChairToUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 26, 17, 30, 55, 553, DateTimeKind.Local).AddTicks(4350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 27, 9, 22, 36, 834, DateTimeKind.Local).AddTicks(2041));
        }
    }
}

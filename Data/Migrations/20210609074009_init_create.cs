using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TRANSACTION");

            migrationBuilder.EnsureSchema(
                name: "PROFILE");

            migrationBuilder.EnsureSchema(
                name: "SMS");

            migrationBuilder.EnsureSchema(
                name: "USER");

            migrationBuilder.CreateTable(
                name: "BaseEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_BaseEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SalcustSi = table.Column<int>(type: "int", nullable: true),
                    SalcustCu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalcustTp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NikName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidCodeExpired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPerson = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AccountingUserReferenceId = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatePersianTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chairs_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                schema: "PROFILE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberTypes_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                schema: "SMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: true),
                    financialAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMS",
                schema: "SMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    smsText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMS_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSRegexes",
                schema: "SMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    regex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSRegexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSRegexes_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuspendedUsers",
                schema: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberConfirmated = table.Column<bool>(type: "bit", nullable: false),
                    ValidCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidCodeExpired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspendedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuspendedUsers_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "PROFILE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    TelePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearBirthDate = table.Column<int>(type: "int", nullable: true),
                    MonthBirthDate = table.Column<int>(type: "int", nullable: true),
                    DayBirthDate = table.Column<int>(type: "int", nullable: true),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProfileTypeId = table.Column<int>(type: "int", nullable: true, defaultValue: 3),
                    BankCarNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingSystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtensionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChairToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChairId = table.Column<int>(type: "int", nullable: false),
                    DateDm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 6, 9, 12, 10, 9, 512, DateTimeKind.Local).AddTicks(1063)),
                    DateDs = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "1400/03/19")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChairToUsers_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChairToUsers_Chairs_ChairId",
                        column: x => x.ChairId,
                        principalTable: "Chairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChairToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSConfirmations",
                schema: "SMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    smsId = table.Column<int>(type: "int", nullable: false),
                    confirmationText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSConfirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSConfirmations_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMSConfirmations_Phones_phoneId",
                        column: x => x.phoneId,
                        principalSchema: "SMS",
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMSConfirmations_SMS_smsId",
                        column: x => x.smsId,
                        principalSchema: "SMS",
                        principalTable: "SMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    smsId = table.Column<int>(type: "int", nullable: false),
                    transaction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Phones_phoneId",
                        column: x => x.phoneId,
                        principalSchema: "SMS",
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_SMS_smsId",
                        column: x => x.smsId,
                        principalSchema: "SMS",
                        principalTable: "SMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                schema: "PROFILE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "PROFILE",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                schema: "PROFILE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberTypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneNumberTypes_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalSchema: "PROFILE",
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "PROFILE",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmedTransactions",
                schema: "TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    transactionId = table.Column<int>(type: "int", nullable: false),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    autoConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    manualConfirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmedTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmedTransactions_BaseEntities_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfirmedTransactions_Phones_phoneId",
                        column: x => x.phoneId,
                        principalSchema: "SMS",
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfirmedTransactions_Transactions_transactionId",
                        column: x => x.transactionId,
                        principalSchema: "TRANSACTION",
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChairToUsers_ChairId",
                table: "ChairToUsers",
                column: "ChairId");

            migrationBuilder.CreateIndex(
                name: "IX_ChairToUsers_UserId",
                table: "ChairToUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedTransactions_phoneId",
                schema: "TRANSACTION",
                table: "ConfirmedTransactions",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedTransactions_transactionId",
                schema: "TRANSACTION",
                table: "ConfirmedTransactions",
                column: "transactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                schema: "PROFILE",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProfileId",
                schema: "PROFILE",
                table: "FavoriteProducts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneNumberTypeId",
                schema: "PROFILE",
                table: "PhoneNumbers",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ProfileId",
                schema: "PROFILE",
                table: "PhoneNumbers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_type",
                schema: "SMS",
                table: "Phones",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileTypeId",
                schema: "PROFILE",
                table: "Profiles",
                column: "ProfileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                schema: "PROFILE",
                table: "Profiles",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SMS_phone",
                schema: "SMS",
                table: "SMS",
                column: "phone");

            migrationBuilder.CreateIndex(
                name: "IX_SMSConfirmations_phoneId",
                schema: "SMS",
                table: "SMSConfirmations",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSConfirmations_smsId",
                schema: "SMS",
                table: "SMSConfirmations",
                column: "smsId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSRegexes_type",
                schema: "SMS",
                table: "SMSRegexes",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_phoneId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_smsId",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "smsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_type",
                schema: "TRANSACTION",
                table: "Transactions",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsPerson",
                table: "Users",
                column: "IsPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Order",
                table: "Users",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserType",
                table: "Users",
                column: "UserType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChairToUsers");

            migrationBuilder.DropTable(
                name: "ConfirmedTransactions",
                schema: "TRANSACTION");

            migrationBuilder.DropTable(
                name: "FavoriteProducts",
                schema: "PROFILE");

            migrationBuilder.DropTable(
                name: "PhoneNumbers",
                schema: "PROFILE");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SMSConfirmations",
                schema: "SMS");

            migrationBuilder.DropTable(
                name: "SMSRegexes",
                schema: "SMS");

            migrationBuilder.DropTable(
                name: "SuspendedUsers",
                schema: "USER");

            migrationBuilder.DropTable(
                name: "Chairs");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "TRANSACTION");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes",
                schema: "PROFILE");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "PROFILE");

            migrationBuilder.DropTable(
                name: "Phones",
                schema: "SMS");

            migrationBuilder.DropTable(
                name: "SMS",
                schema: "SMS");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BaseEntities");
        }
    }
}

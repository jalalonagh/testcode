using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_Chairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: true),
                    financialAccountId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Phones", x => x.Id);
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
                name: "SMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMSRegexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SMSRegexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuspendedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmated = table.Column<bool>(type: "bit", nullable: false),
                    ValidCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidCodeExpired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SuspendedUsers", x => x.Id);
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
                name: "SMSConfirmations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    smsId = table.Column<int>(type: "int", nullable: false),
                    confirmationText = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SMSConfirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSConfirmations_Phones_phoneId",
                        column: x => x.phoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMSConfirmations_SMS_smsId",
                        column: x => x.smsId,
                        principalTable: "SMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    smsId = table.Column<int>(type: "int", nullable: false),
                    transaction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Phones_phoneId",
                        column: x => x.phoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_SMS_smsId",
                        column: x => x.smsId,
                        principalTable: "SMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChairToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChairId = table.Column<int>(type: "int", nullable: false),
                    DateDm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 6, 26, 17, 30, 55, 553, DateTimeKind.Local).AddTicks(4350)),
                    DateDs = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "1400/04/05"),
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
                    table.PrimaryKey("PK_ChairToUsers", x => x.Id);
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
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Points = table.Column<int>(type: "int", nullable: false),
                    ProfileTypeId = table.Column<int>(type: "int", nullable: true),
                    BankCarNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingSystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtensionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmedTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionId = table.Column<int>(type: "int", nullable: false),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    autoConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    manualConfirmed = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_ConfirmedTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmedTransactions_Phones_phoneId",
                        column: x => x.phoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfirmedTransactions_Transactions_transactionId",
                        column: x => x.transactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_FavoriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberTypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneNumberTypes_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
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
                table: "ConfirmedTransactions",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedTransactions_transactionId",
                table: "ConfirmedTransactions",
                column: "transactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProfileId",
                table: "FavoriteProducts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneNumberTypeId",
                table: "PhoneNumbers",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ProfileId",
                table: "PhoneNumbers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SMSConfirmations_phoneId",
                table: "SMSConfirmations",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSConfirmations_smsId",
                table: "SMSConfirmations",
                column: "smsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_phoneId",
                table: "Transactions",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_smsId",
                table: "Transactions",
                column: "smsId");

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
                name: "ConfirmedTransactions");

            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SMSConfirmations");

            migrationBuilder.DropTable(
                name: "SMSRegexes");

            migrationBuilder.DropTable(
                name: "SuspendedUsers");

            migrationBuilder.DropTable(
                name: "Chairs");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "SMS");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

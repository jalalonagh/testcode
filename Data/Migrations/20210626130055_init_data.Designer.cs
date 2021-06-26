﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210626130055_init_data")]
    partial class init_data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Entities.ConfirmedTransaction.ConfirmedTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool?>("autoConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("manualConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("transactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("phoneId");

                    b.HasIndex("transactionId");

                    b.ToTable("ConfirmedTransactions");
                });

            modelBuilder.Entity("Entities.Phone.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("financialAccountId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("Entities.Profile.FavoriteProduct.FavoriteProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("FavoriteProducts");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumber.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumberTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumberTypeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumberType.PhoneNumberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumberTypes");
                });

            modelBuilder.Entity("Entities.Profile.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AccountingSystemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankCarNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DayBirthDate")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtensionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MonthBirthDate")
                        .HasColumnType("int");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumberId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SecondPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("YearBirthDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Entities.SMS.SMS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("smsText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SMS");
                });

            modelBuilder.Entity("Entities.SMSConfirmation.SMSConfirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("confirmationText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("smsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("phoneId");

                    b.HasIndex("smsId");

                    b.ToTable("SMSConfirmations");
                });

            modelBuilder.Entity("Entities.SMSRegex.SMSRegex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("regex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SMSRegexes");
                });

            modelBuilder.Entity("Entities.Transaction.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("smsId")
                        .HasColumnType("int");

                    b.Property<decimal>("transaction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("phoneId");

                    b.HasIndex("smsId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Entities.User.Chair.Chair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chairs");
                });

            modelBuilder.Entity("Entities.User.ChairToUser.ChairToUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChairId")
                        .HasColumnType("int");

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 6, 26, 17, 30, 55, 553, DateTimeKind.Local).AddTicks(4350));

                    b.Property<string>("DateDs")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("1400/04/05");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChairId");

                    b.HasIndex("UserId");

                    b.ToTable("ChairToUsers");
                });

            modelBuilder.Entity("Entities.User.Role.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entities.User.SuspendedUser.SuspendedUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmated")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("ValidCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidCodeExpired")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SuspendedUsers");
                });

            modelBuilder.Entity("Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AccountingUserReferenceId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset?>("LastLoginDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatePersianTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NikName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SalcustCu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalcustSi")
                        .HasColumnType("int");

                    b.Property<string>("SalcustTp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ValidCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidCodeExpired")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsPerson");

                    b.HasIndex("Order");

                    b.HasIndex("UserType");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.ConfirmedTransaction.ConfirmedTransaction", b =>
                {
                    b.HasOne("Entities.Phone.Phone", "phone")
                        .WithMany("Confirms")
                        .HasForeignKey("phoneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Transaction.Transaction", "transaction")
                        .WithMany("Confirms")
                        .HasForeignKey("transactionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("phone");

                    b.Navigation("transaction");
                });

            modelBuilder.Entity("Entities.Profile.FavoriteProduct.FavoriteProduct", b =>
                {
                    b.HasOne("Entities.Profile.Profile", "Profile")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumber.PhoneNumber", b =>
                {
                    b.HasOne("Entities.Profile.PhoneNumberType.PhoneNumberType", "PhoneNumberType")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PhoneNumberTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Profile.Profile", "Profile")
                        .WithMany("Phones")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PhoneNumberType");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Entities.Profile.Profile", b =>
                {
                    b.HasOne("Entities.User.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Entities.Profile.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.SMSConfirmation.SMSConfirmation", b =>
                {
                    b.HasOne("Entities.Phone.Phone", "phone")
                        .WithMany()
                        .HasForeignKey("phoneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.SMS.SMS", "sms")
                        .WithMany()
                        .HasForeignKey("smsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("phone");

                    b.Navigation("sms");
                });

            modelBuilder.Entity("Entities.Transaction.Transaction", b =>
                {
                    b.HasOne("Entities.Phone.Phone", "phone")
                        .WithMany("Transactions")
                        .HasForeignKey("phoneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.SMS.SMS", "sms")
                        .WithMany("Transactions")
                        .HasForeignKey("smsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("phone");

                    b.Navigation("sms");
                });

            modelBuilder.Entity("Entities.User.ChairToUser.ChairToUser", b =>
                {
                    b.HasOne("Entities.User.Chair.Chair", "Chair")
                        .WithMany("ChairToUsers")
                        .HasForeignKey("ChairId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.User.User", "User")
                        .WithMany("Chairs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Chair");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Phone.Phone", b =>
                {
                    b.Navigation("Confirms");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumberType.PhoneNumberType", b =>
                {
                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("Entities.Profile.Profile", b =>
                {
                    b.Navigation("FavoriteProducts");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Entities.SMS.SMS", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Entities.Transaction.Transaction", b =>
                {
                    b.Navigation("Confirms");
                });

            modelBuilder.Entity("Entities.User.Chair.Chair", b =>
                {
                    b.Navigation("ChairToUsers");
                });

            modelBuilder.Entity("Entities.User.User", b =>
                {
                    b.Navigation("Chairs");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}

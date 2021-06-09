﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Entities.BaseEntity", b =>
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

                    b.HasKey("Id");

                    b.ToTable("BaseEntities");
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
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<bool?>("autoConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("manualConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("transactionId")
                        .HasColumnType("int");

                    b.HasIndex("Order");

                    b.HasIndex("phoneId");

                    b.HasIndex("transactionId");

                    b.ToTable("ConfirmedTransactions", "TRANSACTION");
                });

            modelBuilder.Entity("Entities.Phone.Phone", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<int?>("financialAccountId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("type")
                        .HasColumnType("int");

                    b.HasIndex("Order");

                    b.HasIndex("type");

                    b.ToTable("Phones", "SMS");
                });

            modelBuilder.Entity("Entities.Profile.FavoriteProduct.FavoriteProduct", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FavoriteProducts", "PROFILE");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumber.PhoneNumber", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumberTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasIndex("Order");

                    b.HasIndex("PhoneNumberTypeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("PhoneNumbers", "PROFILE");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumberType.PhoneNumberType", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("Order");

                    b.ToTable("PhoneNumberTypes", "PROFILE");
                });

            modelBuilder.Entity("Entities.Profile.Profile", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("AccountingSystemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankCarNo")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonthBirthDate")
                        .HasColumnType("int");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumberId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("ProfileTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.Property<string>("SecondPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("YearBirthDate")
                        .HasColumnType("int");

                    b.HasIndex("ProfileTypeId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Profiles", "PROFILE");
                });

            modelBuilder.Entity("Entities.SMS.SMS", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("smsText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CreateTime");

                    b.HasIndex("phone");

                    b.ToTable("SMS", "SMS");
                });

            modelBuilder.Entity("Entities.SMSConfirmation.SMSConfirmation", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("confirmationText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("smsId")
                        .HasColumnType("int");

                    b.HasIndex("CreateTime");

                    b.HasIndex("phoneId");

                    b.HasIndex("smsId");

                    b.ToTable("SMSConfirmations", "SMS");
                });

            modelBuilder.Entity("Entities.SMSRegex.SMSRegex", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("regex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasIndex("type");

                    b.ToTable("SMSRegexes", "SMS");
                });

            modelBuilder.Entity("Entities.Transaction.Transaction", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("smsId")
                        .HasColumnType("int");

                    b.Property<decimal>("transaction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasIndex("phoneId");

                    b.HasIndex("smsId");

                    b.HasIndex("type");

                    b.ToTable("Transactions", "TRANSACTION");
                });

            modelBuilder.Entity("Entities.User.Chair.Chair", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Chairs");
                });

            modelBuilder.Entity("Entities.User.ChairToUser.ChairToUser", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<int>("ChairId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 6, 9, 12, 10, 9, 512, DateTimeKind.Local).AddTicks(1063));

                    b.Property<string>("DateDs")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("1400/03/19");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("ChairId");

                    b.HasIndex("UserId");

                    b.ToTable("ChairToUsers");
                });

            modelBuilder.Entity("Entities.User.SuspendedUser.SuspendedUser", b =>
                {
                    b.HasBaseType("Entities.BaseEntity");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmated")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("ValidCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidCodeExpired")
                        .HasColumnType("datetime2");

                    b.ToTable("SuspendedUsers", "USER");
                });

            modelBuilder.Entity("Entities.ConfirmedTransaction.ConfirmedTransaction", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.ConfirmedTransaction.ConfirmedTransaction", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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

            modelBuilder.Entity("Entities.Phone.Phone", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.Phone.Phone", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Profile.FavoriteProduct.FavoriteProduct", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.Profile.FavoriteProduct.FavoriteProduct", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Entities.Profile.Profile", "Profile")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Entities.Profile.PhoneNumber.PhoneNumber", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.Profile.PhoneNumber.PhoneNumber", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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

            modelBuilder.Entity("Entities.Profile.PhoneNumberType.PhoneNumberType", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.Profile.PhoneNumberType.PhoneNumberType", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Profile.Profile", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.Profile.Profile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Entities.User.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Entities.Profile.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.SMS.SMS", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.SMS.SMS", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.SMSConfirmation.SMSConfirmation", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.SMSConfirmation.SMSConfirmation", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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

            modelBuilder.Entity("Entities.SMSRegex.SMSRegex", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.SMSRegex.SMSRegex", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Transaction.Transaction", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.Transaction.Transaction", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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

            modelBuilder.Entity("Entities.User.Chair.Chair", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.User.Chair.Chair", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.User.ChairToUser.ChairToUser", b =>
                {
                    b.HasOne("Entities.User.Chair.Chair", "Chair")
                        .WithMany("ChairToUsers")
                        .HasForeignKey("ChairId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.User.ChairToUser.ChairToUser", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Entities.User.User", "User")
                        .WithMany("Chairs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Chair");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.User.SuspendedUser.SuspendedUser", b =>
                {
                    b.HasOne("Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Entities.User.SuspendedUser.SuspendedUser", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.User.User", b =>
                {
                    b.Navigation("Chairs");

                    b.Navigation("Profile");
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
#pragma warning restore 612, 618
        }
    }
}

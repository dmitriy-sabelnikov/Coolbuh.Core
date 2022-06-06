using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Coolbuh.Core.DataAccess.MsSql.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationSettings",
                columns: table => new
                {
                    type = table.Column<int>(type: "int", nullable: false),
                    digitValue = table.Column<int>(type: "int", nullable: true),
                    stringValue = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettings", x => x.type);
                });

            migrationBuilder.CreateTable(
                name: "ConsolidateReportCatalogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quarter = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    calculateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    flags = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidateReportCatalogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    taxIdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    seniority = table.Column<int>(type: "int", nullable: true),
                    grade = table.Column<int>(type: "int", nullable: true),
                    birthDate = table.Column<DateTime>(type: "date", nullable: true),
                    entryDate = table.Column<DateTime>(type: "date", nullable: true),
                    dismissalDate = table.Column<DateTime>(type: "date", nullable: true),
                    pensionDate = table.Column<DateTime>(type: "date", nullable: true),
                    sex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListAdditionalAccrualTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    flags = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAdditionalAccrualTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListAdditionalPaymentTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAdditionalPaymentTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListCardStatusTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListCardStatusTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListDepartments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListDepartments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListLivingWages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    sum = table.Column<decimal>(type: "numeric(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListLivingWages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListMinimumSalaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    sum = table.Column<decimal>(type: "numeric(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListMinimumSalaries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListOtherAllowances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    percent = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    flags = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOtherAllowances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListPensionAllowances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    percent = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    flags = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListPensionAllowances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListPositions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListPositions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListSocialBenefits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    sum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    limitSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListSocialBenefits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListSpecialSeniorities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    reasonCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListSpecialSeniorities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ConsolidateReportAppendix1s",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consolidateReportCatalogId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    isUkraineNationality = table.Column<bool>(type: "bit", nullable: false),
                    sex = table.Column<int>(type: "int", nullable: false),
                    taxIdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    categoryCode = table.Column<int>(type: "int", nullable: false),
                    accrualTypeCode = table.Column<int>(type: "int", nullable: false),
                    accrualMonth = table.Column<int>(type: "int", nullable: false),
                    accrualYear = table.Column<int>(type: "int", nullable: false),
                    temporaryDisabilityDays = table.Column<int>(type: "int", nullable: false),
                    withoutSalaryDays = table.Column<int>(type: "int", nullable: false),
                    employmentDays = table.Column<int>(type: "int", nullable: false),
                    maternityLeaveDays = table.Column<int>(type: "int", nullable: false),
                    accrualTotalSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    maxAccrualTotalSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    differenceSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    withholdingUniformPaymentSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    accrualUniformPaymentSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    isExistWorkBook = table.Column<bool>(type: "bit", nullable: false),
                    isSpecialSeniority = table.Column<bool>(type: "bit", nullable: false),
                    isPartTimeWork = table.Column<bool>(type: "bit", nullable: false),
                    isNewWorkplace = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidateReportAppendix1s", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConsolidateReportAppendix1s_ConsolidateReportCatalogs_consolidateReportCatalogId",
                        column: x => x.consolidateReportCatalogId,
                        principalTable: "ConsolidateReportCatalogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsolidateReportAppendix4s",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consolidateReportCatalogId = table.Column<int>(type: "int", nullable: false),
                    firmUSREOU = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    firmType = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    taxIdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    entryDate = table.Column<DateTime>(type: "date", nullable: false),
                    dismissalDate = table.Column<DateTime>(type: "date", nullable: false),
                    taxReliefSign = table.Column<int>(type: "int", nullable: false),
                    accrualIncomeSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    paidIncomeSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    accrualTaxSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    transferTaxSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    incomeSign = table.Column<int>(type: "int", nullable: false),
                    accrualWarTaxSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    transferWarTaxSum = table.Column<decimal>(type: "numeric(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidateReportAppendix4s", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConsolidateReportAppendix4s_ConsolidateReportCatalogs_consolidateReportCatalogId",
                        column: x => x.consolidateReportCatalogId,
                        principalTable: "ConsolidateReportCatalogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsolidateReportAppendixes6",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsolidateReportCatalogId = table.Column<int>(type: "int", nullable: false),
                    AccountingPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUkraineNationality = table.Column<bool>(type: "bit", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodStartDay = table.Column<int>(type: "int", nullable: false),
                    PeriodStopDay = table.Column<int>(type: "int", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    DayRate = table.Column<int>(type: "int", nullable: false),
                    HourRate = table.Column<int>(type: "int", nullable: false),
                    MinuteRate = table.Column<int>(type: "int", nullable: false),
                    SeasonSign = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidateReportAppendixes6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsolidateReportAppendixes6_ConsolidateReportCatalogs_ConsolidateReportCatalogId",
                        column: x => x.ConsolidateReportCatalogId,
                        principalTable: "ConsolidateReportCatalogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeChildren",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeChildren", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeChildren_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDisabilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDisabilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeDisabilities_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTaxReliefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    coefficient = table.Column<decimal>(type: "numeric(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaxReliefs", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeTaxReliefs_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    sum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalPayments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    additionalPaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    sum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalPayments", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdditionalPayments_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AdditionalPayments_ListAdditionalPaymentTypes_additionalPaymentTypeId",
                        column: x => x.additionalPaymentTypeId,
                        principalTable: "ListAdditionalPaymentTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCardStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    cardStatusTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCardStatuses", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeCardStatuses_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCardStatuses_ListCardStatusTypes_cardStatusTypeId",
                        column: x => x.cardStatusTypeId,
                        principalTable: "ListCardStatusTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AdditionalAccruals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    additionalAccrualTypeId = table.Column<int>(type: "int", nullable: false),
                    sum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAccruals", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdditionalAccruals_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AdditionalAccruals_ListAdditionalAccrualTypes_additionalAccrualTypeId",
                        column: x => x.additionalAccrualTypeId,
                        principalTable: "ListAdditionalAccrualTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AdditionalAccruals_ListDepartments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "ListDepartments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CivilLawContracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    accrualPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    sum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilLawContracts", x => x.id);
                    table.ForeignKey(
                        name: "FK_CivilLawContracts_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CivilLawContracts_ListDepartments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "ListDepartments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ListGradeAllowances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    percent = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: true),
                    flags = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListGradeAllowances", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListGradeAllowances_ListDepartments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "ListDepartments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SickLists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    accrualPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    enterpriseDays = table.Column<int>(type: "int", nullable: false),
                    enterpriseSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    socialInsuranceDays = table.Column<int>(type: "int", nullable: false),
                    socialInsuranceSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SickLists", x => x.id);
                    table.ForeignKey(
                        name: "FK_SickLists_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SickLists_ListDepartments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "ListDepartments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Vocations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    accrualPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    sum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vocations_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vocations_ListDepartments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "ListDepartments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ListAdministrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxIdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    telephoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    positionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAdministrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListAdministrations_ListPositions_positionId",
                        column: x => x.positionId,
                        principalTable: "ListPositions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSpecialSeniorities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    periodBegin = table.Column<DateTime>(type: "date", nullable: true),
                    periodEnd = table.Column<DateTime>(type: "date", nullable: true),
                    specialSeniorityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSpecialSeniorities", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialSeniorities_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialSeniorities_ListSpecialSeniorities_specialSeniorityId",
                        column: x => x.specialSeniorityId,
                        principalTable: "ListSpecialSeniorities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCardId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    accountingPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    baseSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    pensionAllowanceId = table.Column<int>(type: "int", nullable: true),
                    pensionAllowanceSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    gradeAllowanceId = table.Column<int>(type: "int", nullable: true),
                    gradeAllowanceSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    otherAllowanceId = table.Column<int>(type: "int", nullable: true),
                    otherAllowanceSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    totalSum = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.id);
                    table.ForeignKey(
                        name: "FK_Salaries_EmployeeCards_employeeCardId",
                        column: x => x.employeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Salaries_ListDepartments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "ListDepartments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Salaries_ListGradeAllowances_gradeAllowanceId",
                        column: x => x.gradeAllowanceId,
                        principalTable: "ListGradeAllowances",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Salaries_ListOtherAllowances_otherAllowanceId",
                        column: x => x.otherAllowanceId,
                        principalTable: "ListOtherAllowances",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Salaries_ListPensionAllowances_pensionAllowanceId",
                        column: x => x.pensionAllowanceId,
                        principalTable: "ListPensionAllowances",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAccruals_AccountingPeriod",
                table: "AdditionalAccruals",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAccruals_AccountingPeriod_DepartmentId",
                table: "AdditionalAccruals",
                columns: new[] { "accountingPeriod", "departmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAccruals_additionalAccrualTypeId",
                table: "AdditionalAccruals",
                column: "additionalAccrualTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAccruals_departmentId",
                table: "AdditionalAccruals",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAccruals_employeeCardId",
                table: "AdditionalAccruals",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPayments_AccountingPeriod",
                table: "AdditionalPayments",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPayments_AccountingPeriod_AdditionalPaymentTypeId",
                table: "AdditionalPayments",
                columns: new[] { "accountingPeriod", "additionalPaymentTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPayments_additionalPaymentTypeId",
                table: "AdditionalPayments",
                column: "additionalPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPayments_employeeCardId",
                table: "AdditionalPayments",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilLawContracts_AccountingPeriod",
                table: "CivilLawContracts",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_CivilLawContracts_AccountingPeriod_DepartmentId",
                table: "CivilLawContracts",
                columns: new[] { "accountingPeriod", "departmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CivilLawContracts_departmentId",
                table: "CivilLawContracts",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilLawContracts_employeeCardId",
                table: "CivilLawContracts",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidateReportAppendix1s_consolidateReportCatalogId",
                table: "ConsolidateReportAppendix1s",
                column: "consolidateReportCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidateReportAppendix4s_consolidateReportCatalogId",
                table: "ConsolidateReportAppendix4s",
                column: "consolidateReportCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidateReportAppendixes6_ConsolidateReportCatalogId",
                table: "ConsolidateReportAppendixes6",
                column: "ConsolidateReportCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCardStatuses_cardStatusTypeId",
                table: "EmployeeCardStatuses",
                column: "cardStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCardStatuses_employeeCardId",
                table: "EmployeeCardStatuses",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChildren_employeeCardId",
                table: "EmployeeChildren",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDisabilities_employeeCardId",
                table: "EmployeeDisabilities",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSpecialSeniorities_employeeCardId",
                table: "EmployeeSpecialSeniorities",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSpecialSeniorities_specialSeniorityId",
                table: "EmployeeSpecialSeniorities",
                column: "specialSeniorityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaxReliefs_employeeCardId",
                table: "EmployeeTaxReliefs",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ListAdditionalAccrualTypes_Code",
                table: "ListAdditionalAccrualTypes",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListAdditionalPaymentTypes_Code",
                table: "ListAdditionalPaymentTypes",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListAdministrations_positionId",
                table: "ListAdministrations",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_ListCardStatusTypes_Code",
                table: "ListCardStatusTypes",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListDepartments_Code",
                table: "ListDepartments",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListGradeAllowances_Code",
                table: "ListGradeAllowances",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListGradeAllowances_departmentId",
                table: "ListGradeAllowances",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOtherAllowances_Code",
                table: "ListOtherAllowances",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListPensionAllowances_Code",
                table: "ListPensionAllowances",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListPositions_Code",
                table: "ListPositions",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListSpecialSeniorities_Code",
                table: "ListSpecialSeniorities",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AccountingPeriod",
                table: "Payments",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_employeeCardId",
                table: "Payments",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_AccountingPeriod",
                table: "Salaries",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_AccountingPeriod_DepartmentId",
                table: "Salaries",
                columns: new[] { "accountingPeriod", "departmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_departmentId",
                table: "Salaries",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_employeeCardId",
                table: "Salaries",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_gradeAllowanceId",
                table: "Salaries",
                column: "gradeAllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_otherAllowanceId",
                table: "Salaries",
                column: "otherAllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_pensionAllowanceId",
                table: "Salaries",
                column: "pensionAllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SickLists_AccountingPeriod",
                table: "SickLists",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_SickLists_AccountingPeriod_DepartmentId",
                table: "SickLists",
                columns: new[] { "accountingPeriod", "departmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_SickLists_departmentId",
                table: "SickLists",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SickLists_employeeCardId",
                table: "SickLists",
                column: "employeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocations_AccountingPeriod",
                table: "Vocations",
                column: "accountingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_Vocations_AccountingPeriod_DepartmentId",
                table: "Vocations",
                columns: new[] { "accountingPeriod", "departmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Vocations_departmentId",
                table: "Vocations",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocations_employeeCardId",
                table: "Vocations",
                column: "employeeCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalAccruals");

            migrationBuilder.DropTable(
                name: "AdditionalPayments");

            migrationBuilder.DropTable(
                name: "ApplicationSettings");

            migrationBuilder.DropTable(
                name: "CivilLawContracts");

            migrationBuilder.DropTable(
                name: "ConsolidateReportAppendix1s");

            migrationBuilder.DropTable(
                name: "ConsolidateReportAppendix4s");

            migrationBuilder.DropTable(
                name: "ConsolidateReportAppendixes6");

            migrationBuilder.DropTable(
                name: "EmployeeCardStatuses");

            migrationBuilder.DropTable(
                name: "EmployeeChildren");

            migrationBuilder.DropTable(
                name: "EmployeeDisabilities");

            migrationBuilder.DropTable(
                name: "EmployeeSpecialSeniorities");

            migrationBuilder.DropTable(
                name: "EmployeeTaxReliefs");

            migrationBuilder.DropTable(
                name: "ListAdministrations");

            migrationBuilder.DropTable(
                name: "ListLivingWages");

            migrationBuilder.DropTable(
                name: "ListMinimumSalaries");

            migrationBuilder.DropTable(
                name: "ListSocialBenefits");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "SickLists");

            migrationBuilder.DropTable(
                name: "Vocations");

            migrationBuilder.DropTable(
                name: "ListAdditionalAccrualTypes");

            migrationBuilder.DropTable(
                name: "ListAdditionalPaymentTypes");

            migrationBuilder.DropTable(
                name: "ConsolidateReportCatalogs");

            migrationBuilder.DropTable(
                name: "ListCardStatusTypes");

            migrationBuilder.DropTable(
                name: "ListSpecialSeniorities");

            migrationBuilder.DropTable(
                name: "ListPositions");

            migrationBuilder.DropTable(
                name: "ListGradeAllowances");

            migrationBuilder.DropTable(
                name: "ListOtherAllowances");

            migrationBuilder.DropTable(
                name: "ListPensionAllowances");

            migrationBuilder.DropTable(
                name: "EmployeeCards");

            migrationBuilder.DropTable(
                name: "ListDepartments");
        }
    }
}

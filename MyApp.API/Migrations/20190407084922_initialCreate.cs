using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApp.API.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    KnownAs = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    DocumentDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    PaymentDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelationType = table.Column<string>(maxLength: 50, nullable: false),
                    RelationTypeDesc = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    SemesterDesc = table.Column<string>(maxLength: 256, nullable: true),
                    SemesterStartMonth = table.Column<string>(maxLength: 10, nullable: true),
                    SemesterEndMonth = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Likes",
                columns: table => new
                {
                    LikerId = table.Column<int>(nullable: false),
                    LikeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.LikerId, x.LikeeId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikeeId",
                        column: x => x.LikeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(nullable: false),
                    RecipientId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    DateRead = table.Column<DateTime>(nullable: true),
                    MessageSent = table.Column<DateTime>(nullable: false),
                    SenderDeleted = table.Column<bool>(nullable: false),
                    RecipientDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_States",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PinCode = table.Column<int>(nullable: true),
                    ContactNumber = table.Column<string>(maxLength: 50, nullable: true),
                    District = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colleges_Districts",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDistricts_Districts",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CFSSN = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 80, nullable: true),
                    LastName = table.Column<string>(maxLength: 80, nullable: true),
                    FatherName = table.Column<string>(maxLength: 80, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    BloodGroup = table.Column<string>(maxLength: 80, nullable: true),
                    Religion = table.Column<string>(maxLength: 80, nullable: true),
                    Caste = table.Column<string>(maxLength: 80, nullable: true),
                    MotherTongue = table.Column<string>(maxLength: 80, nullable: true),
                    Nationality = table.Column<string>(maxLength: 80, nullable: true),
                    FirstAdmissionYear = table.Column<int>(nullable: true),
                    EmailId = table.Column<string>(maxLength: 256, nullable: true),
                    CurrentAddress = table.Column<string>(nullable: true),
                    CurrentCity = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentCityId = table.Column<int>(nullable: true),
                    CurrentDistrict = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentDistrictId = table.Column<int>(nullable: true),
                    PinCode = table.Column<int>(nullable: true),
                    PhoneWithStdCode = table.Column<string>(maxLength: 255, nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    PermanentCity = table.Column<string>(maxLength: 255, nullable: true),
                    PermanentCityId = table.Column<int>(nullable: true),
                    PermanentDistrict = table.Column<string>(maxLength: 255, nullable: true),
                    PermanentDistrictId = table.Column<int>(nullable: true),
                    ProfilePicBinary = table.Column<byte[]>(nullable: true),
                    MobileNumber1 = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    StudentStatus = table.Column<bool>(nullable: true),
                    Marks = table.Column<int>(nullable: true),
                    PlaceOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    PlaceOfBirthPinNo = table.Column<int>(nullable: true),
                    StateOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    CountryOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    Disability = table.Column<bool>(nullable: true),
                    DisabilityType = table.Column<string>(maxLength: 100, nullable: true),
                    IsCollege = table.Column<string>(maxLength: 100, nullable: true),
                    IsAllSemSupport = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    PrevCFSSN = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_SubDistricts",
                        column: x => x.CurrentCityId,
                        principalTable: "SubDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Districts",
                        column: x => x.CurrentDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAcademics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    SchoolName = table.Column<string>(maxLength: 256, nullable: true),
                    SchoolBoardType = table.Column<string>(maxLength: 50, nullable: true),
                    Standard = table.Column<string>(maxLength: 10, nullable: true),
                    AcademicGroup = table.Column<string>(maxLength: 80, nullable: true),
                    SchoolAddress = table.Column<string>(nullable: true),
                    SchoolCity = table.Column<string>(maxLength: 80, nullable: true),
                    SchoolCityId = table.Column<int>(nullable: true),
                    SchoolDistrict = table.Column<string>(maxLength: 80, nullable: true),
                    SchoolDistrictId = table.Column<int>(nullable: true),
                    YearOfPassing = table.Column<int>(nullable: true),
                    Marks = table.Column<int>(nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    MediumOfInstruction = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAcademics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAcademics_SubDistricts",
                        column: x => x.SchoolCityId,
                        principalTable: "SubDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAcademics_Districts",
                        column: x => x.SchoolDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAcademics_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    DocumentDesc = table.Column<string>(nullable: true),
                    DocumentBinary = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDocuments_Students",
                        column: x => x.DocumentTypeId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    CollegeId = table.Column<int>(nullable: false),
                    EnrollmentYear = table.Column<int>(nullable: true),
                    EnrollmentDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Colleges",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Courses",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StudentSemId = table.Column<int>(nullable: true),
                    FeesAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FeesDesc = table.Column<string>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: true),
                    ChequeNumber = table.Column<string>(maxLength: 256, nullable: true),
                    BankDetails = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFees_PaymentTypes",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentFees_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPlacements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    Organisation = table.Column<string>(maxLength: 256, nullable: true),
                    PlacementStartDate = table.Column<string>(maxLength: 256, nullable: true),
                    PlacementDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPlacements_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentRelations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    RelationTypeId = table.Column<int>(nullable: true),
                    RelationName = table.Column<string>(maxLength: 50, nullable: true),
                    Occupation = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    AnnualIncome = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneWithSTDCode = table.Column<string>(maxLength: 50, nullable: true),
                    PermanentAddress = table.Column<string>(maxLength: 50, nullable: true),
                    PermanentCity = table.Column<string>(maxLength: 50, nullable: true),
                    PermanentCityId = table.Column<int>(nullable: true),
                    PermanentDistrict = table.Column<string>(maxLength: 50, nullable: true),
                    PermanentDistrictId = table.Column<int>(nullable: true),
                    PermanentState = table.Column<string>(maxLength: 50, nullable: true),
                    PermanentStateId = table.Column<int>(nullable: true),
                    PermanentPincode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRelations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentRelations_SubDistricts",
                        column: x => x.PermanentCityId,
                        principalTable: "SubDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRelations_Districts",
                        column: x => x.PermanentDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRelations_States",
                        column: x => x.PermanentStateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRelations_RelationTypes",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRelations_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSemesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentEnrollId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false),
                    SemesterGrade = table.Column<decimal>(type: "numeric(10, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSemesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSemesters_Semesters",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSemesters_StudentEnrollments",
                        column: x => x.StudentEnrollId,
                        principalTable: "StudentEnrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "India" });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Code", "DocumentDesc" },
                values: new object[,]
                {
                    { 1, "SSLC Mark", "10th Mark Sheet" },
                    { 2, "12th Mark", "12th Mark Sheet" },
                    { 3, "Ration Card", "Family Member Details" },
                    { 4, "Birth Certificate", "Birth Certificate" },
                    { 5, "Aadhaar", "Aadhaar Details" },
                    { 6, "UG Degree", "Under Grduate Degree Certificate" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Code", "PaymentDesc" },
                values: new object[,]
                {
                    { 1, "Cash", "Cash" },
                    { 2, "Cheque", "Cheque" },
                    { 3, "DD", "Demand Draft" }
                });

            migrationBuilder.InsertData(
                table: "RelationTypes",
                columns: new[] { "Id", "RelationType", "RelationTypeDesc" },
                values: new object[,]
                {
                    { 6, "Brother", "Sibling" },
                    { 4, "Guardian", "Uncle, Aunt" },
                    { 5, "Sister", "Sibling" },
                    { 2, "Mother", "Parent" },
                    { 1, "Father", "Parent" },
                    { 3, "GrandParent", "Grand Father , Grand Mother" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Code", "SemesterDesc", "SemesterEndMonth", "SemesterStartMonth" },
                values: new object[,]
                {
                    { 12, "Year 4", null, "Apr", "Jun" },
                    { 1, "Sem 1", null, "Nov", "Jun" },
                    { 2, "Sem 2", null, "Apr", "Dec" },
                    { 3, "Sem 3", null, "Nov", "Jun" },
                    { 4, "Sem 4", null, "Apr", "Dec" },
                    { 5, "Sem 5", null, "Nov", "Jun" },
                    { 6, "Sem 6", null, "Apr", "Dec" },
                    { 7, "Sem 7", null, "Nov", "Jun" },
                    { 8, "Sem 8", null, "Apr", "Dec" },
                    { 9, "Year 1", null, "Apr", "Jun" },
                    { 10, "Year 2", null, "Apr", "Jun" },
                    { 11, "Year 3", null, "Apr", "Jun" },
                    { 13, "Year 5", null, "Apr", "Jun" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Andaman and Nicobar Island" },
                    { 21, 1, "Maharashtra" },
                    { 22, 1, "Manipur" },
                    { 23, 1, "Meghalaya" },
                    { 24, 1, "Mizoram" },
                    { 25, 1, "Nagaland" },
                    { 26, 1, "Odisha" },
                    { 20, 1, "Madhya Pradesh" },
                    { 27, 1, "Puducherry" },
                    { 29, 1, "Rajasthan" },
                    { 30, 1, "Sikkim" },
                    { 31, 1, "Tamil Nadu" },
                    { 32, 1, "Telangana" },
                    { 33, 1, "Tripura" },
                    { 34, 1, "Uttar Pradesh" },
                    { 28, 1, "Punjab" },
                    { 19, 1, "Lakshadweep" },
                    { 18, 1, "Kerala" },
                    { 17, 1, "Karnataka" },
                    { 2, 1, "Andhra Pradesh" },
                    { 3, 1, "Arunachal Pradesh" },
                    { 4, 1, "Assam" },
                    { 5, 1, "Bihar" },
                    { 6, 1, "Chandigarh" },
                    { 7, 1, "Chhattisgarh" },
                    { 8, 1, "Dadra and Nagar Haveli" },
                    { 9, 1, "Daman and Diu" },
                    { 10, 1, "Delhi" },
                    { 11, 1, "Goa" },
                    { 12, 1, "Gujarat" },
                    { 13, 1, "Haryana" },
                    { 14, 1, "Himachal Pradesh" },
                    { 15, 1, "Jammu and Kashmir" },
                    { 16, 1, "Jharkhand" },
                    { 35, 1, "Uttarakhand" },
                    { 36, 1, "West Bengal" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 515, "Ariyalur", 31 },
                    { 544, "Vellore", 31 },
                    { 543, "Thiruvarur", 31 },
                    { 542, "Thiruvannamalai", 31 },
                    { 541, "Thiruvallur", 31 },
                    { 540, "Tiruppur", 31 },
                    { 539, "Thirunelveli", 31 },
                    { 538, "Tiruchirapalli", 31 },
                    { 537, "Tuticorin", 31 },
                    { 536, "Theni", 31 },
                    { 535, "Thanjavur", 31 },
                    { 534, "Sivagangai", 31 },
                    { 533, "Salem", 31 },
                    { 532, "Ramanathapuram", 31 },
                    { 531, "Pudukkottai", 31 },
                    { 530, "Perambalur", 31 },
                    { 529, "Nilgiris", 31 },
                    { 528, "Namakkal", 31 },
                    { 527, "Nagapattinam", 31 },
                    { 526, "Madurai", 31 },
                    { 525, "Krishnagiri", 31 },
                    { 524, "Karur", 31 },
                    { 523, "Kanyakumari", 31 },
                    { 522, "Kanchipuram", 31 },
                    { 521, "Erode", 31 },
                    { 520, "Dindigul", 31 },
                    { 519, "Dharmapuri", 31 },
                    { 518, "Cuddalore", 31 },
                    { 517, "Coimbatore", 31 },
                    { 516, "Chennai", 31 },
                    { 545, "Viluppuram", 31 },
                    { 546, "Virudhunagar", 31 }
                });

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
                name: "IX_Colleges_DistrictId",
                table: "Colleges",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_StateId",
                table: "Districts",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeeId",
                table: "Likes",
                column: "LikeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAcademics_SchoolCityId",
                table: "StudentAcademics",
                column: "SchoolCityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAcademics_SchoolDistrictId",
                table: "StudentAcademics",
                column: "SchoolDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAcademics_StudentId",
                table: "StudentAcademics",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDocuments_DocumentTypeId",
                table: "StudentDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_CollegeId",
                table: "StudentEnrollments",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_CourseId",
                table: "StudentEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_StudentId",
                table: "StudentEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFees_PaymentTypeId",
                table: "StudentFees",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFees_StudentId",
                table: "StudentFees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlacements_StudentId",
                table: "StudentPlacements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRelations_PermanentCityId",
                table: "StudentRelations",
                column: "PermanentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRelations_PermanentDistrictId",
                table: "StudentRelations",
                column: "PermanentDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRelations_PermanentStateId",
                table: "StudentRelations",
                column: "PermanentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRelations_RelationTypeId",
                table: "StudentRelations",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRelations_StudentId",
                table: "StudentRelations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentCityId",
                table: "Students",
                column: "CurrentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentDistrictId",
                table: "Students",
                column: "CurrentDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSemesters_SemesterId",
                table: "StudentSemesters",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSemesters_StudentEnrollId",
                table: "StudentSemesters",
                column: "StudentEnrollId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDistricts_DistrictId",
                table: "SubDistricts",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "StudentAcademics");

            migrationBuilder.DropTable(
                name: "StudentDocuments");

            migrationBuilder.DropTable(
                name: "StudentFees");

            migrationBuilder.DropTable(
                name: "StudentPlacements");

            migrationBuilder.DropTable(
                name: "StudentRelations");

            migrationBuilder.DropTable(
                name: "StudentSemesters");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "RelationTypes");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubDistricts");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    ExperienceTime = table.Column<int>(type: "int", nullable: false),
                    ExpectedSalary = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanySize = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSkill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Qualifications = table.Column<int>(type: "int", nullable: false),
                    SalaryType = table.Column<int>(type: "int", nullable: false),
                    StartBudget = table.Column<double>(type: "float", nullable: false),
                    EndBudget = table.Column<double>(type: "float", nullable: false),
                    JobExperience = table.Column<int>(type: "int", nullable: false),
                    JobShift = table.Column<int>(type: "int", nullable: false),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobPosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vacancy = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "AllJobsClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllJobsClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllJobsClasses_JobClass_JobClassId",
                        column: x => x.JobClassId,
                        principalTable: "JobClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllJobsClasses_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppliedJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedJobs_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppliedJobs_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d8bbcb9-6d72-4776-b97a-54dd330775ca", "7151b06b-6891-42af-91ee-f7c4de9c62d9", "admin", "ADMIN" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "5cd972a9-e093-49ce-9297-c7908857a981", "candidate", "CANDIDATE" },
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "742a4575-753d-47f2-a376-17982fc4925c", "employer", "EMPLOYER" }
                });

            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "Id", "AboutMe", "Age", "CurrentCompany", "ExpectedSalary", "Experience", "ExperienceTime", "IsDeleted", "Location", "Name", "Phone", "ProfileImg", "Qualification", "UserId" },
                values: new object[,]
                {
                    { new Guid("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"), "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;", 23, "Fresh Graduate", 300, ".Net Developer", 5, false, 0, "Hammad Mirza", 3000000.0, "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", 0, "995ce588-b342-47b8-88f7-349365f898f9" },
                    { new Guid("31bb5001-4266-4b90-992e-2a729b26d26b"), "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;", 23, "Fresh Graduate", 400, "Php Laravel", 6, false, 0, "Ahtesham", 3000000.0, "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", 0, "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9" },
                    { new Guid("6209c878-b598-4939-bccf-909e58d12504"), "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;", 23, "Fresh Graduate", 500, "React Designer", 8, false, 1, "Sohaib", 3000000.0, "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", 1, "4e9e311a-0926-423c-b136-eab5ba39998a" }
                });

            migrationBuilder.InsertData(
                table: "Employer",
                columns: new[] { "Id", "CompanyAbout", "CompanyLogo", "CompanyName", "CompanySize", "CompanyWebsite", "Founded", "Headquarters", "Industry", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { new Guid("262ff2ba-d323-4916-b767-e9f1707ef7a2"), "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.", "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", "Avitex Agency", 200, "https://jobs.nokriwp.com/", new DateTime(2023, 5, 15, 13, 14, 32, 139, DateTimeKind.Utc).AddTicks(3264), "Las Vegas, NV 89107, USA", "It", false, "2fe7daaa-bb2f-43a6-915b-083816e43b87" },
                    { new Guid("4ea1f880-57ef-4f0b-8a19-5aa356e93091"), "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.", "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", "Honda", 600, "https://jobs.nokriwp.com/", new DateTime(2023, 5, 15, 13, 14, 32, 139, DateTimeKind.Utc).AddTicks(3274), "Islamabad", "Machenical", false, "06e4bc68-0d75-429c-b513-e12c2ab03494" },
                    { new Guid("680b65c6-46cf-48ac-88f7-29ab807b29d5"), "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.", "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", "Demo 1", 50, "https://jobs.nokriwp.com/", new DateTime(2023, 5, 15, 13, 14, 32, 139, DateTimeKind.Utc).AddTicks(3269), "Lahore", "It", false, "088fffd7-94b4-448e-9b67-5619fcf19441" }
                });

            migrationBuilder.InsertData(
                table: "JobClass",
                columns: new[] { "Id", "IsDeleted", "name" },
                values: new object[,]
                {
                    { new Guid("63acd142-d323-42c5-a453-1b67f40fd073"), false, 1 },
                    { new Guid("642a9e91-5c4a-4284-aa0f-69e39a93ea6d"), false, 0 },
                    { new Guid("930c379d-d9e6-4a48-82b0-4f586d6aafc8"), false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "IsDeleted", "JobSkill" },
                values: new object[,]
                {
                    { new Guid("010039fb-a687-4db5-8ada-3b586d3a4788"), false, ".Net" },
                    { new Guid("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d"), false, "Designing" },
                    { new Guid("2dd27837-b570-4c81-8bfc-bf8cad8323b6"), false, "Java" },
                    { new Guid("83c89321-daf9-4ade-b229-d57615a32f10"), false, "Arts" },
                    { new Guid("9a126650-2936-442e-92ba-7d7dc32ff6f9"), false, "React Native" },
                    { new Guid("aafbde46-32ee-45bd-b52a-a76a1ac12a78"), false, "Php" },
                    { new Guid("b749f4b8-3bc3-4a05-816b-56e0d12dfaaa"), false, "Architecture" },
                    { new Guid("bae33518-8dc8-4d53-80ca-e8f58a9fd808"), false, "JS" },
                    { new Guid("e4599076-fa12-4fe9-a8e4-35130d73729e"), false, "MERN Stack" },
                    { new Guid("f235f414-fc41-4acb-a1ee-1fd79aea7eae"), false, "Management" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CandidateId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EmployerId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06e4bc68-0d75-429c-b513-e12c2ab03494", 0, null, "3ab09366-1c92-4df8-9359-fa6a607e7c05", "ApplicationUser", "employer3@gmail.com", true, new Guid("4ea1f880-57ef-4f0b-8a19-5aa356e93091"), "Employer 3", "Third Employer", false, null, "EMPLOYER3@EMAIL.COM", "EMPLOYER3@EMAIL.COM", "AQAAAAEAACcQAAAAELMQoRAg7Iyb/fDI5q1kc0Y2gwjyMWuu4j83yTgWpAwDwE6ouIhV0TgeMVjNAFVgbw==", null, false, "777741d5-4e30-42ff-a45f-d80a6a91210c", false, "employer3@gmail.com" },
                    { "088fffd7-94b4-448e-9b67-5619fcf19441", 0, null, "a15ca4fc-6c96-4dd0-a333-7f6782c33f18", "ApplicationUser", "employer2@gmail.com", true, new Guid("680b65c6-46cf-48ac-88f7-29ab807b29d5"), "Employer 2", "Second Employer", false, null, "EMPLOYER2@EMAIL.COM", "EMPLOYER2@EMAIL.COM", "AQAAAAEAACcQAAAAEBnKJMCz0ptskmJIabziD1T9t9dY8hYTh+DKE72+ExJpuiM+oTw3dU/T6bXM3Y6v1w==", null, false, "f8ab57db-3aff-4cc0-80d7-3e0bbe578bc4", false, "employer2@gmail.com" },
                    { "2fe7daaa-bb2f-43a6-915b-083816e43b87", 0, null, "1590f093-7cdd-4bbb-82d7-678b7f96f022", "ApplicationUser", "employer1@gmail.com", true, new Guid("262ff2ba-d323-4916-b767-e9f1707ef7a2"), "Employer 1", "first Employer", false, null, "EMPLOYER1@EMAIL.COM", "EMPLOYER1@EMAIL.COM", "AQAAAAEAACcQAAAAELz6kQLhTSAKnCts7uGEjpjqnUhUpR7ytmxg8kKuq83PBIywF8CPFC21xVJz1hGySQ==", null, false, "9b6bef18-f694-44a9-b8c0-e1817ed4e239", false, "employer1@gmail.com" },
                    { "4e9e311a-0926-423c-b136-eab5ba39998a", 0, new Guid("6209c878-b598-4939-bccf-909e58d12504"), "e5cbbc66-1c0b-46ff-98a2-2d5ec0f3b361", "ApplicationUser", "candidate3@gmail.com", true, null, "Candidate 3", "third Candidate", false, null, "CANDIDATE3@EMAIL.COM", "CANDIDATE3@EMAIL.COM", "AQAAAAEAACcQAAAAEJrGYgsrHoCVdysboFLuM8J3iGT7DF5sj804gA1g7dUrEdMJ5zARnbkpTuM18qRVYw==", null, false, "336bd7af-fd27-44c0-9695-42ce41f9da57", false, "candidate3@gmail.com" },
                    { "995ce588-b342-47b8-88f7-349365f898f9", 0, new Guid("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"), "25666956-b80e-4346-aa11-05b3ab8db405", "ApplicationUser", "candidate1@gmail.com", true, null, "Candidate 1", "First CAndidate", false, null, "CANDIDATE1@EMAIL.COM", "CANDIDATE1@EMAIL.COM", "AQAAAAEAACcQAAAAEHhzW/ttpWxntZczQvtVe/6wVz+M7bTVQiLv6uXkUH3fEkxfFVB1XAmTJFzQ+5jbrw==", null, false, "bb100257-add6-469e-af0e-d37be33c5236", false, "candidate@gmail.com" },
                    { "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9", 0, new Guid("31bb5001-4266-4b90-992e-2a729b26d26b"), "51cc3bf1-de92-4ba8-bd08-a90aadca99b3", "ApplicationUser", "candidate2@gmail.com", true, null, "Candidate 2", "Second Candidate", false, null, "CANDIDATE2@EMAIL.COM", "CANDIDATE2@EMAIL.COM", "AQAAAAEAACcQAAAAEHWz5FWODKl87LGJrfAbZGSqJrpyHBQF4RQ7SE/tKNCudK0nxrb/KyAYsLzmEfRwbg==", null, false, "135fe06c-c45c-4511-9233-1fa5caca87aa", false, "candidate2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "Id", "CandidateId", "IsDeleted", "SkillId" },
                values: new object[,]
                {
                    { new Guid("037bb42e-67a5-4105-bb3c-539bb8d8a906"), new Guid("6209c878-b598-4939-bccf-909e58d12504"), false, new Guid("2dd27837-b570-4c81-8bfc-bf8cad8323b6") },
                    { new Guid("232c30ea-e8f6-446a-9af1-a2a20cc1c422"), new Guid("31bb5001-4266-4b90-992e-2a729b26d26b"), false, new Guid("aafbde46-32ee-45bd-b52a-a76a1ac12a78") },
                    { new Guid("26ae6b7d-0ac2-461a-9a11-42f965a2d977"), new Guid("6209c878-b598-4939-bccf-909e58d12504"), false, new Guid("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d") },
                    { new Guid("2aa2ed81-38c6-47a3-bfd0-90c031f340df"), new Guid("6209c878-b598-4939-bccf-909e58d12504"), false, new Guid("83c89321-daf9-4ade-b229-d57615a32f10") },
                    { new Guid("4cf506e5-818e-4f35-ac3c-000f3e87a604"), new Guid("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"), false, new Guid("010039fb-a687-4db5-8ada-3b586d3a4788") },
                    { new Guid("66b6ad12-bce1-4928-a59d-de02192a7c10"), new Guid("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"), false, new Guid("9a126650-2936-442e-92ba-7d7dc32ff6f9") },
                    { new Guid("af2e3fb6-a3b7-4e1a-83e4-5ee05dde72d7"), new Guid("1163535c-d87f-4a75-8e85-e0d69eb9f0ea"), false, new Guid("b749f4b8-3bc3-4a05-816b-56e0d12dfaaa") }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "DeadLine", "Description", "EmployerId", "EndBudget", "Icon", "IsDeleted", "JobExperience", "JobPosted", "JobShift", "JobStatus", "Location", "Qualifications", "Responsibility", "SalaryType", "StartBudget", "Title", "Type", "Vacancy" },
                values: new object[,]
                {
                    { new Guid("4db3c416-6eae-4f01-bfd3-1ff3b45aea98"), new DateTime(2023, 5, 20, 18, 14, 32, 63, DateTimeKind.Local).AddTicks(3479), "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.", new Guid("4ea1f880-57ef-4f0b-8a19-5aa356e93091"), 340.0, "https://www.logodesign.net/images/abstract-logo.png", false, 3, new DateTime(2023, 5, 15, 18, 14, 32, 63, DateTimeKind.Local).AddTicks(3597), 2, 0, 0, 1, "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor", 0, 190.0, "Product Designer", 5, 50 },
                    { new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"), new DateTime(2023, 5, 20, 18, 14, 32, 63, DateTimeKind.Local).AddTicks(3479), "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.", new Guid("262ff2ba-d323-4916-b767-e9f1707ef7a2"), 456.0, "https://img.freepik.com/premium-vector/gradient-business-investment-logo-design_269830-887.jpg?w=2000", false, 1, new DateTime(2023, 5, 15, 18, 14, 32, 63, DateTimeKind.Local).AddTicks(3567), 0, 0, 0, 0, "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor", 0, 123.0, "Marketing Manager", 0, 20 },
                    { new Guid("eec67987-eb6a-4251-95aa-ede40e76332f"), new DateTime(2023, 5, 20, 18, 14, 32, 63, DateTimeKind.Local).AddTicks(3479), "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.", new Guid("680b65c6-46cf-48ac-88f7-29ab807b29d5"), 777.0, "https://media.istockphoto.com/id/1304359165/vector/motion-data-speed-g-letter-logo-design.jpg?s=612x612&w=0&k=20&c=2A0yYWv8zHhztdShuGoVW87yJZqseV6AKJX0QL2cVuQ=", false, 6, new DateTime(2023, 5, 15, 18, 14, 32, 63, DateTimeKind.Local).AddTicks(3590), 0, 0, 2, 0, "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor", 0, 334.0, "Software Engineer", 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "AllJobsClasses",
                columns: new[] { "Id", "IsDeleted", "JobClassId", "JobId" },
                values: new object[,]
                {
                    { new Guid("02d42141-3627-48e2-a9ee-4142f85ca4e5"), false, new Guid("930c379d-d9e6-4a48-82b0-4f586d6aafc8"), new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e") },
                    { new Guid("0d84a83a-3460-41e1-a942-49dd6d0411bd"), false, new Guid("63acd142-d323-42c5-a453-1b67f40fd073"), new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e") },
                    { new Guid("63c2a7a6-8ebb-4bc9-ac98-8465abbb9994"), false, new Guid("642a9e91-5c4a-4284-aa0f-69e39a93ea6d"), new Guid("eec67987-eb6a-4251-95aa-ede40e76332f") },
                    { new Guid("6c931ccd-e4db-4671-a7b9-b5be4b1b69ca"), false, new Guid("930c379d-d9e6-4a48-82b0-4f586d6aafc8"), new Guid("4db3c416-6eae-4f01-bfd3-1ff3b45aea98") },
                    { new Guid("a4b97db1-2aff-49a7-be60-c59867fd74d7"), false, new Guid("63acd142-d323-42c5-a453-1b67f40fd073"), new Guid("eec67987-eb6a-4251-95aa-ede40e76332f") },
                    { new Guid("e2865ba0-ee6c-43d8-a61e-4b9df0f1d386"), false, new Guid("642a9e91-5c4a-4284-aa0f-69e39a93ea6d"), new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "06e4bc68-0d75-429c-b513-e12c2ab03494" },
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "088fffd7-94b4-448e-9b67-5619fcf19441" },
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "2fe7daaa-bb2f-43a6-915b-083816e43b87" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "4e9e311a-0926-423c-b136-eab5ba39998a" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "995ce588-b342-47b8-88f7-349365f898f9" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9" }
                });

            migrationBuilder.InsertData(
                table: "JobSkills",
                columns: new[] { "Id", "IsDeleted", "JobId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("037bb42e-67a5-4105-bb3c-539bb8d8a906"), false, new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"), new Guid("aafbde46-32ee-45bd-b52a-a76a1ac12a78") },
                    { new Guid("272eaf21-8b37-4562-b440-96b4befe752f"), false, new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"), new Guid("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d") },
                    { new Guid("340a0320-8302-4860-999f-3a256a785a20"), false, new Guid("eec67987-eb6a-4251-95aa-ede40e76332f"), new Guid("010039fb-a687-4db5-8ada-3b586d3a4788") },
                    { new Guid("ca58283f-d5f4-4eb0-92e3-6873e6821129"), false, new Guid("eec67987-eb6a-4251-95aa-ede40e76332f"), new Guid("0b886a97-0b5a-44e0-b1a9-c1ddecb67f2d") },
                    { new Guid("f0f7f73e-aad5-416a-af2f-0153f313ae05"), false, new Guid("4db3c416-6eae-4f01-bfd3-1ff3b45aea98"), new Guid("010039fb-a687-4db5-8ada-3b586d3a4788") },
                    { new Guid("fad6993c-c654-4c17-9078-174818d7236f"), false, new Guid("a8c485f2-b08b-45bb-b1cf-8fd43556e00e"), new Guid("bae33518-8dc8-4d53-80ca-e8f58a9fd808") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllJobsClasses_JobClassId",
                table: "AllJobsClasses",
                column: "JobClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AllJobsClasses_JobId",
                table: "AllJobsClasses",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedJobs_CandidateId",
                table: "AppliedJobs",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedJobs_JobsId",
                table: "AppliedJobs",
                column: "JobsId");

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
                name: "IX_AspNetUsers_CandidateId",
                table: "AspNetUsers",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerId",
                table: "AspNetUsers",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobId",
                table: "JobSkills",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllJobsClasses");

            migrationBuilder.DropTable(
                name: "AppliedJobs");

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
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "JobClass");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}

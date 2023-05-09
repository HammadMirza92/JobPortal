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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    ExperienceTime = table.Column<int>(type: "int", nullable: false),
                    ExpectedSalary = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanySize = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSkill = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    EmployeerId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AspNetUsers_Employer_EmployeerId",
                        column: x => x.EmployeerId,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    EmployerId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobClassId = table.Column<int>(type: "int", nullable: false)
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
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
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
                    { "1d8bbcb9-6d72-4776-b97a-54dd330775ca", "cd7d5c65-7d6b-49e2-8b3f-b69ab4a5263c", "admin", "ADMIN" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "c3963357-100a-4d87-9191-c51d3ee91c2c", "candidate", "CANDIDATE" },
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "8f74bb4f-3374-4f7a-bd1b-562a2a40d547", "employer", "EMPLOYER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EmployeerId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4e9e311a-0926-423c-b136-eab5ba39998a", 0, "f2d1cd47-f120-4358-a245-19c06480c5be", "ApplicationUser", "candidate3@gmail.com", true, null, "Candidate 3", "third Candidate", false, null, "CANDIDATE3@EMAIL.COM", "CANDIDATE3@EMAIL.COM", "AQAAAAEAACcQAAAAEImlsxyzzki4HXgOPffKdjemt4i4PagUv8SaLOXT1akgFt6biK6Gt1A2m7cmh5WbOw==", null, false, "449bd3b7-f60a-464a-83ba-9f90698bbc1a", false, "candidate3@gmail.com" },
                    { "995ce588-b342-47b8-88f7-349365f898f9", 0, "1043d906-133d-4d75-9b83-39b8d3baf469", "ApplicationUser", "candidate1@gmail.com", true, null, "Candidate 1", "First CAndidate", false, null, "CANDIDATE1@EMAIL.COM", "CANDIDATE1@EMAIL.COM", "AQAAAAEAACcQAAAAEGQpe4DNj8E1rmFR2pi7K214+ed6VJNcvB8HAbIl7x3ffN7TiVCvuaDxpnQYt1c8SA==", null, false, "7f1883d3-2e57-4cd3-ab61-913c8735f9d7", false, "candidate@gmail.com" },
                    { "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9", 0, "bfb8c3ef-42d7-4b75-8ea2-ae2cf9293f3e", "ApplicationUser", "candidate2@gmail.com", true, null, "Candidate 2", "Second Candidate", false, null, "CANDIDATE2@EMAIL.COM", "CANDIDATE2@EMAIL.COM", "AQAAAAEAACcQAAAAEIPPVWxzUI2deunQo4h7k5d+OAVlwI/Bvv2PqerJoOi2LaDZ+N3/Rla6dSwzFQnPsw==", null, false, "65a49954-8ac8-4e87-b030-cdb826c2583b", false, "candidate2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "Id", "AboutMe", "Age", "ExpectedSalary", "Experience", "ExperienceTime", "Location", "Name", "Phone", "ProfileImg", "Qualification", "UserId" },
                values: new object[,]
                {
                    { 1, "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;", 23, 300, ".Net Developer", 5, 0, "Hammad Mirza", 3000000, "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", 0, "" },
                    { 2, "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;", 23, 400, "Php Laravel", 6, 0, "Ahtesham", 3000000, "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", 0, "" },
                    { 3, "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines;", 23, 500, "React Designer", 8, 1, "Sohaib", 3000000, "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", 1, "" }
                });

            migrationBuilder.InsertData(
                table: "Employer",
                columns: new[] { "Id", "CompanyAbout", "CompanyLogo", "CompanyName", "CompanySize", "CompanyWebsite", "Founded", "Headquarters", "Industry", "UserId" },
                values: new object[,]
                {
                    { 1, "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.", "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", "Avitex Agency", 200, "https://jobs.nokriwp.com/", new DateTime(2023, 5, 9, 12, 7, 7, 714, DateTimeKind.Utc).AddTicks(8738), "Las Vegas, NV 89107, USA", "It", "2fe7daaa-bb2f-43a6-915b-083816e43b87" },
                    { 2, "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.", "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", "Demo 1", 50, "https://jobs.nokriwp.com/", new DateTime(2023, 5, 9, 12, 7, 7, 714, DateTimeKind.Utc).AddTicks(8745), "Lahore", "It", "088fffd7-94b4-448e-9b67-5619fcf19441" },
                    { 3, "Are you a User Experience Designer with a track record of delivering intuitive digital experiences that drive results? Are you a strategic storyteller and systems thinker who can concept and craft smart, world-class campaigns across a variety of mediums?\r\n\r\nDeloitte's Green Dot Agency is looking to add a Lead User Experience Designer to our experience design team. We want a passionate creative who's inspired by new trends and emerging technologies, and is able to integrate them into memorable user experiences. A problem solver who is entrepreneurial, collaborative, hungry, and humble; can deliver beautifully designed, leading-edge experiences under tight deadlines; and who has demonstrated proven expertise.", "https://th.bing.com/th/id/R.219c36f0da053be6810bf890683de60a?rik=TMTQOLdr87KvBA&pid=ImgRaw&r=0", "Honda", 600, "https://jobs.nokriwp.com/", new DateTime(2023, 5, 9, 12, 7, 7, 714, DateTimeKind.Utc).AddTicks(8748), "Islamabad", "Machenical", "06e4bc68-0d75-429c-b513-e12c2ab03494" }
                });

            migrationBuilder.InsertData(
                table: "JobClass",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Feature" },
                    { 2, "Urgent" },
                    { 3, "Private" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "JobSkill" },
                values: new object[,]
                {
                    { 1, "Php" },
                    { 2, "JS" },
                    { 3, "Designing" },
                    { 4, "Application Development" },
                    { 5, "Arts" },
                    { 6, ".Net" },
                    { 7, "Development" },
                    { 8, "Modeling" },
                    { 9, "Architecture" },
                    { 10, "Management" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "4e9e311a-0926-423c-b136-eab5ba39998a" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "995ce588-b342-47b8-88f7-349365f898f9" },
                    { "7023e28f-c1dc-42cd-ad76-858802f45979", "cc53dc1c-a0d0-49a3-8f31-06b320fe22a9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EmployeerId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06e4bc68-0d75-429c-b513-e12c2ab03494", 0, "571541e9-f03b-45c5-89cb-5a6de064e42a", "ApplicationUser", "employer3@gmail.com", true, 3, "Employer 3", "Third Employer", false, null, "EMPLOYER3@EMAIL.COM", "EMPLOYER3@EMAIL.COM", "AQAAAAEAACcQAAAAEGbEdzoDEtaHV2sjMjcE1zqHL81dQMgkH7CqdHNgAJl410Vgf14ViqnDPbIBNcICyQ==", null, false, "e5b4ef44-1f3f-4053-8eb4-776dad094115", false, "employer3@gmail.com" },
                    { "088fffd7-94b4-448e-9b67-5619fcf19441", 0, "007b9eb2-4275-4294-a6b2-13df4ee5ae8a", "ApplicationUser", "employer2@gmail.com", true, 2, "Employer 2", "Second Employer", false, null, "EMPLOYER2@EMAIL.COM", "EMPLOYER2@EMAIL.COM", "AQAAAAEAACcQAAAAEBjZNIvTw8+RlRmqU8iCCaRNFoM80JZPy8jyIHyxemNVnq0Zd6l3S6M1toizoHuWdw==", null, false, "e2314102-d471-49d2-98a0-16fa6797b22f", false, "employer2@gmail.com" },
                    { "2fe7daaa-bb2f-43a6-915b-083816e43b87", 0, "b88bdf56-e89a-4d49-a6a1-17899a054454", "ApplicationUser", "employer1@gmail.com", true, 1, "Employer 1", "first Employer", false, null, "EMPLOYER1@EMAIL.COM", "EMPLOYER1@EMAIL.COM", "AQAAAAEAACcQAAAAEFqrzcrHD3YKEKHkfoBHTInXEnzgAf6Y4ozlMcYb0inXDPx/CYdinH/WJSccY2KJug==", null, false, "64f4cf18-4bb9-419b-8cd9-58996aecb57a", false, "employer1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "Id", "CandidateId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 1, 6 },
                    { 3, 1, 9 },
                    { 4, 2, 1 },
                    { 5, 3, 3 },
                    { 6, 3, 5 },
                    { 7, 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "DeadLine", "Description", "EmployerId", "EndBudget", "Icon", "JobExperience", "JobPosted", "JobShift", "JobStatus", "Location", "Qualifications", "Responsibility", "SalaryType", "StartBudget", "Title", "Type", "Vacancy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.", 1, 456.0, "https://img.freepik.com/premium-vector/gradient-business-investment-logo-design_269830-887.jpg?w=2000", 1, new DateTime(2023, 5, 9, 17, 7, 7, 624, DateTimeKind.Local).AddTicks(1735), 0, 0, 0, 0, "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor", 0, 123.0, "Marketing Manager", 0, 20 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.", 1, 777.0, "https://media.istockphoto.com/id/1304359165/vector/motion-data-speed-g-letter-logo-design.jpg?s=612x612&w=0&k=20&c=2A0yYWv8zHhztdShuGoVW87yJZqseV6AKJX0QL2cVuQ=", 6, new DateTime(2023, 5, 9, 17, 7, 7, 624, DateTimeKind.Local).AddTicks(1755), 0, 0, 2, 0, "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor", 0, 334.0, "Software Engineer", 0, 5 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.", 2, 340.0, "https://www.logodesign.net/images/abstract-logo.png", 3, new DateTime(2023, 5, 9, 17, 7, 7, 624, DateTimeKind.Local).AddTicks(1759), 2, 0, 0, 1, "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor", 0, 190.0, "Product Designer", 5, 50 }
                });

            migrationBuilder.InsertData(
                table: "AllJobsClasses",
                columns: new[] { "Id", "JobClassId", "JobId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "06e4bc68-0d75-429c-b513-e12c2ab03494" },
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "088fffd7-94b4-448e-9b67-5619fcf19441" },
                    { "b189a208-8a38-42c5-9922-5dcb918e85c9", "2fe7daaa-bb2f-43a6-915b-083816e43b87" }
                });

            migrationBuilder.InsertData(
                table: "JobSkills",
                columns: new[] { "Id", "JobId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 3 },
                    { 5, 2, 6 },
                    { 6, 3, 6 }
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
                name: "IX_AspNetUsers_EmployeerId",
                table: "AspNetUsers",
                column: "EmployeerId");

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
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}

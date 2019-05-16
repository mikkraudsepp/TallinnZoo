using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WorkPosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConservationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConservationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificClassification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificClassification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
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
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UploadedDateTime = table.Column<DateTime>(nullable: false),
                    FileType = table.Column<string>(nullable: true),
                    UploaderUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_AspNetUsers_UploaderUserId",
                        column: x => x.UploaderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoundTrack",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Reader = table.Column<string>(nullable: true),
                    TrackLength = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    TimesPlayed = table.Column<int>(nullable: false),
                    UploadedDateTime = table.Column<DateTime>(nullable: false),
                    FileType = table.Column<string>(nullable: true),
                    UploaderUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoundTrack_AspNetUsers_UploaderUserId",
                        column: x => x.UploaderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BinomialName = table.Column<string>(maxLength: 80, nullable: true),
                    LastEdited = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    MapSegmentId = table.Column<Guid>(nullable: true),
                    FeaturedImgId = table.Column<Guid>(nullable: true),
                    ConservationStatusId = table.Column<Guid>(nullable: true),
                    ScientificClassificationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_ConservationStatus_ConservationStatusId",
                        column: x => x.ConservationStatusId,
                        principalTable: "ConservationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Media_FeaturedImgId",
                        column: x => x.FeaturedImgId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_ScientificClassification_ScientificClassificationId",
                        column: x => x.ScientificClassificationId,
                        principalTable: "ScientificClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalFact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    AnimalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalFact_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapSegment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AppMapId = table.Column<Guid>(nullable: true),
                    AnimalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapSegment_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MapSegment_AppMap_AppMapId",
                        column: x => x.AppMapId,
                        principalTable: "AppMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaInAnimal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnimalId = table.Column<Guid>(nullable: false),
                    MediaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaInAnimal_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaInAnimal_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoundTrackInAnimal",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(nullable: false),
                    SoundTrackId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundTrackInAnimal", x => new { x.AnimalId, x.SoundTrackId });
                    table.ForeignKey(
                        name: "FK_SoundTrackInAnimal_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoundTrackInAnimal_SoundTrack_SoundTrackId",
                        column: x => x.SoundTrackId,
                        principalTable: "SoundTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusInMapSegment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActiveDateTimeFrom = table.Column<DateTime>(nullable: true),
                    ActiveDateTimeTo = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MapSegmentId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInMapSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusInMapSegment_Animal_MapSegmentId",
                        column: x => x.MapSegmentId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusInMapSegment_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeoCoordinate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    MapSegmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCoordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoCoordinate_MapSegment_MapSegmentId",
                        column: x => x.MapSegmentId,
                        principalTable: "MapSegment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppMap",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4fd691de-e726-42ae-8831-ded116db2e1e"), "Tallinna loomaaia kaart" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("dbedacf4-8c03-440b-a3dc-076fd7a779c9"), "0e65e318-4efb-41f2-ac85-9ce3d5228d7b", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "WorkPosition" },
                values: new object[,]
                {
                    { new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), 0, "d790468e-67cd-4306-8308-5b8d1c394105", "mikkraudsepp@hotmail.com", false, "Mikk", "Raudsepp", false, null, null, null, null, null, false, null, false, null, null },
                    { new Guid("bbd5a089-fa55-45e9-89ba-aa81589d56cb"), 0, "16b6038b-5a11-4179-96b5-2c964b8ed88d", "themikkraudsepp@gmail.com", false, "Admin", "Admin", false, null, null, null, null, null, false, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "ConservationStatus",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { new Guid("8f12e90a-78c1-4b72-a027-c267d259b48f"), "EX", "Extinct" },
                    { new Guid("65df37b0-99de-4cc2-94c1-b0e739918c78"), "EW", "Extinct in the wild" },
                    { new Guid("ba3c48c2-2464-470a-9e6b-762a7dd6d3cf"), "CR", "Critically endangered" },
                    { new Guid("f794ed3b-e145-48e6-a16e-b21d9b62037c"), "EN", "Endangered" },
                    { new Guid("922b93a0-f05d-4b82-a4bf-5980d2b1b58a"), "VU", "Vulnerable" },
                    { new Guid("8c30cfca-2365-46f7-b97c-c96ca29b24fd"), "NT", "Near threatened" },
                    { new Guid("78202fb8-b51e-4177-9f68-acb9d3cf6c3d"), "LC", "Least concern" },
                    { new Guid("5be82bdd-cec5-437d-b7d4-c591f1cb4eaf"), "DD", "Data deficient" },
                    { new Guid("3977b2d0-8dba-404b-9e78-52246e026881"), "NE", "Not evaluated" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "DateCreated", "Description", "SenderEmail" },
                values: new object[] { new Guid("f7e2edad-0d7a-478e-9fb6-e15e5c9f54d9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a test feedback", "bob.test@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), new Guid("dbedacf4-8c03-440b-a3dc-076fd7a779c9") });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "FileType", "Name", "UploadedDateTime", "UploaderUserId", "Url" },
                values: new object[,]
                {
                    { new Guid("c15a9527-ce53-4938-959f-91fba1f86037"), "image", "Seal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/image/seal-avatar.jpg" },
                    { new Guid("4abde759-cc78-409e-986e-8a9eb08bff7d"), "image", "Lion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/image/lion-avatar.jpg" },
                    { new Guid("4504700e-44c8-4741-87d6-3093a11b0f03"), "image", "Japanese macaque", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/image/japanese-macaque-avatar.jpg" },
                    { new Guid("8c3f3234-142b-47e2-8db2-2b570e003953"), "image", "Warhog", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/image/warhog-avatar-1.jpg" },
                    { new Guid("7eb5a7bf-a5c3-45b6-84f2-5e1bbfc90bde"), "image", "Chimpanzee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/image/chimpanzee-avatar-1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SoundTrack",
                columns: new[] { "Id", "FileName", "FileType", "Name", "Reader", "TimesPlayed", "TrackLength", "UploadedDateTime", "UploaderUserId", "Url" },
                values: new object[,]
                {
                    { new Guid("278a22a3-580e-4b70-8b18-19a6f9d67a00"), null, "mp3", "Seal facts", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(6965), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/grayseal-1.mp3" },
                    { new Guid("ca08cae5-d38c-4194-b850-bc1018268649"), null, "mp3", "Lõvi kirjeldus", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7464), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/lion-1.mp3" },
                    { new Guid("52d30bdc-fb30-40aa-9d6a-a81f7a0dd519"), null, "mp3", "Jaapani makaak 1", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7434), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/japanese-macaque-1.mp3" },
                    { new Guid("ead5bd8a-1535-4661-a477-d9efa39fab30"), null, "mp3", "Jaapani makaak 2", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7452), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/japanese-macaque-2.mp3" },
                    { new Guid("b758d1ae-3c48-4566-a47b-5a0f172c9739"), null, "mp3", "Jaapani makaak 3", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7457), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/japanese-macaque-3.mp3" },
                    { new Guid("8f909c41-a935-4691-97b4-e0d076151e0a"), null, "mp3", "Jaapani makaak 4", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7461), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/japanese-macaque-4.mp3" },
                    { new Guid("4643af16-75e5-47a7-8e22-07dfaec59350"), null, "mp3", "Kuidas rääkida šimpansiga", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7468), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/chimpanzee-1.mp3" },
                    { new Guid("c8481863-0e6c-4fda-b363-ac6d826a010d"), null, "mp3", "Tüügassiga on imeline loom", null, 0, null, new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(7471), new Guid("2fcdd784-1ff2-4e93-9380-36005a9f1328"), "media/audio/warhog-1.mp3" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BinomialName", "ConservationStatusId", "Created", "Description", "FeaturedImgId", "LastEdited", "MapSegmentId", "Name", "ScientificClassificationId" },
                values: new object[,]
                {
                    { new Guid("e24360c3-ef70-443d-bb42-dfc3d790e745"), "Halichoerus grypus", new Guid("78202fb8-b51e-4177-9f68-acb9d3cf6c3d"), new DateTime(2019, 5, 14, 14, 51, 57, 766, DateTimeKind.Local).AddTicks(3752), "Hallhüljes (Halichoerus grypus) on loivaliste (Pinnipedia) seltsi hülglaste (Phocidae) sugukonda kuuluv veeimetaja. Hallhüljes on Läänemere imetajatest suurim [1]. Ta on üks kolmest Eestis elavast hülglasest, omanimelise perekonna ainuliik.", new Guid("c15a9527-ce53-4938-959f-91fba1f86037"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hallhüljes", null },
                    { new Guid("91668f09-7e3b-4b48-9b99-a99ec9bab704"), "Panthera leo", new Guid("922b93a0-f05d-4b82-a4bf-5980d2b1b58a"), new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(5843), "Lõvid on väga suured ja võimsa kehaehitusega. Isaste kehapikkus on 180–240 cm, saba pikkus 60–90 cm, mass 180–227 kg. Kere on sale, isegi kiitsakas. Pea on erakordselt massiivne, võrdlemisi pika koonuga. Jäsemed on lüheldased ja väga tugevad. Pikk saba lõpeb tutiga. Keha katab lühikene pruunikaskollane karvastik. Täiskasvanud isasloomal on pikk tumedam lakk, mis katab nii kaela, õlgu kui ka rinda.", new Guid("4abde759-cc78-409e-986e-8a9eb08bff7d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lõvi", null },
                    { new Guid("8e45bca4-b6db-40c4-a78b-b295b9d3dcd6"), "Macaca fuscata", new Guid("78202fb8-b51e-4177-9f68-acb9d3cf6c3d"), new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(5906), "Jässaka kehaehituse ja tiheda karvakasukaga jaapani makaagid on kõige põhjapoolsema levikuga ahvid. Talvekülmade eest otsivad kaitset kuumaveeallikates. Tegutsevad nii puudel kui maapinnal, ujuvad ja sukelduvad suurepäraselt. Söövad puuvilju, taimede lehti ja juuri, putukaid, limuseid jms, ka pisiimetajaid. Elavad gruppidena, mida juhib tugev isasloom ja kus on selgelt välja kujunenud alluvussuhted. Omavahelisel suhtlemisel on tähtsal kohal häälitsused, miimika ja žestid. Pojad sünnivad enamasti kevad-suvel. Järglaste eest hoolitseb sageli ka isane. Loomaaias on elanud kuni 35 aastat vanaks.", new Guid("4504700e-44c8-4741-87d6-3093a11b0f03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jaapani makaak", null },
                    { new Guid("211634e3-04f7-403e-81ff-c64229036005"), "Phacochoerus africanus", new Guid("78202fb8-b51e-4177-9f68-acb9d3cf6c3d"), new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(5933), "Asustavad savanne ja hõredaid põõsastikke, vältides tihedaid metsi. Elavad rühmades, kuhu kuulu-vad 1–3 emist koos põrsastega. Kuldid hoiavad eraldi. Tegutsevad päeval, veetes öö urus, kuhu täiskasvanud sisenevad tagurpidi, sulgedes uruava oma suure tüükalise peaga. Toituvad rohttaimedest, liikudes ringi poolroomates “põlvili”, esijäsemetel on randmeliigese kohal paksud mõhnad. Sigivad aasta läbi, kuigi enim poegi on vihmaperioodil. Jooksuajal teevad isased mootoripodinat meenutavat häält ja katsuvad rammu, surudes teineteist teelt, laubad vastamisi. Emane sünnitab urus 3–4 vöötideta põrsast.", new Guid("8c3f3234-142b-47e2-8db2-2b570e003953"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tüügassiga", null },
                    { new Guid("f2edd8b2-9c37-49a8-b3ef-6c95559b70aa"), "Pan troglodytes", new Guid("78202fb8-b51e-4177-9f68-acb9d3cf6c3d"), new DateTime(2019, 5, 14, 14, 51, 57, 768, DateTimeKind.Local).AddTicks(5920), "Asustavad metsi, võsastikke ja kohati ka lagedamaid alasid. Tegutsevad nii puudel kui maapinnal. Aktiivsed päeval, ööbivad puude otsa ehitatud pesades. Söövad puuvilju, lehti, seemneid, marju, putukaid. Vahel söövad šimpansid ka liha, püüdes üheskoos saagiks väiksemaid loomi. Elavad 20–30-isendilistes seltsingutes, kus valitseb keeruline võimujaotus. Karjasisestes suhetes on nad väga sallivad, kuid võõrast karjast sissetungijate vastu vaenulikud. Sigivad läbi aasta, pärast 230-päevast tiinust toob emane ilmale 1 poja. Emast võõrdumine algab u. 5. eluaastast. Suguküpsuse saavutavad 12–15-aastastena. Eluiga kuni 50 a. Geneetiliselt on šimpans inimese lähim elav sugulane. Šimpanseid ohustab vihmametsade hävitamine ja salaküttimine.", new Guid("7eb5a7bf-a5c3-45b6-84f2-5e1bbfc90bde"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Šimpans", null }
                });

            migrationBuilder.InsertData(
                table: "AnimalFact",
                columns: new[] { "Id", "AnimalId", "Description", "Label" },
                values: new object[,]
                {
                    { new Guid("4314b535-c9a7-44cb-8cfc-f0ea70d680b1"), new Guid("e24360c3-ef70-443d-bb42-dfc3d790e745"), "Hallhülge eluiga jääb tavaliselt 15–25 aasta vahele. Vanim loodusest leitud isend oli 46-aastane emane.", "Eluiga" },
                    { new Guid("bd2bd2db-91e2-41d5-a962-e6ea70573b6e"), new Guid("e24360c3-ef70-443d-bb42-dfc3d790e745"), "Hallhülge ladinakeelse nimetuse tähendus tuleb kreekakeelsetest sõnadest Halios – meri, khoiros – siga ja grupos – konksnina.", "Nimetus" },
                    { new Guid("50909a13-284e-4557-823c-a408e20155d4"), new Guid("91668f09-7e3b-4b48-9b99-a99ec9bab704"), "Läbi aegade on lõvi peetud loomade kuningaks. See sai alguse raamatust \"Physiologus\".", "Loomade kuningas" }
                });

            migrationBuilder.InsertData(
                table: "MapSegment",
                columns: new[] { "Id", "AnimalId", "AppMapId", "Name" },
                values: new object[,]
                {
                    { new Guid("453ee0f6-78e9-40d6-ba3b-3d8a0640f420"), new Guid("e24360c3-ef70-443d-bb42-dfc3d790e745"), new Guid("4fd691de-e726-42ae-8831-ded116db2e1e"), "Hallhülge bassein" },
                    { new Guid("958d7e70-e7d3-42b3-8c2f-4ed6106d03e2"), new Guid("91668f09-7e3b-4b48-9b99-a99ec9bab704"), new Guid("4fd691de-e726-42ae-8831-ded116db2e1e"), "Lõvipuur" },
                    { new Guid("9cc92bf1-d090-4306-b02c-c9f1da1019dd"), new Guid("8e45bca4-b6db-40c4-a78b-b295b9d3dcd6"), new Guid("4fd691de-e726-42ae-8831-ded116db2e1e"), "Ahvipuur - Jaapani Makaak" },
                    { new Guid("dc6ff54c-1b6d-4378-95e0-3d3aba33cd0e"), new Guid("211634e3-04f7-403e-81ff-c64229036005"), new Guid("4fd691de-e726-42ae-8831-ded116db2e1e"), "Tüügassea aedik" },
                    { new Guid("71d894c6-c0c4-41a5-a192-c6d7850e2ed5"), new Guid("f2edd8b2-9c37-49a8-b3ef-6c95559b70aa"), new Guid("4fd691de-e726-42ae-8831-ded116db2e1e"), "Šimpansite aed" }
                });

            migrationBuilder.InsertData(
                table: "SoundTrackInAnimal",
                columns: new[] { "AnimalId", "SoundTrackId", "Id", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("e24360c3-ef70-443d-bb42-dfc3d790e745"), new Guid("278a22a3-580e-4b70-8b18-19a6f9d67a00"), new Guid("019eed61-5875-4cb1-8c90-594d4986ad75"), true },
                    { new Guid("91668f09-7e3b-4b48-9b99-a99ec9bab704"), new Guid("ca08cae5-d38c-4194-b850-bc1018268649"), new Guid("c5891d55-b656-4b1b-b47e-8cc9543c5f03"), true },
                    { new Guid("8e45bca4-b6db-40c4-a78b-b295b9d3dcd6"), new Guid("52d30bdc-fb30-40aa-9d6a-a81f7a0dd519"), new Guid("842fb276-a826-4fc9-a450-70c156e81c46"), true },
                    { new Guid("8e45bca4-b6db-40c4-a78b-b295b9d3dcd6"), new Guid("ead5bd8a-1535-4661-a477-d9efa39fab30"), new Guid("f487b8fd-5888-4b67-bd88-8ea3083778c2"), false },
                    { new Guid("8e45bca4-b6db-40c4-a78b-b295b9d3dcd6"), new Guid("b758d1ae-3c48-4566-a47b-5a0f172c9739"), new Guid("6e995e97-1f3a-4b12-9b8d-94ff1a0f1cad"), false },
                    { new Guid("8e45bca4-b6db-40c4-a78b-b295b9d3dcd6"), new Guid("8f909c41-a935-4691-97b4-e0d076151e0a"), new Guid("d282ff90-b385-4383-a51e-94f51163a63a"), false },
                    { new Guid("211634e3-04f7-403e-81ff-c64229036005"), new Guid("c8481863-0e6c-4fda-b363-ac6d826a010d"), new Guid("aa973ac9-8645-44fa-aba0-c0ceb2652b2f"), true },
                    { new Guid("f2edd8b2-9c37-49a8-b3ef-6c95559b70aa"), new Guid("4643af16-75e5-47a7-8e22-07dfaec59350"), new Guid("603a21f9-4e5c-46fd-9d75-6e8841e2463c"), true }
                });

            migrationBuilder.InsertData(
                table: "GeoCoordinate",
                columns: new[] { "Id", "Created", "Latitude", "Longitude", "MapSegmentId" },
                values: new object[,]
                {
                    { new Guid("b7337199-1b9e-4c37-9544-7d1165674784"), new DateTime(2019, 5, 14, 14, 51, 57, 769, DateTimeKind.Local).AddTicks(724), 59.451625300000003, 24.717528000000001, new Guid("453ee0f6-78e9-40d6-ba3b-3d8a0640f420") },
                    { new Guid("5eedeba4-6028-4616-9d1d-b8cc9523849f"), new DateTime(2019, 5, 14, 14, 51, 57, 769, DateTimeKind.Local).AddTicks(1215), 59.4514493, 24.717574899999999, new Guid("958d7e70-e7d3-42b3-8c2f-4ed6106d03e2") },
                    { new Guid("e9a1b22a-a7b8-4fc1-bb6f-964edd3242df"), new DateTime(2019, 5, 14, 14, 51, 57, 769, DateTimeKind.Local).AddTicks(1200), 59.451569300000003, 24.717741199999999, new Guid("9cc92bf1-d090-4306-b02c-c9f1da1019dd") },
                    { new Guid("c84aebfd-350b-4935-9d3f-d6330bbc940f"), new DateTime(2019, 5, 14, 14, 51, 57, 769, DateTimeKind.Local).AddTicks(1306), 59.451567400000002, 24.7173722, new Guid("dc6ff54c-1b6d-4378-95e0-3d3aba33cd0e") },
                    { new Guid("2cee4b21-8c16-4e23-9cd9-74cb8cdb0906"), new DateTime(2019, 5, 14, 14, 51, 57, 769, DateTimeKind.Local).AddTicks(1297), 59.451469899999999, 24.717251099999999, new Guid("71d894c6-c0c4-41a5-a192-c6d7850e2ed5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ConservationStatusId",
                table: "Animal",
                column: "ConservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_FeaturedImgId",
                table: "Animal",
                column: "FeaturedImgId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ScientificClassificationId",
                table: "Animal",
                column: "ScientificClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFact_AnimalId",
                table: "AnimalFact",
                column: "AnimalId");

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
                name: "IX_GeoCoordinate_MapSegmentId",
                table: "GeoCoordinate",
                column: "MapSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MapSegment_AnimalId",
                table: "MapSegment",
                column: "AnimalId",
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MapSegment_AppMapId",
                table: "MapSegment",
                column: "AppMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_UploaderUserId",
                table: "Media",
                column: "UploaderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInAnimal_AnimalId",
                table: "MediaInAnimal",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInAnimal_MediaId",
                table: "MediaInAnimal",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_SoundTrack_UploaderUserId",
                table: "SoundTrack",
                column: "UploaderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoundTrackInAnimal_SoundTrackId",
                table: "SoundTrackInAnimal",
                column: "SoundTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusInMapSegment_MapSegmentId",
                table: "StatusInMapSegment",
                column: "MapSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusInMapSegment_StatusId",
                table: "StatusInMapSegment",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalFact");

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
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "GeoCoordinate");

            migrationBuilder.DropTable(
                name: "MediaInAnimal");

            migrationBuilder.DropTable(
                name: "SoundTrackInAnimal");

            migrationBuilder.DropTable(
                name: "StatusInMapSegment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MapSegment");

            migrationBuilder.DropTable(
                name: "SoundTrack");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "AppMap");

            migrationBuilder.DropTable(
                name: "ConservationStatus");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "ScientificClassification");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

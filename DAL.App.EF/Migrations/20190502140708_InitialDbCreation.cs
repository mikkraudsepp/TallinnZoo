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
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    AppMapId = table.Column<Guid>(nullable: false),
                    AnimalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapSegment_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapSegment_AppMap_AppMapId",
                        column: x => x.AppMapId,
                        principalTable: "AppMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AppMap",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1fefc037-df28-4bfe-9f65-65918be312ed"), "Tallinna loomaaia kaart" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cc0e99f5-1b03-424d-bddc-442c361f6fa3"), "2f22a1f7-05e9-401a-bf98-15270b9204f2", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "WorkPosition" },
                values: new object[,]
                {
                    { new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), 0, "b0335a25-326a-4292-8fb7-376cfdc2fc15", "mikkraudsepp@hotmail.com", false, "Mikk", "Raudsepp", false, null, null, null, null, null, false, null, false, null, null },
                    { new Guid("a226d610-1108-408d-ba66-77c69c760466"), 0, "f4c27799-185f-4452-af93-5399be3e2425", "themikkraudsepp@gmail.com", false, "Admin", "Admin", false, null, null, null, null, null, false, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "ConservationStatus",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { new Guid("46470634-c4af-42b9-8eec-8c117a557f50"), "EX", "Extinct" },
                    { new Guid("5e4737fc-82fb-47b5-8337-b6f595ba080e"), "EW", "Extinct in the wild" },
                    { new Guid("613315a8-b6f5-49ec-9583-7d33492e7be3"), "CR", "Critically endangered" },
                    { new Guid("a5ecde65-5848-404a-a6ef-d42bfe4e97dc"), "EN", "Endangered" },
                    { new Guid("a2679cb7-2f56-4913-99cc-4e5d97d3bb38"), "VU", "Vulnerable" },
                    { new Guid("09492d41-c971-443d-8717-a360b38ccb81"), "NT", "Near threatened" },
                    { new Guid("58b8818d-f4d3-4d39-8906-88b79080fd92"), "LC", "Least concern" },
                    { new Guid("74f3d6f7-4f14-42c9-bdeb-1fcb77890a02"), "DD", "Data deficient" },
                    { new Guid("ae5e6d70-4365-448c-8edc-4474562e2ff1"), "NE", "Not evaluated" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "DateCreated", "Description", "SenderEmail" },
                values: new object[] { new Guid("cfc4ec24-6069-4189-9e0c-482849e3fcad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a test feedback", "bob.test@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), new Guid("cc0e99f5-1b03-424d-bddc-442c361f6fa3") });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "FileType", "Name", "UploadedDateTime", "UploaderUserId", "Url" },
                values: new object[,]
                {
                    { new Guid("e0d6dbe3-2fac-45a7-b672-b55e63bb8c45"), "image", "Seal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/image/seal-avatar.jpg" },
                    { new Guid("7d0f2cfb-0c8e-4c00-afe0-28b1ed5a9de1"), "image", "Lion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/image/lion-avatar.jpg" },
                    { new Guid("9a522da8-aef2-4647-bddd-a88153c1738b"), "image", "Japanese macaque", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/image/japanese-macaque-avatar.jpg" },
                    { new Guid("86d1c8bd-f68b-4f9f-84bc-19447bf78c71"), "image", "Warhog", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/image/warhog-avatar-1.jpg" },
                    { new Guid("f249d2ba-5bb4-486d-b0da-c9c0acdac1e3"), "image", "Chimpanzee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/image/chimpanzee-avatar-1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SoundTrack",
                columns: new[] { "Id", "FileName", "FileType", "Name", "Reader", "TimesPlayed", "TrackLength", "UploadedDateTime", "UploaderUserId", "Url" },
                values: new object[,]
                {
                    { new Guid("e167329f-4473-4267-9c5d-3027f01c57ce"), null, "mp3", "Seal facts", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7368), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/grayseal-1.mp3" },
                    { new Guid("cdbfe51d-e9a1-493c-a611-fbfa1d76cbbb"), null, "mp3", "Lõvi kirjeldus", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7828), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/lion-1.mp3" },
                    { new Guid("ae6e2c2c-1e7d-475b-beec-ffb53130757b"), null, "mp3", "Jaapani makaak 1", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7799), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/japanese-macaque-1.mp3" },
                    { new Guid("022c10d3-1ef8-4606-810a-58dd51fe319b"), null, "mp3", "Jaapani makaak 2", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7812), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/japanese-macaque-2.mp3" },
                    { new Guid("889e743b-3ab8-41a9-b7de-1bda37de9bd0"), null, "mp3", "Jaapani makaak 3", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7820), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/japanese-macaque-3.mp3" },
                    { new Guid("67b00230-bbd0-40f5-998b-6b4e7b79f31e"), null, "mp3", "Jaapani makaak 4", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7824), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/japanese-macaque-4.mp3" },
                    { new Guid("4c0154a4-10b5-43c6-ab4a-7b2d4acb638e"), null, "mp3", "Kuidas rääkida simpansiga", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7832), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/chimpanzee-1.mp3" },
                    { new Guid("78829890-edbe-491b-a27d-900f5457606b"), null, "mp3", "Tüügassiga on imeline loom", null, 0, null, new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(7835), new Guid("10f58b68-f85b-4526-988e-5eb132aae5b9"), "media/audio/warhog-1.mp3" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BinomialName", "ConservationStatusId", "Created", "Description", "FeaturedImgId", "LastEdited", "MapSegmentId", "Name", "ScientificClassificationId" },
                values: new object[,]
                {
                    { new Guid("90de391c-a3dc-4aa1-9208-011ef4b6718e"), "Halichoerus grypus", new Guid("58b8818d-f4d3-4d39-8906-88b79080fd92"), new DateTime(2019, 5, 2, 17, 7, 7, 616, DateTimeKind.Local).AddTicks(6572), "Hallhüljes (Halichoerus grypus) on loivaliste (Pinnipedia) seltsi hülglaste (Phocidae) sugukonda kuuluv veeimetaja. Hallhüljes on Läänemere imetajatest suurim [1]. Ta on üks kolmest Eestis elavast hülglasest, omanimelise perekonna ainuliik.", new Guid("e0d6dbe3-2fac-45a7-b672-b55e63bb8c45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hallhüljes", null },
                    { new Guid("3b233f62-c406-4850-bffa-fbb8809b74a8"), "Panthera leo", new Guid("a2679cb7-2f56-4913-99cc-4e5d97d3bb38"), new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(6423), "Lõvid on väga suured ja võimsa kehaehitusega. Isaste kehapikkus on 180–240 cm, saba pikkus 60–90 cm, mass 180–227 kg. Kere on sale, isegi kiitsakas. Pea on erakordselt massiivne, võrdlemisi pika koonuga. Jäsemed on lüheldased ja väga tugevad. Pikk saba lõpeb tutiga. Keha katab lühikene pruunikaskollane karvastik. Täiskasvanud isasloomal on pikk tumedam lakk, mis katab nii kaela, õlgu kui ka rinda.", new Guid("7d0f2cfb-0c8e-4c00-afe0-28b1ed5a9de1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lõvi", null },
                    { new Guid("6c10d341-465a-4fc1-902e-d55f58d57a5a"), "Macaca fuscata", new Guid("58b8818d-f4d3-4d39-8906-88b79080fd92"), new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(6486), "Jässaka kehaehituse ja tiheda karvakasukaga jaapani makaagid on kõige põhjapoolsema levikuga ahvid. Talvekülmade eest otsivad kaitset kuumaveeallikates. Tegutsevad nii puudel kui maapinnal, ujuvad ja sukelduvad suurepäraselt. Söövad puuvilju, taimede lehti ja juuri, putukaid, limuseid jms, ka pisiimetajaid. Elavad gruppidena, mida juhib tugev isasloom ja kus on selgelt välja kujunenud alluvussuhted. Omavahelisel suhtlemisel on tähtsal kohal häälitsused, miimika ja žestid. Pojad sünnivad enamasti kevad-suvel. Järglaste eest hoolitseb sageli ka isane. Loomaaias on elanud kuni 35 aastat vanaks.", new Guid("9a522da8-aef2-4647-bddd-a88153c1738b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jaapani makaak", null },
                    { new Guid("b493b31f-53ea-4ea3-8774-6c31fd5f5694"), "Phacochoerus africanus", new Guid("58b8818d-f4d3-4d39-8906-88b79080fd92"), new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(6513), "Asustavad savanne ja hõredaid põõsastikke, vältides tihedaid metsi. Elavad rühmades, kuhu kuulu-vad 1–3 emist koos põrsastega. Kuldid hoiavad eraldi. Tegutsevad päeval, veetes öö urus, kuhu täiskasvanud sisenevad tagurpidi, sulgedes uruava oma suure tüükalise peaga. Toituvad rohttaimedest, liikudes ringi poolroomates “põlvili”, esijäsemetel on randmeliigese kohal paksud mõhnad. Sigivad aasta läbi, kuigi enim poegi on vihmaperioodil. Jooksuajal teevad isased mootoripodinat meenutavat häält ja katsuvad rammu, surudes teineteist teelt, laubad vastamisi. Emane sünnitab urus 3–4 vöötideta põrsast.", new Guid("86d1c8bd-f68b-4f9f-84bc-19447bf78c71"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tüügassiga", null },
                    { new Guid("75436cc9-9a97-4d75-9037-e714f286d456"), "Pan troglodytes", new Guid("58b8818d-f4d3-4d39-8906-88b79080fd92"), new DateTime(2019, 5, 2, 17, 7, 7, 618, DateTimeKind.Local).AddTicks(6500), "Asustavad metsi, võsastikke ja kohati ka lagedamaid alasid. Tegutsevad nii puudel kui maapinnal. Aktiivsed päeval, ööbivad puude otsa ehitatud pesades. Söövad puuvilju, lehti, seemneid, marju, putukaid. Vahel söövad šimpansid ka liha, püüdes üheskoos saagiks väiksemaid loomi. Elavad 20–30-isendilistes seltsingutes, kus valitseb keeruline võimujaotus. Karjasisestes suhetes on nad väga sallivad, kuid võõrast karjast sissetungijate vastu vaenulikud. Sigivad läbi aasta, pärast 230-päevast tiinust toob emane ilmale 1 poja. Emast võõrdumine algab u. 5. eluaastast. Suguküpsuse saavutavad 12–15-aastastena. Eluiga kuni 50 a. Geneetiliselt on šimpans inimese lähim elav sugulane. Šimpanseid ohustab vihmametsade hävitamine ja salaküttimine.", new Guid("f249d2ba-5bb4-486d-b0da-c9c0acdac1e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Simpans", null }
                });

            migrationBuilder.InsertData(
                table: "AnimalFact",
                columns: new[] { "Id", "AnimalId", "Description", "Label" },
                values: new object[,]
                {
                    { new Guid("f15bcc3a-3b5c-4b23-831d-5dc8b326248e"), new Guid("90de391c-a3dc-4aa1-9208-011ef4b6718e"), "Hallhülge eluiga jääb tavaliselt 15–25 aasta vahele. Vanim loodusest leitud isend oli 46-aastane emane.", "Eluiga" },
                    { new Guid("c32d65a3-d8c8-45f2-82c9-322fe359d177"), new Guid("90de391c-a3dc-4aa1-9208-011ef4b6718e"), "Hallhülge ladinakeelse nimetuse tähendus tuleb kreekakeelsetest sõnadest Halios – meri, khoiros – siga ja grupos – konksnina.", "Nimetus" },
                    { new Guid("a45b72f3-061c-4e33-b2ce-68ebc8161a6b"), new Guid("3b233f62-c406-4850-bffa-fbb8809b74a8"), "Läbi aegade on lõvi peetud loomade kuningaks. See sai alguse raamatust \"Physiologus\".", "Loomade kuningas" }
                });

            migrationBuilder.InsertData(
                table: "MapSegment",
                columns: new[] { "Id", "AnimalId", "AppMapId", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { new Guid("ced5e15e-bfa2-40ca-b69f-dd1af627b2c1"), new Guid("90de391c-a3dc-4aa1-9208-011ef4b6718e"), new Guid("1fefc037-df28-4bfe-9f65-65918be312ed"), 59.451625300000003, 24.717528000000001, "Hallhülge bassein" },
                    { new Guid("dd27b43a-d1d6-4e45-a876-2346d4d02a03"), new Guid("3b233f62-c406-4850-bffa-fbb8809b74a8"), new Guid("1fefc037-df28-4bfe-9f65-65918be312ed"), 59.4514493, 24.717574899999999, "Lõvipuur" },
                    { new Guid("90783308-2044-4dbe-930a-5092798c9932"), new Guid("6c10d341-465a-4fc1-902e-d55f58d57a5a"), new Guid("1fefc037-df28-4bfe-9f65-65918be312ed"), 59.451569300000003, 24.717741199999999, "Ahvipuur - Jaapani Makaak" },
                    { new Guid("1b218311-e37a-4413-9ff8-c31ad5a9b548"), new Guid("b493b31f-53ea-4ea3-8774-6c31fd5f5694"), new Guid("1fefc037-df28-4bfe-9f65-65918be312ed"), 59.451567400000002, 24.7173722, "Tüügassea aedik" },
                    { new Guid("b6ffd553-bc2e-4f4b-a805-be37b36e0f51"), new Guid("75436cc9-9a97-4d75-9037-e714f286d456"), new Guid("1fefc037-df28-4bfe-9f65-65918be312ed"), 59.451469899999999, 24.717251099999999, "Simpansite aed" }
                });

            migrationBuilder.InsertData(
                table: "SoundTrackInAnimal",
                columns: new[] { "AnimalId", "SoundTrackId", "Id", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("90de391c-a3dc-4aa1-9208-011ef4b6718e"), new Guid("e167329f-4473-4267-9c5d-3027f01c57ce"), new Guid("343f8a63-46a4-4916-83f2-859128524f8c"), true },
                    { new Guid("3b233f62-c406-4850-bffa-fbb8809b74a8"), new Guid("cdbfe51d-e9a1-493c-a611-fbfa1d76cbbb"), new Guid("3604a989-676d-4e78-85f5-42e76d8cd4a5"), true },
                    { new Guid("6c10d341-465a-4fc1-902e-d55f58d57a5a"), new Guid("ae6e2c2c-1e7d-475b-beec-ffb53130757b"), new Guid("fa8f4bb9-7401-474d-98c4-f5afca6266b1"), true },
                    { new Guid("6c10d341-465a-4fc1-902e-d55f58d57a5a"), new Guid("022c10d3-1ef8-4606-810a-58dd51fe319b"), new Guid("6d1f32dd-b891-4dab-be2a-83c49ed427cc"), false },
                    { new Guid("6c10d341-465a-4fc1-902e-d55f58d57a5a"), new Guid("889e743b-3ab8-41a9-b7de-1bda37de9bd0"), new Guid("ffceabee-e2b9-47a0-a812-31f70de552b0"), false },
                    { new Guid("6c10d341-465a-4fc1-902e-d55f58d57a5a"), new Guid("67b00230-bbd0-40f5-998b-6b4e7b79f31e"), new Guid("09da8cc2-596b-4921-a668-0b260249348f"), false },
                    { new Guid("b493b31f-53ea-4ea3-8774-6c31fd5f5694"), new Guid("78829890-edbe-491b-a27d-900f5457606b"), new Guid("6bab48f6-1cc2-415c-9008-ec319212bd6b"), true },
                    { new Guid("75436cc9-9a97-4d75-9037-e714f286d456"), new Guid("4c0154a4-10b5-43c6-ab4a-7b2d4acb638e"), new Guid("b0763070-2ebe-4fb8-80b6-d28e516337ec"), true }
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
                name: "IX_MapSegment_AnimalId",
                table: "MapSegment",
                column: "AnimalId",
                unique: true);

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
                name: "MapSegment");

            migrationBuilder.DropTable(
                name: "MediaInAnimal");

            migrationBuilder.DropTable(
                name: "SoundTrackInAnimal");

            migrationBuilder.DropTable(
                name: "StatusInMapSegment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AppMap");

            migrationBuilder.DropTable(
                name: "SoundTrack");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Status");

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

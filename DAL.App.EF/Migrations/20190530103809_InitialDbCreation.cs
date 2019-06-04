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
                    Name = table.Column<string>(maxLength: 80, nullable: false)
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
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultiLangString",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 10240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiLangString", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificClassification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
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
                    Name = table.Column<string>(maxLength: 20, nullable: false)
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
                    Url = table.Column<string>(nullable: false),
                    UploadedDateTime = table.Column<DateTime>(nullable: false),
                    FileType = table.Column<string>(nullable: true),
                    UploaderUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_AspNetUsers_UploaderUserId",
                        column: x => x.UploaderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoundTrack",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Reader = table.Column<string>(nullable: true),
                    TrackLength = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
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
                name: "ConservationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameId = table.Column<Guid>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConservationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConservationStatus_MultiLangString_NameId",
                        column: x => x.NameId,
                        principalTable: "MultiLangString",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(maxLength: 5, nullable: true),
                    Value = table.Column<string>(maxLength: 10240, nullable: true),
                    MultiLangStringId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_MultiLangString_MultiLangStringId",
                        column: x => x.MultiLangStringId,
                        principalTable: "MultiLangString",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameId = table.Column<Guid>(nullable: false),
                    DescriptionId = table.Column<Guid>(nullable: true),
                    BinomialName = table.Column<string>(nullable: true),
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
                        name: "FK_Animal_MultiLangString_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "MultiLangString",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Media_FeaturedImgId",
                        column: x => x.FeaturedImgId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_MultiLangString_NameId",
                        column: x => x.NameId,
                        principalTable: "MultiLangString",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Label = table.Column<string>(maxLength: 25, nullable: false),
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
                    NameId = table.Column<Guid>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_MapSegment_MultiLangString_NameId",
                        column: x => x.NameId,
                        principalTable: "MultiLangString",
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
                values: new object[] { new Guid("d18419f5-19ca-4d3b-a74d-daf44da89934"), "Tallinna loomaaia kaart" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2b913302-415f-4ec2-9c24-82a7bac22eef"), "6cbcc069-e4fa-422a-bbdb-fcf9a6663438", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "WorkPosition" },
                values: new object[,]
                {
                    { new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), 0, "1fcb5843-2914-490d-a317-d8aa8c760336", "mikkraudsepp@hotmail.com", false, "Mikk", "Raudsepp", false, null, null, null, "AQAAAAEAACcQAAAAELI5ojPLGNuB7ry/fu4lOA8nWBb4qT99TB1AVkfmL5AVAbjLDkmV8AtZLZ8XEyEusA==", null, false, null, false, null, null },
                    { new Guid("0894321a-bb5d-436c-beb9-ddecafabac23"), 0, "ee09d5c0-5af4-4b95-a5d5-3ad07db3b50e", "themikkraudsepp@gmail.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEC1WrS6YWn6rSBBvT1BxRFbSoXvtirCPBP7go2hZIrzppOy2TA4+BhE+u4Yk1bHHOg==", null, false, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "DateCreated", "Description", "SenderEmail" },
                values: new object[] { new Guid("ee277506-21b3-41f4-bb30-f12272cc56e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a test feedback", "bob.test@email.com" });

            migrationBuilder.InsertData(
                table: "MultiLangString",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("1282b083-32af-4cc8-9577-96020c7049d1"), "Lõvipuur" },
                    { new Guid("17566ca3-1bfa-4388-a195-a8d2d8081682"), "Ahvipuur - Jaapani Makaak" },
                    { new Guid("365173d7-2339-4722-8236-40845c621858"), "Hallhülge bassein" },
                    { new Guid("2752af18-e1fb-4af8-a287-012bc9babc25"), "Asustavad savanne ja hõredaid põõsastikke, vältides tihedaid metsi. Elavad rühmades, kuhu kuulu-vad 1–3 emist koos põrsastega. Kuldid hoiavad eraldi. Tegutsevad päeval, veetes öö urus, kuhu täiskasvanud sisenevad tagurpidi, sulgedes uruava oma suure tüükalise peaga. Toituvad rohttaimedest, liikudes ringi poolroomates “põlvili”, esijäsemetel on randmeliigese kohal paksud mõhnad. Sigivad aasta läbi, kuigi enim poegi on vihmaperioodil. Jooksuajal teevad isased mootoripodinat meenutavat häält ja katsuvad rammu, surudes teineteist teelt, laubad vastamisi. Emane sünnitab urus 3–4 vöötideta põrsast." },
                    { new Guid("78d439fc-b991-418d-b7c9-9f06a64d32fc"), "Tüügassiga" },
                    { new Guid("70c61e1e-2081-4175-baa7-0e61293e8ed3"), "Asustavad metsi, võsastikke ja kohati ka lagedamaid alasid. Tegutsevad nii puudel kui maapinnal. Aktiivsed päeval, ööbivad puude otsa ehitatud pesades. Söövad puuvilju, lehti, seemneid, marju, putukaid. Vahel söövad šimpansid ka liha, püüdes üheskoos saagiks väiksemaid loomi. Elavad 20–30-isendilistes seltsingutes, kus valitseb keeruline võimujaotus. Karjasisestes suhetes on nad väga sallivad, kuid võõrast karjast sissetungijate vastu vaenulikud. Sigivad läbi aasta, pärast 230-päevast tiinust toob emane ilmale 1 poja. Emast võõrdumine algab u. 5. eluaastast. Suguküpsuse saavutavad 12–15-aastastena. Eluiga kuni 50 a. Geneetiliselt on šimpans inimese lähim elav sugulane. Šimpanseid ohustab vihmametsade hävitamine ja salaküttimine." },
                    { new Guid("a2233944-65a5-4dbd-a10e-76951285e28f"), "Šimpans" },
                    { new Guid("9bffe23d-e223-40f3-acab-8e46733fc5b0"), "Jässaka kehaehituse ja tiheda karvakasukaga jaapani makaagid on kõige põhjapoolsema levikuga ahvid. Talvekülmade eest otsivad kaitset kuumaveeallikates. Tegutsevad nii puudel kui maapinnal, ujuvad ja sukelduvad suurepäraselt. Söövad puuvilju, taimede lehti ja juuri, putukaid, limuseid jms, ka pisiimetajaid. Elavad gruppidena, mida juhib tugev isasloom ja kus on selgelt välja kujunenud alluvussuhted. Omavahelisel suhtlemisel on tähtsal kohal häälitsused, miimika ja žestid. Pojad sünnivad enamasti kevad-suvel. Järglaste eest hoolitseb sageli ka isane. Loomaaias on elanud kuni 35 aastat vanaks." },
                    { new Guid("a1bd7680-cc7a-4728-8138-177d2f8c075a"), "Jaapani makaak" },
                    { new Guid("a204fab0-4e36-49d0-8431-4f7bb8f8dd60"), "Lõvid on väga suured ja võimsa kehaehitusega. Isaste kehapikkus on 180–240 cm, saba pikkus 60–90 cm, mass 180–227 kg. Kere on sale, isegi kiitsakas. Pea on erakordselt massiivne, võrdlemisi pika koonuga. Jäsemed on lüheldased ja väga tugevad. Pikk saba lõpeb tutiga. Keha katab lühikene pruunikaskollane karvastik. Täiskasvanud isasloomal on pikk tumedam lakk, mis katab nii kaela, õlgu kui ka rinda." },
                    { new Guid("953864c7-e5b1-47f5-addd-f1cfa880cd33"), "Lõvi" },
                    { new Guid("90a99419-2008-455f-8cbb-be8ea66a1ec5"), "Määramata" },
                    { new Guid("b9ec0f4d-d0bb-48fd-a2a1-36e86531b4cc"), "Hallhüljes" },
                    { new Guid("0b9ae366-0e78-47cc-a30d-aa2c7d4d57eb"), "Šimpansite aed" },
                    { new Guid("5b65fdaf-5e96-4224-9230-fd1c6bdc3f6c"), "Andmed puudulikud" },
                    { new Guid("17dd693e-a778-446c-a144-58268cd15106"), "Ohuväline" },
                    { new Guid("dabe1fca-51bf-445d-98c1-ba76b81a65ce"), null },
                    { new Guid("b61de002-eb12-4a9b-81c9-c82b5e09427d"), "Ohulähedane" },
                    { new Guid("be367196-fe95-49fd-86b6-d2aafb6f1f6d"), "Ohualdis" },
                    { new Guid("843cadc1-b5ec-4f6f-9eef-ee326a22e8a9"), "Eriti ohustatud" },
                    { new Guid("7de9ce19-9446-48a8-aae7-94b9580adf6f"), "Äärmiselt ohustatud" },
                    { new Guid("802f783e-0f6b-46cd-bd3a-624dd71fd365"), "Looduses välja surnud" },
                    { new Guid("b90153c2-30c6-46fc-b349-98a061d70737"), "Välja surnud" },
                    { new Guid("1a35aea1-d1f2-404f-9aea-057fdb8f46de"), "Hallhüljes (Halichoerus grypus) on loivaliste (Pinnipedia) seltsi hülglaste (Phocidae) sugukonda kuuluv veeimetaja. Hallhüljes on Läänemere imetajatest suurim [1]. Ta on üks kolmest Eestis elavast hülglasest, omanimelise perekonna ainuliik." },
                    { new Guid("0056883d-1d16-4488-9b08-da57588c684c"), "Tüügassea aedik" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), new Guid("2b913302-415f-4ec2-9c24-82a7bac22eef") });

            migrationBuilder.InsertData(
                table: "ConservationStatus",
                columns: new[] { "Id", "Abbreviation", "NameId" },
                values: new object[,]
                {
                    { new Guid("f4d3b9d5-6a59-4585-a376-73c92e72d41c"), "EW", new Guid("802f783e-0f6b-46cd-bd3a-624dd71fd365") },
                    { new Guid("b5aee811-c222-4ecd-9a07-fe185071e0db"), "NE", new Guid("90a99419-2008-455f-8cbb-be8ea66a1ec5") },
                    { new Guid("4d0bf831-8fc8-4068-913f-0dd1d20c76e6"), "DD", new Guid("5b65fdaf-5e96-4224-9230-fd1c6bdc3f6c") },
                    { new Guid("73c49f8c-356a-4e5d-a880-71666e5b4ab6"), "LC", new Guid("17dd693e-a778-446c-a144-58268cd15106") },
                    { new Guid("dabe1fca-51bf-445d-98c1-ba76b81a65ce"), "NT", new Guid("b61de002-eb12-4a9b-81c9-c82b5e09427d") },
                    { new Guid("780dc291-f2b5-4205-9a7b-7d5fe71b0b5d"), "VU", new Guid("be367196-fe95-49fd-86b6-d2aafb6f1f6d") },
                    { new Guid("dab80580-7c4d-4b9d-b587-55a179f9c0d1"), "EN", new Guid("843cadc1-b5ec-4f6f-9eef-ee326a22e8a9") },
                    { new Guid("50d53b38-19fe-49a7-b3b8-7fda571d2dde"), "CR", new Guid("7de9ce19-9446-48a8-aae7-94b9580adf6f") },
                    { new Guid("0b6a01f6-95db-4004-b947-c4f9b4e7a8f4"), "EX", new Guid("b90153c2-30c6-46fc-b349-98a061d70737") }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "FileType", "Name", "UploadedDateTime", "UploaderUserId", "Url" },
                values: new object[,]
                {
                    { new Guid("4d189082-332a-42d9-8bf0-8a1369af2595"), "image", "Seal", new DateTime(2019, 5, 30, 13, 38, 8, 808, DateTimeKind.Local).AddTicks(6471), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/image/seal-avatar.jpg" },
                    { new Guid("a4f5879f-dab4-444f-a5a0-8e07f94cb1d2"), "image", "Lion", new DateTime(2019, 5, 30, 13, 38, 8, 810, DateTimeKind.Local).AddTicks(9621), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/image/lion-avatar.jpg" },
                    { new Guid("2578c833-f359-4e63-883c-dcf8f4403740"), "image", "Japanese macaque", new DateTime(2019, 5, 30, 13, 38, 8, 810, DateTimeKind.Local).AddTicks(9653), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/image/japanese-macaque-avatar.jpg" },
                    { new Guid("a8bdeda0-db5a-46e8-aede-3d1ef4d3a537"), "image", "Warhog", new DateTime(2019, 5, 30, 13, 38, 8, 810, DateTimeKind.Local).AddTicks(9659), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/image/warhog-avatar-1.jpg" },
                    { new Guid("1f0713b8-c4e9-4ebc-a8f6-7fed7cc93aee"), "image", "Chimpanzee", new DateTime(2019, 5, 30, 13, 38, 8, 810, DateTimeKind.Local).AddTicks(9666), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/image/chimpanzee-avatar-1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SoundTrack",
                columns: new[] { "Id", "FileName", "FileType", "Name", "Reader", "TimesPlayed", "TrackLength", "UploadedDateTime", "UploaderUserId", "Url" },
                values: new object[,]
                {
                    { new Guid("448e5bdf-e43f-43ef-a5a3-bd59d3ebf7f9"), null, "mp3", "Kuidas rääkida šimpansiga", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7093), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/chimpanzee-1.mp3" },
                    { new Guid("bcfeb077-6337-422e-ba6b-9d8cfc0a1150"), null, "mp3", "Jaapani makaak 4", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7081), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/japanese-macaque-4.mp3" },
                    { new Guid("e4ae86e6-5880-465b-aa66-cadadd817cac"), null, "mp3", "Lõvi kirjeldus", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7086), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/lion-1.mp3" },
                    { new Guid("c754da9b-74f5-4528-b571-0bb096b7ef0f"), null, "mp3", "Seal facts", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(4972), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/grayseal-1.mp3" },
                    { new Guid("48f37e93-4023-4b41-bc21-af97382ed82b"), null, "mp3", "Jaapani makaak 2", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7064), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/japanese-macaque-2.mp3" },
                    { new Guid("bad860ee-36c0-40c8-b85c-500a8d129d25"), null, "mp3", "Jaapani makaak 3", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7075), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/japanese-macaque-3.mp3" },
                    { new Guid("92228787-d505-4ec9-8deb-b04fdc3f0acf"), null, "mp3", "Tüügassiga on imeline loom", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7100), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/warhog-1.mp3" },
                    { new Guid("9339e128-5847-4cca-9ad7-5748ab7e8fc2"), null, "mp3", "Jaapani makaak 1", null, 0, null, new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(7043), new Guid("fdc54f6e-c086-4649-b957-90c1d75b1416"), "media/audio/japanese-macaque-1.mp3" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Id", "Culture", "MultiLangStringId", "Value" },
                values: new object[,]
                {
                    { new Guid("17cea1fe-98e0-4609-a40a-c1f48c32ec9b"), "en", new Guid("365173d7-2339-4722-8236-40845c621858"), "Gray seal pool" },
                    { new Guid("55186b51-ffa4-404d-8a4c-82b6c9fa4850"), "en", new Guid("17566ca3-1bfa-4388-a195-a8d2d8081682"), "Monkey cage - Japan macaque" },
                    { new Guid("8f7ed301-f264-46ba-b387-4e8e373e4434"), "en", new Guid("2752af18-e1fb-4af8-a287-012bc9babc25"), "Asustavad savanne ja hõredaid põõsastikke, vältides tihedaid metsi. Elavad rühmades, kuhu kuulu-vad 1–3 emist koos põrsastega. Kuldid hoiavad eraldi. Tegutsevad päeval, veetes öö urus, kuhu täiskasvanud sisenevad tagurpidi, sulgedes uruava oma suure tüükalise peaga. Toituvad rohttaimedest, liikudes ringi poolroomates “põlvili”, esijäsemetel on randmeliigese kohal paksud mõhnad. Sigivad aasta läbi, kuigi enim poegi on vihmaperioodil. Jooksuajal teevad isased mootoripodinat meenutavat häält ja katsuvad rammu, surudes teineteist teelt, laubad vastamisi. Emane sünnitab urus 3–4 vöötideta põrsast." },
                    { new Guid("3dcc4efd-097e-4a38-badc-3900a939cd4b"), "en", new Guid("a204fab0-4e36-49d0-8431-4f7bb8f8dd60"), "Lõvid on väga suured ja võimsa kehaehitusega. Isaste kehapikkus on 180–240 cm, saba pikkus 60–90 cm, mass 180–227 kg. Kere on sale, isegi kiitsakas. Pea on erakordselt massiivne, võrdlemisi pika koonuga. Jäsemed on lüheldased ja väga tugevad. Pikk saba lõpeb tutiga. Keha katab lühikene pruunikaskollane karvastik. Täiskasvanud isasloomal on pikk tumedam lakk, mis katab nii kaela, õlgu kui ka rinda." },
                    { new Guid("d72fda2b-a8e2-445a-a177-04b8f523befd"), "en", new Guid("78d439fc-b991-418d-b7c9-9f06a64d32fc"), "Warhog" },
                    { new Guid("80a748f8-a5a5-44f1-96a2-c2a6dc5a07b4"), "en", new Guid("1282b083-32af-4cc8-9577-96020c7049d1"), "Lion cage" },
                    { new Guid("a2f78bc2-b33d-41ee-8c55-412f26b5b855"), "en", new Guid("70c61e1e-2081-4175-baa7-0e61293e8ed3"), "Asustavad metsi, võsastikke ja kohati ka lagedamaid alasid. Tegutsevad nii puudel kui maapinnal. Aktiivsed päeval, ööbivad puude otsa ehitatud pesades. Söövad puuvilju, lehti, seemneid, marju, putukaid. Vahel söövad šimpansid ka liha, püüdes üheskoos saagiks väiksemaid loomi. Elavad 20–30-isendilistes seltsingutes, kus valitseb keeruline võimujaotus. Karjasisestes suhetes on nad väga sallivad, kuid võõrast karjast sissetungijate vastu vaenulikud. Sigivad läbi aasta, pärast 230-päevast tiinust toob emane ilmale 1 poja. Emast võõrdumine algab u. 5. eluaastast. Suguküpsuse saavutavad 12–15-aastastena. Eluiga kuni 50 a. Geneetiliselt on šimpans inimese lähim elav sugulane. Šimpanseid ohustab vihmametsade hävitamine ja salaküttimine." },
                    { new Guid("9bd1023d-d5d2-42c1-8e89-f2d672ab3d77"), "en", new Guid("a2233944-65a5-4dbd-a10e-76951285e28f"), "Chimpanzee" },
                    { new Guid("103310d3-5c54-4479-b0c2-9f1f525e1a3d"), "en", new Guid("9bffe23d-e223-40f3-acab-8e46733fc5b0"), "Jässaka kehaehituse ja tiheda karvakasukaga jaapani makaagid on kõige põhjapoolsema levikuga ahvid. Talvekülmade eest otsivad kaitset kuumaveeallikates. Tegutsevad nii puudel kui maapinnal, ujuvad ja sukelduvad suurepäraselt. Söövad puuvilju, taimede lehti ja juuri, putukaid, limuseid jms, ka pisiimetajaid. Elavad gruppidena, mida juhib tugev isasloom ja kus on selgelt välja kujunenud alluvussuhted. Omavahelisel suhtlemisel on tähtsal kohal häälitsused, miimika ja žestid. Pojad sünnivad enamasti kevad-suvel. Järglaste eest hoolitseb sageli ka isane. Loomaaias on elanud kuni 35 aastat vanaks." },
                    { new Guid("af212ce5-8261-4366-8c1f-72818abb211f"), "en", new Guid("a1bd7680-cc7a-4728-8138-177d2f8c075a"), "Japanese macaque" },
                    { new Guid("91a0c1ff-24e7-40d5-9d5d-0ec7fdee9e0d"), "en", new Guid("953864c7-e5b1-47f5-addd-f1cfa880cd33"), "Lion" },
                    { new Guid("d5b3357a-8b9f-4c35-af5e-ec1763842819"), "en", new Guid("be367196-fe95-49fd-86b6-d2aafb6f1f6d"), "Vulnerable" },
                    { new Guid("9c0b637a-bc56-465f-ad75-3441c1c2044b"), "en", new Guid("b9ec0f4d-d0bb-48fd-a2a1-36e86531b4cc"), "Gray seal" },
                    { new Guid("f556338c-5733-452f-aeed-9af2df8419da"), "en", new Guid("90a99419-2008-455f-8cbb-be8ea66a1ec5"), "Not evaluated" },
                    { new Guid("00a2e27b-3340-415e-9d15-e69436fd8d24"), "en", new Guid("5b65fdaf-5e96-4224-9230-fd1c6bdc3f6c"), "Data deficient" },
                    { new Guid("bb07f445-a8bc-494e-b9e3-22e14b287839"), "en", new Guid("17dd693e-a778-446c-a144-58268cd15106"), "Least concern" },
                    { new Guid("90276a8e-eca7-4563-9e46-231d518b8d7a"), "en", new Guid("b61de002-eb12-4a9b-81c9-c82b5e09427d"), "Near threatened" },
                    { new Guid("cd3112f8-4896-4d43-bd49-21fac33408fa"), "en", new Guid("0b9ae366-0e78-47cc-a30d-aa2c7d4d57eb"), "Chimpanzee fence" },
                    { new Guid("b96d4118-d796-4da5-b171-2894e03080a2"), "en", new Guid("843cadc1-b5ec-4f6f-9eef-ee326a22e8a9"), "Endangered" },
                    { new Guid("d0e2840d-7b96-4888-a688-9cd54f935e4e"), "en", new Guid("7de9ce19-9446-48a8-aae7-94b9580adf6f"), "Critically endangered" },
                    { new Guid("2a1e0740-1287-4315-bc69-2b34cfe1f297"), "en", new Guid("802f783e-0f6b-46cd-bd3a-624dd71fd365"), "Extinct in the wild" },
                    { new Guid("578cebbc-bac4-4b38-aa0d-32ac0739bcb8"), "en", new Guid("b90153c2-30c6-46fc-b349-98a061d70737"), "Extinct" },
                    { new Guid("2dc30082-5f4d-44de-9ab1-6f36d7c3172c"), "en", new Guid("1a35aea1-d1f2-404f-9aea-057fdb8f46de"), "Hallhüljes (Halichoerus grypus) on loivaliste (Pinnipedia) seltsi hülglaste (Phocidae) sugukonda kuuluv veeimetaja. Hallhüljes on Läänemere imetajatest suurim [1]. Ta on üks kolmest Eestis elavast hülglasest, omanimelise perekonna ainuliik." },
                    { new Guid("92d24e6c-5430-44f4-b30e-10d6ad8711c1"), "en", new Guid("0056883d-1d16-4488-9b08-da57588c684c"), "Warhog pen" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BinomialName", "ConservationStatusId", "Created", "DescriptionId", "FeaturedImgId", "LastEdited", "MapSegmentId", "NameId", "ScientificClassificationId" },
                values: new object[,]
                {
                    { new Guid("cdd01034-b6e4-464f-acc7-018c6dd6a528"), "Panthera leo", new Guid("780dc291-f2b5-4205-9a7b-7d5fe71b0b5d"), new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(1350), new Guid("a204fab0-4e36-49d0-8431-4f7bb8f8dd60"), new Guid("a4f5879f-dab4-444f-a5a0-8e07f94cb1d2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("953864c7-e5b1-47f5-addd-f1cfa880cd33"), null },
                    { new Guid("a9b70d38-f88c-473f-a915-da3a79e1bd32"), "Halichoerus grypus", new Guid("73c49f8c-356a-4e5d-a880-71666e5b4ab6"), new DateTime(2019, 5, 30, 13, 38, 8, 811, DateTimeKind.Local).AddTicks(1393), new Guid("1a35aea1-d1f2-404f-9aea-057fdb8f46de"), new Guid("4d189082-332a-42d9-8bf0-8a1369af2595"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b9ec0f4d-d0bb-48fd-a2a1-36e86531b4cc"), null },
                    { new Guid("32770294-faaf-4b95-8e4c-94a7116b7857"), "Macaca fuscata", new Guid("73c49f8c-356a-4e5d-a880-71666e5b4ab6"), new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(1537), new Guid("9bffe23d-e223-40f3-acab-8e46733fc5b0"), new Guid("2578c833-f359-4e63-883c-dcf8f4403740"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a1bd7680-cc7a-4728-8138-177d2f8c075a"), null },
                    { new Guid("b05520b0-86f3-45a9-b921-a961a3b43cc2"), "Pan troglodytes", new Guid("73c49f8c-356a-4e5d-a880-71666e5b4ab6"), new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(1614), new Guid("70c61e1e-2081-4175-baa7-0e61293e8ed3"), new Guid("1f0713b8-c4e9-4ebc-a8f6-7fed7cc93aee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a2233944-65a5-4dbd-a10e-76951285e28f"), null },
                    { new Guid("f2fd2868-6a30-42fd-9ed4-b06f158a2ac5"), "Phacochoerus africanus", new Guid("73c49f8c-356a-4e5d-a880-71666e5b4ab6"), new DateTime(2019, 5, 30, 13, 38, 8, 812, DateTimeKind.Local).AddTicks(1679), new Guid("2752af18-e1fb-4af8-a287-012bc9babc25"), new Guid("a8bdeda0-db5a-46e8-aede-3d1ef4d3a537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("78d439fc-b991-418d-b7c9-9f06a64d32fc"), null }
                });

            migrationBuilder.InsertData(
                table: "AnimalFact",
                columns: new[] { "Id", "AnimalId", "Description", "Label" },
                values: new object[,]
                {
                    { new Guid("43f365f7-c86d-4c09-92d3-bcff1d8219bc"), new Guid("cdd01034-b6e4-464f-acc7-018c6dd6a528"), "Läbi aegade on lõvi peetud loomade kuningaks. See sai alguse raamatust \"Physiologus\".", "Loomade kuningas" },
                    { new Guid("0e1d531b-f935-43e6-975c-901032182137"), new Guid("a9b70d38-f88c-473f-a915-da3a79e1bd32"), "Hallhülge eluiga jääb tavaliselt 15–25 aasta vahele. Vanim loodusest leitud isend oli 46-aastane emane.", "Eluiga" },
                    { new Guid("c6e7058c-2db4-477e-8255-55b70a0421ae"), new Guid("a9b70d38-f88c-473f-a915-da3a79e1bd32"), "Hallhülge ladinakeelse nimetuse tähendus tuleb kreekakeelsetest sõnadest Halios – meri, khoiros – siga ja grupos – konksnina.", "Nimetus" }
                });

            migrationBuilder.InsertData(
                table: "MapSegment",
                columns: new[] { "Id", "AnimalId", "AppMapId", "NameId" },
                values: new object[,]
                {
                    { new Guid("44c969b4-9797-416e-8fa4-fd22a162aa0c"), new Guid("cdd01034-b6e4-464f-acc7-018c6dd6a528"), new Guid("d18419f5-19ca-4d3b-a74d-daf44da89934"), new Guid("1282b083-32af-4cc8-9577-96020c7049d1") },
                    { new Guid("2e2eab20-6483-4661-9a01-93443e9432a7"), new Guid("a9b70d38-f88c-473f-a915-da3a79e1bd32"), new Guid("d18419f5-19ca-4d3b-a74d-daf44da89934"), new Guid("365173d7-2339-4722-8236-40845c621858") },
                    { new Guid("8e6c2633-e92f-457b-a0b8-fceaaabbaf0d"), new Guid("32770294-faaf-4b95-8e4c-94a7116b7857"), new Guid("d18419f5-19ca-4d3b-a74d-daf44da89934"), new Guid("17566ca3-1bfa-4388-a195-a8d2d8081682") },
                    { new Guid("1fd771ee-b64b-451a-9d50-7b3cfc451ec3"), new Guid("b05520b0-86f3-45a9-b921-a961a3b43cc2"), new Guid("d18419f5-19ca-4d3b-a74d-daf44da89934"), new Guid("0b9ae366-0e78-47cc-a30d-aa2c7d4d57eb") },
                    { new Guid("04f5b970-5df7-41ca-9db1-3880d64b539f"), new Guid("f2fd2868-6a30-42fd-9ed4-b06f158a2ac5"), new Guid("d18419f5-19ca-4d3b-a74d-daf44da89934"), new Guid("0056883d-1d16-4488-9b08-da57588c684c") }
                });

            migrationBuilder.InsertData(
                table: "SoundTrackInAnimal",
                columns: new[] { "AnimalId", "SoundTrackId", "Id", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("cdd01034-b6e4-464f-acc7-018c6dd6a528"), new Guid("e4ae86e6-5880-465b-aa66-cadadd817cac"), new Guid("da6eef37-6652-4ddd-a2d5-657076dedab9"), true },
                    { new Guid("a9b70d38-f88c-473f-a915-da3a79e1bd32"), new Guid("c754da9b-74f5-4528-b571-0bb096b7ef0f"), new Guid("09ed8c77-5f39-4f6e-8b50-6e676063db03"), true },
                    { new Guid("32770294-faaf-4b95-8e4c-94a7116b7857"), new Guid("9339e128-5847-4cca-9ad7-5748ab7e8fc2"), new Guid("4bca50ae-25f3-4a7b-9ed6-8ae3d1e36114"), true },
                    { new Guid("32770294-faaf-4b95-8e4c-94a7116b7857"), new Guid("48f37e93-4023-4b41-bc21-af97382ed82b"), new Guid("afb40cad-05a8-4480-a011-38e9f923fde1"), false },
                    { new Guid("32770294-faaf-4b95-8e4c-94a7116b7857"), new Guid("bad860ee-36c0-40c8-b85c-500a8d129d25"), new Guid("3b47aec1-d566-47c8-8873-76ee3beaaf39"), false },
                    { new Guid("32770294-faaf-4b95-8e4c-94a7116b7857"), new Guid("bcfeb077-6337-422e-ba6b-9d8cfc0a1150"), new Guid("2e596d22-a575-4396-aa4c-a7c65c2ea99f"), false },
                    { new Guid("b05520b0-86f3-45a9-b921-a961a3b43cc2"), new Guid("448e5bdf-e43f-43ef-a5a3-bd59d3ebf7f9"), new Guid("256acd8c-1018-49fd-9f59-f72721f0f6e7"), true },
                    { new Guid("f2fd2868-6a30-42fd-9ed4-b06f158a2ac5"), new Guid("92228787-d505-4ec9-8deb-b04fdc3f0acf"), new Guid("eca17f60-eefd-4bad-b847-e584fd158bec"), true }
                });

            migrationBuilder.InsertData(
                table: "GeoCoordinate",
                columns: new[] { "Id", "Created", "Latitude", "Longitude", "MapSegmentId" },
                values: new object[,]
                {
                    { new Guid("a15fad4d-fe58-42a8-b2bc-337da12a5764"), new DateTime(2019, 5, 30, 13, 38, 8, 813, DateTimeKind.Local).AddTicks(9982), 59.4514493, 24.717574899999999, new Guid("44c969b4-9797-416e-8fa4-fd22a162aa0c") },
                    { new Guid("912fa574-ab18-45e3-8077-07851cd4e10c"), new DateTime(2019, 5, 30, 13, 38, 8, 813, DateTimeKind.Local).AddTicks(8241), 59.451625300000003, 24.717528000000001, new Guid("2e2eab20-6483-4661-9a01-93443e9432a7") },
                    { new Guid("c0246b32-f0b5-435b-af7b-53d40d1f7d56"), new DateTime(2019, 5, 30, 13, 38, 8, 813, DateTimeKind.Local).AddTicks(9926), 59.451569300000003, 24.717741199999999, new Guid("8e6c2633-e92f-457b-a0b8-fceaaabbaf0d") },
                    { new Guid("2a6e1be2-ba6b-4076-adc0-d9352e294e57"), new DateTime(2019, 5, 30, 13, 38, 8, 814, DateTimeKind.Local).AddTicks(20), 59.451469899999999, 24.717251099999999, new Guid("1fd771ee-b64b-451a-9d50-7b3cfc451ec3") },
                    { new Guid("d8df83d6-6f1c-4812-b6db-64b9e8ac8905"), new DateTime(2019, 5, 30, 13, 38, 8, 814, DateTimeKind.Local).AddTicks(56), 59.451567400000002, 24.7173722, new Guid("04f5b970-5df7-41ca-9db1-3880d64b539f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ConservationStatusId",
                table: "Animal",
                column: "ConservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_DescriptionId",
                table: "Animal",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_FeaturedImgId",
                table: "Animal",
                column: "FeaturedImgId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_NameId",
                table: "Animal",
                column: "NameId");

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
                name: "IX_ConservationStatus_NameId",
                table: "ConservationStatus",
                column: "NameId");

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
                name: "IX_MapSegment_NameId",
                table: "MapSegment",
                column: "NameId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Translation_MultiLangStringId",
                table: "Translation",
                column: "MultiLangStringId");
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
                name: "Translation");

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
                name: "MultiLangString");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

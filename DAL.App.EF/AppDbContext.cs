using System;
using Contracts.DAL.Base;
using Domain;
using Domain.Animals;
using Domain.Identity;
using Domain.Map;
using Domain._Shared.Statuses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IDataContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<StatusInMapSegment> StatusInMapSegment { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<ConservationStatus> ConservationStatus { get; set; }
        public DbSet<ScientificClassification> ScientificClassification { get; set; }
        public DbSet<AnimalFact> AnimalFact { get; set; }
        public DbSet<AppMap> AppMap { get; set; }
        public DbSet<MapSegment> MapSegment { get; set; }
        public DbSet<GeoCoordinate> GeoCoordinate { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaInAnimal> MediaInAnimal { get; set; }
        public DbSet<SoundTrack> SoundTrack { get; set; }
        public DbSet<SoundTrackInAnimal> SoundTrackInAnimal { get; set; }

        //ADD MIGRATION
        //dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp

        //APPLY MIGRATION
        //dotnet ef database update --project DAL.App.EF --startup-project WebApp

        //DELETE MIGRATIONS FOLDER
        //dotnet ef database drop --project DAL.App.EF --startup-project WebApp

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.MapSegment)
                .WithOne(a => a.Animal)
                .HasForeignKey<MapSegment>(c => c.AnimalId);
            
            /* AnimalInSoundtrack mapping */

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasKey(sa => new {sa.AnimalId, sa.SoundTrackId});

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasOne(sa => sa.Animal)
                .WithMany(a => a.AnimalSoundTracks)
                .HasForeignKey(sa => sa.AnimalId);

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasOne(sa => sa.SoundTrack)
                .WithMany(s => s.AnimalSoundtracks)
                .HasForeignKey(sa => sa.SoundTrackId);
            

            #region Databse seeding

            var identityRoleAdmin = new AppRole()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "Admin"
            };
            
            modelBuilder.Entity<AppRole>()
                .HasData(
                    identityRoleAdmin
                );
            
            var superAdminUser = new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mikk",
                LastName = "Raudsepp",
                Email = "mikkraudsepp@hotmail.com"
            };

            var adminUser = new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "Admin",
                Email = "themikkraudsepp@gmail.com"
            };

            modelBuilder.Entity<AppUser>()
                .HasData(
                    superAdminUser,
                    adminUser
                );
            
         
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = identityRoleAdmin.Id,
                UserId = superAdminUser.Id
            });
            
            modelBuilder.Entity<Feedback>()
                .HasData(new Feedback
                    {
                        Id = Guid.NewGuid(),
                        Description = "This is a test feedback",
                        DateCreated = new DateTime(),
                        SenderEmail = "bob.test@email.com"
                    }
                );

            var extinct = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Extinct",
                Abbreviation = "EX"
            };

            var extinctInTheWild = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Extinct in the wild",
                Abbreviation = "EW"
            };

            var criticallyEndangered = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Critically endangered",
                Abbreviation = "CR"
            };

            var endangered = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Endangered",
                Abbreviation = "EN"
            };

            var vulnerable = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Vulnerable",
                Abbreviation = "VU"
            };

            var nearThreatened = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Near threatened",
                Abbreviation = "NT"
            };

            var leastConcerned = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Least concern",
                Abbreviation = "LC"
            };

            var dataDeficient = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Data deficient",
                Abbreviation = "DD"
            };

            var notEvaluated = new ConservationStatus
            {
                Id = Guid.NewGuid(),
                Name = "Not evaluated",
                Abbreviation = "NE"
            };

            modelBuilder.Entity<ConservationStatus>()
                .HasData(
                    extinct,
                    extinctInTheWild,
                    criticallyEndangered,
                    endangered,
                    vulnerable,
                    nearThreatened,
                    leastConcerned,
                    dataDeficient,
                    notEvaluated
                );

            var sealAvatarImg = new Media()
            {
                Id = Guid.NewGuid(),
                UploaderUserId = superAdminUser.Id,
                Name = "Seal",
                Url = "media/image/seal-avatar.jpg",
                FileType = "image"
            };

            var lionAvatarImg = new Media()
            {
                Id = Guid.NewGuid(),
                UploaderUserId = superAdminUser.Id,
                Name = "Lion",
                Url = "media/image/lion-avatar.jpg",
                FileType = "image"
            };

            var japaneseMacaqueAvatarImg = new Media()
            {
                Id = Guid.NewGuid(),
                UploaderUserId = superAdminUser.Id,
                Name = "Japanese macaque",
                Url = "media/image/japanese-macaque-avatar.jpg",
                FileType = "image"
            };
            
            var warhogAvatarImg = new Media()
            {
                Id = Guid.NewGuid(),
                UploaderUserId = superAdminUser.Id,
                Name = "Warhog",
                Url = "media/image/warhog-avatar-1.jpg",
                FileType = "image"
            };
            
            var chimpanzeeAvatarImg = new Media()
            {
                Id = Guid.NewGuid(),
                UploaderUserId = superAdminUser.Id,
                Name = "Chimpanzee",
                Url = "media/image/chimpanzee-avatar-1.jpg",
                FileType = "image"
            };
            
            modelBuilder.Entity<Media>()
                .HasData(
                    sealAvatarImg,
                    lionAvatarImg,
                    japaneseMacaqueAvatarImg,
                    warhogAvatarImg,
                    chimpanzeeAvatarImg
                );

            var graySeal = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Hallhüljes",
                BinomialName = "Halichoerus grypus",
                FeaturedImgId = sealAvatarImg.Id,
                Description =
                    "Hallhüljes (Halichoerus grypus) on loivaliste (Pinnipedia) seltsi hülglaste (Phocidae) sugukonda kuuluv veeimetaja. Hallhüljes on Läänemere imetajatest suurim [1]. Ta on üks kolmest Eestis elavast hülglasest, omanimelise perekonna ainuliik.",
                ConservationStatusId = leastConcerned.Id
            };

            modelBuilder.Entity<Animal>()
                .HasData(
                    graySeal
                );

            var graySealFact1 = new AnimalFact()
            {
                Id = Guid.NewGuid(),
                Label = "Eluiga",
                Description =
                    "Hallhülge eluiga jääb tavaliselt 15–25 aasta vahele. Vanim loodusest leitud isend oli 46-aastane emane.",
                AnimalId = graySeal.Id
            };

            var graySealFact2 = new AnimalFact()
            {
                Id = Guid.NewGuid(),
                Label = "Nimetus",
                Description =
                    "Hallhülge ladinakeelse nimetuse tähendus tuleb kreekakeelsetest sõnadest Halios – meri, khoiros – siga ja grupos – konksnina.",
                AnimalId = graySeal.Id
            };

            modelBuilder.Entity<AnimalFact>()
                .HasData(
                    graySealFact1,
                    graySealFact2
                );

            var lion = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Lõvi",
                BinomialName = "Panthera leo",
                FeaturedImgId = lionAvatarImg.Id,
                Description =
                    "Lõvid on väga suured ja võimsa kehaehitusega. Isaste kehapikkus on 180–240 cm, saba pikkus 60–90 cm, mass 180–227 kg. Kere on sale, isegi kiitsakas. Pea on erakordselt massiivne, võrdlemisi pika koonuga. Jäsemed on lüheldased ja väga tugevad. Pikk saba lõpeb tutiga. Keha katab lühikene pruunikaskollane karvastik. Täiskasvanud isasloomal on pikk tumedam lakk, mis katab nii kaela, õlgu kui ka rinda.",
                ConservationStatusId = vulnerable.Id
            };

            modelBuilder.Entity<Animal>()
                .HasData(
                    lion
                );

            var lionFact1 = new AnimalFact()
            {
                Id = Guid.NewGuid(),
                Label = "Loomade kuningas",
                Description = "Läbi aegade on lõvi peetud loomade kuningaks. See sai alguse raamatust \"Physiologus\".",
                AnimalId = lion.Id
            };

            modelBuilder.Entity<AnimalFact>()
                .HasData(
                    lionFact1
                );

            var japaneseMacaque = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Jaapani makaak",
                BinomialName = "Macaca fuscata",
                FeaturedImgId = japaneseMacaqueAvatarImg.Id,
                Description =
                    "Jässaka kehaehituse ja tiheda karvakasukaga jaapani makaagid on kõige põhjapoolsema levikuga ahvid. Talvekülmade eest otsivad kaitset kuumaveeallikates. Tegutsevad nii puudel kui maapinnal, ujuvad ja sukelduvad suurepäraselt. Söövad puuvilju, taimede lehti ja juuri, putukaid, limuseid jms, ka pisiimetajaid. Elavad gruppidena, mida juhib tugev isasloom ja kus on selgelt välja kujunenud alluvussuhted. Omavahelisel suhtlemisel on tähtsal kohal häälitsused, miimika ja žestid. Pojad sünnivad enamasti kevad-suvel. Järglaste eest hoolitseb sageli ka isane. Loomaaias on elanud kuni 35 aastat vanaks.",
                ConservationStatusId = leastConcerned.Id
            };

            modelBuilder.Entity<Animal>()
                .HasData(
                    japaneseMacaque
                );
            
            var chimpanzee = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Šimpans",
                BinomialName = "Pan troglodytes",
                FeaturedImgId = chimpanzeeAvatarImg.Id,
                Description =
                    "Asustavad metsi, võsastikke ja kohati ka lagedamaid alasid. Tegutsevad nii puudel kui maapinnal. Aktiivsed päeval, ööbivad puude otsa ehitatud pesades. Söövad puuvilju, lehti, seemneid, marju, putukaid. Vahel söövad šimpansid ka liha, püüdes üheskoos saagiks väiksemaid loomi. Elavad 20–30-isendilistes seltsingutes, kus valitseb keeruline võimujaotus. Karjasisestes suhetes on nad väga sallivad, kuid võõrast karjast sissetungijate vastu vaenulikud. Sigivad läbi aasta, pärast 230-päevast tiinust toob emane ilmale 1 poja. Emast võõrdumine algab u. 5. eluaastast. Suguküpsuse saavutavad 12–15-aastastena. Eluiga kuni 50 a. Geneetiliselt on šimpans inimese lähim elav sugulane. Šimpanseid ohustab vihmametsade hävitamine ja salaküttimine.",
                ConservationStatusId = leastConcerned.Id
            };

            modelBuilder.Entity<Animal>()
                .HasData(
                    chimpanzee
                );
            
            var warhog = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Tüügassiga",
                BinomialName = "Phacochoerus africanus",
                FeaturedImgId = warhogAvatarImg.Id,
                Description =
                    "Asustavad savanne ja hõredaid põõsastikke, vältides tihedaid metsi. Elavad rühmades, kuhu kuulu-vad 1–3 emist koos põrsastega. Kuldid hoiavad eraldi. Tegutsevad päeval, veetes öö urus, kuhu täiskasvanud sisenevad tagurpidi, sulgedes uruava oma suure tüükalise peaga. Toituvad rohttaimedest, liikudes ringi poolroomates “põlvili”, esijäsemetel on randmeliigese kohal paksud mõhnad. Sigivad aasta läbi, kuigi enim poegi on vihmaperioodil. Jooksuajal teevad isased mootoripodinat meenutavat häält ja katsuvad rammu, surudes teineteist teelt, laubad vastamisi. Emane sünnitab urus 3–4 vöötideta põrsast.",
                ConservationStatusId = leastConcerned.Id
            };

            modelBuilder.Entity<Animal>()
                .HasData(
                    warhog
                );

            var graySealAudio = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Seal facts",
                Url = "media/audio/grayseal-1.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };

            var japaneseMacaqueAudio = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Jaapani makaak 1",
                Url = "media/audio/japanese-macaque-1.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };
            
            var japaneseMacaqueAudio2 = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Jaapani makaak 2",
                Url = "media/audio/japanese-macaque-2.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };
            
            var japaneseMacaqueAudio3 = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Jaapani makaak 3",
                Url = "media/audio/japanese-macaque-3.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };
            
            var japaneseMacaqueAudio4 = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Jaapani makaak 4",
                Url = "media/audio/japanese-macaque-4.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };

            var lionAudio = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Lõvi kirjeldus",
                Url = "media/audio/lion-1.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };
            
            var chimpanzeeAudio = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Kuidas rääkida šimpansiga",
                Url = "media/audio/chimpanzee-1.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };
            
            var warhogAudio = new SoundTrack()
            {
                Id = Guid.NewGuid(),
                Name = "Tüügassiga on imeline loom",
                Url = "media/audio/warhog-1.mp3",
                UploaderUserId = superAdminUser.Id,
                UploadedDateTime = DateTime.Now,
                FileType = "mp3"
            };

            modelBuilder.Entity<SoundTrack>()
                .HasData(
                    graySealAudio,
                    lionAudio,
                    japaneseMacaqueAudio,
                    japaneseMacaqueAudio2,
                    japaneseMacaqueAudio3,
                    japaneseMacaqueAudio4,
                    chimpanzeeAudio,
                    warhogAudio
                );

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = graySeal.Id,
                        SoundTrackId = graySealAudio.Id,
                        IsFeatured = true
                    }
                );

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = lion.Id,
                        SoundTrackId = lionAudio.Id,
                        IsFeatured = true
                    }
                );

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = japaneseMacaque.Id,
                        SoundTrackId = japaneseMacaqueAudio.Id,
                        IsFeatured = true
                    }
                );
            
            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = japaneseMacaque.Id,
                        SoundTrackId = japaneseMacaqueAudio2.Id,
                        IsFeatured = false
                    }
                );

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = japaneseMacaque.Id,
                        SoundTrackId = japaneseMacaqueAudio3.Id,
                        IsFeatured = false
                    }
                );

            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = japaneseMacaque.Id,
                        SoundTrackId = japaneseMacaqueAudio4.Id,
                        IsFeatured = false
                    }
                );
            
            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = chimpanzee.Id,
                        SoundTrackId = chimpanzeeAudio.Id,
                        IsFeatured = true
                    }
                );
            
            modelBuilder.Entity<SoundTrackInAnimal>()
                .HasData(new SoundTrackInAnimal
                    {
                        Id = Guid.NewGuid(),
                        AnimalId = warhog.Id,
                        SoundTrackId = warhogAudio.Id,
                        IsFeatured = true
                    }
                );
            
            var appMap = new AppMap()
            {
                Id = Guid.NewGuid(),
                Name = "Tallinna loomaaia kaart"
            };
            
//Google maps coordinates
//            var mapSegmenent1 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Hallhülge bassein",
//                Latitude = 59.451646,
//                Longitude = 24.717348,
//                AnimalId = graySeal.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent2 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Ahvipuur - Jaapani Makaak",
//                Latitude = 59.451554,
//                Longitude = 24.717615,
//                AnimalId = japaneseMacaque.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent3 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Lõvipuur",
//                Latitude = 59.451427,
//                Longitude = 24.717456,
//                AnimalId = lion.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent4 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Šimpansite aed",
//                Latitude = 59.451486,
//                Longitude = 24.717137,
//                AnimalId = chimpanzee.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent5 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Tüügassea aedik",
//                Latitude = 59.451582,
//                Longitude = 24.717265,
//                AnimalId = warhog.Id,
//                AppMapId = appMap.Id
//            };


//Test 1
//            var mapSegmenent1 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Hallhülge bassein",
//                Latitude = 59.4516783,
//                Longitude = 24.7175138,
//                AnimalId = graySeal.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent2 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Ahvipuur - Jaapani Makaak",
//                Latitude = 59.451577,
//                Longitude = 24.7178677,
//                AnimalId = japaneseMacaque.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent3 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Lõvipuur",
//                Latitude = 59.4514222,
//                Longitude = 24.7175905,
//                AnimalId = lion.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent4 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Šimpansite aed",
//                Latitude = 59.4515003,
//                Longitude = 24.7172726,
//                AnimalId = chimpanzee.Id,
//                AppMapId = appMap.Id
//            };
//            
//            var mapSegmenent5 = new MapSegment()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Tüügassea aedik",
//                Latitude = 59.4516211,
//                Longitude = 24.7173995,
//                AnimalId = warhog.Id,
//                AppMapId = appMap.Id
//            };
            
//Test 2

            
            var mapSegment1 = new MapSegment()
            {
                Id = Guid.NewGuid(),
                Name = "Hallhülge bassein",
                AnimalId = graySeal.Id,
                AppMapId = appMap.Id
            };
            
            var geoCoordinate1 = new GeoCoordinate()
            {
                Id = Guid.NewGuid(),
                Latitude = 59.4516253,
                Longitude = 24.717528,
                Created = DateTime.Now,
                MapSegmentId = mapSegment1.Id
            };
            
            var mapSegment2 = new MapSegment()
            {
                Id = Guid.NewGuid(),
                Name = "Ahvipuur - Jaapani Makaak",
                AnimalId = japaneseMacaque.Id,
                AppMapId = appMap.Id
            };
            
            var geoCoordinate2 = new GeoCoordinate()
            {
                Id = Guid.NewGuid(),
                Latitude = 59.4515693,
                Longitude = 24.7177412,
                Created = DateTime.Now,
                MapSegmentId = mapSegment2.Id
            };
            
            var mapSegment3 = new MapSegment()
            {
                Id = Guid.NewGuid(),
                Name = "Lõvipuur",
                AnimalId = lion.Id,
                AppMapId = appMap.Id
            };
            
            var geoCoordinate3 = new GeoCoordinate()
            {
                Id = Guid.NewGuid(),
                Latitude = 59.4514493,
                Longitude = 24.7175749,
                Created = DateTime.Now,
                MapSegmentId = mapSegment3.Id
            };
            
            var mapSegment4 = new MapSegment()
            {
                Id = Guid.NewGuid(),
                Name = "Šimpansite aed",
                AnimalId = chimpanzee.Id,
                AppMapId = appMap.Id
            };
            
            var geoCoordinate4 = new GeoCoordinate()
            {
                Id = Guid.NewGuid(),
                Latitude = 59.4514699,
                Longitude = 24.7172511,
                Created = DateTime.Now,
                MapSegmentId = mapSegment4.Id
            };
            
            var mapSegment5 = new MapSegment()
            {
                Id = Guid.NewGuid(),
                Name = "Tüügassea aedik",
                AnimalId = warhog.Id,
                AppMapId = appMap.Id
            };
            
            var geoCoordinate5 = new GeoCoordinate()
            {
                Id = Guid.NewGuid(),
                Latitude = 59.4515674,
                Longitude = 24.7173722,
                Created = DateTime.Now,
                MapSegmentId = mapSegment5.Id
            };
            
            modelBuilder.Entity<GeoCoordinate>()
                .HasData(
                    geoCoordinate1,
                    geoCoordinate2,
                    geoCoordinate3,
                    geoCoordinate4,
                    geoCoordinate5
                );
            
            
            modelBuilder.Entity<MapSegment>()
                .HasData(
                    mapSegment1,
                    mapSegment2,
                    mapSegment3,
                    mapSegment4,
                    mapSegment5
                );

            
            modelBuilder.Entity<AppMap>()
                .HasData(
                    appMap
                );


            #endregion
        }
    }
}
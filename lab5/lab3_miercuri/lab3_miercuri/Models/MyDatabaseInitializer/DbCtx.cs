using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab3_miercuri.Models.MyDatabaseInitializer
{

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new Initp());
            //Database.SetInitializer<DbCtx>(new CreateDatabaseIfNotExists<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseIfModelChanges<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseAlways<DbCtx>());
        }

    
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ContactInfo> ContactsInfo { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            BookType cover1 = new BookType { BookTypeId = 67, Name = "Hardcover" };
            BookType cover2 = new BookType { BookTypeId = 68, Name = "Paperback" };

            Region region1 = new Region { RegionId = 1, Name = "Alba" };
            Region region2 = new Region { RegionId = 2, Name = "Arad" };
            Region region3 = new Region { RegionId = 3, Name = "Argeș" };
            Region region4 = new Region { RegionId = 4, Name = "Bacău" };

            ctx.BookTypes.Add(cover1);
            ctx.BookTypes.Add(cover2);

            ctx.Regions.Add(region1);
            ctx.Regions.Add(region2);
            ctx.Regions.Add(region3);
            ctx.Regions.Add(region4);
            ctx.Regions.Add(new Region { RegionId = 5, Name = "Bihor" });
            ctx.Regions.Add(new Region { RegionId = 6, Name = "Bistrița-Năsăud" });
            ctx.Regions.Add(new Region { RegionId = 7, Name = "Botoșani" });
            ctx.Regions.Add(new Region { RegionId = 8, Name = "Brașov" });
            ctx.Regions.Add(new Region { RegionId = 9, Name = "Brăila" });
            ctx.Regions.Add(new Region { RegionId = 10, Name = "Buzău" });
            ctx.Regions.Add(new Region { RegionId = 11, Name = "Caraș-Severin" });
            ctx.Regions.Add(new Region { RegionId = 12, Name = "Cluj" });
            ctx.Regions.Add(new Region { RegionId = 13, Name = "Constanța" });
            ctx.Regions.Add(new Region { RegionId = 14, Name = "Covasna" });
            ctx.Regions.Add(new Region { RegionId = 15, Name = "Dâmbovița" });
            ctx.Regions.Add(new Region { RegionId = 16, Name = "Dolj" });
            ctx.Regions.Add(new Region { RegionId = 17, Name = "Galați" });
            ctx.Regions.Add(new Region { RegionId = 18, Name = "Gorj" });
            ctx.Regions.Add(new Region { RegionId = 19, Name = "Harghita" });
            ctx.Regions.Add(new Region { RegionId = 20, Name = "Hunedoara" });
            ctx.Regions.Add(new Region { RegionId = 21, Name = "Ialomița" });
            ctx.Regions.Add(new Region { RegionId = 22, Name = "Iași" });
            ctx.Regions.Add(new Region { RegionId = 23, Name = "Ilfov" });
            ctx.Regions.Add(new Region { RegionId = 24, Name = "Maramureș" });
            ctx.Regions.Add(new Region { RegionId = 25, Name = "Mehedinți" });
            ctx.Regions.Add(new Region { RegionId = 26, Name = "Mureș" });
            ctx.Regions.Add(new Region { RegionId = 27, Name = "Neamț" });
            ctx.Regions.Add(new Region { RegionId = 28, Name = "Olt" });
            ctx.Regions.Add(new Region { RegionId = 29, Name = "Prahova" });
            ctx.Regions.Add(new Region { RegionId = 30, Name = "Satu Mare" });
            ctx.Regions.Add(new Region { RegionId = 31, Name = "Sălaj" });
            ctx.Regions.Add(new Region { RegionId = 32, Name = "Sibiu" });
            ctx.Regions.Add(new Region { RegionId = 33, Name = "Suceava" });
            ctx.Regions.Add(new Region { RegionId = 34, Name = "Teleorman" });
            ctx.Regions.Add(new Region { RegionId = 35, Name = "Timiș" });
            ctx.Regions.Add(new Region { RegionId = 36, Name = "Tulcea" });
            ctx.Regions.Add(new Region { RegionId = 37, Name = "Vaslui" });
            ctx.Regions.Add(new Region { RegionId = 38, Name = "Vâlcea" });
            ctx.Regions.Add(new Region { RegionId = 39, Name = "Vrancea" });
            ctx.Regions.Add(new Region { RegionId = 40, Name = "București" });
            ctx.Regions.Add(new Region { RegionId = 41, Name = "București-Sector 1" });
            ctx.Regions.Add(new Region { RegionId = 42, Name = "București-Sector-2" });
            ctx.Regions.Add(new Region { RegionId = 43, Name = "București-Sector-3" });
            ctx.Regions.Add(new Region { RegionId = 44, Name = "București-Sector-4" });
            ctx.Regions.Add(new Region { RegionId = 45, Name = "București-Sector 5" });
            ctx.Regions.Add(new Region { RegionId = 46, Name = "București - Sector 6" });
            ctx.Regions.Add(new Region { RegionId = 47, Name = "Călărași" });
            ctx.Regions.Add(new Region { RegionId = 48, Name = "Giurgiu" });

            ContactInfo contact1 = new ContactInfo
            {
                PhoneNumber = "0712345678",
                BirthDay = "16",
                BirthMonth = "03",
                BirthYear = 1991,
                CNP = "2910316014007",
                GenderType = Gender.Female,
                Resident = false,
                RegionId = region1.RegionId
            };

            ContactInfo contact2 = new ContactInfo
            {
                PhoneNumber = "0713345878",
                BirthDay = "07",
                BirthMonth = "04",
                BirthYear = 2002,
                CNP = "6020407023976",
                GenderType = Gender.Female,
                Resident = false,
                RegionId = region2.RegionId
            };

            ContactInfo contact3 = new ContactInfo
            {
                PhoneNumber = "0711345678",
                BirthDay = "30",
                BirthMonth = "10",
                BirthYear = 2002,
                CNP = "5021030031736",
                GenderType = Gender.Male,
                Resident = false,
                RegionId = region3.RegionId
            };

            /* ContactInfo contact3 = new ContactInfo
             {
                 PhoneNumber = "0714445678",
                 BirthDay = "25",
                 BirthMonth = "10",
                 BirthYear = 2002,
                 CNP = "5021225032864",
                 GenderType = Gender.Male,
                 Resident = false,
                 Region = region3
             };
            */
            ContactInfo contact4 = new ContactInfo
            {
                PhoneNumber = "0712665679",
                BirthDay = "13",
                BirthMonth = "05",
                BirthYear = 1986,
                CNP = "2860513040701",
                GenderType = Gender.Female,
                Resident = false,
                RegionId = region4.RegionId
            };

            ctx.ContactsInfo.Add(contact1);
            ctx.ContactsInfo.Add(contact2);
            ctx.ContactsInfo.Add(contact3);
            ctx.ContactsInfo.Add(contact4);

            ctx.Books.Add(new Book
            {
                Title = "The Atomic Times",
                Author = "Michael Harris",
                Publisher = new Publisher { Name = "HarperCollins", ContactInfo = contact1 },
                BookType = cover1,
                Genres = new List<Genre> {
                    new Genre { Name = "Horror"}
                }
            });
            ctx.Books.Add(new Book
            {
                Title = "In Defense of Elitism",
                Author = "Joel Stein",
                Publisher = new Publisher { Name = "Macmillan Publishers", ContactInfo = contact2 },
                BookType = cover1,
                Genres = new List<Genre> {
                    new Genre { Name = "Humor"}
                }
            });
            ctx.Books.Add(new Book
            {
                Title = "The Canterbury Tales",
                Author = "Geoffrey Chaucer",
                Summary = "At the Tabard Inn, a tavern in Southwark, near London, the narrator joins a company of twenty-nine pilgrims. The pilgrims, like the narrator, are traveling to the shrine of the martyr Saint Thomas Becket in Canterbury. The narrator gives a descriptive account of twenty-seven of these pilgrims, including a Knight, Squire, Yeoman, Prioress, Monk, Friar, Merchant, Clerk, Man of Law, Franklin, Haberdasher, Carpenter, Weaver, Dyer, Tapestry-Weaver, Cook, Shipman, Physician, Wife, Parson, Plowman, Miller, Manciple, Reeve, Summoner, Pardoner, and Host. (He does not describe the Second Nun or the Nun’s Priest, although both characters appear later in the book.) The Host, whose name, we find out in the Prologue to the Cook’s Tale, is Harry Bailey, suggests that the group ride together and entertain one another with stories. He decides that each pilgrim will tell two stories on the way to Canterbury and two on the way back. Whomever he judges to be the best storyteller will receive a meal at Bailey’s tavern, courtesy of the other pilgrims. The pilgrims draw lots and determine that the Knight will tell the first tale.",
                Publisher = new Publisher { Name = "Scholastic", ContactInfo = contact3 },
                BookType = cover2,
                Genres = new List<Genre> {
                    new Genre { Name = "Satire"},
                    new Genre { Name = "Fabilau"},
                    new Genre { Name = "Allegory"},
                    new Genre { Name = "Burlesque"}
                }
            });
            ctx.Books.Add(new Book
            {
                Title = "Python Crash Course, 2nd Edition: A Hands-On, Project-Based Introduction to Programming",
                Author = "Eric Matthers",
                Publisher = new Publisher { Name = "Schol", ContactInfo = contact4 },
                BookType = cover2,
                Genres = new List<Genre> {
                    new Genre { Name = "Programming"}
                }
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}
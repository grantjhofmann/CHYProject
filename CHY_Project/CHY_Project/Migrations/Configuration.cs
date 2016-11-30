namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using CHY_Project.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CHY_Project.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(CHY_Project.Models.AppDbContext db)
        //{
        //    var genres = new List<Genre>
        //    {
        //        new Genre {GenreName = "Pop" },
        //        new Genre {GenreName = "Alternative" },
        //        new Genre {GenreName = "Dance" },
        //        new Genre {GenreName = "Country" },
        //        new Genre {GenreName = "Hip-Hop/Rap" },
        //        new Genre {GenreName = "Holiday" },
        //        new Genre {GenreName = "Rock" },
        //        new Genre {GenreName = "J-Pop" },
        //        new Genre {GenreName = "Classical" },
        //        new Genre {GenreName = "Soundtrack" },
        //        new Genre {GenreName = "Progressive Trance" },
        //        new Genre {GenreName = "Comedy" },
        //        new Genre {GenreName = "Children's Music" },
        //        new Genre {GenreName = "Singer/Songwriter" },
        //        new Genre {GenreName = "Nu Metal" },
        //        new Genre {GenreName = "Folk" },
        //        new Genre {GenreName = "Reggae" },
        //        new Genre {GenreName = "House" }
        //};

        //    genres.ForEach(g => db.Genres.AddOrUpdate(x => x.GenreName, g)); db.SaveChanges();

        //    var artists = new List<Artist>
        //{
        //    new Artist { ArtistName = "LMFAO", Genres = new List<Genre>() },
        //    new Artist { ArtistName = "ADELE", Genres = new List<Genre>() },
        //    new Artist { ArtistName = "Foster the People", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Maroon 5", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "David Guetta", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Usher", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Lady GaGa", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Rihanna", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Blake Shelton", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Nicki Minaj", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Kanye West", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Jay-Z", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Luke Bryan", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "The Band Perry", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Selena Gomez & the Scene", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Lady Antebellum", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Eli Young Band", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "The Byars Family", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Drake", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Gym Class Heroes", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Justin Bieber", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Coldplay", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Snoop Dogg", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Wiz Khalifa", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Cobra Starship", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Jason Derulo", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Kelly Clarkson", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "T-Pain", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Kelly Clarkson", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Flo Rida", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "DEV", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Bruno Mars", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Christina Perri", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "B.o.B", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Pitbull", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Wale", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Alexandra Stan", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Nickelback", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Rick Ross", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Waka Flocka Flame", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Florence + the Machine", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Jessie J", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Martin Solveig", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Dragonette", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Jake Owen", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Sean Paul", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Miranda Lambert", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Hot Chelle Rae", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Roscoe Dash", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Chevelle", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "James Bay", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Ariana Grande", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Sam Hunt", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "One Direction", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Nick Jonas", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Mark Ronson", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Hozier", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Kendrick Lamar", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "FLOW", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Has Zimmer", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "James Newton Howard", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Andain", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Bryant Oden", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Linkin Park", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Julian Smith", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Malvina Reynolds", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Peter, Paul & Mary", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Bobby McFerrin", Genres = new List<Genre>()},
        //    new Artist { ArtistName = "Calvin Harris", Genres = new List<Genre>()}
        //};

        //    artists.ForEach(a => db.Artists.AddOrUpdate(b => b.ArtistName, a));
        //    db.SaveChanges();

        //    AddOrUpdateArtistGenre(db, "LMFAO", "Pop");
        //    AddOrUpdateArtistGenre(db, "ADELE", "Pop");
        //    AddOrUpdateArtistGenre(db, "Foster the People", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Maroon 5", "Pop");
        //    AddOrUpdateArtistGenre(db, "David Guetta", "Dance");
        //    AddOrUpdateArtistGenre(db, "Usher", "Dance");
        //    AddOrUpdateArtistGenre(db, "Lady GaGa", "Pop");
        //    AddOrUpdateArtistGenre(db, "Rihanna", "Pop");
        //    AddOrUpdateArtistGenre(db, "Blake Shelton", "Pop");
        //    AddOrUpdateArtistGenre(db, "Blake Shelton", "Pop");
        //    AddOrUpdateArtistGenre(db, "Nicki Minaj", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Kanye West", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Luke Bryan", "Country");
        //    AddOrUpdateArtistGenre(db, "The Band Perry", "Country");
        //    AddOrUpdateArtistGenre(db, "Selena Gomez & the Scene", "Pop");
        //    AddOrUpdateArtistGenre(db, "Lady Antebellum", "Country");
        //    AddOrUpdateArtistGenre(db, "Eli Young Band", "Country");
        //    AddOrUpdateArtistGenre(db, "The Byars Family", "Country");
        //    AddOrUpdateArtistGenre(db, "Drake", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Gym Class Heroes", "Pop");
        //    AddOrUpdateArtistGenre(db, "Justin Bieber", "Holiday");
        //    AddOrUpdateArtistGenre(db, "Coldplay", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Snoop Dogg", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Wiz Khalifa", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Cobra Starship", "Pop");
        //    AddOrUpdateArtistGenre(db, "Jason Derulo", "Pop");
        //    AddOrUpdateArtistGenre(db, "Kelly Clarkson", "Pop");
        //    AddOrUpdateArtistGenre(db, "T-Pain", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Flo Ride", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "DEV", "Pop");
        //    AddOrUpdateArtistGenre(db, "Bruno Mars", "Pop");
        //    AddOrUpdateArtistGenre(db, "Christina Perri", "Pop");
        //    AddOrUpdateArtistGenre(db, "B.o.B.", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Pitbull", "Pop");
        //    AddOrUpdateArtistGenre(db, "Wale", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Alexandra Stan", "Dance");
        //    AddOrUpdateArtistGenre(db, "Nickelback", "Rock");
        //    AddOrUpdateArtistGenre(db, "Rick Ross", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Waka Flocka Flame", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Florence + the Machine", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Jessie J", "Pop");
        //    AddOrUpdateArtistGenre(db, "Martin Solveig", "Dance");
        //    AddOrUpdateArtistGenre(db, "Dragonette", "Dance");
        //    AddOrUpdateArtistGenre(db, "Jake Owen", "Country");
        //    AddOrUpdateArtistGenre(db, "Hot Chelle Rae", "Pop");
        //    AddOrUpdateArtistGenre(db, "Roscoe Dash", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Chevelle", "Rock");
        //    AddOrUpdateArtistGenre(db, "James Bay", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Ariana Grande", "Pop");
        //    AddOrUpdateArtistGenre(db, "Sam Hunt", "Country");
        //    AddOrUpdateArtistGenre(db, "One Direction", "Pop");
        //    AddOrUpdateArtistGenre(db, "Nick Jonas", "Pop");
        //    AddOrUpdateArtistGenre(db, "Mark Ronson", "Pop");
        //    AddOrUpdateArtistGenre(db, "Hozier", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Kendrick Lamar", "Rap");
        //    AddOrUpdateArtistGenre(db, "FLOW", "Pop");
        //    AddOrUpdateArtistGenre(db, "FLOW", "J-Pop");
        //    AddOrUpdateArtistGenre(db, "Hans Zimmer", "Classical");
        //    AddOrUpdateArtistGenre(db, "Hans Zimmer", "Soundtrack");
        //    AddOrUpdateArtistGenre(db, "James Newton Howard", "Classical");
        //    AddOrUpdateArtistGenre(db, "James Newton Howard", "Soundtrack");
        //    AddOrUpdateArtistGenre(db, "Andain", "Progressive Trance");
        //    AddOrUpdateArtistGenre(db, "Andain", "Dance");
        //    AddOrUpdateArtistGenre(db, "Bryant Oden", "Comedy");
        //    AddOrUpdateArtistGenre(db, "Bryant Oden", "Children's Music");
        //    AddOrUpdateArtistGenre(db, "Bryant Oden", "Singer/Songwriter");
        //    AddOrUpdateArtistGenre(db, "Jay-Z", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Jay-Z", "Nu-Metal");
        //    AddOrUpdateArtistGenre(db, "Linkin Park", "Alternative");
        //    AddOrUpdateArtistGenre(db, "Linkin Park", "Nu Metal");
        //    AddOrUpdateArtistGenre(db, "Linkin Park", "Hip-Hop/Rap");
        //    AddOrUpdateArtistGenre(db, "Julian Smith", "Comedy");
        //    AddOrUpdateArtistGenre(db, "Malvina Reynold", "Folk");
        //    AddOrUpdateArtistGenre(db, "Peter, Paul & Mary", "Singer/Songwriter");
        //    AddOrUpdateArtistGenre(db, "Bobby McFerrin", "Reggae");
        //    AddOrUpdateArtistGenre(db, "Calvin Harris", "Dance");
        //    db.SaveChanges();




        //    Song song1 = new Song();
        //    song1.SongName = "Rolling in the Deep";
        //    db.Songs.AddOrUpdate(s => s.SongName, song1);
        //    db.SaveChanges();
        //    song1.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song1);
        //    song1.DiscountPrice = song1.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song1);
        //    db.SaveChanges();
        //    song1 = db.Songs.FirstOrDefault(s => s.SongName == "Rolling in the Deep");
        //    song1.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song1.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song1.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song1);
        //    db.SaveChanges();

        //    Song song2 = new Song();
        //    song2.SongName = "Rumor Has It";
        //    db.Songs.AddOrUpdate(s => s.SongName, song2);
        //    db.SaveChanges();
        //    song2.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song2);
        //    song2.DiscountPrice = song2.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song2);
        //    db.SaveChanges();
        //    song2 = db.Songs.FirstOrDefault(s => s.SongName == "Rumor Has It");
        //    song2.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song2.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song2.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song2);
        //    db.SaveChanges();

        //    Song song3 = new Song();
        //    song3.SongName = "Turning Tables";
        //    db.Songs.AddOrUpdate(s => s.SongName, song3);
        //    db.SaveChanges();
        //    song3.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song3);
        //    song3.DiscountPrice = song3.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song3);
        //    db.SaveChanges();
        //    song3 = db.Songs.FirstOrDefault(s => s.SongName == "Turning Tables");
        //    song3.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song3.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song3.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song3);
        //    db.SaveChanges();

        //    Song song4 = new Song();
        //    song3.SongName = "Don't You Remember";
        //    db.Songs.AddOrUpdate(s => s.SongName, song3);
        //    db.SaveChanges();
        //    song3.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song3);
        //    song3.DiscountPrice = song3.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song3);
        //    db.SaveChanges();
        //    song3 = db.Songs.FirstOrDefault(s => s.SongName == "Don't You Remember");
        //    song3.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song3.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song4.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song4);
        //    db.SaveChanges();

        //    Song song5 = new Song();
        //    song5.SongName = "Set Fire to the Rain";
        //    db.Songs.AddOrUpdate(s => s.SongName, song5);
        //    db.SaveChanges();
        //    song5.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song5);
        //    song5.DiscountPrice = song5.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song5);
        //    db.SaveChanges();
        //    song5 = db.Songs.FirstOrDefault(s => s.SongName == "Set Fire to the Rain");
        //    song5.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song5.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song5.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song5);
        //    db.SaveChanges();

        //    Song song6 = new Song();
        //    song6.SongName = "He Won't Go";
        //    db.Songs.AddOrUpdate(s => s.SongName, song6);
        //    db.SaveChanges();
        //    song6.RegularPrice = 1.19m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song6);
        //    song6.DiscountPrice = song6.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song6);
        //    db.SaveChanges();
        //    song6 = db.Songs.FirstOrDefault(s => s.SongName == "He Won't Go");
        //    song6.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song6.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song6.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song6);
        //    db.SaveChanges();

        //    Song song7 = new Song();
        //    song7.SongName = "Take It All";
        //    db.Songs.AddOrUpdate(s => s.SongName, song7);
        //    db.SaveChanges();
        //    song7.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song7);
        //    song7.DiscountPrice = song7.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song7);
        //    db.SaveChanges();
        //    song7 = db.Songs.FirstOrDefault(s => s.SongName == "Take It All");
        //    song7.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song7.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song7.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song7);
        //    db.SaveChanges();

        //    Song song8 = new Song();
        //    song8.SongName = "Rolling in the Deep";
        //    db.Songs.AddOrUpdate(s => s.SongName, song8);
        //    db.SaveChanges();
        //    song8.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song8);
        //    song8.DiscountPrice = song8.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song8);
        //    db.SaveChanges();
        //    song8 = db.Songs.FirstOrDefault(s => s.SongName == "I'll Be Waiting");
        //    song8.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song8.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song8.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song8);
        //    db.SaveChanges();

        //    Song song9 = new Song();
        //    song9.SongName = "One and Only";
        //    db.Songs.AddOrUpdate(s => s.SongName, song9);
        //    db.SaveChanges();
        //    song9.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song9);
        //    song9.DiscountPrice = song9.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song9);
        //    db.SaveChanges();
        //    song9 = db.Songs.FirstOrDefault(s => s.SongName == "One and Only");
        //    song9.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song9.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song9.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song9);
        //    db.SaveChanges();

        //    Song song10 = new Song();
        //    song10.SongName = "Lovesong";
        //    db.Songs.AddOrUpdate(s => s.SongName, song10);
        //    db.SaveChanges();
        //    song10.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song10);
        //    song10.DiscountPrice = song10.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song10);
        //    db.SaveChanges();
        //    song10 = db.Songs.FirstOrDefault(s => s.SongName == "Lovesong");
        //    song10.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song10.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song10.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song10);
        //    db.SaveChanges();

        //    Song song11 = new Song();
        //    song11.SongName = "Someone Like You";
        //    db.Songs.AddOrUpdate(s => s.SongName, song11);
        //    db.SaveChanges();
        //    song11.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song11);
        //    song11.DiscountPrice = song11.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song11);
        //    db.SaveChanges();
        //    song11 = db.Songs.FirstOrDefault(s => s.SongName == "Someone Like You");
        //    song11.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song11.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song11.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song11);
        //    db.SaveChanges();

        //    Song song12 = new Song();
        //    song12.SongName = "I Found A Boy";
        //    db.Songs.AddOrUpdate(s => s.SongName, song12);
        //    db.SaveChanges();
        //    song12.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song12);
        //    song12.DiscountPrice = song12.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song12);
        //    db.SaveChanges();
        //    song12 = db.Songs.FirstOrDefault(s => s.SongName == "I Found A Boy");
        //    song12.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ADELE"));
        //    song12.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song12.Album.AlbumName = "21";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song12);
        //    db.SaveChanges();

        //    Song song13 = new Song();
        //    song13.SongName = "Marry the Night";
        //    db.Songs.AddOrUpdate(s => s.SongName, song13);
        //    db.SaveChanges();
        //    song13.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song13);
        //    song13.DiscountPrice = song13.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song13);
        //    db.SaveChanges();
        //    song13 = db.Songs.FirstOrDefault(s => s.SongName == "Marry the Night");
        //    song13.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song13.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song13.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song13);
        //    db.SaveChanges();

        //    Song song14 = new Song();
        //    song14.SongName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.SongName, song14);
        //    db.SaveChanges();
        //    song14.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song14);
        //    song14.DiscountPrice = song14.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song14);
        //    db.SaveChanges();
        //    song14 = db.Songs.FirstOrDefault(s => s.SongName == "Born This Way");
        //    song14.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song14.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song14.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song14);
        //    db.SaveChanges();

        //    Song song15 = new Song();
        //    song15.SongName = "Government Hooker";
        //    db.Songs.AddOrUpdate(s => s.SongName, song15);
        //    db.SaveChanges();
        //    song15.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song15);
        //    song15.DiscountPrice = song15.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song15);
        //    db.SaveChanges();
        //    song15 = db.Songs.FirstOrDefault(s => s.SongName == "Government Hooker");
        //    song15.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song15.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song15.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song15);
        //    db.SaveChanges();

        //    Song song16 = new Song();
        //    song16.SongName = "Judas";
        //    db.Songs.AddOrUpdate(s => s.SongName, song16);
        //    db.SaveChanges();
        //    song16.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song16);
        //    song16.DiscountPrice = song16.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song16);
        //    db.SaveChanges();
        //    song16 = db.Songs.FirstOrDefault(s => s.SongName == "Judas");
        //    song16.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song16.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song16.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song16);
        //    db.SaveChanges();

        //    Song song17 = new Song();
        //    song17.SongName = "Americano";
        //    db.Songs.AddOrUpdate(s => s.SongName, song17);
        //    db.SaveChanges();
        //    song17.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song17);
        //    song17.DiscountPrice = song17.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song17);
        //    db.SaveChanges();
        //    song17 = db.Songs.FirstOrDefault(s => s.SongName == "Americano");
        //    song17.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song17.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song17.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song17);
        //    db.SaveChanges();

        //    Song song18 = new Song();
        //    song18.SongName = "Hair";
        //    db.Songs.AddOrUpdate(s => s.SongName, song18);
        //    db.SaveChanges();
        //    song18.RegularPrice = 1.39m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song18);
        //    song18.DiscountPrice = song18.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song18);
        //    db.SaveChanges();
        //    song18 = db.Songs.FirstOrDefault(s => s.SongName == "Hair");
        //    song18.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song18.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song18.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song18);
        //    db.SaveChanges();

        //    Song song19 = new Song();
        //    song19.SongName = "Bloody Mary";
        //    db.Songs.AddOrUpdate(s => s.SongName, song19);
        //    db.SaveChanges();
        //    song19.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song19);
        //    song19.DiscountPrice = song19.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song19);
        //    db.SaveChanges();
        //    song19 = db.Songs.FirstOrDefault(s => s.SongName == "Bloody Mary");
        //    song19.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song19.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song19.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song19);
        //    db.SaveChanges();

        //    Song song20 = new Song();
        //    song20.SongName = "Black Jesus + Amen Fashion";
        //    db.Songs.AddOrUpdate(s => s.SongName, song20);
        //    db.SaveChanges();
        //    song20.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song20);
        //    song20.DiscountPrice = song20.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song20);
        //    db.SaveChanges();
        //    song20 = db.Songs.FirstOrDefault(s => s.SongName == "Black Jesus + Amen Fashion");
        //    song20.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song20.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song20.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song20);
        //    db.SaveChanges();

        //    Song song21 = new Song();
        //    song21.SongName = "Bad Kids";
        //    db.Songs.AddOrUpdate(s => s.SongName, song21);
        //    db.SaveChanges();
        //    song21.RegularPrice = 1.49m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song21);
        //    song21.DiscountPrice = song21.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song21);
        //    db.SaveChanges();
        //    song21 = db.Songs.FirstOrDefault(s => s.SongName == "Bad Kids");
        //    song21.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song21.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song21.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song21);
        //    db.SaveChanges();

        //    Song song22 = new Song();
        //    song22.SongName = "Fashion of His Love";
        //    db.Songs.AddOrUpdate(s => s.SongName, song22);
        //    db.SaveChanges();
        //    song22.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song22);
        //    song22.DiscountPrice = song22.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song22);
        //    db.SaveChanges();
        //    song22 = db.Songs.FirstOrDefault(s => s.SongName == "Fashion of His Love");
        //    song22.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song22.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song22.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song22);
        //    db.SaveChanges();

        //    Song song23 = new Song();
        //    song23.SongName = "Highway Unicorn (Road to Love)";
        //    db.Songs.AddOrUpdate(s => s.SongName, song23);
        //    db.SaveChanges();
        //    song23.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song23);
        //    song23.DiscountPrice = song23.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song23);
        //    db.SaveChanges();
        //    song23 = db.Songs.FirstOrDefault(s => s.SongName == "Highway Unicorn (Road to Love");
        //    song23.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song23.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song23.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song23);
        //    db.SaveChanges();

        //    Song song24 = new Song();
        //    song24.SongName = "Heavy Metal Lover";
        //    db.Songs.AddOrUpdate(s => s.SongName, song24);
        //    db.SaveChanges();
        //    song24.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song24);
        //    song24.DiscountPrice = song24.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song24);
        //    db.SaveChanges();
        //    song24 = db.Songs.FirstOrDefault(s => s.SongName == "Heavy Metal Lover");
        //    song24.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song24.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song24.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song24);
        //    db.SaveChanges();

        //    Song song25 = new Song();
        //    song25.SongName = "Electric Chapel";
        //    db.Songs.AddOrUpdate(s => s.SongName, song25);
        //    db.SaveChanges();
        //    song25.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song25);
        //    song25.DiscountPrice = song25.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song25);
        //    db.SaveChanges();
        //    song25 = db.Songs.FirstOrDefault(s => s.SongName == "Electric Chapel");
        //    song25.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song25.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song25.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song25);
        //    db.SaveChanges();

        //    Song song26 = new Song();
        //    song26.SongName = "The Queen";
        //    db.Songs.AddOrUpdate(s => s.SongName, song26);
        //    db.SaveChanges();
        //    song26.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song26);
        //    song26.DiscountPrice = song26.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song26);
        //    db.SaveChanges();
        //    song26 = db.Songs.FirstOrDefault(s => s.SongName == "The Queen");
        //    song26.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song26.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song26.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song26);
        //    db.SaveChanges();

        //    Song song27 = new Song();
        //    song27.SongName = "You and I";
        //    db.Songs.AddOrUpdate(s => s.SongName, song27);
        //    db.SaveChanges();
        //    song27.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song27);
        //    song27.DiscountPrice = song27.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song27);
        //    db.SaveChanges();
        //    song27 = db.Songs.FirstOrDefault(s => s.SongName == "You and I");
        //    song27.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song27.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song27.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song27);
        //    db.SaveChanges();

        //    Song song28 = new Song();
        //    song28.SongName = "The Edge of Glory";
        //    db.Songs.AddOrUpdate(s => s.SongName, song28);
        //    db.SaveChanges();
        //    song28.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song28);
        //    song28.DiscountPrice = song28.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song28);
        //    db.SaveChanges();
        //    song28 = db.Songs.FirstOrDefault(s => s.SongName == "The Edge of Glory");
        //    song28.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lady GaGa"));
        //    song28.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song22.Album.AlbumName = "Born This Way";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song22);
        //    db.SaveChanges();

        //    Song song29 = new Song();
        //    song29.SongName = "Only If For A Night";
        //    db.Songs.AddOrUpdate(s => s.SongName, song29);
        //    db.SaveChanges();
        //    song29.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song29);
        //    song29.DiscountPrice = song29.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song29);
        //    db.SaveChanges();
        //    song29 = db.Songs.FirstOrDefault(s => s.SongName == "Only If For A Night");
        //    song29.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song29.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song29.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song29);
        //    db.SaveChanges();

        //    Song song30 = new Song();
        //    song30.SongName = "Shake It Out";
        //    db.Songs.AddOrUpdate(s => s.SongName, song30);
        //    db.SaveChanges();
        //    song30.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song30);
        //    song30.DiscountPrice = song30.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song30);
        //    db.SaveChanges();
        //    song30 = db.Songs.FirstOrDefault(s => s.SongName == "Shake It Out");
        //    song30.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song30.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song30.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song30);
        //    db.SaveChanges();

        //    Song song31 = new Song();
        //    song31.SongName = "What the Water Gave Me";
        //    db.Songs.AddOrUpdate(s => s.SongName, song31);
        //    db.SaveChanges();
        //    song31.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song31);
        //    song31.DiscountPrice = song31.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song31);
        //    db.SaveChanges();
        //    song31 = db.Songs.FirstOrDefault(s => s.SongName == "What the Water Gave Me");
        //    song31.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song31.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song31.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song31);
        //    db.SaveChanges();

        //    Song song32 = new Song();
        //    song32.SongName = "Never Let Me Go";
        //    db.Songs.AddOrUpdate(s => s.SongName, song32);
        //    db.SaveChanges();
        //    song32.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song32);
        //    song32.DiscountPrice = song32.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song32);
        //    db.SaveChanges();
        //    song32 = db.Songs.FirstOrDefault(s => s.SongName == "Never Let Me Go");
        //    song32.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song32.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song32.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song32);
        //    db.SaveChanges();

        //    Song song33 = new Song();
        //    song33.SongName = "Breaking Down";
        //    db.Songs.AddOrUpdate(s => s.SongName, song33);
        //    db.SaveChanges();
        //    song33.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song33);
        //    song33.DiscountPrice = song33.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song33);
        //    db.SaveChanges();
        //    song33 = db.Songs.FirstOrDefault(s => s.SongName == "Breaking Down");
        //    song33.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song33.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song33.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song33);
        //    db.SaveChanges();

        //    Song song34 = new Song();
        //    song34.SongName = "Lover to Lover";
        //    db.Songs.AddOrUpdate(s => s.SongName, song34);
        //    db.SaveChanges();
        //    song34.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song34);
        //    song34.DiscountPrice = song34.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song34);
        //    db.SaveChanges();
        //    song34 = db.Songs.FirstOrDefault(s => s.SongName == "Lover to Lover");
        //    song34.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song34.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song34.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song34);
        //    db.SaveChanges();

        //    Song song35 = new Song();
        //    song35.SongName = "No Light, No Light";
        //    db.Songs.AddOrUpdate(s => s.SongName, song35);
        //    db.SaveChanges();
        //    song35.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song35);
        //    song35.DiscountPrice = song35.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song35);
        //    db.SaveChanges();
        //    song35 = db.Songs.FirstOrDefault(s => s.SongName == "No Light, No Light");
        //    song35.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song35.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song35.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song35);
        //    db.SaveChanges();

        //    Song song36 = new Song();
        //    song36.SongName = "Seven Devils";
        //    db.Songs.AddOrUpdate(s => s.SongName, song36);
        //    db.SaveChanges();
        //    song36.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song36);
        //    song36.DiscountPrice = song36.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song36);
        //    db.SaveChanges();
        //    song36 = db.Songs.FirstOrDefault(s => s.SongName == "Seven Devils");
        //    song36.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song36.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song36.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song36);
        //    db.SaveChanges();

        //    Song song37 = new Song();
        //    song37.SongName = "Heartlines";
        //    db.Songs.AddOrUpdate(s => s.SongName, song37);
        //    db.SaveChanges();
        //    song37.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song37);
        //    song37.DiscountPrice = song37.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song37);
        //    db.SaveChanges();
        //    song37 = db.Songs.FirstOrDefault(s => s.SongName == "Heartlines");
        //    song37.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song37.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song37.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song37);
        //    db.SaveChanges();

        //    Song song38 = new Song();
        //    song38.SongName = "Spectrum";
        //    db.Songs.AddOrUpdate(s => s.SongName, song38);
        //    db.SaveChanges();
        //    song38.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song38);
        //    song38.DiscountPrice = song38.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song38);
        //    db.SaveChanges();
        //    song38 = db.Songs.FirstOrDefault(s => s.SongName == "Spectrum");
        //    song38.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song38.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song38.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song38);
        //    db.SaveChanges();

        //    Song song39 = new Song();
        //    song39.SongName = "All of This and Heaven Too";
        //    db.Songs.AddOrUpdate(s => s.SongName, song39);
        //    db.SaveChanges();
        //    song39.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song39);
        //    song39.DiscountPrice = song39.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song39);
        //    db.SaveChanges();
        //    song39 = db.Songs.FirstOrDefault(s => s.SongName == "All of This and Heaven Too");
        //    song39.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song39.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song39.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song39);
        //    db.SaveChanges();

        //    Song song40 = new Song();
        //    song40.SongName = "Leave My Body";
        //    db.Songs.AddOrUpdate(s => s.SongName, song40);
        //    db.SaveChanges();
        //    song40.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song40);
        //    song40.DiscountPrice = song40.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song40);
        //    db.SaveChanges();
        //    song40 = db.Songs.FirstOrDefault(s => s.SongName == "Leave My Body");
        //    song40.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song40.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song40.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song40);
        //    db.SaveChanges();

        //    Song song41 = new Song();
        //    song41.SongName = "Remain Nameless";
        //    db.Songs.AddOrUpdate(s => s.SongName, song41);
        //    db.SaveChanges();
        //    song41.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song41);
        //    song41.DiscountPrice = song41.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song41);
        //    db.SaveChanges();
        //    song41 = db.Songs.FirstOrDefault(s => s.SongName == "Remain Nameless");
        //    song41.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song41.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song41.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song41);
        //    db.SaveChanges();

        //    Song song42 = new Song();
        //    song42.SongName = "Strangeness and Charm";
        //    db.Songs.AddOrUpdate(s => s.SongName, song42);
        //    db.SaveChanges();
        //    song42.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song42);
        //    song42.DiscountPrice = song42.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song42);
        //    db.SaveChanges();
        //    song42 = db.Songs.FirstOrDefault(s => s.SongName == "Strangeness and Charm");
        //    song42.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song42.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song42.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song42);
        //    db.SaveChanges();

        //    Song song43 = new Song();
        //    song43.SongName = "Bedroom Hymns";
        //    db.Songs.AddOrUpdate(s => s.SongName, song43);
        //    db.SaveChanges();
        //    song43.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song43);
        //    song43.DiscountPrice = song43.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song43);
        //    db.SaveChanges();
        //    song43 = db.Songs.FirstOrDefault(s => s.SongName == "Bedroom Hymns");
        //    song43.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song43.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song43.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song43);
        //    db.SaveChanges();

        //    Song song44 = new Song();
        //    song44.SongName = "What the Water Gave Me (Demo)";
        //    db.Songs.AddOrUpdate(s => s.SongName, song44);
        //    db.SaveChanges();
        //    song44.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song44);
        //    song44.DiscountPrice = song44.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song44);
        //    db.SaveChanges();
        //    song44 = db.Songs.FirstOrDefault(s => s.SongName == "What the Water Gave Me (Demo)");
        //    song44.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Florence + the Machine"));
        //    song44.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song44.Album.AlbumName = "Ceremonials (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song44);
        //    db.SaveChanges();

        //    Song song45 = new Song();
        //    song45.SongName = "Craving";
        //    db.Songs.AddOrUpdate(s => s.SongName, song45);
        //    db.SaveChanges();
        //    song45.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song45);
        //    song45.DiscountPrice = song45.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song45);
        //    db.SaveChanges();
        //    song45 = db.Songs.FirstOrDefault(s => s.SongName == "Craving");
        //    song45.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song45.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song45.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song45);
        //    db.SaveChanges();

        //    Song song46 = new Song();
        //    song46.SongName = "Hold Back the River";
        //    db.Songs.AddOrUpdate(s => s.SongName, song46);
        //    db.SaveChanges();
        //    song46.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song46);
        //    song46.DiscountPrice = song46.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song46);
        //    db.SaveChanges();
        //    song46 = db.Songs.FirstOrDefault(s => s.SongName == "Hold Back the River");
        //    song46.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song46.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song46.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song46);
        //    db.SaveChanges();

        //    Song song47 = new Song();
        //    song47.SongName = "Let t Go";
        //    db.Songs.AddOrUpdate(s => s.SongName, song47);
        //    db.SaveChanges();
        //    song47.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song47);
        //    song47.DiscountPrice = song47.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song47);
        //    db.SaveChanges();
        //    song47 = db.Songs.FirstOrDefault(s => s.SongName == "Let it Go");
        //    song47.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song47.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song47.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song47);
        //    db.SaveChanges();

        //    Song song48 = new Song();
        //    song48.SongName = "If You Ever Want to Be in Love";
        //    db.Songs.AddOrUpdate(s => s.SongName, song48);
        //    db.SaveChanges();
        //    song48.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song48);
        //    song48.DiscountPrice = song48.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song48);
        //    db.SaveChanges();
        //    song48 = db.Songs.FirstOrDefault(s => s.SongName == "If You Ever Want to Be in Love");
        //    song48.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song48.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song48.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song48);
        //    db.SaveChanges();

        //    Song song49 = new Song();
        //    song49.SongName = "Best Fake Smile";
        //    db.Songs.AddOrUpdate(s => s.SongName, song49);
        //    db.SaveChanges();
        //    song49.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song49);
        //    song49.DiscountPrice = song49.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song49);
        //    db.SaveChanges();
        //    song49 = db.Songs.FirstOrDefault(s => s.SongName == "Best Fake Smile");
        //    song49.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song49.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song49.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song49);
        //    db.SaveChanges();

        //    Song song50 = new Song();
        //    song50.SongName = "When We Were on Fire";
        //    db.Songs.AddOrUpdate(s => s.SongName, song50);
        //    db.SaveChanges();
        //    song50.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song50);
        //    song50.DiscountPrice = song50.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song50);
        //    db.SaveChanges();
        //    song50 = db.Songs.FirstOrDefault(s => s.SongName == "When We Were on Fire");
        //    song50.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song50.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song50.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song50);
        //    db.SaveChanges();

        //    Song song51 = new Song();
        //    song51.SongName = "Move Together";
        //    db.Songs.AddOrUpdate(s => s.SongName, song51);
        //    db.SaveChanges();
        //    song51.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song51);
        //    song51.DiscountPrice = song51.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song51);
        //    db.SaveChanges();
        //    song51 = db.Songs.FirstOrDefault(s => s.SongName == "Move Together");
        //    song51.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song51.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song51.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song51);
        //    db.SaveChanges();

        //    Song song52 = new Song();
        //    song52.SongName = "Scars";
        //    db.Songs.AddOrUpdate(s => s.SongName, song52);
        //    db.SaveChanges();
        //    song52.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song52);
        //    song52.DiscountPrice = song52.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song52);
        //    db.SaveChanges();
        //    song52 = db.Songs.FirstOrDefault(s => s.SongName == "Scars");
        //    song52.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song52.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song52.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song52);
        //    db.SaveChanges();

        //    Song song53 = new Song();
        //    song53.SongName = "Collide";
        //    db.Songs.AddOrUpdate(s => s.SongName, song53);
        //    db.SaveChanges();
        //    song53.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song53);
        //    song53.DiscountPrice = song53.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song53);
        //    db.SaveChanges();
        //    song53 = db.Songs.FirstOrDefault(s => s.SongName == "Collide");
        //    song53.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song53.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song53.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song45);
        //    db.SaveChanges();

        //    Song song54 = new Song();
        //    song54.SongName = "Get Out While You Can";
        //    db.Songs.AddOrUpdate(s => s.SongName, song54);
        //    db.SaveChanges();
        //    song54.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song54);
        //    song54.DiscountPrice = song54.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song54);
        //    db.SaveChanges();
        //    song54 = db.Songs.FirstOrDefault(s => s.SongName == "Get Out While You Can");
        //    song54.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song54.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song54.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song54);
        //    db.SaveChanges();

        //    Song song55 = new Song();
        //    song55.SongName = "Need the Sun to Break";
        //    db.Songs.AddOrUpdate(s => s.SongName, song55);
        //    db.SaveChanges();
        //    song55.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song55);
        //    song55.DiscountPrice = song55.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song55);
        //    db.SaveChanges();
        //    song55 = db.Songs.FirstOrDefault(s => s.SongName == "Need the Sun to Break");
        //    song55.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song55.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song55.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song55);
        //    db.SaveChanges();

        //    Song song56 = new Song();
        //    song56.SongName = "Incomplete";
        //    db.Songs.AddOrUpdate(s => s.SongName, song56);
        //    db.SaveChanges();
        //    song56.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song56);
        //    song56.DiscountPrice = song56.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song56);
        //    db.SaveChanges();
        //    song56 = db.Songs.FirstOrDefault(s => s.SongName == "Incomplete");
        //    song56.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "James Bay"));
        //    song56.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Alternative"));
        //    song56.Album.AlbumName = "Chaos and the Calm";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song56);
        //    db.SaveChanges();

        //    Song song57 = new Song();
        //    song57.SongName = "Eat Randy";
        //    db.Songs.AddOrUpdate(s => s.SongName, song57);
        //    db.SaveChanges();
        //    song57.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song57);
        //    song57.DiscountPrice = song57.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song57);
        //    db.SaveChanges();
        //    song57 = db.Songs.FirstOrDefault(s => s.SongName == "Eat Randy");
        //    song57.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Julian Smith"));
        //    song57.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Comedy"));
        //    song57.Album.AlbumName = "Eat Randy - Single";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song57);
        //    db.SaveChanges();

        //    Song song58 = new Song();
        //    song58.SongName = "Misery";
        //    db.Songs.AddOrUpdate(s => s.SongName, song58);
        //    db.SaveChanges();
        //    song58.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song58);
        //    song58.DiscountPrice = song58.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song58);
        //    db.SaveChanges();
        //    song58 = db.Songs.FirstOrDefault(s => s.SongName == "Misery");
        //    song58.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song58.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song58.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song58);
        //    db.SaveChanges();

        //    Song song59 = new Song();
        //    song59.SongName = "Give a Little More";
        //    db.Songs.AddOrUpdate(s => s.SongName, song59);
        //    db.SaveChanges();
        //    song59.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song59);
        //    song59.DiscountPrice = song59.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song59);
        //    db.SaveChanges();
        //    song59 = db.Songs.FirstOrDefault(s => s.SongName == "Give a Little More");
        //    song59.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song59.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song59.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song59);
        //    db.SaveChanges();

        //    Song song60 = new Song();
        //    song60.SongName = "Stutter";
        //    db.Songs.AddOrUpdate(s => s.SongName, song60);
        //    db.SaveChanges();
        //    song60.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song60);
        //    song60.DiscountPrice = song60.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song60);
        //    db.SaveChanges();
        //    song60 = db.Songs.FirstOrDefault(s => s.SongName == "Stutter");
        //    song60.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song60.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song60.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song57);
        //    db.SaveChanges();

        //    Song song61 = new Song();
        //    song61.SongName = "Don't Know Nothing";
        //    db.Songs.AddOrUpdate(s => s.SongName, song61);
        //    db.SaveChanges();
        //    song61.RegularPrice = 1.39m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song61);
        //    song61.DiscountPrice = song61.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song61);
        //    db.SaveChanges();
        //    song61 = db.Songs.FirstOrDefault(s => s.SongName == "Don't Know Nothing");
        //    song61.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song61.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song61.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song61);
        //    db.SaveChanges();

        //    Song song62 = new Song();
        //    song62.SongName = "Never Gonna Leave This Bed";
        //    db.Songs.AddOrUpdate(s => s.SongName, song62);
        //    db.SaveChanges();
        //    song62.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song62);
        //    song62.DiscountPrice = song62.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song62);
        //    db.SaveChanges();
        //    song62 = db.Songs.FirstOrDefault(s => s.SongName == "Never Gonna Leave This Bed");
        //    song62.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song62.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song62.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song62);
        //    db.SaveChanges();

        //    Song song63 = new Song();
        //    song63.SongName = "I Can't Lie";
        //    db.Songs.AddOrUpdate(s => s.SongName, song63);
        //    db.SaveChanges();
        //    song63.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song63);
        //    song63.DiscountPrice = song63.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song63);
        //    db.SaveChanges();
        //    song63 = db.Songs.FirstOrDefault(s => s.SongName == "I Can't Lie");
        //    song63.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song63.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song63.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song63);
        //    db.SaveChanges();

        //    Song song64 = new Song();
        //    song64.SongName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.SongName, song64);
        //    db.SaveChanges();
        //    song64.RegularPrice = 1.49m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song64);
        //    song64.DiscountPrice = song64.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song64);
        //    db.SaveChanges();
        //    song64 = db.Songs.FirstOrDefault(s => s.SongName == "Hands All Over");
        //    song64.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song64.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song64.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song64);
        //    db.SaveChanges();

        //    Song song65 = new Song();
        //    song65.SongName = "How";
        //    db.Songs.AddOrUpdate(s => s.SongName, song65);
        //    db.SaveChanges();
        //    song65.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song65);
        //    song65.DiscountPrice = song65.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song65);
        //    db.SaveChanges();
        //    song65 = db.Songs.FirstOrDefault(s => s.SongName == "How");
        //    song65.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song65.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song65.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song65);
        //    db.SaveChanges();

        //    Song song66 = new Song();
        //    song66.SongName = "Get Back in My Life";
        //    db.Songs.AddOrUpdate(s => s.SongName, song66);
        //    db.SaveChanges();
        //    song66.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song66);
        //    song66.DiscountPrice = song66.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song66);
        //    db.SaveChanges();
        //    song66 = db.Songs.FirstOrDefault(s => s.SongName == "Get Back in My Life");
        //    song66.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song66.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song66.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song66);
        //    db.SaveChanges();

        //    Song song67 = new Song();
        //    song67.SongName = "Just A Feeling";
        //    db.Songs.AddOrUpdate(s => s.SongName, song67);
        //    db.SaveChanges();
        //    song67.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song67);
        //    song67.DiscountPrice = song67.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song67);
        //    db.SaveChanges();
        //    song67 = db.Songs.FirstOrDefault(s => s.SongName == "Just A Feeling");
        //    song67.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song67.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song67.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song67);
        //    db.SaveChanges();

        //    Song song68 = new Song();
        //    song68.SongName = "Runaway";
        //    db.Songs.AddOrUpdate(s => s.SongName, song68);
        //    db.SaveChanges();
        //    song68.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song68);
        //    song68.DiscountPrice = song68.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song68);
        //    db.SaveChanges();
        //    song68 = db.Songs.FirstOrDefault(s => s.SongName == "Runaway");
        //    song68.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song68.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song68.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song68);
        //    db.SaveChanges();

        //    Song song69 = new Song();
        //    song69.SongName = "Out of Goodbyes";
        //    db.Songs.AddOrUpdate(s => s.SongName, song69);
        //    db.SaveChanges();
        //    song69.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song69);
        //    song69.DiscountPrice = song69.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song69);
        //    db.SaveChanges();
        //    song69 = db.Songs.FirstOrDefault(s => s.SongName == "Out of Goodbyes");
        //    song69.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song69.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song69.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song69);
        //    db.SaveChanges();

        //    Song song70 = new Song();
        //    song70.SongName = "Moves Like Jaggers";
        //    db.Songs.AddOrUpdate(s => s.SongName, song70);
        //    db.SaveChanges();
        //    song70.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song70);
        //    song70.DiscountPrice = song70.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song70);
        //    db.SaveChanges();
        //    song70 = db.Songs.FirstOrDefault(s => s.SongName == "Moves Like Jagger");
        //    song70.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song70.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song70.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song70);
        //    db.SaveChanges();

        //    Song song71 = new Song();
        //    song71.SongName = "The Air That I Breathe";
        //    db.Songs.AddOrUpdate(s => s.SongName, song71);
        //    db.SaveChanges();
        //    song71.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song71);
        //    song71.DiscountPrice = song71.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song71);
        //    db.SaveChanges();
        //    song71 = db.Songs.FirstOrDefault(s => s.SongName == "The Air That I Breathe");
        //    song71.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song71.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song71.Album.AlbumName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song71);
        //    db.SaveChanges();


        //    Song song72 = new Song();
        //    song72.SongName = "Misery";
        //    db.Songs.AddOrUpdate(s => s.SongName, song72);
        //    db.SaveChanges();
        //    song72.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song72);
        //    song72.DiscountPrice = song72.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song72);
        //    db.SaveChanges();
        //    song72 = db.Songs.FirstOrDefault(s => s.SongName == "Misery");
        //    song72.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song72.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song72.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song72);
        //    db.SaveChanges();

        //    Song song73 = new Song();
        //    song73.SongName = "Give a Little More";
        //    db.Songs.AddOrUpdate(s => s.SongName, song73);
        //    db.SaveChanges();
        //    song73.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song73);
        //    song73.DiscountPrice = song73.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song73);
        //    db.SaveChanges();
        //    song73 = db.Songs.FirstOrDefault(s => s.SongName == "Give a Little More");
        //    song73.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song73.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song73.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song73);
        //    db.SaveChanges();

        //    Song song74 = new Song();
        //    song74.SongName = "Stutter";
        //    db.Songs.AddOrUpdate(s => s.SongName, song74);
        //    db.SaveChanges();
        //    song74.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song74);
        //    song74.DiscountPrice = song74.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song74);
        //    db.SaveChanges();
        //    song74 = db.Songs.FirstOrDefault(s => s.SongName == "Stutter");
        //    song74.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song74.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song74.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song57);
        //    db.SaveChanges();

        //    Song song75 = new Song();
        //    song75.SongName = "Don't Know Nothing";
        //    db.Songs.AddOrUpdate(s => s.SongName, song75);
        //    db.SaveChanges();
        //    song75.RegularPrice = 1.39m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song75);
        //    song75.DiscountPrice = song75.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song75);
        //    db.SaveChanges();
        //    song75 = db.Songs.FirstOrDefault(s => s.SongName == "Don't Know Nothing");
        //    song75.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song75.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song75.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song75);
        //    db.SaveChanges();

        //    Song song76 = new Song();
        //    song76.SongName = "Never Gonna Leave This Bed";
        //    db.Songs.AddOrUpdate(s => s.SongName, song76);
        //    db.SaveChanges();
        //    song76.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song76);
        //    song76.DiscountPrice = song76.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song76);
        //    db.SaveChanges();
        //    song76 = db.Songs.FirstOrDefault(s => s.SongName == "Never Gonna Leave This Bed");
        //    song76.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song76.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song76.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song76);
        //    db.SaveChanges();

        //    Song song77 = new Song();
        //    song77.SongName = "I Can't Lie";
        //    db.Songs.AddOrUpdate(s => s.SongName, song77);
        //    db.SaveChanges();
        //    song77.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song77);
        //    song77.DiscountPrice = song77.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song77);
        //    db.SaveChanges();
        //    song77 = db.Songs.FirstOrDefault(s => s.SongName == "I Can't Lie");
        //    song77.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song77.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song77.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song77);
        //    db.SaveChanges();

        //    Song song78 = new Song();
        //    song78.SongName = "Hands All Over";
        //    db.Songs.AddOrUpdate(s => s.SongName, song78);
        //    db.SaveChanges();
        //    song78.RegularPrice = 1.49m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song78);
        //    song78.DiscountPrice = song78.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song78);
        //    db.SaveChanges();
        //    song78 = db.Songs.FirstOrDefault(s => s.SongName == "Hands All Over");
        //    song78.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song78.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song78.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song78);
        //    db.SaveChanges();

        //    Song song79 = new Song();
        //    song79.SongName = "How";
        //    db.Songs.AddOrUpdate(s => s.SongName, song79);
        //    db.SaveChanges();
        //    song79.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song79);
        //    song79.DiscountPrice = song79.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song79);
        //    db.SaveChanges();
        //    song79 = db.Songs.FirstOrDefault(s => s.SongName == "How");
        //    song79.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song79.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song79.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song79);
        //    db.SaveChanges();

        //    Song song80 = new Song();
        //    song80.SongName = "Get Back in My Life";
        //    db.Songs.AddOrUpdate(s => s.SongName, song80);
        //    db.SaveChanges();
        //    song80.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song80);
        //    song80.DiscountPrice = song80.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song80);
        //    db.SaveChanges();
        //    song80 = db.Songs.FirstOrDefault(s => s.SongName == "Get Back in My Life");
        //    song80.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song80.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song80.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song80);
        //    db.SaveChanges();

        //    Song song81 = new Song();
        //    song81.SongName = "Just A Feeling";
        //    db.Songs.AddOrUpdate(s => s.SongName, song81);
        //    db.SaveChanges();
        //    song81.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song81);
        //    song81.DiscountPrice = song81.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song81);
        //    db.SaveChanges();
        //    song81 = db.Songs.FirstOrDefault(s => s.SongName == "Just A Feeling");
        //    song81.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song81.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song81.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song81);
        //    db.SaveChanges();

        //    Song song82 = new Song();
        //    song82.SongName = "Runaway";
        //    db.Songs.AddOrUpdate(s => s.SongName, song82);
        //    db.SaveChanges();
        //    song82.RegularPrice = 0.89m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song82);
        //    song82.DiscountPrice = song82.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song82);
        //    db.SaveChanges();
        //    song82 = db.Songs.FirstOrDefault(s => s.SongName == "Runaway");
        //    song82.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song82.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song82.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song82);
        //    db.SaveChanges();

        //    Song song83 = new Song();
        //    song83.SongName = "Out of Goodbyes";
        //    db.Songs.AddOrUpdate(s => s.SongName, song83);
        //    db.SaveChanges();
        //    song83.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song83);
        //    song83.DiscountPrice = song69.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song83);
        //    db.SaveChanges();
        //    song83 = db.Songs.FirstOrDefault(s => s.SongName == "Out of Goodbyes");
        //    song83.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song83.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song83.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song83);
        //    db.SaveChanges();

        //    Song song84 = new Song();
        //    song84.SongName = "Moves Like Jaggers";
        //    db.Songs.AddOrUpdate(s => s.SongName, song84);
        //    db.SaveChanges();
        //    song84.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song84);
        //    song84.DiscountPrice = song84.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song84);
        //    db.SaveChanges();
        //    song84 = db.Songs.FirstOrDefault(s => s.SongName == "Moves Like Jagger");
        //    song84.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song84.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song84.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song84);
        //    db.SaveChanges();

        //    Song song85 = new Song();
        //    song85.SongName = "Last Change";
        //    db.Songs.AddOrUpdate(s => s.SongName, song85);
        //    db.SaveChanges();
        //    song85.RegularPrice = 1.29m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song85);
        //    song85.DiscountPrice = song85.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song85);
        //    db.SaveChanges();
        //    song85 = db.Songs.FirstOrDefault(s => s.SongName == "Last Change");
        //    song85.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song85.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song85.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song85);
        //    db.SaveChanges();

        //    Song song86 = new Song();
        //    song86.SongName = "No Curtain Call";
        //    db.Songs.AddOrUpdate(s => s.SongName, song86);
        //    db.SaveChanges();
        //    song86.RegularPrice = 1.19m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song86);
        //    song86.DiscountPrice = song86.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song86);
        //    db.SaveChanges();
        //    song86 = db.Songs.FirstOrDefault(s => s.SongName == "No Curtain Call");
        //    song86.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song86.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song86.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song86);
        //    db.SaveChanges();

        //    Song song87 = new Song();
        //    song87.SongName = "If I Ain't Got You";
        //    db.Songs.AddOrUpdate(s => s.SongName, song87);
        //    db.SaveChanges();
        //    song87.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song87);
        //    song87.DiscountPrice = song87.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song87);
        //    db.SaveChanges();
        //    song87 = db.Songs.FirstOrDefault(s => s.SongName == "If I Ain't Got You");
        //    song87.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song87.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song87.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song87);
        //    db.SaveChanges();

        //    Song song88 = new Song();
        //    song88.SongName = "The Air That I Breathe";
        //    db.Songs.AddOrUpdate(s => s.SongName, song88);
        //    db.SaveChanges();
        //    song88.RegularPrice = 0.99m;
        //    db.Songs.AddOrUpdate(s => s.RegularPrice, song88);
        //    song88.DiscountPrice = song88.RegularPrice;
        //    db.Songs.AddOrUpdate(s => s.DiscountPrice, song88);
        //    db.SaveChanges();
        //    song88 = db.Songs.FirstOrDefault(s => s.SongName == "The Air That I Breathe");
        //    song88.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Maroon 5"));
        //    song88.Genres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
        //    song88.Album.AlbumName = "Hands All Over (Deluxe Version)";
        //    db.Songs.AddOrUpdate(s => s.Album.AlbumName, song88);
        //    db.SaveChanges();



        //}
        //void AddOrUpdateArtistGenre(AppDbContext db, string artistName, string genreName)
        //{
        //    Genre genre = db.Genres.SingleOrDefault(g => g.GenreName == genreName);
        //    Artist artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
        //    artist.Genres.Add(genre);
        //}
        //void AddOrUpdateSongGenre(AppDbContext db, string songName, string genreName)
        //{
        //    Genre genre = db.Genres.SingleOrDefault(g => g.GenreName == genreName);
        //    Song song = db.Songs.SingleOrDefault(s => s.SongName == songName);
        //    song.Genres.Add(genre);

        //}
    }
    }

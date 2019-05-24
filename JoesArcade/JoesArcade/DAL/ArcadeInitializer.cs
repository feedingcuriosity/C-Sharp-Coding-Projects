using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoesArcade.Models;

namespace JoesArcade.DAL
{
    //causes database to be created when needed and loads data into the new database.
    public class ArcadeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ArcadeContext>
    {
        //The Seed method uses the VideoGameContext object to add new entities(or rows) to the database (or entity set)
        //Note "seed" is best practice
        protected override void Seed(ArcadeContext context)
        {
            //create a collection of new entities

            var videogames = new List<VideoGame>
            {
                new VideoGame{Year=1982, Game="Joust", Genre="Action", Publisher="Williams Entertainment", OriginalPlatform="Arcade"},
                new VideoGame{Year=2003, Game="WarioWare,Inc.: Mega Microgames!", Genre="Action", Publisher="Nintendo", OriginalPlatform="Game Boy Advance"},
                new VideoGame{Year=2004, Game="Katamari Damacy", Genre="Action", Publisher="Namco", OriginalPlatform="PlayStation 2"},
                new VideoGame{Year=1977, Game="Zork", Genre="Adventure", Publisher="Infocom", OriginalPlatform="PDP-10"},
                new VideoGame{Year=1990, Game="The Secret of Monkey Island", Genre="Adventure", Publisher="LucasArts", OriginalPlatform="PC"},
                new VideoGame{Year=1991, Game="Monkey Island 2: LeChuck's Revenge", Genre="Adventure", Publisher="LucasArts", OriginalPlatform="PC"},
                new VideoGame{Year=1993, Game="Day of the Tentacle", Genre="Adventure", Publisher="LucasArts", OriginalPlatform="PC"},
                new VideoGame{Year=1993, Game="Myst", Genre="Adventure", Publisher="Broderbund", OriginalPlatform="Macintosh"},
                new VideoGame{Year=1993, Game="Sam & Max Hit the Road", Genre="Adventure", Publisher="LucasArts", OriginalPlatform="PC"},
                new VideoGame{Year=1998, Game="Grim Fandango", Genre="Adventure", Publisher="LucasArts", OriginalPlatform="PC"},
                new VideoGame{Year=1999, Game="Shenmue", Genre="Adventure", Publisher="Sega", OriginalPlatform="Dreamcast"},
                new VideoGame{Year=2012, Game="Journey", Genre="Adventure", Publisher="Sony Computer Entertainment", OriginalPlatform="PlayStation 3"},
                new VideoGame{Year=2012, Game="The Walking Dead", Genre="Adventure", Publisher="Telltale Games", OriginalPlatform="PC, PlayStation 3, Xbox 360"},
                new VideoGame{Year=1991, Game="Street Fighter II", Genre="Fighting", Publisher="Capcom", OriginalPlatform="Arcade"},
                new VideoGame{Year=1992, Game="Mortal Kombat", Genre="Fighting", Publisher="Midway", OriginalPlatform="Arcade"},
                new VideoGame{Year=1993, Game="Mortal Kombat II", Genre="Fighting", Publisher="Midway", OriginalPlatform="Arcade"},
                new VideoGame{Year=1997, Game="Tekken 3", Genre="Fighting", Publisher="Namco", OriginalPlatform="Arcade"},
                new VideoGame{Year=1998, Game="SoulCalibur", Genre="Fighting", Publisher="Namco", OriginalPlatform="Arcade"},
                new VideoGame{Year=2001, Game="Super Smash Bros. Melee", Genre="Fighting", Publisher="Nintendo", OriginalPlatform="GameCube"},
                new VideoGame{Year=2002, Game="Soulcalibur II", Genre="Fighting", Publisher="Namco", OriginalPlatform="Arcade"}
            };

            //adds them to the appropriate DbSet property 
            videogames.ForEach(s => context.VideoGames.Add(s));

            //and then saves the changes to the database.
            context.SaveChanges();

        }
    }
}
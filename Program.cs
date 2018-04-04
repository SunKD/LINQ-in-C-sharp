using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================

            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            IEnumerable<Artist> artistQuery =  from artist in Artists where artist.Hometown == "Mount Vernon" select artist;
            foreach(Artist artist in artistQuery){
                System.Console.WriteLine(artist.ArtistName + ", " + artist.Age);
            }
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================
            var min = (from person in Artists select person.Age).Min();
            var youngest = from person in Artists where person.Age == min select person;
            foreach (Artist artist in youngest)
            {
                System.Console.WriteLine(artist.ArtistName + ", " + artist.Age);
            }
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            var williams = (from people in Artists where people.RealName.Contains("William") select people);
            foreach (Artist artist in williams)
            {
                System.Console.WriteLine(artist.ArtistName + ", Real name: " +artist.RealName + ", " + artist.Age);
            }
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            var eightChars = (from match in Groups where (match.GroupName).Count() > 8 select match);
            foreach (Group group in eightChars)
            {
                System.Console.WriteLine(group.GroupName);
            }
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            var oldest = (from artist in Artists orderby artist.Age descending select artist).Take(3);
            foreach (Artist person in oldest)
            {
                System.Console.WriteLine(person.ArtistName + ", " + person.Age);
            }
            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================

            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
        }
    }
}

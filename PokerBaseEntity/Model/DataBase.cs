using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerBaseEntity.Model
{
    class DataBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DOB { get; set; }
        public string Image { get; set; }
        public string DateOfBirth { get; set; }
        public List<DataBaseTournament> Tournaments{get; set;}
        public static List<DataBase> GetPlayers(string Name = null, string LastName = null, string City = null, DateTime date = default(DateTime),List<DataBaseTournament> tourn=null)
        {
            Name = (string.IsNullOrWhiteSpace(Name) ? null : Name);
            LastName = (string.IsNullOrWhiteSpace(LastName) ? null : LastName);
            City = (string.IsNullOrWhiteSpace(City) ? null : City);
            var context = new PokerPlayersContext();
            var players = from p in context.Players
                          where p.PlayerName == (Name ?? p.PlayerName)
                          where p.Surname == (LastName ?? p.Surname)
                          where p.DOB == (date == default(DateTime) ? p.DOB : date)
                          where p.City.CityName == (City ?? p.City.CityName)
                          select p;
           
            List<DataBase> list = new List<DataBase>();
            foreach (var player in players)
            {
                DataBase db = new DataBase();
                db.Name = player.PlayerName;
                db.LastName = player.Surname;
                db.City = player.City.CityName;
                db.DOB = player.DOB;
                db.Image = player.Image;
                db.DateOfBirth = db.DOB.Date.ToShortDateString();
                if(tourn==null)
                list.Add(db);
                else
                { 
                    bool ok=true;
                    foreach(var t in tourn)
                    {
                        
                        if (!(t.Players.Exists(p=>p.DateOfBirth==db.DateOfBirth&&p.City==db.City&&p.DOB==db.DOB&&p.LastName==db.LastName&&p.Name==db.Name)))
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok) list.Add(db);
                }
            }
            return list;

        }
        public DataBase ToDataBase(Player player)
        {
           
            Name = player.PlayerName;
            LastName = player.Surname;
            City = player.City.CityName;
            DOB = player.DOB;
            Image = player.Image;
            DateOfBirth = DOB.Date.ToShortDateString();
            return this;
        }
        public static void SavePlayer(string Name,string LastName,string City,DateTime DOB,List<DataBaseTournament> Tournaments,string Image="D:\\PhotosPokerPlayer\\noname.png")
        {
            var pl = DataBase.GetPlayers(Name, LastName, City, DOB, Tournaments);
            if (pl.Count != 0) return;
            var context = new PokerPlayersContext();
            var cities=context.Cities.Where(p=>p.CityName==City);
            City city;
            if(cities.Count()==0)
            {
                 city=context.Cities.Add(new City{CityName=City});
            }
            else city=cities.Single();
            HashSet<Tournament> tournaments = new HashSet<Tournament>();
            int len=Tournaments.Count;
            int []places=new int[len];
                  if(Tournaments==null)tournaments=null;
                  else
                  {
                      int i=0;
                      foreach(var T in Tournaments)
                      {
                          Tournament t = context.Tournaments.Where(p => p.TournamentName == T.TournamentName).Single();
                          if (T.Place == null)
                              places[i++] = -1;
                          else places[i++]=Int32.Parse(T.Place);
                          tournaments.Add(t);
                      }
                  }
                  
           
            Player player = context.Players.Add(new Player { PlayerName = Name, Surname = LastName, City = city, DOB = DOB, Image = Image,RegistrationDate=DateTime.Now});
            var tournPl = context.TournamentPlayers;
            ICollection<TournamentPlayer> TP=new HashSet<TournamentPlayer>();
            if (tournaments != null)
            {
                int i=0;
                foreach (var t in tournaments)
                {
                    TournamentPlayer tp;
                    if (places[i] != -1)
                        tp = context.TournamentPlayers.Add(new TournamentPlayer { Player = player, Tournament = t, Place = places[i++] });
                    else { tp = context.TournamentPlayers.Add(new TournamentPlayer { Player = player, Tournament = t }); i++; }
                    TP.Add(tp);
                }
                player.TournamentPlayers = TP;
            }
            context.SaveChanges();
            
        }
        public static void DeletePlayer(string Name,string LastName,string City,DateTime DOB)
        {
            var context = new PokerPlayersContext();
            var player = from p in context.Players
                         where p.PlayerName == (Name??p.PlayerName)
                         where p.Surname == (LastName??p.Surname)
                         where p.City.CityName == (City??p.City.CityName)
                         where p.DOB == (DOB==default(DateTime)?p.DOB:DOB)
                         select p;
            foreach(var p in player)
            {
                context.Players.Remove(p);
            }
            context.SaveChanges();
        }
        /*public static List<DataBase> GetAll()
        {
            var context = new PokerPlayersContext();
            var players = context.Players;
            List<DataBase> list = new List<DataBase>();
            foreach (var player in players)
            {
                DataBase db = new DataBase();
                db.Name = player.PlayerName;
                db.LastName = player.Surname;
                db.City = player.City.CityName;
                db.DOB = player.DOB;
                db.Image = player.Image;
                list.Add(db);
            }
            return list;
        }
         * */
    }
}

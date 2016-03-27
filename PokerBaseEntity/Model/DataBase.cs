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

        public static List<DataBase> GetPlayers(string Name=null,string LastName=null,string City=null,DateTime date=default(DateTime))
        {
            var context = new PokerPlayersContext();
            var players = from p in context.Players
                where p.PlayerName == (Name==null?p.PlayerName:Name) 
                where p.Surname == (LastName==null?p.Surname:LastName) 
                where p.DOB == (date==default(DateTime)?p.DOB:date)
                where (City==null?p.City.CityName:City)==p.City.CityName
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
                list.Add(db);
            }
            return list;


        }

        public static List<DataBase> GetAll()
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
    }
}

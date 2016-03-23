using System;
using System.Collections.Generic;
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
        public DateTime Date { get; set; }
        public string Image { get; set; }

        public void GetPlayers(string Name,string LastName,string City,DateTime date)
        {
            var context = new PokerPlayersContext();
            var players = from p in context.Players
                where p.PlayerName == Name && p.Surname == LastName && p.DOB == date&&City==p.City.CityName
                select p;
            List<DataBase> list=new List<DataBase>();
            foreach (var player in players)
            {
                DataBase db = new DataBase();
                db.Name = player.PlayerName;
                db.LastName = player.Surname;
                db.City = player.City.CityName;
                db.Date = player.DOB;
                db.Image = player.Image;
                list.Add(db);
            }

            
        }

    }
}

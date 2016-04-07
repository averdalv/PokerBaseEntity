using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerBaseEntity.Model
{
    class DataBaseTournament
    {
        public int Payment { get; set; }
        public bool IsOnline { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Organization { get; set; }
        public string TournamentName { get; set; }
        public string WinRatio { get; set; }
        public List<DataBase> Players{get;set;}
        public bool isChecked { get; set; }
        public static List<DataBaseTournament> GetTourtnaments(int payment=0,bool isOnline=false,DateTime date=default(DateTime),string city=null,string organization=null,string name=null,string winRation=null)       
        {
            name = (string.IsNullOrWhiteSpace(name) ? null : name);
            organization = (string.IsNullOrWhiteSpace(organization) ? null : organization);
            city = (string.IsNullOrWhiteSpace(city) ? null : city);
            winRation = (string.IsNullOrWhiteSpace(winRation) ? null : winRation);
            var context = new PokerPlayersContext();
            var tournaments = from p in context.Tournaments
                          where p.TournamentName == (name ?? p.TournamentName)
                          where p.Organization.OrganizationName == (organization ?? p.Organization.OrganizationName)
                          where p.Date == (date == default(DateTime) ? p.Date : date)
                          where p.City.CityName == (city ?? p.City.CityName)
                          where p.IsOnline==isOnline
                          where p.Payment==(payment==0?p.Payment:payment)
                          where p.WinRatio==(winRation??p.WinRatio)
                          select p;
            List<DataBaseTournament> list = new List<DataBaseTournament>();
            foreach (var tournament in tournaments)
            {
                DataBaseTournament db = new DataBaseTournament();
                db.TournamentName = tournament.TournamentName;
                db.Organization = tournament.Organization.OrganizationName;
                db.City = tournament.City.CityName;
                db.Date = tournament.Date;
                db.Payment = tournament.Payment;
                db.WinRatio = tournament.WinRatio;
                db.IsOnline = tournament.IsOnline;
                var tourPl = context.TournamentPlayers.Where(p => p.TournamentId == tournament.TournamentId);
                List<DataBase> listDataBase = new List<DataBase>();
                foreach(var a in tourPl)
                {
                    var player = a.Player;
                    DataBase DatB=new DataBase();
                    listDataBase.Add(DatB.ToDataBase(player));
                }
                db.Players = listDataBase;
                db.isChecked = false;
                list.Add(db);
            }
            return list;
        }
    }
}

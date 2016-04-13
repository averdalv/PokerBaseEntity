using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PokerBaseEntity.Model
{
    class DataBaseTournament:IDataErrorInfo
    {
        public string Error
        {
            get { return error; }
        }
        private string error;
        public string this[string columnName]
        {
            get
            {

                switch (columnName)
                {
                    
                    case "Place":
                        {
                            bool ok = true;
                            
                               int p;
                            if (!string.IsNullOrWhiteSpace(Place)&&(!Int32.TryParse(Place, out p) || p <= 0 || p <= CountPlace)) { error = "Incorrect place"; ok = false; }
                            
                            if (ok) error = null;
                            break;
                        }
                }
                return error;
            }
        }
        public int Payment { get; set; }
        public bool IsOnline { get; set; }
        public DateTime Date { get; set; }
        public string DATE { get; set; }
        public string City { get; set; }
        public string Organization { get; set; }
        public string TournamentName { get; set; }
        public string WinRatio { get; set; }
        public List<DataBase> Players{get;set;}
        public DataBase FirstPlace { get; set; }
        public DataBase SecondPlace { get; set; }
        public DataBase ThirdPlace { get; set; } 
        public bool isChecked { get; set; }
        public string Place { get; set; }
        public int CountPlayers { get; set; }
        public int CountPlace { get; set; }
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
                          where p.Payment>=(payment==0?p.Payment:payment)
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
                db.DATE = db.Date.ToShortDateString();
                var tourPl = context.TournamentPlayers.Where(p => p.TournamentId == tournament.TournamentId);
                List<DataBase> listDataBase = new List<DataBase>();
                int maxPlace = 0;
                int countPl = 0;
                foreach(var a in tourPl)
                {
                    countPl++;
                    var player = a.Player;
                    DataBase DatB=new DataBase();
                    DatB = DatB.ToDataBase(player);
                    maxPlace = Math.Max((int)a.Place, maxPlace);
                    if (a.Place == 1) db.FirstPlace = DatB;
                    else if (a.Place == 2) db.SecondPlace = DatB;
                    else if (a.Place == 3) db.ThirdPlace = DatB;
                    listDataBase.Add(DatB);
                }
                db.CountPlayers = countPl;
                db.CountPlace = maxPlace;
                db.Players = listDataBase;
                db.isChecked = false;
                list.Add(db);
            }
            return list;
        }
    }
}

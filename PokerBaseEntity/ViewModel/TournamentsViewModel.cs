using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerBaseEntity.Model;

namespace PokerBaseEntity.ViewModel
{
    class TournamentsViewModel
    {
        public int Payment { get; set; }
        public bool IsOnline { get; set; }
        public DateTime Date { get; set; }
        public string DATE { get; set; }
        public string City { get; set; }
        public string Organization { get; set; }
        public string TournamentName { get; set; }
        public string WinRatio { get; set; }
        public List<DataBase> Players { get; set; }
        public DataBase FirstPlace { get; set; }
        public DataBase SecondPlace { get; set; }
        public DataBase ThirdPlace { get; set; }
        public bool isChecked { get; set; }
        public string Place { get; set; }
        public int CountPlayers { get; set; }
        public int CountPlace { get; set; }
        public TournamentsViewModel(DataBaseTournament db)
        {
            Payment = db.Payment;
            IsOnline = db.IsOnline;
            Date = db.Date;
            DATE = db.DATE;
            City = db.City;
            Organization = db.Organization;
            TournamentName = db.TournamentName;
            WinRatio = db.WinRatio;
            Players = db.Players;
            FirstPlace = db.FirstPlace;
            SecondPlace = db.SecondPlace;
            ThirdPlace = db.ThirdPlace;
            isChecked = db.isChecked;
            Place = db.Place;
            CountPlayers = db.CountPlayers;
            CountPlace = db.CountPlayers;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokerBaseEntity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public City()
        {
            this.Players = new HashSet<Player>();
            this.Tournaments = new HashSet<Tournament>();
        }
    
        public int CityId { get; set; }
        public string CityName { get; set; }
    
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
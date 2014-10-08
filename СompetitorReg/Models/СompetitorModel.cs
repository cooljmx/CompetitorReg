using System;

namespace CompetitorReg.Models
{
    public class СompetitorModel
    {
        public int IdСompetitor { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

using System;
using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class Competitor
    {
        public virtual int IdСompetitor { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Name { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string ContactPhone { get; set; }
        public virtual DateTime BirthDate { get; set; }
    }

    public class CompetitorMap : ClassMap<Competitor>
    {
        public CompetitorMap()
        {
            Table("Competitor");
            Id(x => x.IdСompetitor).Column("IdСompetitor").GeneratedBy.Identity();
            Map(x => x.Surname).Column("Surname");
            Map(x => x.Name).Column("Name");
            Map(x => x.MiddleName).Column("MiddleName");
            Map(x => x.ContactPhone).Column("ContactPhone");
            Map(x => x.BirthDate).Column("BirthDate");
        }
    }

}

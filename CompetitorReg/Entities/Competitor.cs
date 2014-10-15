using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class Competitor
    {
        public virtual int Id { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Name { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string ContactPhone { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string BirthPlace { get; set; }
        public virtual string PassportSerial { get; set; }
        public virtual string PassportNumber { get; set; }
        public virtual string IssuingAuthority { get; set; }
        public virtual string DepartmentCode { get; set; }
        public virtual DateTime IssueDate { get; set; }
        public virtual string Nee { get; set; }
        public virtual string IncorporationPlace { get; set; }
        public virtual string ResidencePlace { get; set; }
        public virtual IList<Interview> InterviewList { get; set; }
    }

    public class CompetitorMap : ClassMap<Competitor>
    {
        public CompetitorMap()
        {
            Table("Competitor");
            Id(x => x.Id).Column("IdCompetitor").GeneratedBy.Identity();
            Map(x => x.Surname).Column("Surname");
            Map(x => x.Name).Column("Name");
            Map(x => x.MiddleName).Column("MiddleName");
            Map(x => x.ContactPhone).Column("ContactPhone");
            Map(x => x.BirthDate).Column("BirthDate");
            Map(x => x.BirthPlace).Column("BirthPlace");
            Map(x => x.PassportSerial).Column("PassportSerial");
            Map(x => x.PassportNumber).Column("PassportNumber");
            Map(x => x.IssuingAuthority).Column("IssuingAuthority");
            Map(x => x.DepartmentCode).Column("DepartmentCode");
            Map(x => x.IssueDate).Column("IssueDate");
            Map(x => x.Nee).Column("Nee");
            Map(x => x.IncorporationPlace).Column("IncorporationPlace");
            Map(x => x.ResidencePlace).Column("ResidencePlace");
            HasMany(x => x.InterviewList).KeyColumn("IdCompetitor").LazyLoad();
        }
    }
}

using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class Interview
    {
        public virtual int Id { get; set; }
        public virtual string HrComment { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string TestResult { get; set; }
        public virtual string CompetitorComment { get; set; }

        public virtual Competitor Competitor { get; set; }
        public virtual StatusR StatusR { get; set; }
        public virtual InterviewStatus InterviewStatus { get; set; }
        public virtual InterviewSecurityStatus InterviewSecurityStatus { get; set; }

        public virtual IList<Position> PositionList { get; set; }
    }

    public class InterviewMap : ClassMap<Interview>
    {
        public InterviewMap()
        {
            Table("Interview");
            Id(x => x.Id).Column("IdInterview").GeneratedBy.Identity();
            Map(x => x.HrComment).Column("HrComment");
            Map(x => x.Date).Column("Date");
            Map(x => x.TestResult).Column("TestResult");
            Map(x => x.CompetitorComment).Column("CompetitorComment");
            References(x => x.Competitor).Column("IdCompetitor");
            References(x => x.StatusR).Column("IdStatusR");
            References(x => x.InterviewStatus).Column("IdInterviewStatus");
            References(x => x.InterviewSecurityStatus).Column("IdInterviewSecurityStatus");
            HasManyToMany(x => x.PositionList)
                .Table("RelInterviewPosition")
                .ParentKeyColumn("IdInterview")
                .ChildKeyColumn("IdPosition")
                .LazyLoad();
        }
    }
}

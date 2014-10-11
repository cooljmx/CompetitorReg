using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class InterviewSecurityStatus
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class InterviewSecurityStatusMap : ClassMap<InterviewSecurityStatus>
    {
        public InterviewSecurityStatusMap()
        {
            Table("InterviewSecurityStatus");
            Id(x => x.Id).Column("IdInterviewSecurityStatus");
            Map(x => x.Name).Column("Name");
        }
    }
}

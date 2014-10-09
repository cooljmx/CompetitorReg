using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class InterviewStatus
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class InterviewStatusMap : ClassMap<InterviewStatus>
    {
        public InterviewStatusMap()
        {
            Table("InterviewStatus");
            Id(x => x.Id).Column("IdInterviewStatus").GeneratedBy.Identity();
            Map(x => x.Name).Column("Name");
        }
    }
}

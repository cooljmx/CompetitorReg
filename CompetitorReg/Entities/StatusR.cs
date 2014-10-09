using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class StatusR
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class StatusRMap : ClassMap<StatusR>
    {
        public StatusRMap()
        {
            Table("StatusR");
            Id(x => x.Id).Column("IdStatusR");
            Map(x => x.Name).Column("Name");
        }
    }
}

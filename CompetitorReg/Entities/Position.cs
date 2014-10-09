using FluentNHibernate.Mapping;

namespace CompetitorReg.Entities
{
    public class Position
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        {
            Table("Position");
            Id(x => x.Id).Column("IdPosition").GeneratedBy.Identity();
            Map(x => x.Name).Column("Name");
        }
    }
}

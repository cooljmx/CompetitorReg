using FluentNHibernate.Mapping;

namespace StaffReg.Entities
{
    public class Staff
    {
        public virtual int IdStaff { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Name { get; set; }
        public virtual string MiddleName { get; set; }
    }

    public class StaffMap : ClassMap<Staff>
    {
        public StaffMap()
        {
            Table("Staff");
            Id(x => x.IdStaff).Column("IdStaff").GeneratedBy.TriggerIdentity();
            Map(x => x.Surname).Column("Surname");
            Map(x => x.Name).Column("Name");
            Map(x => x.MiddleName).Column("MiddleName");
        }
    }

}

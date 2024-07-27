using Ex.Domain.ActivityAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.ActivityAgg
{
    public class Activity : AuditableAggregateRootBase<long>
    {
        public string Name { get; private set; }
        public int Type { get; private set; }
        public int SubType { get; private set; }
        public int? SourceId { get; private set; }
        public bool IsOther { get; set; }

        protected Activity() { }

        public Activity(Guid creator, string name, int type, int subType, int? sourceId, bool isOther, IActivityService service) : base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
            Type = type;
            SubType = subType;
            SourceId = sourceId;
            IsOther = isOther;
        }

        public void Edit(Guid actor, string name, int type, int subType, int? sourceId, bool isOther, IActivityService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;
            Type = type;
            SubType = subType;
            SourceId= sourceId;
            IsOther = isOther;

            Modified(actor);
        }
    }
}

using Ex.Domain.TaskMasterAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.TaskMasterAgg
{
    public class TaskMaster : AuditableAggregateRootBase<long>
    {
        public string Name { get; set; }

        protected TaskMaster() { }

        public TaskMaster(Guid creator, string name, ITaskMasterService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
        }

        public void Edit(Guid actor, string name, ITaskMasterService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;

            Modified(actor);
        }
    }
}

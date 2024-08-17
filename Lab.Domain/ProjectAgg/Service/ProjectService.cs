using Ex.Domain.PartAgg;
using Ex.Domain.GasTypeAgg;
using Ex.Domain.WireTypeAgg;
using Ex.Domain.PowderTypeAgg;
using Ex.Application.Contracts.Project;
using Ex.Domain.WireScrewAgg;
using PhoenixFramework.Core.Exceptions;

namespace Ex.Domain.ProjectAgg.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IPartRepository _partRepository;
        private readonly IGasTypeRepository _gasTypeRepository;
        private readonly IWireTypeRepository _wireTypeRepository;
        private readonly IPowderTypeRepository _powderTypeRepository;
        private readonly IWireScrewRepository _wireScrewRepository;

        public ProjectService(IPartRepository partRepository, IGasTypeRepository gasTypeRepository,
            IWireTypeRepository wireTypeRepository, IPowderTypeRepository powderTypeRepository,
            IWireScrewRepository wireScrewRepository)
        {
            _partRepository = partRepository;
            _gasTypeRepository = gasTypeRepository;
            _wireTypeRepository = wireTypeRepository;
            _powderTypeRepository = powderTypeRepository;
            _wireScrewRepository = wireScrewRepository;
        }

        public void SetDetails(Project project, List<ProjectDetailOperations> details)
        {
            foreach (var incomming in details)
            {
                var partId = _partRepository.GetIdBy(incomming.PartGuid);

                long? gasTypeId = null;
                if (incomming.GasTypeGuid is not null)
                    gasTypeId = _gasTypeRepository.GetIdBy(incomming.GasTypeGuid.Value);

                long? wireTypeId = null;
                if (incomming.WireTypeGuid is not null)
                    wireTypeId = _wireTypeRepository.GetIdBy(incomming.WireTypeGuid.Value);

                long? wireScrewId = null;
                if (incomming.WireScrewGuid is not null)
                    wireScrewId = _wireScrewRepository.GetIdBy(incomming.WireScrewGuid.Value);

                long? powderTypeId = null;
                if (incomming.PowderTypeGuid is not null)
                    powderTypeId = _powderTypeRepository.GetIdBy(incomming.PowderTypeGuid.Value);

                if (incomming.Id > 0)
                {
                    var detail = project.Details.FirstOrDefault(x => x.Id == incomming.Id);

                    if (incomming.IsDeleted)
                    {
                        project.Details.Remove(detail);
                        continue;
                    }

                    detail.Edit(partId, incomming.PartCode, gasTypeId, wireTypeId, wireScrewId, incomming.WireThickness,
                        incomming.WireConsumption, powderTypeId, incomming.Description);
                }
                else
                {
                    var item = new ProjectDetail(partId, incomming.PartCode, gasTypeId, wireTypeId, wireScrewId,
                        incomming.WireThickness, incomming.WireConsumption, powderTypeId, incomming.Description);

                    project.AddDetail(item);
                }
            }

            if (project.Details.GroupBy(x => x.PartCode).Any(x => x.Count() > 1))
                throw new BusinessException("0", "کد قطعه تکراری وارد شده است، لطفا اصلاح کنید.");
        }
    }
}

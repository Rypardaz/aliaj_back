using AM.Application.Contracts.Project;
using AM.Domain.GasTypeAgg;
using AM.Domain.PartAgg;
using AM.Domain.PowderTypeAgg;
using AM.Domain.WireTypeAgg;

namespace AM.Domain.ProjectAgg.Service;

public class ProjectService(
    IPartRepository partRepository,
    IGasTypeRepository gasTypeRepository,
    IWireTypeRepository wireTypeRepository,
    IPowderTypeRepository powderTypeRepository)
    : IProjectService
{
    public void SetDetails(Project project, List<ProjectDetailOperations> details)
    {
        foreach (var incomming in details)
        {
            long? partId = null;
            if (incomming.PartGuid is not null)
                partId = partRepository.GetIdBy(incomming.PartGuid.Value);

            long? gasTypeId = null;
            if (incomming.GasTypeGuid is not null)
                gasTypeId = gasTypeRepository.GetIdBy(incomming.GasTypeGuid.Value);

            long? wireTypeId = null;
            if (incomming.WireTypeGuid is not null)
                wireTypeId = wireTypeRepository.GetIdBy(incomming.WireTypeGuid.Value);

            long? powderTypeId = null;
            if (incomming.PowderTypeGuid is not null)
                powderTypeId = powderTypeRepository.GetIdBy(incomming.PowderTypeGuid.Value);

            if (incomming.Id > 0)
            {
                var detail = project.Details.FirstOrDefault(x => x.Id == incomming.Id);

                if (incomming.IsDeleted)
                {
                    project.Details.Remove(detail);
                    continue;
                }

                detail.Edit(partId, incomming.PartCode, gasTypeId, wireTypeId, incomming.WireScrewGuid,
                    incomming.ProductionQty, incomming.WireThickness, incomming.WireConsumption, powderTypeId,
                    incomming.Description);
            }
            else
            {
                var item = new ProjectDetail(partId, incomming.PartCode, gasTypeId, wireTypeId,
                    incomming.WireScrewGuid, incomming.ProductionQty, incomming.WireThickness,
                    incomming.WireConsumption, powderTypeId, incomming.Description);

                project.AddDetail(item);
            }
        }

        // if (project.Details.GroupBy(x => x.PartCode).Any(x => x.Count() > 1))
        //     throw new BusinessException("0", "کد قطعه تکراری وارد شده است، لطفا اصلاح کنید.");
    }
}
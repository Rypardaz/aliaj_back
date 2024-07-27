using Ex.Domain.GasTypeAgg;
using Ex.Domain.ProjectAgg;
using Ex.Domain.ActivityAgg;
using Ex.Domain.PersonnelAgg;
using Ex.Domain.PowderTypeAgg;
using Ex.Application.Contracts.DailyRecord;
using Ex.Domain.WireTypeAgg;
using Ex.Domain.WireScrewAgg;

namespace Ex.Domain.DailyRecordAgg.Service
{
    public class DailyRecordService : IDailyRecordService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IGasTypeRepository _gasTypeRepository;
        private readonly IPowderTypeRepository _powderTypeRepository;
        private readonly IWireTypeRepository _wireTypeRepository;
        private readonly IWireScrewRepository _wireScrewRepository;

        public DailyRecordService(IPersonnelRepository personnelRepository, IProjectRepository projectRepository, IActivityRepository activityRepository, IGasTypeRepository gasTypeRepository, IPowderTypeRepository powderTypeRepository, IWireTypeRepository wireTypeRepository, IWireScrewRepository wireScrewRepository)
        {
            _personnelRepository = personnelRepository;
            _projectRepository = projectRepository;
            _activityRepository = activityRepository;
            _gasTypeRepository = gasTypeRepository;
            _powderTypeRepository = powderTypeRepository;
            _wireTypeRepository = wireTypeRepository;
            _wireScrewRepository = wireScrewRepository;
        }

        public void SetDetails(DailyRecord dailyRecord, List<DailyRecordDetailOperations> details)
        {
            dailyRecord.EmptyDetails();

            foreach (var detail in details)
            {
                var personnelId = _personnelRepository.GetIdBy(detail.PersonnelGuid);
                var projectDetailId = _projectRepository.DetailIdBy(detail.ProjectDetailGuid);
                var activityId = _activityRepository.GetIdBy(detail.ActivityGuid);

                var item = new DailyRecordDetail(dailyRecord.Id, personnelId, projectDetailId, detail.StartTime,
                    detail.EndTime, activityId, detail.WireConsumption);

                if (detail.GasTypeGuid is not null)
                    item.SetGasTypeId(_gasTypeRepository.GetIdBy(detail.GasTypeGuid.Value));

                if (detail.PowderTypeGuid is not null)
                    item.SetPowderTypeId(_powderTypeRepository.GetIdBy(detail.PowderTypeGuid.Value));

                if (detail.WireTypeGuid is not null)
                    item.SetWireTypeId(_wireTypeRepository.GetIdBy(detail.WireTypeGuid.Value));

                if (detail.WireScrewGuid is not null)
                    item.SetWireScrewId(_wireScrewRepository.GetIdBy(detail.WireScrewGuid.Value));
                
                dailyRecord.AddDetail(item);
            }
        }
    }
}
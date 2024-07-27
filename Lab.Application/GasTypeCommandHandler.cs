using Ex.Application.Contracts.GasType;
using Ex.Domain.GasTypeAgg.Service;
using Ex.Domain.GasTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Domain.GasTypeGroupAgg;

namespace Ex.Application
{
    public class GasTypeCommandHandler :
    ICommandHandler<CreateGasType, Guid>,
    ICommandHandler<EditGasType>,
    ICommandHandler<RemoveGasType>,
    ICommandHandler<ActivateGasType>,
    ICommandHandler<DeactivateGasType>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IGasTypeRepository _gasTypeRepository;
        private readonly IGasTypeService _gasTypeService;
        private readonly IGasTypeGroupRepository _gasTypeGroupRepository;

        public GasTypeCommandHandler(IClaimHelper claimHelper
            , IGasTypeRepository gasTypeRepository
            , IGasTypeService gasTypeService
            , IGasTypeGroupRepository gasTypeGroupRepository)
        {
            _claimHelper = claimHelper;
            _gasTypeRepository = gasTypeRepository;
            _gasTypeService = gasTypeService;
            _gasTypeGroupRepository = gasTypeGroupRepository;
        }

        public Guid Handle(CreateGasType command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var gasTypeGroupId = _gasTypeGroupRepository.GetIdBy(command.GasTypeGroupGuid);
            var gasType = new GasType(creator, gasTypeGroupId, command.Name, _gasTypeService);
            _gasTypeRepository.Create(gasType);
            return gasType.Guid;
        }

        public void Handle(EditGasType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var gasType = _gasTypeRepository.Load(command.Guid);
            var gasTypeGroupId = _gasTypeGroupRepository.GetIdBy(command.GasTypeGroupGuid);
            gasType.Edit(actor, gasTypeGroupId, command.Name, _gasTypeService);
        }

        public void Handle(RemoveGasType command)
        {
            var gasType = _gasTypeRepository.Load(command.Guid);
            _gasTypeRepository.Delete(gasType);
        }
        public void Handle(ActivateGasType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var gasType = _gasTypeRepository.Load(command.Guid);
            gasType.Activate();
        }

        public void Handle(DeactivateGasType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var gasType = _gasTypeRepository.Load(command.Guid);
            gasType.Deactivate();
        }
    }
}

using Ex.Application.Contracts.PowderType;
using Ex.Domain.PowderTypeAgg.Service;
using Ex.Domain.PowderTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Domain.PowderTypeGroupAgg;

namespace Ex.Application
{
    public class PowderTypeCommandHandler :
        ICommandHandler<CreatePowderType, Guid>,
        ICommandHandler<EditPowderType>,
        ICommandHandler<RemovePowderType>,
        ICommandHandler<ActivatePowderType>,
        ICommandHandler<DeactivatePowderType>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IPowderTypeRepository _powderTypeRepository;
        private readonly IPowderTypeService _powderTypeService;
        private readonly IPowderTypeGroupRepository _powderTypeGroupRepository;

        public PowderTypeCommandHandler(IClaimHelper claimHelper
            , IPowderTypeRepository powderTypeRepository
            , IPowderTypeService powderTypeService
            , IPowderTypeGroupRepository powderTypeGroupRepository)
        {
            _claimHelper = claimHelper;
            _powderTypeRepository = powderTypeRepository;
            _powderTypeService = powderTypeService;
            _powderTypeGroupRepository = powderTypeGroupRepository;
        }

        public Guid Handle(CreatePowderType command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var powderTypeGroupId = _powderTypeGroupRepository.GetIdBy(command.PowderTypeGroupGuid);
            var powderType = new PowderType(creator, powderTypeGroupId, command.Name, _powderTypeService);
            _powderTypeRepository.Create(powderType);
            return powderType.Guid;
        }

        public void Handle(EditPowderType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var powderType = _powderTypeRepository.Load(command.Guid);
            var powderTypeGroupId = _powderTypeGroupRepository.GetIdBy(command.PowderTypeGroupGuid);
            powderType.Edit(actor, powderTypeGroupId, command.Name, _powderTypeService);
        }

        public void Handle(RemovePowderType command)
        {
            var powderType = _powderTypeRepository.Load(command.Guid);
            _powderTypeRepository.Delete(powderType);
        }
        public void Handle(ActivatePowderType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var powderType = _powderTypeRepository.Load(command.Guid);
            powderType.Activate();
        }

        public void Handle(DeactivatePowderType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var powderType = _powderTypeRepository.Load(command.Guid);
            powderType.Deactivate();
        }
    }
}

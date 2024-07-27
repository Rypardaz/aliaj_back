﻿using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Infrastructure.Query.Contracts.PowderTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PowderTypeGroup
{
    public interface IPowderTypeGroupQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<PowderTypeGroupViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditPowderTypeGroup GetDetails(Guid guid);
        List<PowderTypeGroupComboModel> Combo();
    }
}

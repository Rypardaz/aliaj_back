using System;
using System.Collections.Generic;
using PhoenixFramework.Domain;
using UserManagement.Application.Contracts.ViewModels;

namespace UserManagement.Domain.Feature
{
    public interface IFeatureRepository : IRepository<int, Feature>
    {
        List<FeatureViewModel> GetList(Guid? userGroupGuid);
        int GetIdBy(string engName);
    }
}
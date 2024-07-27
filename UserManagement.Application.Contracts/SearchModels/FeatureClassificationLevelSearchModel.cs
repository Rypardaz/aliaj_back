using System;

namespace UserManagement.Application.Contracts.SearchModels;

public class FeatureClassificationLevelSearchModel
{
    public Guid UserClassificationLevelGuid { get; set; }
    public string FeatureTitle { get; set; }
}
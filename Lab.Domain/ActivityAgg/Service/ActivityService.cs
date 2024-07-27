﻿using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.ActivityAgg.Service
{
    public class ActivityService : IActivityService
    {
        private Expression<Func<Activity, bool>>? _predicate;
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public void ThrowWhenDuplicatedName(string name, long? id = null)
        {
            _predicate = x => x.Name == name;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_activityRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_activityRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

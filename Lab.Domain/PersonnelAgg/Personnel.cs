﻿using Ex.Domain.PersonnelAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.PersonnelAgg
{
    public class Personnel : AuditableAggregateRootBase<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string? NationalCode { get; private set; }
        public long? SalonId { get; set; }

        protected Personnel()
        {
        }

        public Personnel(Guid creator, string name, string code, string family, string? nationalCode, long? salonId,
            IPersonnelService service) : base(creator)
        {
            service.ThrowWhenDuplicatedName(name, family);

            Code = code;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            SalonId = salonId;
        }

        public void Edit(Guid actor, string name, string code, string family, string? nationalCode, long? salonId,
            IPersonnelService service)
        {
            service.ThrowWhenDuplicatedName(name, family, Id);

            Code = code;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            SalonId = salonId;

            Modified(actor);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface ILocationManager
    {
        IList<ContactLocation> GetAll();
        ContactLocation Get(Guid contactId);
        void Add(ContactLocationAddDto contactLocationAddDto);
        void Update(ContactLocationDto contactLocationDto);
        void Delete(ContactLocation contactLocation);
    }
}

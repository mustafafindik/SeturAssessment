﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturAssessment.ContactService.Entities.ViewModels
{
    public class ReportRequestModelWithLocation : ReportRequestModel
    {
        public string location { get; set; }
    }
}

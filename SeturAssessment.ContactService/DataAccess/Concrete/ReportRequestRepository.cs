using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SeturAssessment.ContactService.Entities.ViewModels;

namespace SeturAssessment.ContactService.DataAccess.Concrete
{
    public class ReportRequestRepository:IReportRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        
    }
}

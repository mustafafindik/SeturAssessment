using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.Business.Concrete;
using SeturAssessment.ReportService.DataAccess.Abstract;
using SeturAssessment.ReportService.DataAccess.Concrete;
using SeturAssessment.ReportService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ReportService.Utilities.DependencyResolvers.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReportManager>().As<IReportManager>().SingleInstance();
            builder.RegisterType<ReportRepository>().As<IReportRepository>().SingleInstance();



        }
    }
}

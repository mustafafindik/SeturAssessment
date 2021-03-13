using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.Business.Concrete;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.DataAccess.Concrete;

namespace SeturAssessment.ContactService.Utilities.DependencyResolvers.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactManager>().As<IContactManager>().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().SingleInstance();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.Business.Concrete;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.DataAccess.Concrete;
using SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ContactService.Utilities.DependencyResolvers.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactManager>().As<IContactManager>().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().SingleInstance();

            builder.RegisterType<EmailManager>().As<IEmailManager>().SingleInstance();
            builder.RegisterType<EmailRepository>().As<IEmailRepository>().SingleInstance();

            builder.RegisterType<PhoneNumberManager>().As<IPhoneNumberManager>().SingleInstance();
            builder.RegisterType<PhoneNumberRepository>().As<IPhoneNumberRepository>().SingleInstance();

            builder.RegisterType<LocationManager>().As<ILocationManager>().SingleInstance();
            builder.RegisterType<LocationRepository>().As<ILocationRepository>().SingleInstance();
            builder.RegisterType<ContactLocationRepository>().As<IContactLocationRepository>().SingleInstance();


            builder.RegisterType<MqQueueHelper>().As<IMessageBrokerHelper>().SingleInstance();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Seeds
{
    public static class ContactSeedData
    {
        public static void Seed(IApplicationBuilder app)
        {

            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();


            if (!context.Contacts.Any())
            {
                var contacts = new[]
                {
                    new Contact() { FirstName = "Ali" , LastName = "Yazıcı", Firm = "Apple", ContactDetails =
                        new List<ContactDetail>()
                        {
                            new ContactDetail(){Phone = "05550011220",Email = "Ali@yazıcı.com",Location = "İstanbul"},                           
                            new ContactDetail(){Phone = "05550011234",Email = "Ali2@yazıcı.com",Location = "Ankara"}

                         }
                    },

                    new Contact() { FirstName = "Muhammed" , LastName = "Ali", Firm = "Migrat", ContactDetails =
                        new List<ContactDetail>()
                        {
                            new ContactDetail(){Phone = "0834223344",Email = "Muhammed@ali.com",Location = "İstanbul"},
                            new ContactDetail(){Phone = "05550011234",Email = "MuhammedAli@Migrat.com",Location = "İstanbul"}

                        }
                    },

                    new Contact() { FirstName = "Burcu" , LastName = "Güneş", Firm = "Youware", ContactDetails =
                        new List<ContactDetail>()
                        {
                            new ContactDetail(){Phone = "05445556677",Email = "Burcu@Youware.com",Location = "İzmir"},
                            new ContactDetail(){Phone = "05550011234",Email = "Burcu@gunes.com",Location = "Ankara"}

                        }
                    },


                    new Contact() { FirstName = "Barış" , LastName = "Özcan", Firm = "Youtube", ContactDetails =
                        new List<ContactDetail>()
                        {
                            new ContactDetail(){Phone = "06452223344",Email = "barisozcan@Youtube.com",Location = "İstanbul"},
                            new ContactDetail(){Phone = "06452223322",Email = "barisozcan@barisozcan.com",Location = "Bursa"}

                        }
                    },

                    new Contact() { FirstName = "Neslihan" , LastName = "Türk", Firm = "LawsM", ContactDetails =
                        new List<ContactDetail>()
                        {
                            new ContactDetail(){Phone = "05443334455",Email = "neslihanturk@LawsM.com",Location = "İstanbul"},
                            new ContactDetail(){Phone = "05443334423",Email = "neslihanturk@neslihanturk.com",Location = "Bursa"}

                        }
                    },


                };

                context.AddRange(contacts);
                context.SaveChanges();



            }





        }
    }
}
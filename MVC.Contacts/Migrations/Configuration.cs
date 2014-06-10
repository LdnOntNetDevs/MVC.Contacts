namespace MVC.Contacts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC.Contacts.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<MVC.Contacts.Models.ContactsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC.Contacts.Models.ContactsDb";
        }

        protected override void Seed(MVC.Contacts.Models.ContactsDb context)
        {
            context.Contacts.AddOrUpdate(r => r.Name,
                new Contact
                {
                    Name = "Bob Smith",
                    Address = "123 Street",
                    City = "London",
                    Email = "bob@internet.com",
                    State = "Ontario",
                    Twitter = "BobTweets",
                    Zip = "N561B3",
                    PhoneNumbers = new List<ContactPhone> {
                         new ContactPhone
                     {
                         PhoneNumber = "555-555-5555",
                         Type = PhoneType.Home
                     }
                     }

                },
                  new Contact
                  {
                      Name = "Tanya Oaks",
                      Address = "125 Street",
                      City = "London",
                      Email = "tanya@internet.com",
                      State = "Ontario",
                      Twitter = "TanyaTweets",
                      Zip = "N561B3",
                      PhoneNumbers = new List<ContactPhone> {
                         new ContactPhone
                     {
                         PhoneNumber = "555-555-5555",
                         Type = PhoneType.Work
                     }
                     }

                  },
                    new Contact
                    {
                        Name = "Chris Brown",
                        Address = "321 Street",
                        City = "London",
                        Email = "Chris@internet.com",
                        State = "Ontario",
                        Twitter = "ChrisTweets",
                        Zip = "N561B3",
                        PhoneNumbers = new List<ContactPhone> {
                         new ContactPhone
                     {
                         PhoneNumber = "555-555-5555",
                         Type = PhoneType.Home
                     }
                     }

                    }
                );

            for (int i = 0; i < 1000; i++)
            {
                context.Contacts.AddOrUpdate(r => r.Name,
                    new Contact
                    {
                        Name = i.ToString(),
                        Address = "123 Sesame Street",
                        City = "Nowhere",
                        Email = string.Concat(i.ToString(), "@internet.com"),
                        State = "Ontario",
                        Twitter = string.Concat(i.ToString(), "Tweets"),
                        Zip = "123458"
                    });
            }

        }
    }
}

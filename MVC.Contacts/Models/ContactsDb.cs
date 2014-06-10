using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Contacts.Models
{
    public interface IContactsDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();

    }
    public class ContactsDb: DbContext, IContactsDb
    {
   

        public ContactsDb(): base("name=DefaultConnection")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }

        IQueryable<T> IContactsDb.Query<T>()
        {
            return Set<T>();
        }

        void IContactsDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IContactsDb.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IContactsDb.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IContactsDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}
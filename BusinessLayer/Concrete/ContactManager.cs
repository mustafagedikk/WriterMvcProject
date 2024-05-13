using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public  class ContactManager:IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact ContactGetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public int GetContactCount()
        {
            return _contactDal.List(x=>x.ContactID>0).Count();
        }

        public List<Contact> GetList()
        {
          return  _contactDal.List().OrderByDescending(x=>x.ContactDate).ToList();
        }

        public List<Contact> GetListContactSearch( string search)
        {
            return _contactDal.List(x => x.Message.Contains(search)).ToList();
        }
    }
}

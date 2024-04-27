using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IContactService
    {
        List<Contact> GetList();//Liste türünde tüm tüm category değerlerini döner

        void ContactAdd(Contact contact);

        Contact ContactGetByID(int id); ///Gelecek id değerine göre sadece bir kategori döner

        void ContactDelete(Contact contact);

        void ContactUpdate(Contact contact);
    }
}

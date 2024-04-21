using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetList();//Liste türünde tüm tüm category değerlerini döner

        void CategoryAdd(Category category);

        Category GetByID(int id); ///Gelecek id değerine göre sadece bir kategori döner

        void CategoryDelete(Category category);

        void CategoryUpdate(Category category);

    }
}

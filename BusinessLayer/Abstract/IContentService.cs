using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {

        List<Content> GetList();//Liste türünde tüm tüm category değerlerini döner
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingID(int id); ///id ye göre tüm listeyi döndür
        void ContentAdd(Content content);

        Content GetByID(int id); ///Gelecek id değerine göre sadece bir kategori döner

        void ContentDelete(Content content);

        void ContentUpdate(Content content);
    }
}

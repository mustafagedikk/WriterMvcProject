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
    public class ContentManager : IContentService
    {
        IContentDal _ContentDal;

        public ContentManager(IContentDal contentDal)
        {
            _ContentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _ContentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
          return  _ContentDal.List();
        }

        public List<Content> GetListByHeadingID(int id)///idye göre tüm listeyi döner
        {
            return _ContentDal.List(X => X.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _ContentDal.List(x => x.WriterID == id);
        }
    }
}

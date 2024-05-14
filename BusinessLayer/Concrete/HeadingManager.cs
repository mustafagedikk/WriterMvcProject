using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading CharHeading()
        {
            throw new NotImplementedException();
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            //return _headingDal.List();
            return _headingDal.List().Where(x => x.HeadingStatus == true).ToList();
        }

        public List<Heading> GetListByCategory(int id)
        {
           return _headingDal.List(x => x.CategoryID == id).ToList();
        }

        //Sadece filtre false olanlar listelenecek
        public List<Heading> GetListByHeadingStatus()
        {
            return _headingDal.List().Where(x => x.HeadingStatus == false).ToList();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public void HeadingAdd(Heading heading)
        {
             _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        
    }
}

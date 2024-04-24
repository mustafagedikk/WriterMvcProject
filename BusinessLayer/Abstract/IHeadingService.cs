using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading heading);
        Heading GetByID(int id);

        void HeadingDelete(Heading heading);

        void HeadingUpdate(Heading heading);


        ///statu false olanları getireceğim////
        List<Heading> GetListByHeadingStatus();
    }
}

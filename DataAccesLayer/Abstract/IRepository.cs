using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
 public  interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        void Delete(T p);

        /// ID si 5 olan yazar
        T Get(Expression<Func<T, bool>> filter);

        
        void Update(T p);

        //***İsmi ali olan yazarlar örnek olarak bulunabilir.*****
        List<T> List(Expression<Func<T, bool>> filter);
       
    }
}

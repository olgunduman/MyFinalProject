using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
   {
       
   }
}

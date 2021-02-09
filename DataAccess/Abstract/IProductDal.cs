using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Core.DataAccess;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
   {
       
   }
}

//Code Refactoring

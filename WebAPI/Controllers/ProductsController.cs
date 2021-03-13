using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loose coupled
        //naming convention
        //Ioc Container -- Inversion of Control
        IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
       
        [HttpGet("getall")]
  //      [Authorize(Roles = "product.list")]
        public IActionResult GetAll()
        {

            Thread.Sleep(1000);
            //dependenct chain 
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
       // [Authorize(Roles = "product.add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
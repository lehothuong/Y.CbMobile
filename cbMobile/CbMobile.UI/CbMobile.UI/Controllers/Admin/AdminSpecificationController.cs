using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSpecificationController : ControllerBase
    {
        private readonly ISpecificationAppService _specificationAppService;
        public AdminSpecificationController(ISpecificationAppService specificationAppService)
        {
            _specificationAppService = specificationAppService;
        }
        [HttpGet]
        [Route("AdminGetAllSpecification")]
        public IActionResult AdminGetAllSpecification(int page = 1, int pageSize = 10)
        {
            return Ok(_specificationAppService.AdminGetAllSpecification(page, pageSize));
        }
        [HttpGet]
        [Route("GetDetailSpecification")]
        public IActionResult GetDetailSpecification(int id)
        {
            return Ok(_specificationAppService.GetDetailSpecification(id));
        }
        [HttpPost]
        [Route("CreateSpecification")]
        public IActionResult CreateSpecification([FromBody]Specification specification)
        {
            if (ModelState.IsValid)
            {
                var model = _specificationAppService.CreateSpecification(specification);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateSpecification")]
        public IActionResult UpdateSpecification([FromBody]Specification specification)
        {
            if (ModelState.IsValid)
            {
                var model = _specificationAppService.UpdateSpecification(specification);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteSpecification")]
        public IActionResult DeleteSpecification(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _specificationAppService.DeleteSpecification(id);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetListDropdownSpecification")]
        public IActionResult GetListDropdownCategoryBanner()
        {
            return Ok(_specificationAppService.GetListDropdownSpecification());
        }
        [HttpPost]
        [Route("CreateDetailSpecification")]
        public IActionResult CreateDetailSpecification(DetailSpecification detailSpecification)
        {
            if (ModelState.IsValid)
            {
                var model = _specificationAppService.CreateDetailSpecification(detailSpecification);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetAllSpecificationById")]
        public IActionResult GetAllSpecificationById(int id)
        {
            return Ok(_specificationAppService.GetAllSpecificationById(id));
        }
        [HttpGet]
        [Route("GetSpecificationById")]
        public IActionResult GetSpecificationById(int id, int productId, int specificationId)
        {
            return Ok(_specificationAppService.GetSpecificationById(id, productId, specificationId));
        }
        [HttpPut]
        [Route("UpdateDetailSpecification")]
        public IActionResult UpdateDetailSpecification([FromBody]DetailSpecification detailSpecification)
        {
            if (ModelState.IsValid)
            {
                var model = _specificationAppService.UpdateDetailSpecification(detailSpecification);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteDetailSpecification")]
        public IActionResult DeleteDetailSpecification(int id, int productId, int specificationId)
        {
            if (ModelState.IsValid)
            {
                var model = _specificationAppService.DeleteDetailSpecification(id, productId, specificationId);
                return Ok(model);
            }
            return NotFound();
        }
       
    }
}
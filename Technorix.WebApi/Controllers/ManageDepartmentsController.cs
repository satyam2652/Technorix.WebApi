using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;

namespace Technorix.WebApi.Controllers
{
    public class ManageDepartmentsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManageDepartmentsController(ILogger<BaseController> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// This endpoint fetches all departments
        /// </summary>
        /// <returns>List of all departments</returns>
        [HttpGet]
        [Route("getAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            try
            {
                var data = _unitOfWork.DepartmentsService.GetAllDepartments();

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// This method fetches deprtment by Department ID
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getDepartmentDetails")]
        public IActionResult GetDepartmentById(int DepartmentId)
        {
            try
            {
                var data = _unitOfWork.DepartmentsService.GetDepartmentById(DepartmentId);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// Creates a new department
        /// </summary>
        /// <param name="DepartmentDetails">Only provide title & created by</param>
        /// <returns></returns>
        [HttpPost]
        [Route("createDepartment")]
        public IActionResult AddDepartmentDetails(DepartmentsMst DepartmentDetails)
        {
            try
            {
                var data = _unitOfWork.DepartmentsService.CreateDepartment(DepartmentDetails);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// Updates a deprtment detail
        /// </summary>
        /// <param name="DepartmentDetails">only provide title to update & modified by</param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateDepartment")]
        public IActionResult UpdateDepartmentDetails(DepartmentsMst DepartmentDetails)
        {
            try
            {
                var data = _unitOfWork.DepartmentsService.UpdateDepartment(DepartmentDetails);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}

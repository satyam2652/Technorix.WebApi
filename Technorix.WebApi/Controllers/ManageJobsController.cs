using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;

namespace Technorix.WebApi.Controllers
{
    public class ManageJobsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManageJobsController(ILogger<BaseController> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Fetches all Jobs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllJobs")]
        public IActionResult GetAllJobs()
        {
            try
            {
                var data = _unitOfWork.JobsService.GetAllJobs();

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// Creates a new job
        /// </summary>
        /// <param name="jobDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createJob")]
        public IActionResult AddJobDetails(JobsModel jobDetails)
        {
            try
            {
                var data = _unitOfWork.JobsService.AddJobDetails(jobDetails);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// Updates an existing job by job id
        /// </summary>
        /// <param name="jobDetails"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateJob")]
        public IActionResult UpdateJobDetails(JobsModel jobDetails)
        {
            try
            {
                var data = _unitOfWork.JobsService.UpdateJobDetails(jobDetails);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// Fetches a role by its job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getJobDetails")]
        public IActionResult GetJobById(int JobId)
        {
            try
            {
                var data = _unitOfWork.JobsService.GetJobDetailsById(JobId);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        /// <summary>
        /// Fetches jobs by Job title filter
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getJobDetailsByFilter")]
        public IActionResult GetJobByFilter(string JobTitle)
        {
            try
            {
                var data = _unitOfWork.JobsService.GetJobDetailsByFilter(JobTitle);

                return Ok(data);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}

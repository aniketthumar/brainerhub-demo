using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrainerHubDemoModel.Helper;
using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoService.BrainerHubDemoRepository.Implementation;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using System.ComponentModel.DataAnnotations;

namespace BrainerHubDemo.Controllers.V1
{
    /// <summary>
    /// JobsController
    /// </summary>
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        #region Declaration
        private IJobsRepository _jobsRepository;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializing Jobs Controller 
        /// </summary>
        /// <param name="jobsRepository">Jobs Repository</param>
        /// <param name="config">Configuration</param>
        public JobsController(IJobsRepository jobsRepository, IConfiguration config)
        {
            _jobsRepository = jobsRepository;
            _config = config;
        }
        #endregion

        #region Update Jobs
        /// <summary>
        /// Update Jobs
        /// </summary>           
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpPost("{job_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutJobs([FromBody][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] UpdateJobsRequestModel updateJobsRequestModel, [FromRoute][Required] int job_id)
        {
            await _jobsRepository.UpdateJob(updateJobsRequestModel,job_id);
            return Ok();

        }
        #endregion

        #region Update Jobs
        /// <summary>
        /// Update Jobs
        /// </summary>           
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpGet("{job_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateJobs([FromQuery][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] UpdateJobsRequestModel updateJobsRequestModel, [FromRoute][Required] int job_id)
        {
            await _jobsRepository.UpdateJob(updateJobsRequestModel,job_id);
            return Ok(_config.GetValue<string>("OkResponse"));

        }
        #endregion
    }
}

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
    /// TaskController
    /// </summary>
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Declaration
        private ITaskRepository _taskRepository;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializing Tasks Controller 
        /// </summary>
        /// <param name="taskRepository">Tasks Repository</param>
        /// <param name="config">Configuration</param>
        public TaskController(ITaskRepository taskRepository, IConfiguration config)
        {
            _taskRepository = taskRepository;
            _config = config;
        }
        #endregion

        #region Update Tasks
        /// <summary>
        /// Update Tasks
        /// </summary>           
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpPost("{task_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTasks([FromBody][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] UpdateTaskRequestModel updateTaskRequestModel, [FromRoute][Required] int task_id)
        {
            await _taskRepository.UpdateTask(updateTaskRequestModel,task_id);
            return Ok();

        }
        #endregion

        #region Update Tasks
        /// <summary>
        /// Update Tasks
        /// </summary>           
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpGet("{task_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTasks([FromQuery][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] UpdateTaskRequestModel updateTaskRequestModel, [FromRoute][Required] int task_id)
        {
            await _taskRepository.UpdateTask(updateTaskRequestModel,task_id);
            return Ok(_config.GetValue<string>("OkResponse"));

        }
        #endregion
    }
}

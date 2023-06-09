using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BrainerHubDemoModel.CustomModels;
using BrainerHubDemoModel.Helper;
using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoModel.ResponseModel;
using BrainerHubDemoService.BrainerHubDemoRepository.Implementation;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using System.ComponentModel.DataAnnotations;

namespace BrainerHubDemo.Controllers.V1
{
    /// <summary>
    /// Students Controller
    /// </summary>
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region Declaration
        private IStudentRepository _studentRepository;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializing Students Controller 
        /// </summary>
        /// <param name="studentRepository">Student Repository</param>
        /// <param name="config">Configuration</param>
        public StudentsController(IStudentRepository studentRepository, IConfiguration config)
        {
            _studentRepository = studentRepository;
            _config = config;
        }
        #endregion

        #region Create Student
        /// <summary>
        /// Create Student
        /// </summary>           
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostStudent([FromBody][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] StudentRequestModel studentRequestModel)
        {
            await _studentRepository.CreateStudent(studentRequestModel);

            return StatusCode(StatusCodes.Status201Created);

        }
        #endregion

        #region Update Student
        /// <summary>
        /// Update Student
        /// </summary>           
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpPost("{student_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProduct([FromBody][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] UpdateStudentRequestModel updateStudentRequestModel, [FromRoute][Required] int student_id)
        {
            updateStudentRequestModel.StudentId = student_id;
            await _studentRepository.UpdateStudent(updateStudentRequestModel);
            return Ok(_config.GetValue<string>("OkResponse"));

        }
        #endregion


        #region List
        /// <summary>
        /// Get Students List
        /// </summary>                
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpGet]
        [ProducesResponseType(typeof(StudentListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnauthorizedResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorReponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Liststudent([FromQuery][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] StudentListRequestModel studentListRequestModel)
        {

            var list = await _studentRepository.Liststudent(studentListRequestModel);
            return Ok(list);
        }
        #endregion
    }
}

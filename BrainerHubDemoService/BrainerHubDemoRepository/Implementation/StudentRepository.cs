using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BrainerHubDemoModel.Helper;
using BrainerHubDemoModel.POcSampleDB;
using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoModel.ResponseModel;
using BrainerHubDemoModel.SpDbContext;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrainerHubDemoModel.Helper.Constants;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Implementation
{
    public class StudentRepository : IStudentRepository
    {

        #region Initialization
        // Initialize the database context class.
        POCSampleContext _dbcontext;
        POCSpDbContext _spdbcontext;
        POCSpContext _spcontext;

        public StudentRepository(POCSpDbContext spdbcontext, POCSpContext spContext, POCSampleContext dbcontext)
        {
            _spdbcontext = spdbcontext;
            _spcontext = spContext;
            _dbcontext = dbcontext;
        }
        #endregion

        #region Post
        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentRequestModel"></param>
        public async Task CreateStudent(StudentRequestModel studentRequestModel)
        {
            string sqlQuery = "[sp_API_Student_Create] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}";
            object[] param = { studentRequestModel.ContactFirstName, studentRequestModel.ContactLastName, studentRequestModel.ContactEmail, studentRequestModel.ContactPhone,studentRequestModel.ContactLocationId,studentRequestModel.ContactMethodId,studentRequestModel.ContactMethodName,
            studentRequestModel.ContactMethodNote,studentRequestModel.StudentStatusId,studentRequestModel.StudentStatusCode,studentRequestModel.StudentClassScheduleId,studentRequestModel.StudentSourceContactId,studentRequestModel.StudentTeacherId,studentRequestModel.StudentRecruiterId,
            studentRequestModel.StudentJobId,studentRequestModel.StudentContactMethodId,studentRequestModel.StudentContactMethod,studentRequestModel.StudentContactMethodNote,studentRequestModel.StudentClassificationID,studentRequestModel.CurrentContContactID,studentRequestModel.CurrentUser};
            await _spdbcontext.ExecuteStoreProceduredNoReturn(sqlQuery, param);
        }
        #endregion
        
        #region Put
        /// <summary>
        /// Update Student 
        /// </summary>
        /// <param name="updateStudentRequestModel"></param>
        /// <returns></returns>
        public async Task UpdateStudent(UpdateStudentRequestModel updateStudentRequestModel)
        {
            string sqlQuery = "[sp_API_Student_Update] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}";
            object[] param = { updateStudentRequestModel.StudentId, updateStudentRequestModel.StudentContactId,
             updateStudentRequestModel.ContactFirstName, updateStudentRequestModel.ContactLastName, updateStudentRequestModel.ContactEmail, updateStudentRequestModel.ContactPhone,updateStudentRequestModel.ContactLocationId,updateStudentRequestModel.ContactMethodId,updateStudentRequestModel.ContactMethodName,
            updateStudentRequestModel.ContactMethodNote,updateStudentRequestModel.StudentStatusId,updateStudentRequestModel.StudentStatusCode,updateStudentRequestModel.StudentClassScheduleId,updateStudentRequestModel.StudentSourceContactId,updateStudentRequestModel.StudentTeacherId,updateStudentRequestModel.StudentRecruiterId,
            updateStudentRequestModel.StudentJobId,updateStudentRequestModel.StudentContactMethodId,updateStudentRequestModel.StudentContactMethod,updateStudentRequestModel.StudentContactMethodNote,updateStudentRequestModel.StudentClassificationID,updateStudentRequestModel.CurrentContContactID,updateStudentRequestModel.CurrentUser};
            await _spdbcontext.ExecuteStoreProceduredNoReturn(sqlQuery, param);
        }
        #endregion

        #region List Students
        /// <summary>
        /// List Students
        /// </summary>
        /// <param name="statusid"></param>
        /// <returns>Students List</returns>
        public async Task<List<StudentListResponse>> Liststudent(StudentListRequestModel studentListRequestModel)
        {
            // Get Student List 
            string sqlQuery = "[sp_API_Student_List] {0},{1},{2},{3},{4},{5}";
            object[] param = { studentListRequestModel.StudentID,studentListRequestModel.StudentContactId,studentListRequestModel.StudentStatusId,studentListRequestModel.StudentStatusName,studentListRequestModel.CurrentContContactID,studentListRequestModel.CurrentUser };
            var result = await _spdbcontext.ExecuteStoreProcedureStudent(sqlQuery, param);

            return result;
        }
        #endregion
    }
}

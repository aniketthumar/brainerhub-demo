using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoModel.ResponseModel
{
    /// <summary>
    /// StudentListResponse
    /// </summary>
    public class StudentListResponse
    {
        /// <summary>
        /// STUD_StudentID
        /// </summary>
        public int STUD_StudentID { get; set; }
        /// <summary>
        /// STUD_ContactID
        /// </summary>
        public int STUD_ContactID { get; set; }
        /// <summary>
        /// STUD_FirstName
        /// </summary>
        public string? STUD_FirstName { get; set; }
        /// <summary>
        /// STUD_LastName
        /// </summary>
        public string? STUD_LastName { get; set; }
        /// <summary>
        /// STUD_Phone1
        /// </summary>
        public string? STUD_Phone1 { get; set; }
        /// <summary>
        /// Email1
        /// </summary>
        public string? Email1 { get; set; }
        /// <summary>
        /// STUD_LocationID
        /// </summary>
        public int? STUD_LocationID { get; set; }
        /// <summary>
        /// STUD_ContactTypeID
        /// </summary>
        public int? STUD_ContactTypeID { get; set; }
        /// <summary>
        /// STUD_ContactTypeCode
        /// </summary>
        public string? STUD_ContactTypeCode { get; set; }
        /// <summary>
        /// STUD_StatusID
        /// </summary>
        public int? STUD_StatusID { get; set; }
        /// <summary>
        /// STUD_StatusName
        /// </summary>
        public string? STUD_StatusName { get; set; }
        /// <summary>
        /// STUD_ContactMethodID
        /// </summary>
        public int? STUD_ContactMethodID { get; set; }
    }
}

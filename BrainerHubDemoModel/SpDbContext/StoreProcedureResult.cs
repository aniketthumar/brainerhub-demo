using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoModel.SpDbContext
{
    public partial class StoreProcedureResult
    {
        /// <summary>
        /// ExecutreStoreProcedureResult
        /// </summary>
        public class ExecutreStoreProcedureResult
        {
            /// <summary>
            /// The string that assign as ErrorMessage
            /// </summary>
            public string? ErrorMessage { get; set; }
            /// <summary>
            /// The string that assign as Result
            /// </summary>
            public string? Result { get; set; }
        }
        /// <summary>
        /// ExecutreStoreProcedureResultWithEntitySID
        /// </summary>
        public class ExecutreStoreProcedureResultWithEntitySID
        {
            /// <summary>
            /// The string that assign as ErrorMessage
            /// </summary>
            public string? ErrorMessage { get; set; }
            /// <summary>
            /// The string that assign as Result
            /// </summary>
            public string? Result { get; set; }

            /// <summary>
            /// The string that assign as EntitiySID
            /// </summary>
            public string? EntitiySID { get; set; }
        }
        /// <summary>
        /// ExecutreStoreProcedureResultWithSID
        /// </summary>
        public class ExecutreStoreProcedureResultWithSID
        {
            /// <summary>
            /// The string that assign as ErrorMessage
            /// </summary>
            public string? ErrorMessage { get; set; }
            /// <summary>
            /// The string that assign as SID
            /// </summary>
            public string? SID { get; set; }

        }
        /// <summary>
        /// ExecuteStoreProcedureResultWithId
        /// </summary>
        public class ExecuteStoreProcedureResultWithId
        {
            /// <summary>
            /// The string that assign as ErrorMessage
            /// </summary>
            public string? ErrorMessage { get; set; }
            /// <summary>
            /// The string that assign as Id
            /// </summary>
            public int Id { get; set; }
        }
        /// <summary>
        /// ExecutreStoreProcedureResultList
        /// </summary>
        public class ExecutreStoreProcedureResultList
        {
            /// <summary>
            /// The string that assign as ErrorMessage
            /// </summary>
            public string? ErrorMessage { get; set; }

            /// <summary>
            /// The string that assign as Result
            /// </summary>
            public string? Result { get; set; }

            /// <summary>
            /// The string that assign as TotalCount
            /// </summary>
            public int TotalCount { get; set; }
        }
    }
}

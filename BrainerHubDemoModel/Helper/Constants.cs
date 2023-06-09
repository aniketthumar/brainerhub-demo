using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoModel.Helper
{
    /// <summary>
    /// Constants
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// SearchParameters
        /// </summary>
        public class SearchParameters
        {
            /// <summary>
            /// PageSize
            /// </summary>
            public const string PageSize = "PageSize";
            /// <summary>
            /// ShowMy
            /// </summary>
            public const string ShowMy = "ShowMy";
            /// <summary>
            /// ShowAll
            /// </summary>
            public const string ShowAll = "ShowAll";
            /// <summary>
            /// ModifiedAfter
            /// </summary>
            public const string ModifiedAfter = "ModifiedAfter";
            /// <summary>
            /// RequiredFields
            /// </summary>
            public const string RequiredFields = "RequiredFields";
            /// <summary>
            /// Filters
            /// </summary>
            public const string Filters = "Filters";
            /// <summary>
            /// ContinuationToken
            /// </summary>
            public const string ContinuationToken = "ContinuationToken";
            /// <summary>
            /// SortOrder
            /// </summary>
            public const string SortOrder = "SortOrder";
            /// <summary>
            /// SortColumn
            /// </summary>
            public const string SortColumn = "SortColumn";
            /// <summary>
            /// SearchText
            /// </summary>
            public const string SearchText = "SearchText";
            /// <summary>
            /// PageStart
            /// </summary>
            public const string PageStart = "Page";
            /// <summary>
            /// Conjuction
            /// </summary>
            public const string Conjuction = "Conjuction";

        }
        /// <summary>
        /// DatabaseErrorCodes
        /// </summary>
        public static class DatabaseErrorCodes
        {
            /// <summary>
            /// NotExist
            /// </summary>
            public const string NotExist = "51000";
            /// <summary>
            /// NotAllowed
            /// </summary>
            public const string NotAllowed = "52000";
        }
        /// <summary>
        /// Status
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// Active
            /// </summary>
            Active = 1,
            /// <summary>
            /// Inactive
            /// </summary>
            Inactive = 2

        }
    }
}

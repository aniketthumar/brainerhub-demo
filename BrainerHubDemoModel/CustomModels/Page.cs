using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BrainerHubDemoModel.CustomModels
{
    /// <summary>
    /// Page
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Initialization Page
        /// </summary>
        public Page()
        {
            Meta = new Meta();
            Result = new JArray();
        }

        /// <summary>
        /// Initialization Meta
        /// </summary>
        [JsonProperty(PropertyName = "meta")]
        public Meta Meta { get; set; }

        /// <summary>
        /// Initialization Result
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public Object Result { get; set; }

    }
}

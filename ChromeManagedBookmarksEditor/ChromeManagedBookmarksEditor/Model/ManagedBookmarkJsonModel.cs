using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeManagedBookmarksEditor.Model
{
    public class ManagedBookmarkJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("children")]
        public IEnumerable<ManagedBookmarkJsonModel> Children { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("toplevel_name")]
        public string ToplevelName { get; set; }
    }
}

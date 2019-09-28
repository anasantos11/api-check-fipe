using CheckFipe.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.Models
{
    public class RetornoFipe
    {
        [JsonProperty("id")]
        public long Codigo { get; set; }

        [JsonProperty("fipe_name")]
        public virtual string Nome { get; set; }
    }
}

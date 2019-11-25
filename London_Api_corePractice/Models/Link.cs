using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice.Models
{
    public class Link
    {
        public const string GetMethod = "Get";

        public static Link To(string routeName, object routeValues = null) => new Link
        {
            RouteName = routeName,
            RouteValue = routeValues,
            Method = GetMethod,
            Reltions = null
        };

        [JsonProperty(Order =-4)]
        public string Href { get; set; }

        [JsonProperty(Order =-3,
            PropertyName ="rel"
            ,NullValueHandling =NullValueHandling.Ignore)]
        public string[] Reltions { get; set; }


        [JsonProperty(Order =-2,
            DefaultValueHandling =DefaultValueHandling.Ignore
            ,NullValueHandling =NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }


        //Store Route Name before being rewrtten by the Link RewritingFilter
        [JsonIgnore]
        public string RouteName { get; set; }

        //Store Route Parameter before being rewrtten by the Link RewritingFilter
        [JsonIgnore]
        public object RouteValue { get; set; }
    }
}

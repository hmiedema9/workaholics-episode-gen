using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared
{
    public class Episode
    {
        public int season { get; set; }
        public int episode { get; set; }
        public string title { get; set; }
        public string directed_by { get; set; }
        public string written_by { get; set; }
        public string air_date { get; set; }
    }
}

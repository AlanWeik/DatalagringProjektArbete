using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataBaseConnection;

namespace Store
{
    static class State
    {
        public static Customer User { get; set; }
        public static List<Movie> Movies { get; set; }
        public static Movie Pick { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Data.Options
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
}

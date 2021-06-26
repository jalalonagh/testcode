﻿using System.Collections.Generic;

namespace ManaBaseData
{
    public class DataRepositoryConfiguration
    {
        public IEnumerable<string> EntityAssemblies { get; set; }
        public string MigrationAssembly { get; set; }
    }
}

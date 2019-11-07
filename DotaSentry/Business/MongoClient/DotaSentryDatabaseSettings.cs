using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaSentry.Business.MongoClient
{
    public class DotaSentryDatabaseSettings
    {
        public string HeroesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

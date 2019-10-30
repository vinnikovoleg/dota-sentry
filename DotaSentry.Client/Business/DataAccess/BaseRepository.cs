using System;
using System.Collections.Generic;
using System.Text;

namespace DotaSentry.Client.Business.DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly JsonClient JsonClient;
        protected readonly string Host = "https://api.opendota.com";

        protected BaseRepository(JsonClient jsonClient)
        {
            JsonClient = jsonClient;
        }
    }
}

namespace DotaSentry.Business.DataAccess.Steam.Client
{
    public class WebApiClient
    {
        protected readonly JsonClient JsonClient;
        
        protected WebApiClient(JsonClient jsonClient)
        {
            JsonClient = jsonClient;
        }
        
    }
}
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotaSentry.Business.DataAccess
{
    public class RemoteFileSaver
    {
        public async Task<string> SaveAsync(string url, string filePath)
        {
            using var http = new HttpClient();
            using var data = await http.GetAsync(url);
            await using var file = File.Create(filePath);
            await data.Content.CopyToAsync(file);
            return filePath;
        }
    }
}
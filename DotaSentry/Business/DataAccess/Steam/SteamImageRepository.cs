using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Steam.Client;
using Microsoft.AspNetCore.Hosting;

namespace DotaSentry.Business.DataAccess.Steam
{
    public class SteamImageRepository
    {
        private readonly SteamFileClient _steamFileClient;
        private readonly string _imagesRelativePath = Path.Combine("StaticFiles", "Temp", "Images");
        private readonly IWebHostEnvironment _environment;

        public SteamImageRepository(
            SteamFileClient steamFileClient, IWebHostEnvironment environment)
        {
            _steamFileClient = steamFileClient;
            _environment = environment;
        }

        public async Task<string> GetSteamImageUrlAsync(long imageId)
        {
            var fileName = $"{imageId}.png";
            var imagesPhysicalPath = Path.Combine(_environment.WebRootPath, _imagesRelativePath);
            var filePath = Path.Combine(imagesPhysicalPath, fileName);
            if (File.Exists(filePath))
            {
                return Path.Combine(_imagesRelativePath, fileName);
            }

            var logoInfo = await _steamFileClient.GetLogoInfoAsync(imageId);
            if (logoInfo?.Data == null)
            {
                return null;
            }

            if (!Directory.Exists(imagesPhysicalPath))
            {
                Directory.CreateDirectory(imagesPhysicalPath);
            }

            using var http = new HttpClient();
            using var data = await http.GetAsync(logoInfo.Data.Url);
            await using var file = File.Create(filePath);
            await data.Content.CopyToAsync(file);
            return Path.Combine(_imagesRelativePath, fileName);
        }
    }
}

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Steam;
using Microsoft.AspNetCore.Hosting;

namespace DotaSentry.Business.DataAccess
{
    public class ImageRepository
    {
        private readonly SteamFileClient _steamFileClient;
        private readonly string _imagesRelativePath = Path.Combine("StaticFiles", "Temp", "Images");
        private readonly IWebHostEnvironment _environment;
        private readonly RemoteFileSaver _remoteFileSaver;

        public ImageRepository(
            SteamFileClient steamFileClient,
            IWebHostEnvironment environment,
            RemoteFileSaver remoteFileSaver)
        {
            _steamFileClient = steamFileClient;
            _environment = environment;
            _remoteFileSaver = remoteFileSaver;
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

            await _remoteFileSaver.SaveAsync(logoInfo.Data.Url.ToString(), filePath);
            return Path.Combine(_imagesRelativePath, fileName);
        }
    }
}

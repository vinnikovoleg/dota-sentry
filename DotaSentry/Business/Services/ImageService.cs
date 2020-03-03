using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SteamFileRepository = DotaSentry.Business.SteamClient.DataAccess.SteamFileRepository;

namespace DotaSentry.Business.Services
{
    public class ImageService
    {
        private readonly SteamFileRepository _steamFileRepository;
        private readonly string _imagesRelativePath = "/StaticFiles/Temp/Images";
        private readonly IWebHostEnvironment _environment;

        public ImageService(
            SteamFileRepository steamFileRepository, IWebHostEnvironment environment)
        {
            _steamFileRepository = steamFileRepository;
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

            var logoInfo = await _steamFileRepository.GetLogoInfoAsync(imageId);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.SteamClient.Business.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Business.Services
{
    public class ImageService
    {
        private readonly SteamFileRepository _steamFileRepository;
        private readonly string _imageDirectoryPath = "StaticFiles/Images";
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
            var imagesDirectory = Path.Combine(_environment.WebRootPath, _imageDirectoryPath);
            var filePath = Path.Combine(imagesDirectory, fileName);
            if (File.Exists(filePath))
            {
                return $"/StaticFiles/Images/{fileName}";
            }

            var logoInfo = await _steamFileRepository.GetLogoInfoAsync(imageId);
            if (logoInfo?.Data == null)
            {
                return null;
            }

            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }

            using var http = new HttpClient();
            using var data = await http.GetAsync(logoInfo.Data.Url);
            await using var file = File.Create(filePath);
            await data.Content.CopyToAsync(file);
            return $"/StaticFiles/Images/{fileName}";
        }
    }
}

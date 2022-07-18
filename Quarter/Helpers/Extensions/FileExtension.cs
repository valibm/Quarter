﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Quarter.Helpers.Extensions
{
    public static class FileExtension
    {
        public static string CreateFileName(this IFormFile file)
        {
            string name = Guid.NewGuid().ToString() + file.FileName;

            if (name.Length > 255)
            {
                name = name.Substring(name.Length - 254);
            }

            return name;
        }

        public static async Task<string> CreateFile(this IFormFile file, IWebHostEnvironment env)
        {
            string name = file.CreateFileName();

            string path = Path.Combine(env.WebRootPath, "assets", "uploads", "images", name);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return name;
        }
    }
}

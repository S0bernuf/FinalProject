using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FinalProject.BusinessLogic.Services
{
    public class PhotoService
    {
        public static byte[] ResizeImage(IFormFile imageFile)
        {
            using var image = Image.Load<Rgba32>(imageFile.OpenReadStream());
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(200, 200),
                Mode = ResizeMode.Crop
            }));

            using var ms = new MemoryStream();
            image.SaveAsJpeg(ms);
            return ms.ToArray();
        }
    }
}

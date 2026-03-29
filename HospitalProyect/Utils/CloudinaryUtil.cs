using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace HospitalProyect.Utils
{
    public class CloudinaryUtil
    {
        public static string UploadImage(IFormFile photofile, IConfiguration config)
        {
            if (photofile == null || photofile.Length == 0)
            {
                return null;
            }

            string cloudName = config["Cloudinary:CloudName"];
            string apiKey = config["Cloudinary:ApiKey"];
            string apiSecret = config["Cloudinary:ApiSecret"];

            Account account = new Account(cloudName, apiKey, apiSecret);
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            using (var stream = photofile.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(photofile.FileName, stream)
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception($"Cloudinary upload error: {uploadResult.Error.Message}");
                }

                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}

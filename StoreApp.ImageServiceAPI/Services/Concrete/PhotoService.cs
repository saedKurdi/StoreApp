using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using StoreApp.ImageServiceAPI.DTOS;
using StoreApp.ImageServiceAPI.Services.Abstractl;
using StoreApp.ImageServiceAPI.Settings;

namespace StoreApp.ImageServiceAPI.Services.Concrete;
public class PhotoService : IPhotoService
{
    private readonly IConfiguration _configuration;
    private CloudinarySettings cloudinarySettings;
    private Cloudinary cloudinary;

    public PhotoService(IConfiguration configuration)
    {
        _configuration = configuration;
        cloudinarySettings = _configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
        Account account = new Account(cloudinarySettings.CloudName,cloudinarySettings.ApiKey,cloudinarySettings.ApiSecret);
        cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadImageAsync(PhotoCreationDTO dto)
    {
        var file = dto.FormFile;
        var uploadedResult = new ImageUploadResult();
        if(file?.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription (file.Name,stream),
                };
                uploadedResult = await cloudinary.UploadAsync(uploadParams);
                if (uploadedResult != null)
                {
                    return uploadedResult.Url.ToString();
                }
            }
        }
        return string.Empty;

    }
}

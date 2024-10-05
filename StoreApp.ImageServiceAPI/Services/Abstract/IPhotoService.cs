using StoreApp.ImageServiceAPI.DTOS;

namespace StoreApp.ImageServiceAPI.Services.Abstractl;
public interface IPhotoService
{
    Task<string> UploadImageAsync(PhotoCreationDTO dto);
}

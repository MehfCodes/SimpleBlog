using System;

namespace SimpleBlog.Repository.Interfaces;

public interface IImageRepository
{
    Task<string?> UploadAsync(IFormFile file);
}

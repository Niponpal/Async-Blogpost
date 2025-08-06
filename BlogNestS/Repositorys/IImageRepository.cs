namespace BlogNestS.Repositorys
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}

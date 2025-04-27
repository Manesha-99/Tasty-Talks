using Tasty_Talks_BackEnd.Model.Domain;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadAsync(Image image);

        Task<Image> DeleteAsync(int id);
    }
}

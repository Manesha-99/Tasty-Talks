using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Model.Domain;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLImageRepository:IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly TastyTalksDbContext tastyTalksDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLImageRepository(IWebHostEnvironment webHostEnvironment, TastyTalksDbContext tastyTalksDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.tastyTalksDbContext = tastyTalksDbContext;
            this.httpContextAccessor = httpContextAccessor;
        }


        //Delete Image Function----------------------------------------------------------
        public async Task<Image> DeleteAsync(int id)
        {
            var image = await tastyTalksDbContext.Image.FirstOrDefaultAsync(x => x.Id == id);

            if (image == null) {
                return null;
            }

            tastyTalksDbContext.Image.Remove(image);
            await tastyTalksDbContext.SaveChangesAsync();

            return image;
        }


        //Upload Image Function-----------------------------------------------------------
        public async Task<Image> UploadAsync(Image image)
        {

            //Create Local Path----
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtension}");


            //Upload Image to Local Path----
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);


            //Create URL Path----
            var urlPath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlPath;

            //Save to database----
            await tastyTalksDbContext.Image.AddAsync(image);
            await tastyTalksDbContext.SaveChangesAsync();

            return image;

        }



        
    }
}

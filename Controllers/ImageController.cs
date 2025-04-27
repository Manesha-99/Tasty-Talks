using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasty_Talks_BackEnd.Model.Domain;
using Tasty_Talks_BackEnd.Model.DTO;
using Tasty_Talks_BackEnd.Repositories;

namespace Tasty_Talks_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //Image Upload Function-----------------------------------------------
        //api/Image/Upload
        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            validateFileUpload(request);

            if (ModelState.IsValid) 
            {
                //Convert DTO request to Domain Model

                var domainModel = new Image
                {
                    File = request.File,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length
                };

                //Upload Repository

                await imageRepository.UploadAsync(domainModel);

                return Ok(domainModel);
                
            }

            return BadRequest(ModelState);
        }


        //Function For Delete Image------------------------------------------

        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteImage(int id)
        {
            var imageDomainModel = await imageRepository.DeleteAsync(id);

            if (imageDomainModel == null) {
                return BadRequest();
            }

            return Ok(imageDomainModel);
        }


        //Validation of File
        private void validateFileUpload(ImageUploadRequestDTO request)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtension.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported File EXtension");
            }

            if (request.File.Length > 10485760) 
            {
                ModelState.AddModelError("file", "Image must be lower than 10Mb");
            }
        }
    }
}

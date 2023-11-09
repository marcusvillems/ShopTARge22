using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ShopTARge22.Data;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ShopTARge22.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly ShopTARge22Context _context;

        public FileServices
            (
                IHostEnvironment webhost,
                ShopTARge22Context context
            )
        {
            _webHost = webhost;
            _context = context; 
        }

        public void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream()) {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            RealEstateId = domain.Id,
                        };

                        image.CopyTo( target );
                        files.ImageData = target.ToArray();

                        _context.FileToDatabases.Add( files ); 
                    }
                }
            }
        }
        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\")) 
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
                }

                foreach (var file in dto.Files)
                {
                    string uploadFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id,
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }

        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var imageId = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
                var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageId.ExistingFilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.FileToApis.Remove(imageId);
                await _context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            var ImageId = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + ImageId.ExistingFilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FileToApis.Remove(ImageId);
            await _context.SaveChangesAsync();

            return null;

        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var ImageId = await _context.FileToDatabases
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            var filePath = ImageId.ImageTitle;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FileToDatabases.Remove(ImageId);
            await _context.SaveChangesAsync();

            return null;

        }


    }

}



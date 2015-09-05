using LinqToExcel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using VMS.Api.Models;

namespace VMS.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImportController : ApiController
    {
        //[HttpPost]
        //public  IHttpActionResult Post([FromBody]ExcelFileModel data){
        //    byte[] exl = Convert.FromBase64String(data.Value);

        //    return Ok();
        //}

        [HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            
            var provider = GetMultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            IQueryable<ArtistAlbum> kk = null;
            foreach (MultipartFileData file in provider.FileData)
            {
                #region get sheet data
                System.IO.File.Move(file.LocalFileName, file.LocalFileName+".xlsx");
                string pathToExcelFile = file.LocalFileName + ".xlsx";

                string sheetName = "Sheet1";

                var excelFile = new ExcelQueryFactory(pathToExcelFile);

                // ADD COLUMN MAPPINGS:
                //excelFile.AddMapping("Name", "Artist Name");
                //excelFile.AddMapping("Title", "Album Title");

                var artistAlbums = from a in excelFile.Worksheet<ArtistAlbum>(sheetName) select a;
                 kk = artistAlbums;
                #endregion
            }
           

            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = GetDeserializedFileName(result.FileData.First());

            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

            // Remove this line as well as GetFormData method if you're not
            // sending any form data with your upload request
            var fileUploadObj = GetFormData<UploadDataModel>(result);

            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            var returnData = "nisar";
            return this.Request.CreateResponse(HttpStatusCode.OK, new { kk }, JsonMediaTypeFormatter.DefaultMediaType);
        }
       
        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            // IMPORTANT: replace "(tilde)" with the real tilde character
            // (our editor doesn't allow it, so I just wrote "(tilde)" instead)
            var uploadFolder = "(tilde)/App_Data/Tmp/FileUploads"; // you could put this to web.config
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        // Extracts Request FormatData as a strongly typed model
        private object GetFormData<T>(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData
                    .GetValues(0).FirstOrDefault() ?? String.Empty);
                if (!String.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }

            return null;
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }

    public class UploadDataModel
    {
        public string testString1 { get; set; }
        public string testString2 { get; set; }
    }

    public class ArtistAlbum
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string Department { get; set; }

    }
}

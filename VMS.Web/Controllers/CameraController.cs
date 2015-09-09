using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using VMS.WEB.Models;

namespace VMS.WEB.Controllers
{
    public class CameraController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody]CameraModel data)
        {
            byte[] photo = Convert.FromBase64String(data.Value);
            var dir = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
            string path = "";
            using (System.IO.FileStream fs = System.IO.File.Create(Path.Combine(dir.FullName+"/Capture_IMG", string.Format("Img_{0}.png", Guid.NewGuid()))))
            {
                path = fs.Name;
                fs.Write(photo, 0, photo.Length);
            }
            return Ok(path);
        }

        public IHttpActionResult Get()
        {
            return Ok("kk");
        }
    }
}

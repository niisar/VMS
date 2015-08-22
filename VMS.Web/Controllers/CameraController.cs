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
            using (System.IO.FileStream fs = System.IO.File.Create(Path.Combine(dir.FullName, string.Format("Img_{0}.png", Guid.NewGuid()))))
            {
                fs.Write(photo, 0, photo.Length);
            }
            return Ok();
        }

        public IHttpActionResult Get()
        {
            return Ok("kk");
        }
    }
}

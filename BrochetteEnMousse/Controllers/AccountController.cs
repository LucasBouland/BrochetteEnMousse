using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MousseModels.Data;
using MousseModels.Models;

namespace BrochetteEnMousse.Controllers
{
    //[Authorize(Role="admin")]
    public class AccountController : Controller
    { 
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<User> _userManager;
        
        public AccountController(ApplicationDbContext context,IHostingEnvironment hostingEnvironment,UserManager<User> userManager)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/admins/users")]
        public async Task<IActionResult> ListUser()
        {
            Dictionary<User,IList<String>> listUsersWithRoles = new Dictionary<User, IList<string>>();
            foreach(var user in _context.Users.ToList<User>())
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                listUsersWithRoles.Add(user, userRoles);
            }
            return View("/Views/Admins/Users.cshtml",listUsersWithRoles);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("type")]
        [Route("/admins/users/status")]
        public async Task<IActionResult> updateRole(string type,string id)
        {
            var userFound = _userManager.Users.Single<User>(user => user.Id == id);
            var userRoles = await _userManager.GetRolesAsync(userFound);
            if(type == "promote")
            {
                await _userManager.RemoveFromRoleAsync(userFound, "User");
                await _userManager.AddToRoleAsync(userFound, "Admin");
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(userFound, "Admin");
                await _userManager.AddToRoleAsync(userFound, "User");
            }
            return Json("ok");
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [Route("/user/upload/files")]
        public async Task<IActionResult> uploadIlmage(List<IFormFile> image)
        {
            var user = await _userManager.GetUserAsync(User);
            var theFile = HttpContext.Request.Form.Files.GetFile("file");

            // Get the server path, wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;

            // Building the path to the uploads directory
            var fileRoute = Path.Combine(webRootPath, "uploads");

            // Get the mime type
            var mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;

            // Get File Extension
            string extension = System.IO.Path.GetExtension(theFile.FileName);

            // Generate Random name.
            //string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;
            string name = user.Id + ".jpg";

            // Build the full path inclunding the file name
            string link = Path.Combine(fileRoute, name);

            // Create directory if it does not exist.
            FileInfo dir = new FileInfo(fileRoute);
            dir.Directory.Create();

            // Basic validation on mime types and file extension
            string[] imageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
            string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };

            try
            {
                if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
                {
                    // Copy contents to memory stream.
                    Stream stream;
                    stream = new MemoryStream();
                    theFile.CopyTo(stream);
                    stream.Position = 0;
                    String serverPath = link;

                    // Save the file
                    using (FileStream writerFileStream = System.IO.File.Create(serverPath))
                    {
                        await stream.CopyToAsync(writerFileStream);
                        writerFileStream.Dispose();
                    }

                    // Return the file path as json
                    Hashtable imageUrl = new Hashtable();
                    imageUrl.Add("link", "/uploads/" + name);
                    return Json("ça marche");
                }
                throw new ArgumentException("The image did not pass the validation");
            }
            catch (ArgumentException ex)
            {
                return Json("ça marche pas");
            }

        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;
using MousseModels.Models;

namespace BrochetteEnMousse.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CampaignsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            //TODO changer ca aaaaaaaaaaa
            User user;
            if (User.Identity.IsAuthenticated)
                user = await _context.Users.SingleOrDefaultAsync(u => u.Email == User.Identity.Name);
            else
                user = new User { Id = "" };
            return View(await _context.Campaigns
                .Include(u => u.Sessions)
                .Include(u => u.CampaignUsers)
                    .ThenInclude(u => u.User)
                .Where(u => u.Visibility == MousseModels.Helpers.Visibility.All
               || (u.Visibility == MousseModels.Helpers.Visibility.Members && u.CampaignUsers.Any(cu => cu.UserID == user.Id))
               || (u.Visibility == MousseModels.Helpers.Visibility.Self && u.CampaignUsers.Any(cu => cu.UserID == user.Id && cu.IsGameMaster)))
                .ToListAsync());
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var campaign = await _context.Campaigns.Include(u => u.Sessions).Include(u => u.CampaignUsers).ThenInclude(u => u.User).Include(u => u.CharacterCampaigns).ThenInclude(u => u.Character).FirstOrDefaultAsync(m => m.ID == id);
            if (campaign == null)
            {
                return NotFound();
            }


            var users = await _context.Users.Where(u => !campaign.CampaignUsers.Select(cu => cu.UserID).Contains(u.Id)).ToListAsync();
            ViewBag.Users = users.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Pseudo }).ToList();
            return View(new CampaignDetailsViewModel { Campaign = campaign, Session = new Session(), CampaignUser = new CampaignUser(), Users = users });
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles="Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Visibility,ID")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaign);
                var user = _context.Users.Single(u => u.Email == User.Identity.Name);
                _context.Add(new CampaignUser { CampaignID = campaign.ID, Campaign = campaign, UserID = user.Id, User = user, IsGameMaster = true });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Visibility,ID")] Campaign campaign)
        {
            if (id != campaign.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .FirstOrDefaultAsync(m => m.ID == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(string id)
        {
            return _context.Campaigns.Any(e => e.ID == id);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost("UploadFiles")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            // Get the file from the POST request
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
            string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

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

                    return Json(imageUrl);
                }
                throw new ArgumentException("The image did not pass the validation");
            }

            catch (ArgumentException ex)
            {
                return Json(ex.Message);
            }
        }
        public IActionResult TestAjax()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestAjax(Session session)
        {
            return Json(new { session });
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSession(Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return Json(new { session });
            }
            ViewData["CampaignID"] = new SelectList(_context.Users, "Id", "Id", session.CampaignID);
            return View(session);


        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [Produces("application/json")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlayers(CampaignUser campaignUser)
        {
            var campaignUsers = new List<string>();
            var keys = Request.Form.Keys;

            foreach (var value in Request.Form["Campaign.CampaignUsers"])
            {
                var userId = value;
                var user = _context.Users.Single(u => u.Id == userId);
                var campaign = _context.Campaigns.Single(u => u.ID == Request.Form["Campaign.ID"]);
                var cu = new CampaignUser { UserID = userId, CampaignID = Request.Form["Campaign.ID"], User = user, Campaign = campaign };
                campaignUsers.Add(cu.User.Pseudo);
                _context.Add(cu);
                await _context.SaveChangesAsync();
            }


            return Json(new { campaignUsers });
        }
    }
}

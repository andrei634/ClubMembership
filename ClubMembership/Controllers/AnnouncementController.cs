using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubMembership.Controllers
{
    public class AnnouncementController : Controller
    {
        private AnnouncementRepository announcementRepository;

        public  AnnouncementController(ApplicationDbContext dbContext)
        {
            announcementRepository = new AnnouncementRepository(dbContext);
        }
        // GET: AnnouncementController
        public ActionResult Index()
        {
            var announcementList = announcementRepository.getAllAnnoucements().ToList();
            return View(announcementList);
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: AnnouncementController/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: AnnouncementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if(task.Result)
                {
                    this.announcementRepository.InsertAnnouncement(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = announcementRepository.getAnnouncementById(id);
            return View("EditAnnouncement", model);
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if(task.Result)
                {
                    this.announcementRepository.UpdateAnnouncement(model);
                }

                return RedirectToAction("Index"); ;
            }
            catch
            {
                return View("EditAnnouncement");
            }
        }

        // GET: AnnouncementController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: AnnouncementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubMembership.Controllers
{
    public class MembershipController : Controller
    {
        private MembershipRepository membershipRepository;

        public MembershipController(ApplicationDbContext dbContext)
        {
            membershipRepository = new MembershipRepository(dbContext);
        }
        // GET: MembershipController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MembershipController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MembershipController/Create
        public ActionResult Create()
        {
            return View("CreateMembership");
        }

        // POST: MembershipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MembershipModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    this.membershipRepository.InsertMembership(model);
                }
                return View("Index");
            }
            catch
            {
                return View("CreateMembership");
            }
        }

        // GET: MembershipController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembershipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MembershipController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembershipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

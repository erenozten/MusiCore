using GigHub.Core;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // ctor
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Index action'ı çalıştığında query null olmalı.
        public ActionResult Index(string query = null) 
        {
            var upcomingGigs = _unitOfWork.Gigs.GetUpcomingGigs(query);

            // kullanıcı id'sini aldık.
            var userId = User.Identity.GetUserId();

            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            // Viewmodel oluşturup veriler içine yerleştirildi.
            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Gigs", viewModel);
        }

        // Hakkında
        public ActionResult About()
        {
            ViewBag.Message = "Hakkında";

            return View();
        }

        // İletişim
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim";

            return View();
        }
    }
}
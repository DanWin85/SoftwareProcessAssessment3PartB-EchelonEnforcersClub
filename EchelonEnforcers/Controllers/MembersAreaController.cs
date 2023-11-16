using EchelonEnforcers.Data;
using EchelonEnforcers.Models;
using Microsoft.AspNetCore.Mvc;

namespace EchelonEnforcers.Controllers
{
    public class MembersAreaController : Controller
    {
        private readonly NewsDbContext newsDbContext;
        private readonly CompetitionsDbContext competitionsDbContext;

        public MembersAreaController(NewsDbContext newsDbContext, CompetitionsDbContext competitionsDbContext)
        {
            this.newsDbContext = newsDbContext;
            this.competitionsDbContext = competitionsDbContext;
        }

            public IActionResult MembersArea()
        {
            var viewModel = new MembersAreaViewModel
            {
                NewsItems = newsDbContext.NewsModel.ToList(),
                Competitions = competitionsDbContext.CompetitionsModel.ToList(),
            };

            return View(viewModel);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.BLL.Interfaces;
using WMReplayTestProject.Models;
using WMReplayTestProject.WEB.Models;

namespace WMReplayTestProject.Controllers
{
    public class HomeController : Controller
    {
        readonly private IArticleService _articleService;
        readonly private IMapper _mapper;

        public HomeController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
           var getAllArticles = await _articleService.GetAllAsync();
            var viewModel = _mapper.Map <IEnumerable<ArticleDTO>, IEnumerable<ArticleViewModel>>(getAllArticles);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

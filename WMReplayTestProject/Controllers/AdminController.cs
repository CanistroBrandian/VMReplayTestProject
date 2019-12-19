using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.BLL.Interfaces;
using WMReplayTestProject.WEB.Models;

namespace WMReplayTestProject.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        readonly private IArticleService _articleService;
        readonly private ITagService _tagService;
        readonly private ICategoryService _categoryService;
        readonly private IMapper _mapper;

        public AdminController(IArticleService articleService, ITagService tagService, IMapper mapper, ICategoryService categoryService)
        {
            _articleService = articleService;
            _tagService = tagService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var getAllArticle = await _articleService.GetAllAsync();
            var getAllTag = await _tagService.GetAllAsync();
            var getAllCategory = await _categoryService.GetAllAsync();
            var viewModel = new IndexViewModel
            {
                articleViewModels = _mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<ArticleViewModel>>(getAllArticle),
                categoryViewModels = _mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryViewModel>>(getAllCategory),
                tagViewModels = _mapper.Map<IEnumerable<TagDTO>, IEnumerable<TagViewModel>>(getAllTag),
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleViewModel model)
        {
           var articleDTO = _mapper.Map<ArticleViewModel, ArticleDTO>(model);
           await _articleService.CreateAsync(articleDTO);
           return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> EditArticle(int id, ArticleViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var articleDTO = _mapper.Map<ArticleViewModel, ArticleDTO>(model);
                    await _articleService.UpdateAsync(articleDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel model)
        {
            var categoryDTO = _mapper.Map<CategoryViewModel, CategoryDTO>(model);
            await _categoryService.CreateAsync(categoryDTO);
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> EditCategory(int id, CategoryViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var categoryDTO = _mapper.Map<CategoryViewModel, CategoryDTO>(model);
                    await _categoryService.UpdateAsync(categoryDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagViewModel model)
        {
            var tagDTO = _mapper.Map<TagViewModel, TagDTO>(model);
            await _tagService.CreateAsync(tagDTO);
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> EditTag(int id, TagViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tagDTO = _mapper.Map<TagViewModel, TagDTO>(model);
                    await _tagService.UpdateAsync(tagDTO);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            return View();
        }
    }
}
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
            if (ModelState.IsValid)
            {
                var articleDTO = _mapper.Map<ArticleViewModel, ArticleDTO>(model);
                await _articleService.CreateAsync(articleDTO);
                return RedirectToAction("Index");
            }
            else return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var articleDTO = await _articleService.GetByIdAsync((int)id);
            var articleViewModel = _mapper.Map<ArticleDTO, ArticleViewModel>(articleDTO);
            if (articleViewModel == null)
            {
                return NotFound();
            }
            return View(articleViewModel);
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> DeleteArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.GetByIdAsync((int)id);
            var viewArticle = _mapper.Map<ArticleDTO, ArticleViewModel>(article);
            if (article == null)
            {
                return NotFound();
            }

            return View(viewArticle);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmeDeleteArticle(int id)
        {
            await _articleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryDTO = _mapper.Map<CategoryViewModel, CategoryDTO>(model);
                await _categoryService.CreateAsync(categoryDTO);
                return RedirectToAction("Index");
            }
            else return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetByIdAsync((int)id);
            var viewCategory = _mapper.Map<CategoryDTO, CategoryViewModel>(category);
            if (category == null)
            {
                return NotFound();
            }

            return View(viewCategory);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmeDeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagDTO = _mapper.Map<TagViewModel, TagDTO>(model);
                await _tagService.CreateAsync(tagDTO);
                return RedirectToAction("Index");
            }
            else return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var tagDTO = await _tagService.GetByIdAsync((int)id);
            var tagViewModel = _mapper.Map<TagDTO, TagViewModel>(tagDTO);
            if (tagViewModel == null)
            {
                return NotFound();
            }
            return View(tagViewModel);
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> DeleteTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _tagService.GetByIdAsync((int)id);
            var viewTag = _mapper.Map<TagDTO, TagViewModel>(tag);
            if (tag == null)
            {
                return NotFound();
            }

            return View(viewTag);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmeDeleteTag(int id)
        {
            await _tagService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
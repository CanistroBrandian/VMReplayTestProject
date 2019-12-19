using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.BLL.Interfaces;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.DAL.Interfaces;

namespace WMReplayTestProject.BLL.Services
{
    public class ArticleService : IArticleService
    {

        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<ArticleDTO> CreateAsync(ArticleDTO item)
        {
            try
            {
                if (item.Name != null || item.Description != null)
                {
                    var article = _mapper.Map<ArticleDTO, Article>(item);
                    article.PublishedDateTime =  DateTime.Now;
                    await _articleRepository.CreateAsync(article);
                    return item;
                }
                else
                {
                    new ArgumentNullException("Данные не заполнены");
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                if (_articleRepository.FindByIdAsync(id) != null)
                    await _articleRepository.DeleteAsync(id);
                else new NullReferenceException("Такой записи нет");
            }
            catch (NullReferenceException)
            {

            }
        }

        public async Task<IEnumerable<ArticleDTO>> GetAllAsync()
        {
            var listArticles = await _articleRepository.GetAllAsync();
            var listArticleDTOs = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(listArticles);
            return listArticleDTOs;
        }

        public Task<IEnumerable<ArticleDTO>> GetAllAsync(string category = null, string tag = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleDTO> GetByIdAsync(int id)
        {
            try
            {
                if (_articleRepository.FindByIdAsync(id) != null)
                {
                    var article = await _articleRepository.FindByIdAsync(id);

                    var articleDTO = _mapper.Map<Article, ArticleDTO>(article);
                    return articleDTO;
                }
                else
                {
                     throw new NullReferenceException("Такой записи нет");                   
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public async Task UpdateAsync(ArticleDTO item)
        {
             var sourceArticle = await _articleRepository.FindByIdAsync(item.Id);

            try
            {
                if (sourceArticle != null)
                {
                    sourceArticle.Name = item.Name;
                    sourceArticle.Description = item.Description;
                    sourceArticle.CategoryId = item.CategoryId;
                    sourceArticle.TagId = item.TagId;
                    sourceArticle.PublishedDateTime = DateTime.Now;

                    await _articleRepository.UpdateAsync(sourceArticle);
                }
                else throw new NullReferenceException("Такой записи нет");
            }
            catch (NullReferenceException)
            {

            }
        }

      
    }

}

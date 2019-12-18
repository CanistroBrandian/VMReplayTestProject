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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO item)
        {
            try
            {
                if (item.Name != null || item.Description != null)
                {
                    var category = _mapper.Map<CategoryDTO, Category>(item);
                    await _categoryRepository.CreateAsync(category);
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
                if (_categoryRepository.FindByIdAsync(id) != null)
                    await _categoryRepository.DeleteAsync(id);
                else new NullReferenceException("Такой записи нет");
            }
            catch (NullReferenceException)
            {

            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var listCategorys = await _categoryRepository.GetAllAsync();
            var listCategoryDTOs = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(listCategorys);
            return listCategoryDTOs;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync(string category = null)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            try
            {
                if (_categoryRepository.FindByIdAsync(id) != null)
                {
                    var category = await _categoryRepository.FindByIdAsync(id);

                    var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);
                    return categoryDTO;
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

        public async  Task UpdateAsync(CategoryDTO item)
        {
            var sourceCategory = await _categoryRepository.FindByIdAsync(item.Id);

            try
            {
                if (sourceCategory != null)
                {
                    sourceCategory.Name = item.Name;
                    sourceCategory.Description = item.Description;
                    await _categoryRepository.UpdateAsync(sourceCategory);
                }
                else throw new NullReferenceException("Такой записи нет");
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}

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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
        public async Task<TagDTO> CreateAsync(TagDTO item)
        {
            try
            {
                if (item.Name != null || item.Description != null)
                {
                    var tag = _mapper.Map<TagDTO, Tag>(item);
                    await _tagRepository.CreateAsync(tag);
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
                if (_tagRepository.FindByIdAsync(id) != null)
                    await _tagRepository.DeleteAsync(id);
                else new NullReferenceException("Такой записи нет");
            }
            catch (NullReferenceException)
            {

            }
        }

        public async Task<IEnumerable<TagDTO>> GetAllAsync()
        {
            var listTags = await _tagRepository.GetAllAsync();
            var listTagDTOs = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(listTags);
            return listTagDTOs;
        }

        public async Task<IEnumerable<TagDTO>> GetAllAsync(string tag = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TagDTO> GetByIdAsync(int id)
        {
            try
            {
                if (_tagRepository.FindByIdAsync(id) != null)
                {
                    var tag = await _tagRepository.FindByIdAsync(id);

                    var tagDTO = _mapper.Map<Tag, TagDTO>(tag);
                    return tagDTO;
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

        public async Task UpdateAsync(TagDTO item)
        {
            var sourceTag = await _tagRepository.FindByIdAsync(item.Id);
            try
            {
                if (sourceTag != null)
                {
                    sourceTag.Name = item.Name;
                    sourceTag.Description = item.Description;
                    await _tagRepository.UpdateAsync(sourceTag);
                }
                else throw new NullReferenceException("Такой записи нет");
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}

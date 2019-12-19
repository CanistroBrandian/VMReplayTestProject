using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.BLL.Interfaces;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.DAL.Interfaces;

namespace WMReplayTestProject.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            try
            {
                if (_userRepository.FindUserByIdAsync(id) != null)
                {
                    var user = await _userRepository.FindUserByIdAsync(id);

                    var userDTO = _mapper.Map<User, UserDTO>(user);
                    return userDTO;
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

        public async Task<UserDTO> GetByNameAsync(string name)
        {
            try
            {
                if (_userRepository.FindUserByEmailAsync(name) != null)
                {
                    var user = await _userRepository.FindUserByEmailAsync(name);
                    var userDTO = _mapper.Map<User, UserDTO>(user);
                    return userDTO;
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

        //public async Task UpdateAsync(UserDTO item)
        //{
        //    var sourceUser = await _userRepository.FindUserByIdAsync(item.Id);

        //    try
        //    {
        //        if (sourceUser != null)
        //        {
        //            sourceUser.Email = item.Email;
        //            sourceUser.UserName = item.UserName;
        //            await _userRepository.UpdateAsync(sourceUser);
        //        }
        //        else throw new NullReferenceException("Такой записи нет");
        //    }
        //    catch (NullReferenceException)
        //    {

        //    }
        //}

        public async Task<IdentityResult> AddUserAsync(UserDTO item)
        {
            try
            {
                if (item.Email != null || item.Password != null)
                {
                    var user = _mapper.Map<UserDTO, User>(item);
                   return await _userRepository.AddUserAsync(user, item.Password);                    
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

    }
}

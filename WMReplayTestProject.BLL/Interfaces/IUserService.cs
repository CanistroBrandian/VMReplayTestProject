﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;

namespace WMReplayTestProject.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> GetByNameAsync(string name);
      //  Task UpdateAsync(UserDTO item);
        Task<IdentityResult> AddUserAsync(UserDTO item);

    }
}

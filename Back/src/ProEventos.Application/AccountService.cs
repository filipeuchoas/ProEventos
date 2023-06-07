using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Contratos;
using ProEventos.Application.DTO;
using ProEventos.Domain.Identity;
using ProEventos.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;

        public AccountService(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper,
                              IUserPersist userPersist)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userPersist = userPersist;
        }

        public SignInManager<User> SignInManager { get; }

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string password)
        {
            try
            {
                var user = await _userManager.Users
                    .SingleOrDefaultAsync(user => user.UserName == userUpdateDTO.UserName.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(user, password, true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }

        public async Task<UserDTO> CreateAccountAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDTO>(user);
                    return userToReturn;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar Usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userPersist.GetUserByUserNameAsync(userName);
                if(user == null)
                {
                    return null;
                }

                var userUpdateDTO = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDTO;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar Usuário por Username. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> UpdateAccountAsync(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await _userPersist.GetUserByUserNameAsync(userUpdateDTO.UserName);
                if (user == null) return null;

                _mapper.Map(userUpdateDTO, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.Password);

                _userPersist.Update<User>(user);

                if (await _userPersist.SaveChangesAsync())
                {
                    var userRetorno = await _userPersist.GetUserByUserNameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDTO>(userRetorno);
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar usuário. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExist(string userName)
        {
            try
            {
                return await _userManager.Users
                                         .AnyAsync(user => user.UserName == userName.ToLower());
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }
        }
    }
}

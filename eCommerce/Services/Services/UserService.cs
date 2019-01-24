using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Repositories.Interfaces;
using Model.Model;
using Repositories.Interfaces;
using Repositories.Repositories;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository repo)
    {
        _userRepository = repo;
    }

    public bool Authenticate(string mail, string password)
    {
        var exist = _userRepository.CheckExist(mail, Encrypt(password));
        return exist;
    }

    public User Create(User user)
    {
        if (!string.IsNullOrEmpty(user.Mail))
        {
            if (_userRepository.CheckExist(user.Mail) == false)
            {
                user.Password = Encrypt(user.Password);
                return _userRepository.Add(user);
            }
        }
        return null;
    }

    public bool Delete(User user)
    {
        return _userRepository.Delete(user.Id);
    }

    private string Encrypt(string word)
    {
        if (word == null)
        {
            word = string.Empty;
        }

        var passwordBytes = Encoding.UTF8.GetBytes(word);
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        return Convert.ToBase64String(passwordBytes);
    }
}


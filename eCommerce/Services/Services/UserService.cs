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

    //private List<User> _users = new List<User>
    //{
    //    new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Password = "test" }
    //};

    public bool Authenticate(string mail, string password)
    {
        var exist = _userRepository.CheckExist(mail, encrypt(password));
        return exist;
    }

    public User Create(User user)
    {
        if (user == null)
        {
            if (_userRepository.CheckExist(user.Mail) == false)
            {
                user.Password = encrypt(user.Password);
                return _userRepository.Add(user);
            }
        }
        return (User)null;
    }

    public bool Delete(User user)
    {
        return _userRepository.Delete(user.Id);
    }

    private string encrypt(string word)
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

//    private String decrypt(String word)
//    {

//    if (word == null)
//    {
//        word = String.Empty;
//    }

//    var passwordBytes = Convert.FromBase64String(word);

//    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

//    var bytesDecrypted = Cipher.Decrypt(bytesToBeDecrypted, passwordBytes);

//    return Encoding.UTF8.GetString(bytesDecrypted);

//}


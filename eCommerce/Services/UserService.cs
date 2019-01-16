﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Repositories.Interfaces;
using Model.Model;
using Repositories.Interfaces;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;


    private List<User> _users = new List<User>
        {
            new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Password = "test" }
        };

    public async Task<User> Authenticate(string firstname, string password)
    {
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.FirstName == firstname && x.Password == password));

        // return null if user not found
        if (user == null)
            return null;

        // authentication successful so return user details without password
        user.Password = null;
        return user;
    }

    public User Create(User user)
    {
        user.Password = encrypt(user.Password);
        return _userRepository.Add(user);
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


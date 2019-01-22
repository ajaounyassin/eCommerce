using System;
using System.Collections.Generic;
using Model.Model;

namespace eCommerce.Services.Interfaces
{
    public interface IArticleService
    {
        Article Create(Article article);
        bool Delete(Article article);
        Article Update(Article article);
        List<Article> GetAll();
        List<Article> FindbyName(string name);
    }
}
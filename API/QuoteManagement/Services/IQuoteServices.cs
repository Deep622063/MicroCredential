using Models.Model;
using System.Collections.Generic;

namespace QuoteManagement.Services
{
    public interface IQuoteServices
    {
        List<Quote> GetAll();

        Quote GetById(int id);


        Quote Update(Quote data);

        Quote Add(Quote data);

        bool Delete(int id);
    }
}

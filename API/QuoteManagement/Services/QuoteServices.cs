using Models.Model;
using QuoteManagement.Helper;
using Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace QuoteManagement.Services
{
    public class QuoteServices : IQuoteServices
    {
        private IDataRepository<Quote> _repository;

        private IQuoteHelper _quoteHelper;
        public QuoteServices(IDataRepository<Quote> repository, IQuoteHelper quoteHelper)
        {
            _repository = repository;
            _quoteHelper = quoteHelper;
        }

        public List<Quote> GetAll()
        {
            return _repository.GetAll();
        }

        public Quote GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Quote Update(Quote data)
        {
            data.MaturityAmount = _quoteHelper.GetMaturityAmount(data.Startdate, data.EndDate, data.ContributionAmount);

            return _repository.Update(data);
        }

        public Quote Add(Quote data)
        {
            data.MaturityAmount = _quoteHelper.GetMaturityAmount(data.Startdate, data.EndDate, data.ContributionAmount);

            return _repository.Add(data);
        }

        public bool Delete(int id)
        {
            var quote = this.GetAll().SingleOrDefault(x => x.Id == id);

            return _repository.Delete(quote) == quote;
        }
    }
}

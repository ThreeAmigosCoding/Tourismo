using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Repository.Interface.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;

namespace Tourismo.Core.Service.Implementation.TravelManagement
{
    public class ArrangementService : IArrangementService
    {

        private readonly IArrangementRepository _arrangementRepository;

        public ArrangementService(IArrangementRepository arrangementRepository)
        {
            _arrangementRepository = arrangementRepository;
        }

        public List<Arrangement> GetUserReservations(String email)
        {
            return _arrangementRepository.ReadAll()
                .Where(arrangement => arrangement.Traveler.EmailAddress == email && (arrangement.ArrangementStatus == ArrangementStatus.Reserved || arrangement.ArrangementStatus == ArrangementStatus.Active))
                .OrderBy(arrangement => arrangement.Period.StartDate)
                .ToList();
        }

        public List<Arrangement> GetUserHistory(String email)
        {
            return _arrangementRepository.ReadAll()
                .Where(arrangement => arrangement.Traveler.EmailAddress == email && arrangement.ArrangementStatus == ArrangementStatus.Finished)
                .OrderByDescending(arrangement => arrangement.Period.StartDate)
                .ToList();
        }

        public Dictionary<Travel, int> GetTravelsByMonth(DateTime month)
        {
            int targetYear = month.Year;
            int targetMonth = month.Month;

            var distinctTravels = ReadAll()
                .Where(arrangement =>
                    arrangement.Period.StartDate.Year == targetYear &&
                    arrangement.Period.StartDate.Month == targetMonth)
                .GroupBy(arrangement => arrangement.Travel)
                .ToDictionary(group => group.Key, group => group.Count());

            return distinctTravels;
        }

        public Summarry GetSummarryByMonth(DateTime month)
        {
            int totalSold = ReadAll().Count(a => a.Period.StartDate.Month == month.Month && a.Period.StartDate.Year == month.Year);
            double totalEarned = ReadAll()
                .Where(a => a.Period.StartDate.Month == month.Month && a.Period.StartDate.Year == month.Year)
                .Sum(a => a.Price);

            return new Summarry(totalSold, totalEarned);

        }

        public Summarry GetSummarryByTravel(Travel travel) 
        {
            int totalSold = ReadAll().Count(a => a.Travel.Id == travel.Id);
            double totalEarned = ReadAll()
                .Where(a => a.Travel.Id == travel.Id)
                .Sum(a => a.Price);

            return new Summarry(totalSold, totalEarned);
        }

        public List<Arrangement> GetTravelArrangements(Travel travel)
        {
            return _arrangementRepository.ReadAll()
                .Where(arrangement => arrangement.Travel.Id == travel.Id)
                .OrderByDescending(arrangement => arrangement.Period.StartDate)
                .ToList();
        }

        #region CRUD Methods

        public Arrangement Create(Arrangement entity)
        {
            return _arrangementRepository.Create(entity);
        }

        public Arrangement Delete(Guid id)
        {
            return _arrangementRepository.Delete(id);
        }

        public Arrangement Read(Guid id)
        {
            return _arrangementRepository.Read(id);
        }

        public IEnumerable<Arrangement> ReadAll()
        {
            return _arrangementRepository.ReadAll();
        }

        public Arrangement Update(Arrangement entity)
        {
            return _arrangementRepository.Update(entity);
        }

        #endregion
    }
}

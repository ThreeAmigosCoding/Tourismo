using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Repository.Interface.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;

namespace Tourismo.Core.Service.Implementation.TravelManagement
{
    public class TravelService : ITravelService
    {   

        private readonly ITravelRepository _travelRepository;

        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        #region CRUD Methods

        public Travel Create(Travel entity)
        {
            return _travelRepository.CreateNewTravel(entity);
        }

        public Travel Delete(Guid id)
        {
            return _travelRepository.Delete(id);
        }

        public Travel Read(Guid id)
        {
            return _travelRepository.Read(id);
        }

        public IEnumerable<Travel> ReadAll()
        {
            return _travelRepository.ReadAll();
        }

        public Travel Update(Travel entity)
        {
            return _travelRepository.UpdateTravel(entity);
        }

        #endregion

        public ObservableCollection<Travel> SortByCriteria(ObservableCollection<Travel> travels, string criteria)
        {
            switch (criteria)
            {
                case "Date (soonest first)":
                    return new ObservableCollection<Travel>(travels.OrderBy(t => t.Periods.Min(p => p.StartDate)));

                case "Date (latest first)":
                    return new ObservableCollection<Travel>(travels.OrderByDescending(t => t.Periods.Max(p => p.EndDate)));

                case "Price (lowest first)":
                    return new ObservableCollection<Travel>(travels.OrderBy(t => t.MinimalPrice));

                case "Price (highest first)":
                    return new ObservableCollection<Travel>(travels.OrderByDescending(t => t.MinimalPrice));

                case "Name":
                    return new ObservableCollection<Travel>(travels.OrderBy(t => t.Name));

                default:
                    return travels;
            }
        }

        public ObservableCollection<Travel> Filter(ObservableCollection<Travel> travels, double minPrice, double maxPrice, 
            DateTime minDate, DateTime maxDate)
        {
            var filteredTravels = new ObservableCollection<Travel>(
                travels.Where(travel =>
                    travel.MinimalPrice >= minPrice &&
                    travel.MinimalPrice <= maxPrice &&
                    travel.Periods.Any(period =>
                        period.StartDate >= minDate &&
                        period.StartDate <= maxDate
                    )
                )
            );

            return filteredTravels;
        }

        public IEnumerable<Travel> ReadAllActive()
        {
            return _travelRepository.ReadAll().Where(travel => travel.IsActive);
        }
    }
}

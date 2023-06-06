using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    public class AccommodationOverviewViewModel : NavigableViewModel
    {
        #region Attributes
        private List<Accommodation> _accommodations;
        private IAccommodationService _accommodationService;
        #endregion

        #region Properties
        public List<Accommodation> Accommodations 
        { 
            get { return _accommodations;}
            set
            { 
                _accommodations = value; 
                OnPropertyChanged(nameof(Accommodations));
            }
        }

        public IAccommodationService AccommodationService { get => _accommodationService; }
        #endregion


        public AccommodationOverviewViewModel(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
            _accommodations = _accommodationService.ReadAll().ToList();
        }
    }
}

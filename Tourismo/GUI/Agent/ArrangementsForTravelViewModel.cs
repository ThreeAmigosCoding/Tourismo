using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    public class ArrangementsForTravelViewModel : NavigableViewModel
    {
        #region Attributes
        private IArrangementService _arrangementService;

        private Travel _currentTravel;
        private List<Arrangement> _arrangementsForTravel;
        private Summarry _summary;
        #endregion

        #region Properties
        public Travel CurrentTravel 
        { 
            get { return _currentTravel; } 
            set
            {
                _currentTravel = value;
                OnPropertyChanged(nameof(CurrentTravel));
            }
        }
        public List<Arrangement> ArrangementsForTravel
        {
            get { return _arrangementsForTravel; }
            set
            {
                _arrangementsForTravel = value;
                OnPropertyChanged(nameof(ArrangementsForTravel));
            }
        }
        public Summarry Summarry
        {
            get { return _summary; }
            set
            {
                _summary = value;
                OnPropertyChanged(nameof(Summarry));
            }
        }
        #endregion

        public ArrangementsForTravelViewModel(IArrangementService arrangementService)
        {
            CurrentTravel = GlobalStore.ReadObject<Travel>("ArrangementTravel");
            if (CurrentTravel != null)
            {
                _arrangementService = arrangementService;
                ArrangementsForTravel = _arrangementService.GetTravelArrangements(CurrentTravel);
                Summarry = _arrangementService.GetSummarryByTravel(CurrentTravel);
            }
            
        }
    }
}

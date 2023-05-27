using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Client
{
    public class TravelsOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private readonly List<Travel> _travels;
        private ITravelService _travelService;
        
        #endregion

        #region Properties

        public List<Travel> Travels => _travels;
        public ITravelService TravelService { get => _travelService; }

        #endregion

        
        public TravelsOverviewViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            _travels = _travelService.ReadAll().ToList();
        }


    }
}

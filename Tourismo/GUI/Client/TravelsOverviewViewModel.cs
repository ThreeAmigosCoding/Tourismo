using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;

namespace Tourismo.GUI.Client
{
    public class TravelsOverviewViewModel : NavigableViewModel
    {

        #region Attributes

        private readonly List<Travel> _travels;
        private ITravelService _travelService;
        private readonly MyMapCredentials _mapApiKey = new MyMapCredentials();
        
        #endregion

        #region Properties

        public List<Travel> Travels => _travels;
        public ITravelService TravelService { get => _travelService; }

        public MyMapCredentials MapApiKey => _mapApiKey;

        #endregion

        
        public TravelsOverviewViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            _travels = _travelService.ReadAll().ToList();
        }


    }
}

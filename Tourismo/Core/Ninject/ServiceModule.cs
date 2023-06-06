using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Repository.Implementation;
using Tourismo.Core.Repository.Implementation.TravelManagement;
using Tourismo.Core.Repository.Implementation.UserManagement;
using Tourismo.Core.Repository.Interface;
using Tourismo.Core.Repository.Interface.TravelManagement;
using Tourismo.Core.Repository.Interface.UserManagement;
using Tourismo.Core.Service.Implementation.TravelManagement;
using Tourismo.Core.Service.Implementation.UserManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Service.Interface.UserManagement;
using Tourismo.GUI.Auth;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<LoginViewModel>().To<LoginViewModel>();

            #region Repositories

            Bind(typeof(ICRUDRepository<>)).To(typeof(CRUDRepository<>));
            Bind(typeof(IUserRepository)).To(typeof(UserRepository));

            Bind(typeof(ITravelRepository)).To(typeof(TravelRepository));
            Bind(typeof(IArrangementRepository)).To(typeof(ArrangementRepository));
            Bind(typeof(IAccommodationRepository)).To(typeof(AccommodationRepository));
            Bind(typeof(ITouristAttractionRepository)).To(typeof(TouristAttractionRepository));

            #endregion

            #region Services

            Bind(typeof(IUserService)).To(typeof(UserService));

            Bind(typeof(ITravelService)).To(typeof(TravelService));
            Bind(typeof(IArrangementService)).To(typeof(ArrangementService));
            Bind(typeof(IAccommodationService)).To(typeof(AccommodationService));
            Bind(typeof(ITouristAttractionService)).To(typeof(TouristAttractionService));

            #endregion
        }

    }
}

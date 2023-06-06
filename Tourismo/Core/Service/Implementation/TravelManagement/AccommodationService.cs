﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Repository.Interface.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;

namespace Tourismo.Core.Service.Implementation.TravelManagement
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public AccommodationService(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }



        #region CRUD Methods
        public Accommodation Create(Accommodation entity)
        {
            return _accommodationRepository.Create(entity);
        }

        public Accommodation Delete(Guid id)
        {
            return _accommodationRepository.Delete(id);
        }

        public Accommodation Read(Guid id)
        {
            return _accommodationRepository.Read(id);
        }

        public IEnumerable<Accommodation> ReadAll()
        {
            return _accommodationRepository.ReadAll();
        }

        public Accommodation Update(Accommodation entity)
        {
            return _accommodationRepository.Update(entity);
        }
        #endregion

    }
}

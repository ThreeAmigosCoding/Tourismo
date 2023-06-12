using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tourismo.Core.Model.Helper;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface.TravelManagement;

namespace Tourismo.Core.Repository.Implementation.TravelManagement
{
    public class TravelRepository : CRUDRepository<Travel>, ITravelRepository
    {
        public TravelRepository(DatabaseContext context) : base(context)
        {
        }

        public Travel CreateNewTravel(Travel travel)
        {
            List<Guid> defaultAttractionsIds = travel.DefaultAttractions.Select(a => a.Id).ToList();

            travel.DefaultAttractions = _context.TouristAttractions
                .Where(a => a.Id != null && defaultAttractionsIds.Contains(a.Id))
                .ToList();

            List<Guid> additionalAttractionsIds = travel.AdditionalAttractions.Select(a => a.Id).ToList();

            travel.AdditionalAttractions = _context.TouristAttractions
                .Where(a => a.Id != null && additionalAttractionsIds.Contains(a.Id))
                .ToList();

            travel.Accommodation = _context.Accommodations.FirstOrDefault(a => a.Id == travel.Accommodation.Id);

            _context.Travels.Add(travel);
            _context.SaveChanges();
            return travel;
        }

        public Travel UpdateTravel(Travel entity)
        {
            var entityToUpdate = Read(entity.Id);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

                _context.Entry(entityToUpdate).Collection(e => e.DefaultAttractions).Load();
                _context.Entry(entityToUpdate).Collection(e => e.AdditionalAttractions).Load();
                _context.Entry(entityToUpdate).Collection(e => e.Periods).Load();
                entityToUpdate.DefaultAttractions.Clear();
                entityToUpdate.AdditionalAttractions.Clear();
                entityToUpdate.Periods.Clear();
                _context.SaveChanges();

                foreach (var defaultAttraction in entity.DefaultAttractions)
                {
                    entityToUpdate.DefaultAttractions.Add(_context.TouristAttractions.FirstOrDefault(t => t.Id == defaultAttraction.Id));
                }

                foreach (var additionalAttraction in entity.AdditionalAttractions)
                {
                    entityToUpdate.AdditionalAttractions.Add(_context.TouristAttractions.FirstOrDefault(t => t.Id == additionalAttraction.Id));
                }

                foreach (var newPeriod in entity.Periods)
                {
                    var existingPeriod = _context.DateRange.FirstOrDefault(p => p.Id == newPeriod.Id);
                    if (existingPeriod == null)                 
                        entityToUpdate.Periods.Add(newPeriod);  
                    else                    
                        entityToUpdate.Periods.Add(existingPeriod);
                    
                }
      
                _context.SaveChanges();
            }

            return entityToUpdate;
        }
    }
}

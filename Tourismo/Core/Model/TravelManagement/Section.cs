using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.TravelManagement
{
    public class Section : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        [ForeignKey("DefaultSectionId")]
        private List<TouristAttraction> _defaultAttractions;
        public virtual List<TouristAttraction> DefaultAttractions { get => _defaultAttractions; set => OnPropertyChanged(ref _defaultAttractions, value); }

        [ForeignKey("AdditionalSectionId")]
        private List<TouristAttraction> _additionalAttractions;
        public virtual List<TouristAttraction> AdditionalAttractions { get => _additionalAttractions; set => OnPropertyChanged(ref _additionalAttractions, value); }

        private List<Accommodation> _accommodations;
        public virtual List<Accommodation> Accommodations { get => _accommodations; set => OnPropertyChanged(ref _accommodations, value); }
    }

}

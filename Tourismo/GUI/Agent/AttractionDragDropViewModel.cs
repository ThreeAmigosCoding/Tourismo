using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourismo.Core.Commands.Agent;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Agent
{
    public class AttractionDragDropViewModel : ViewModelBase
    {
        private ObservableCollection<TouristAttraction> _attractions;
        public IEnumerable<TouristAttraction> Attractions
        {
            get => _attractions;
            set { 
                _attractions = new ObservableCollection<TouristAttraction>(value);
                OnPropertyChanged(nameof(Attractions));
            }
        }

        private int _attractionsLength;
        public int AttractionsLength
        {
            get => _attractionsLength;
            set
            {
                _attractionsLength = value;
                OnPropertyChanged(nameof(AttractionsLength));
            }
        }

        private ObservableCollection<TouristAttraction> _unfilteredAttractions;
        public IEnumerable<TouristAttraction> UnfilteredAttractions
        {
            get => _unfilteredAttractions;
            set
            {
                _attractions = new ObservableCollection<TouristAttraction>(value);
                OnPropertyChanged(nameof(UnfilteredAttractions));
            }
        }



        private TouristAttraction _incomingAttraction;
        public TouristAttraction IncomingAttraction
        {
            get { return _incomingAttraction; }
            set { 
                _incomingAttraction = value; 
                OnPropertyChanged(nameof(IncomingAttraction));
            }
        }

        private TouristAttraction _removedAttraction;
        public TouristAttraction RemovedAttraction
        {
            get { return _removedAttraction; }
            set
            {
                _removedAttraction = value;
                OnPropertyChanged(nameof(RemovedAttraction));
            }
        }

        private TouristAttraction _insertedAttraction;
        public TouristAttraction InsertedAttraction
        {
            get { return _insertedAttraction; }
            set
            {
                _insertedAttraction = value;
                OnPropertyChanged(nameof(InsertedAttraction));
            }
        }

        private TouristAttraction _targetAttraction;
        public TouristAttraction TargetAttraction
        {
            get { return _targetAttraction; }
            set
            {
                _targetAttraction = value;
                OnPropertyChanged(nameof(TargetAttraction));
            }
        }


        public ICommand AttractionReceivedCommand { get; }
        public ICommand AttractionRemovedCommand { get; }
        public ICommand AttractionInsertedCommand { get; }

        public AttractionDragDropViewModel()
        {
            _attractions = new ObservableCollection<TouristAttraction>();
            _unfilteredAttractions = new ObservableCollection<TouristAttraction>();
            AttractionReceivedCommand = new AttractionReceivedCommand(this);
            AttractionRemovedCommand = new AttractionRemovedCommand(this);
            AttractionInsertedCommand = new AttractionInsertedCommand(this);
        }

        public void AddAttraction(TouristAttraction attraction)
        {
            if (!_attractions.Contains(attraction))
            {
                _attractions.Add(attraction);
                _unfilteredAttractions.Add(attraction);
                AttractionsLength = Attractions.Count();
            }
                
        }

        public void InsertAttraction(TouristAttraction insertedAttraction, TouristAttraction targetAttraction) 
        {
            if (insertedAttraction == targetAttraction)
                return;

            int oldIndex = _attractions.IndexOf(insertedAttraction);
            int nextIndex = _attractions.IndexOf(targetAttraction);

            if (oldIndex != -1 && nextIndex != -1)
                _attractions.Move(oldIndex, nextIndex);
        }

        public void RemoveAttraction(TouristAttraction attraction)
        {
            _attractions.Remove(attraction);
            _unfilteredAttractions.Remove(attraction);
            AttractionsLength = Attractions.Count();
        }
     
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Model.UserDocumentation;
using Tourismo.Core.Service.Interface.Documentation;
using Tourismo.GUI.Utility;

namespace Tourismo.GUI.Client
{
    class ClientHelpViewModel : NavigableViewModel
    {
        #region Atributes

        private UserDocumentation _documentation;
        private ObservableCollection<UserDocumentationSection> _filteredSections;
        private string _searchText;

        private IUserDocumentationService _userDocumentationService;

        #endregion

        #region Properties

        public UserDocumentation Documentation
        {
            get { return _documentation; }
            set
            {
                _documentation = value;
                OnPropertyChanged(nameof(Documentation));
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                FilterItems();
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public ObservableCollection<UserDocumentationSection> FilteredSections
        {
            get { return _filteredSections; }
            set
            {
                _filteredSections = value;
                OnPropertyChanged(nameof(FilteredSections));
            }
        }

        public IUserDocumentationService UserDocumentationService { get { return _userDocumentationService; } }

        #endregion

        public ClientHelpViewModel(IUserDocumentationService userDocumentationService)
        {
            _userDocumentationService = userDocumentationService;
            _documentation = userDocumentationService.ReadAll().FirstOrDefault(d => d.Type == UserDocumentationType.ClientDocumentation);
            FilterItems();
        }

        private void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredSections = new ObservableCollection<UserDocumentationSection>(_documentation.Sections);
            }
            else
            {
                var filteredItems = Documentation.Sections.Where(t =>
                 t.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                 .ToList();

                FilteredSections = new ObservableCollection<UserDocumentationSection>(filteredItems);
            }
        }

    }
}

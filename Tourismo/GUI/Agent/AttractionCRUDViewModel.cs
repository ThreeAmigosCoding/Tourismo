﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tourismo.Core.Commands.Agent;
using Tourismo.Core.Commands;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Service.Interface.TravelManagement;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;
using Tourismo.Resources.Credentials;

namespace Tourismo.GUI.Agent
{
    class AttractionCRUDViewModel : NavigableViewModel
    {

        #region Attributes

        private string _mode;
        private MyMapCredentials _credentials = new MyMapCredentials();

        private Visibility _deleteButtonVisibility;

        private TouristAttraction _attraction;

        private string _errMsgText;
        private Visibility _errMsgVisibility;

        private ITouristAttractionService _attractionService;

        #endregion

        #region Properties

        public string Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }

        public MyMapCredentials MapCredentials { get => _credentials; }

        public Visibility DeleteButtonVisibility
        {
            get { return _deleteButtonVisibility; }
            set
            {
                _deleteButtonVisibility = value;
                OnPropertyChanged(nameof(DeleteButtonVisibility));
            }
        }

        public TouristAttraction Attraction
        {
            get { return _attraction; }
            set
            {
                _attraction = value;
                OnPropertyChanged(nameof(Attraction));
            }
        }

        public string ErrMsgText
        {
            get => _errMsgText;
            set
            {
                _errMsgText = value;
                OnPropertyChanged(nameof(ErrMsgText));
            }
        }

        public Visibility ErrMsgVisibility
        {
            get => _errMsgVisibility;
            set
            {
                _errMsgVisibility = value;
                OnPropertyChanged(nameof(ErrMsgVisibility));
            }
        }

        public ITouristAttractionService AttractionService { get => _attractionService; }

        #endregion

        #region Commands

        public ICommand? SaveAttractionCommand { get; }

        public ICommand? ChooseAttractionImageCommand { get; }

        public ICommand? DeleteAttractionCommand { get; }

        #endregion

        public AttractionCRUDViewModel(ITouristAttractionService attractionService)
        {
            _attractionService = attractionService;
            _mode = GlobalStore.ReadObject<string>("AttractionCRUDMode");

            if (_mode != null && _mode == "update")
            {
                _deleteButtonVisibility = Visibility.Visible;
                _attraction = GlobalStore.ReadObject<TouristAttraction>("SelectedAttraction");
            }
            else
            {
                _deleteButtonVisibility = Visibility.Hidden;
                _attraction = new TouristAttraction();
                _attraction.Location = new Core.Model.Helper.Location();
            }

            SaveAttractionCommand = new SaveAttractionCommand(this);
            ChooseAttractionImageCommand = new ChooseAttractionImageCommand(this);
            DeleteAttractionCommand = new DeleteAttractionFromDetailsCommand(this);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.UserDocumentation
{
    public class UserDocumentationSection : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        private string _description;
        public string Description { get => _description; set => OnPropertyChanged(ref _description, value);}

        private string _imagePath;
        public string ImagePath { get => _imagePath; set => OnPropertyChanged(ref _imagePath, value); }
    }
}

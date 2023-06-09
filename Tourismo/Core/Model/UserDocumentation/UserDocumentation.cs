using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Model.UserDocumentation
{
    public class UserDocumentation : BaseObservableEntity
    {
        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        private UserDocumentationType _type;
        public UserDocumentationType Type { get => _type; set => OnPropertyChanged(ref _type, value);}

        private List<UserDocumentationSection> _sections;
        public List<UserDocumentationSection> Sections {
            get => _sections; 
            set => OnPropertyChanged(ref _sections, value);
        }
    }
}

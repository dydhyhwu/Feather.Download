using Feather.Tools.Domains;

namespace Feather.Tools.Modules.Downloads.Models
{
    public class AddTaskModel : BindingModel
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("Url");
            }
        }
    }
}
using System;
using Feather.Tools.Domains;

namespace Feather.Tools.Modules.Downloads.Models
{
    public class DownloadTaskModel : BindingModel
    {
        private string _name;
        private Int64 _size;
        private Int64 _completed;
        private string _path;
        private Int64 _speed;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public Int64 Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        public Int64 Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                OnPropertyChanged("Completed");
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }

        public Int64 Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }
    }
}

using System;
using System.Collections.ObjectModel;
using Feather.Tools.Domains;

namespace Feather.Tools.Modules.Downloads.Models
{
    public class Aria2Model : BindingModel
    {
        private ObservableCollection<TaskModel> _activeTaskList;
        private ObservableCollection<TaskModel> _waitingTaskList;
        private ObservableCollection<TaskModel> _stoppedTaskList;
        private Int64 _speed;

        public ObservableCollection<TaskModel> ActiveTaskList
        {
            get { return _activeTaskList; }
            set
            {
                _activeTaskList = value;
                OnPropertyChanged("ActiveTaskList");
            }
        }

        public ObservableCollection<TaskModel> WaitingTaskList
        {
            get { return _waitingTaskList; }
            set
            {
                _waitingTaskList = value;
                OnPropertyChanged("WaitingTaskList");
            }
        }

        public ObservableCollection<TaskModel> StoppedTaskList
        {
            get { return _stoppedTaskList; }
            set
            {
                _stoppedTaskList = value;
                OnPropertyChanged("StoppedTaskList");
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

    public class TaskModel : BindingModel
    {
        private Int64 _completed;
        private Int64 _total;
        private Int64 _speed;

        public Int64 Completed
        {
            get { return _completed;}
            set
            {
                _completed = value;
                OnPropertyChanged("Completed");
            }
        }
        public Int64 Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
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
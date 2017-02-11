using System;
using System.ComponentModel;
using System.Windows.Input;
using Task.Models;
using Xamarin.Forms;

namespace Task
{
    public class EditTaskViewModel : INotifyPropertyChanged
    {
        bool _completed;
        String _description;
        String _title;
        WorkItem _workItem;


        public EditTaskViewModel()
        {
            NavigateBack = () => { return System.Threading.Tasks.Task.FromResult(string.Empty); };
        }

        public void Init(WorkItem workItem)
        {
            if (workItem == null) throw new ArgumentNullException(nameof(workItem));
            _workItem = workItem;
            Title = _workItem.Title;
            Description = _workItem.Description;
            Completed = _workItem.Completed;

            StoreCommand = new Command(async () => { await Save(); });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public String Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (value == _title) return;
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public String Description
        {
            get
            {
                return _description;
            }

            set
            {
                if (value == _description) return;
                _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public bool Completed
        {
            get
            {
                return _completed;
            }

            set
            {
                if (value == _completed) return;
                _completed = value;
                RaisePropertyChanged(nameof(Completed));
            }
        }

        public Command StoreCommand { get; private set; }

        public Func<System.Threading.Tasks.Task> NavigateBack { get; set; }

        private async System.Threading.Tasks.Task Save()
        {
            _workItem.Title = Title;
            _workItem.Description = Description;
            _workItem.Completed = Completed;
            await NavigateBack();
        }

        private void RaisePropertyChanged(string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(name));
            }
        }
    }
}

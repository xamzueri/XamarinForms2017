using System;
using Task.Models;
using Task.ViewModels.Helpers;

namespace Task.ViewModels
{
    public class WorkItemViewModel : BaseViewModel
    {
        string _title;
        string _description;
        bool _completed;

        public WorkItemViewModel(WorkItem workItem)
        {
            if (workItem == null) throw new ArgumentNullException(nameof(workItem));

            Title = workItem.Title;
            Description = workItem.Description;
            Completed = workItem.Completed;
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (value == Title) return;
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                if (value == Description) return;
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
                if (value == Completed) return;
                _completed = value;
                RaisePropertyChanged(nameof(Completed));
            }
        }
    }
}

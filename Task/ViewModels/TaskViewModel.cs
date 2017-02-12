using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Task.Models;
using Task.ViewModels.Helpers;

namespace Task.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        ObservableCollection<WorkItemViewModel> _workItems;

        public TaskViewModel()
        {
            WorkItems = new ObservableCollection<WorkItemViewModel>(GenerateData());
        }

        public ObservableCollection<WorkItemViewModel> WorkItems
        {
            get
            {
                return _workItems;
            }

            set
            {
                if (WorkItems == value) return;
                _workItems = value;
                RaisePropertyChanged(nameof(_workItems));
            }
        }

        private IEnumerable<WorkItemViewModel> GenerateData()
        {
            return new List<WorkItem> {
                new WorkItem { Title = "Plan Xamarin.Forms Talk", Description="This that and the other...", Completed = true},
                new WorkItem { Title = "Order Pizza", Description="Two slices per person", Completed = false},
                new WorkItem { Title = "Share code samples", Description="Share Github link", Completed = false},
            }.Select(w => new WorkItemViewModel(w));
        }
    }
}

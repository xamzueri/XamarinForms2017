using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Task.Models;
using Task.ViewModels.Helpers;

namespace Task.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        ObservableCollection<WorkItemViewModel> _workItems;
        public Action NavigateToTaskCreationPage = () => { };

        public TaskViewModel()
        {
            WorkItems = new ObservableCollection<WorkItemViewModel>(GenerateData());
            AddNewTaskCommand = new Command(CreateNewTask);
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

        public ICommand AddNewTaskCommand { get; private set; }

        private IEnumerable<WorkItemViewModel> GenerateData()
        {
            return new List<WorkItem> {
                new WorkItem { Title = "Plan Xamarin.Forms Talk", Description="This that and the other...", Completed = true},
                new WorkItem { Title = "Order Pizza", Description="Two slices per person", Completed = false},
                new WorkItem { Title = "Share code samples", Description="Share Github link", Completed = false},
            }.Select(w => new WorkItemViewModel(w));
        }

        private void CreateNewTask()
        {
            NavigateToTaskCreationPage();
        }
    }
}

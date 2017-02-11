using System.Collections.ObjectModel;
using Task.Models;
using Xamarin.Forms;

namespace Task.Views
{
    public partial class TaskPage : ContentPage
    {
        ObservableCollection<WorkItem> _workItems;

        public TaskPage()
        {
            InitializeComponent();
            GenerateList();
            TasksListView.ItemsSource = _workItems;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TasksListView.ItemsSource = null;
            TasksListView.ItemsSource = _workItems;
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            await Navigation.PushAsync(new EditTaskPage((WorkItem) e.SelectedItem));
            ((ListView)sender).SelectedItem = null;
        }

        private void GenerateList()
        {
            _workItems = _workItems ?? (_workItems = new ObservableCollection<WorkItem> {
                new WorkItem { Title = "Plan Xamarin.Forms Talk", Description="This that and the other...", Completed = true},
                new WorkItem { Title = "Order Pizza", Description="Two slices per person", Completed = false},
                new WorkItem { Title = "Share code samples", Description="Share Github link", Completed = false},
            });
        }
    }
}

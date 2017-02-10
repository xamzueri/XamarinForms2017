using System.Collections.ObjectModel;
using Task.Models;
using Xamarin.Forms;

namespace Task.Views
{
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TasksListView.ItemsSource = new ObservableCollection<WorkItem> {
                new WorkItem { Title = "Plan Xamarin.Forms Talk", Description="This that and the other...", Done = true},
                new WorkItem { Title = "Order Pizza", Description="Two slices per person", Done = false},
                new WorkItem { Title = "Share code samples", Description="Share Github link", Done = false},
            };
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            await Navigation.PushAsync(new EditTaskPage((WorkItem) e.SelectedItem));
            ((ListView)sender).SelectedItem = null;
        }
    }
}

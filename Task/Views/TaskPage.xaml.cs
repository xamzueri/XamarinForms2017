using System.Collections.ObjectModel;
using Task.Models;
using Task.ViewModels;
using Xamarin.Forms;

namespace Task.Views
{
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            BindingContext = Vm;
            InitializeComponent();
            Vm.NavigateToTaskCreationPage = async () => await Navigation.PushAsync(new EditTaskPage());
        }

        static TaskViewModel _taskViewModel = new TaskViewModel();
        public TaskViewModel Vm => _taskViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            await Navigation.PushAsync(new EditTaskPage((WorkItemViewModel) e.SelectedItem));
            ((ListView)sender).SelectedItem = null;
        }
    }
}

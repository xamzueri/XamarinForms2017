using Task.Models;
using Task.ViewModels;
using Xamarin.Forms;

namespace Task
{
    public partial class EditTaskPage : ContentPage
    {
        private WorkItemViewModel _selectedItem;
        private EditTaskViewModel _vm;
        private EditTaskViewModel Vm => _vm ?? (_vm = new EditTaskViewModel());

        public EditTaskPage()
        {
            InitializeComponent();
            _selectedItem = new WorkItemViewModel(new WorkItem());
            Vm.NavigateBack = NavigateBack;
            Vm.Init(_selectedItem);
            BindingContext = Vm;
        }

        public EditTaskPage(WorkItemViewModel selectedItem) : this()
        {
            _selectedItem = selectedItem;
            Vm.Init(_selectedItem);
            BindingContext = Vm;
            Title = selectedItem.Title;
        }

        async System.Threading.Tasks.Task NavigateBack()
        {
            await Navigation.PopAsync();
        }

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (e.Value)
            {
                Application.Current.Resources["buttonBackgroundColor"] = Color.Blue;
            }
            else
            {
                Application.Current.Resources["buttonBackgroundColor"] = Color.Lime;
            }
        }
    }
}

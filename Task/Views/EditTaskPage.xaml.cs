using Task.Models;
using Xamarin.Forms;

namespace Task
{
    public partial class EditTaskPage : ContentPage
    {
        private WorkItem _selectedItem;
        private EditTaskViewModel _vm;
        private EditTaskViewModel Vm => _vm ?? (_vm = new EditTaskViewModel());

        public EditTaskPage()
        {
            InitializeComponent();
            _selectedItem = new WorkItem();
            Vm.NavigateBack = NavigateBack;
            Vm.Init(_selectedItem);
            BindingContext = Vm;
        }

        public EditTaskPage(WorkItem selectedItem):this()
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
    }
}

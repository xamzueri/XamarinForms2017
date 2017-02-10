using System;
using System.Collections.Generic;
using Task.Models;
using Xamarin.Forms;

namespace Task
{
    public partial class EditTaskPage : ContentPage
    {
        WorkItem selectedItem;

        public EditTaskPage()
        {
            InitializeComponent();
            this.selectedItem = new WorkItem();
        }

        public EditTaskPage(WorkItem selectedItem):this()
        {
            this.selectedItem = selectedItem;
            Title = selectedItem.Title;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

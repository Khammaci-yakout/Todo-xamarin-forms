using System;
using Xamarin.Forms;
using TodoProject.Models;
using Xamarin.CommunityToolkit.Extensions;

namespace TodoProject
{
    public partial class TodoEntryPage : ContentPage
    {
        public TodoEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todo = (Todo)BindingContext;
            await App.Database.SaveTodoAsync(todo);
            await Navigation.PopAsync();
            await this.DisplayToastAsync("Task added successfully !");
        }
    }
}





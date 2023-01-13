using System;
using Xamarin.Forms;
using TodoProject.Models;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;

namespace TodoProject
{ 
    public partial class TodoPage : ContentPage
    {
        public TodoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetTodoesAsync();
        }


        async void OnTodoAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoEntryPage
            {
                BindingContext = new Todo()
            });
        }

        async void Edit_Swipe_item(object sender, EventArgs e)
        {
            int id = (int)((MenuItem)sender).CommandParameter;
            var Todo = await App.Database.GetTodoAsync(id);

                await Navigation.PushAsync(new TodoEntryPage
                {
                    BindingContext =Todo
                });
            
        }

        async void Delete_Swipe_item(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Delete", "Are you sure do delete this task","delete","cancel");
            if (response)
                {
                    int id = (int)((MenuItem)sender).CommandParameter;
                    var todo = await App.Database.GetTodoAsync(id);
                    await App.Database.DeleteTodoAsync(todo);
                    OnAppearing();
                await this.DisplayToastAsync("Task deleted successfully !");
                }
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton imageButton = (sender as ImageButton);
            String i = imageButton.Source.ToString();
            String i1 = "unchecked.png";
            String i2 = "tick.png";
            if (i.Equals("File: "+i1))
            {
                (sender as ImageButton).Source = i2;

            }
            if (i.Equals("File: " + i2))
            {
                (sender as ImageButton).Source = i1;
            }
            
        }

    }
}






using navapp.Models;

namespace navapp
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDBService _dbService;
        private int _editBookId;


        public MainPage(LocalDBService dBService)
        {
            InitializeComponent();
            _dbService = dBService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetBooks());

        }


        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());

        }
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var book = button?.BindingContext as Book;
            if (book != null)
            {
                await _dbService.Delete(book);

                
                listView.ItemsSource = await _dbService.GetBooks();
            }
        }
        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (_editBookId == 0)
            {
                await _dbService.Create(new Book
                {
                    Title = titleEntryField.Text,
                    Author = authorEntryField.Text,
                    Genre = genreEntryField.Text,
                    PublishDate = publishDatePicker.Date,
                    Description = descriptionEditor.Text
                });
            }
            else
            {
                await _dbService.Update(new Book
                {
                    Id = _editBookId,
                    Title = titleEntryField.Text,
                    Author = authorEntryField.Text,
                    Genre = genreEntryField.Text,
                    PublishDate = publishDatePicker.Date,
                    Description = descriptionEditor.Text
                });

                _editBookId = 0;
            }

            titleEntryField.Text = string.Empty;
            authorEntryField.Text = string.Empty;
            genreEntryField.Text = string.Empty;
            publishDatePicker.Date = DateTime.Today;
            descriptionEditor.Text = string.Empty;

            
            listView.ItemsSource = await _dbService.GetBooks();
        }


        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var book = (Book)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editBookId = book.Id;
                    titleEntryField.Text = book.Title;
                    authorEntryField.Text = book.Author;
                    genreEntryField.Text = book.Genre;
                    publishDatePicker.Date = book.PublishDate;
                    descriptionEditor.Text = book.Description;
                    break;

                case "Delete":
                    await _dbService.Delete(book);
                    listView.ItemsSource = await _dbService.GetBooks();
                    break;
            }
        }
    }

}

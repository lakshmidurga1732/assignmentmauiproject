//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;
using navapp.Models;

namespace navapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage(Book book)
        {
            InitializeComponent();

            // Populate the fields with book details
          /*  titleEntryField.Text = book.Title;
            authorEntryField.Text = book.Author;
            genreEntryField.Text = book.Genre;
            publishDatePicker.Date = book.PublishDate;
            descriptionEditor.Text = book.Description;*/
        }
    }
}

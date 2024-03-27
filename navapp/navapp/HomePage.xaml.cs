namespace navapp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private void AddBook_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage(new LocalDBService()));

    }
}
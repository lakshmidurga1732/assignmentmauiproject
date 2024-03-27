namespace navapp
{
    public partial class App : Application
    {
        public App(MainPage mainpage)
        {
            InitializeComponent();

            MainPage = new AppShell(); 


        }
    }
}

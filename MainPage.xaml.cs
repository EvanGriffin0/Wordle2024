using System.Text.RegularExpressions;

namespace Wordle2024
{

  
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        public MainPage()
        {
            InitializeComponent();
        }

        //inform user if they ahve entered a valid userName
        private void onEnterButtonClicked(object sender, EventArgs e)
        {
            string userName = userNameEntry.Text;
            HomePage homePage = new HomePage();
            if (IsValidUserName(userName)){
              
                Navigation.PushAsync(homePage);
            }
            else
            {
                DisplayAlert("Validation", "Username is not Valid, It cannot contain characters other than Letters", "ok");

            }
        }

        private bool IsValidUserName(string userName)
        {
            // Check if the string contains only letters (no numbers or special characters)
            return !string.IsNullOrEmpty(userName) && Regex.IsMatch(userName, "^[a-zA-Z]+$");
        }
    }
}
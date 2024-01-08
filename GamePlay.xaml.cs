using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Wordle2024
{
    public partial class GamePlay : ContentPage
    {
        private int onKeyTappedCounter;
        private string[][] userGuessHolder;
        private char[] randomWord;
        int guessCounter;
        int howManyGreen;

        public GamePlay()
        {
            InitializeComponent();
            onKeyTappedCounter = 0;
            // Check if the user has necessary files and download them if not
            WordManagment.downloadCheck();

            // Call function that returns a random word from the file
            randomWord = GameplayManagement.SelectRandomWord();

            Label header = this.FindByName<Label>("header");
            resetUserGuess();

            // Initialize array
            userGuessHolder = new string[6][];
            for (int i = 0; i < 6; i++)
            {
                userGuessHolder[i] = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    userGuessHolder[i][j] = "p"; // "p" standing for placeholder
                }
            }
        }

        //check if a key on the keyboard is used and what its value is
        private void OnKeyTapped(object sender, EventArgs e)
        {
            //if less than 5 characters are picked allow user to continue
            if (onKeyTappedCounter <= 5)
            {

                if (sender is Label label)
                {
                    string selectedKey = label.Text;

                    switch (onKeyTappedCounter)
                    {
                        case 0:
                            // finds the label that holds the user guess and places key there
                            Label MyLabel = this.FindByName<Label>("userGuessLetter1");
                            MyLabel.Text = selectedKey;
                            //place the users Selected key in the user Guess array
                            userGuessHolder[guessCounter][onKeyTappedCounter] = selectedKey;
                            onKeyTappedCount();
                            break;

                        case 1:
                            Label MyLabel2 = this.FindByName<Label>("userGuessLetter2");
                            MyLabel2.Text = selectedKey;
                            userGuessHolder[guessCounter][onKeyTappedCounter] = selectedKey;

                            onKeyTappedCount();
                            break;

                        case 2:
                            Label MyLabel3 = this.FindByName<Label>("userGuessLetter3");
                            MyLabel3.Text = selectedKey;
                            userGuessHolder[guessCounter][onKeyTappedCounter] = selectedKey;

                            onKeyTappedCount();
                            break;

                        case 3:
                            Label MyLabel4 = this.FindByName<Label>("userGuessLetter4");
                            MyLabel4.Text = selectedKey;
                            userGuessHolder[guessCounter][onKeyTappedCounter] = selectedKey;
                            onKeyTappedCount();
                            break;

                        case 4:
                            Label MyLabel5 = this.FindByName<Label>("userGuessLetter5");
                            MyLabel5.Text = selectedKey;
                            userGuessHolder[guessCounter][onKeyTappedCounter] = selectedKey;
                            onKeyTappedCount();
                            break;
                    }

                }
            }
            else {
                DisplayAlert("Validation", "You can only enter 5 letters \n! Click enter to submit guess", "ok");

            }

        }

        //when a key is tapped update the variable
        public void onKeyTappedCount()
        {
            if (onKeyTappedCounter < 5)
            {
                onKeyTappedCounter++;
            }

        }

        // when backspace is pressed update the variable 
        public void onKeyTappedRemoved()
        {

            if (onKeyTappedCounter > 0)
            {
                onKeyTappedCounter--;
            }
        }

        // action performed when use clicks enter 
        void enterButtonClicked(object sender, EventArgs e)
        {
            //if user has entered 5 character word 
            if (onKeyTappedCounter == 5 && guessCounter <= 6)
            {
                //convert randomLetter from char to string to be compared
                string randomLetter1 = randomWord[0].ToString().ToUpper();
                string randomLetter2 = randomWord[1].ToString().ToUpper();
                string randomLetter3 = randomWord[2].ToString().ToUpper();
                string randomLetter4 = randomWord[3].ToString().ToUpper();
                string randomLetter5 = randomWord[4].ToString().ToUpper();

                howManyGreen = 0;
                Console.WriteLine($"User Guess: {userGuessHolder[guessCounter][0]}, Random Letter: {randomLetter1}");
                // Call the function to compare user's guess with the random word
                switch (guessCounter) {
                 
                    case 0:

                        Label MyLabel = this.FindByName<Label>("oneOne");
                        MyLabel.Text = userGuessHolder[guessCounter][0];
                      
                        if (userGuessHolder[guessCounter][0].Contains( randomLetter1) )
                        {
                            MyLabel.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;
                        }
                        else if(userGuessHolder[guessCounter][0].Contains(randomLetter2) || userGuessHolder[guessCounter][0].Contains( randomLetter3) || userGuessHolder[guessCounter][0].Contains(randomLetter4) || userGuessHolder[guessCounter][0].Contains( randomLetter5))
                        {
                            MyLabel.BackgroundColor = Color.Parse("Orange");


                        }

                        Label MyLabel1 = this.FindByName<Label>("oneTwo");
                        MyLabel1.Text = userGuessHolder[guessCounter][1];

                        if (userGuessHolder[guessCounter][1].Contains(randomLetter2))
                        {
                            MyLabel1.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][1].Contains( randomLetter1 )|| userGuessHolder[guessCounter][1].Contains( randomLetter3) || userGuessHolder[guessCounter][1].Contains(randomLetter4) || userGuessHolder[guessCounter][1].Contains(randomLetter5))
                        {
                            MyLabel1.BackgroundColor = Color.Parse("Orange");

                        }
                        Label MyLabel2 = this.FindByName<Label>("oneThree");
                        MyLabel2.Text = userGuessHolder[guessCounter][2];

                        if (userGuessHolder[guessCounter][2].Contains(randomLetter3))
                        {
                            MyLabel2.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][2].Contains(randomLetter1) || userGuessHolder[guessCounter][2].Contains(randomLetter2) || userGuessHolder[guessCounter][2].Contains(randomLetter4) || userGuessHolder[guessCounter][2].Contains(randomLetter5))
                        {
                            MyLabel2.BackgroundColor = Color.Parse("Orange");

                        }

                        Label MyLabel3 = this.FindByName<Label>("oneFour");
                        MyLabel3.Text = userGuessHolder[guessCounter][3];

                        if (userGuessHolder[guessCounter][3].Contains(randomLetter4))
                        {
                            MyLabel3.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][3].Contains(randomLetter1) || userGuessHolder[guessCounter][3].Contains(randomLetter2) || userGuessHolder[guessCounter][3].Contains(randomLetter3) || userGuessHolder[guessCounter][3].Contains(randomLetter5))
                        {
                            MyLabel3.BackgroundColor = Color.Parse("Orange");

                        }
                        Label MyLabel4 = this.FindByName<Label>("oneFive");
                        MyLabel4.Text = userGuessHolder[guessCounter][4];

                        if (userGuessHolder[guessCounter][4].Contains(randomLetter5))
                        {
                            howManyGreen++;
                            MyLabel4.BackgroundColor = Color.Parse("Green");
                        }
                        else if (userGuessHolder[guessCounter][4].Contains(randomLetter1) || userGuessHolder[guessCounter][4].Contains(randomLetter2) || userGuessHolder[guessCounter][4].Contains(randomLetter3) || userGuessHolder[guessCounter][4].Contains(randomLetter4))
                        {
                            MyLabel4.BackgroundColor = Color.Parse("Orange");

                        }
                        resetUserGuess();
                    guessCounter++;
                    break;


                    case 1:

                    Label MyLabel6 = this.FindByName<Label>("twoOne");
                    MyLabel6.Text = userGuessHolder[guessCounter][0];

                        if (userGuessHolder[guessCounter][0].Contains(randomLetter1))
                        {
                            MyLabel6.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][0].Contains(randomLetter2) || userGuessHolder[guessCounter][0].Contains(randomLetter3) || userGuessHolder[guessCounter][0].Contains(randomLetter4) || userGuessHolder[guessCounter][0].Contains(randomLetter5))
                        {
                            MyLabel6.BackgroundColor = Color.Parse("Orange");
                        }


                    Label MyLabel7 = this.FindByName<Label>("twoTwo");
                    MyLabel7.Text = userGuessHolder[guessCounter][1];

                        if (userGuessHolder[guessCounter][1].Contains(randomLetter2))
                        {
                            MyLabel7.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][1].Contains(randomLetter1) || userGuessHolder[guessCounter][1].Contains(randomLetter3) || userGuessHolder[guessCounter][1].Contains(randomLetter4) || userGuessHolder[guessCounter][1].Contains(randomLetter5))
                        {
                            MyLabel7.BackgroundColor = Color.Parse("Orange");

                        }

                        Label MyLabel8 = this.FindByName<Label>("twoThree");
                        MyLabel8.Text = userGuessHolder[guessCounter][2];

                        if (userGuessHolder[guessCounter][2].Contains(randomLetter3))
                        {
                            MyLabel8.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][2].Contains(randomLetter1) || userGuessHolder[guessCounter][2].Contains(randomLetter2) || userGuessHolder[guessCounter][2].Contains(randomLetter4) || userGuessHolder[guessCounter][2].Contains(randomLetter5))
                        {
                            MyLabel8.BackgroundColor = Color.Parse("Orange");

                        }

                    Label MyLabel9 = this.FindByName<Label>("twoFour");
                    MyLabel9.Text = userGuessHolder[guessCounter][3];

                        if (userGuessHolder[guessCounter][3].Contains(randomLetter4))
                        {
                            MyLabel9.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][3].Contains(randomLetter1) || userGuessHolder[guessCounter][3].Contains(randomLetter2) || userGuessHolder[guessCounter][3].Contains(randomLetter3) || userGuessHolder[guessCounter][3].Contains(randomLetter5))
                        {
                            MyLabel9.BackgroundColor = Color.Parse("Orange");

                        }

                        Label MyLabel10 = this.FindByName<Label>("twoFive");
                        MyLabel10.Text = userGuessHolder[guessCounter][4];
                        if (userGuessHolder[guessCounter][4].Contains(randomLetter5))
                        {

                            MyLabel10.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][4].Contains(randomLetter1) || userGuessHolder[guessCounter][4].Contains(randomLetter2) || userGuessHolder[guessCounter][4].Contains(randomLetter3) || userGuessHolder[guessCounter][4].Contains(randomLetter4))
                        {
                            MyLabel10.BackgroundColor = Color.Parse("Orange");

                        }
                        resetUserGuess();
                        checkIfWinner(howManyGreen);
                        guessCounter++;

                    break;

                case 2:

                    Label MyLabel11 = this.FindByName<Label>("threeOne");
                    MyLabel11.Text = userGuessHolder[guessCounter][0];

                        if (userGuessHolder[guessCounter][0].Contains(randomLetter1))
                        {
                            MyLabel11.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][0].Contains(randomLetter2) || userGuessHolder[guessCounter][0].Contains(randomLetter3) || userGuessHolder[guessCounter][0].Contains(randomLetter4) || userGuessHolder[guessCounter][0].Contains(randomLetter5))
                        {
                            MyLabel11.BackgroundColor = Color.Parse("Orange");
                        }

                    Label MyLabel12 = this.FindByName<Label>("threeTwo");
                    MyLabel12.Text = userGuessHolder[guessCounter][1];

                        if (userGuessHolder[guessCounter][1].Contains(randomLetter2))
                        {
                            MyLabel12.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][1].Contains(randomLetter1) || userGuessHolder[guessCounter][1].Contains(randomLetter3) || userGuessHolder[guessCounter][1].Contains(randomLetter4) || userGuessHolder[guessCounter][1].Contains(randomLetter5))
                        {
                            MyLabel12.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel13 = this.FindByName<Label>("threeThree");
                    MyLabel13.Text = userGuessHolder[guessCounter][2];
                        if (userGuessHolder[guessCounter][2].Contains(randomLetter3))
                        {
                            MyLabel13.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][2].Contains(randomLetter1) || userGuessHolder[guessCounter][2].Contains(randomLetter2) || userGuessHolder[guessCounter][2].Contains(randomLetter4) || userGuessHolder[guessCounter][2].Contains(randomLetter5))
                        {
                            MyLabel13.BackgroundColor = Color.Parse("Orange");

                        }

                    Label MyLabel14 = this.FindByName<Label>("threeFour");
                    MyLabel14.Text = userGuessHolder[guessCounter][3];

                        if (userGuessHolder[guessCounter][3].Contains(randomLetter4))
                        {
                            MyLabel14.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][3].Contains(randomLetter1) || userGuessHolder[guessCounter][3].Contains(randomLetter2) || userGuessHolder[guessCounter][3].Contains(randomLetter3) || userGuessHolder[guessCounter][3].Contains(randomLetter5))
                        {
                            MyLabel14.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel15 = this.FindByName<Label>("threeFive");
                    MyLabel15.Text = userGuessHolder[guessCounter][4];
                        if (userGuessHolder[guessCounter][4].Contains(randomLetter5))
                        {
                            howManyGreen++;
                            MyLabel15.BackgroundColor = Color.Parse("Green");
                        }
                        else if (userGuessHolder[guessCounter][4].Contains(randomLetter1) || userGuessHolder[guessCounter][4].Contains(randomLetter2) || userGuessHolder[guessCounter][4].Contains(randomLetter3) || userGuessHolder[guessCounter][4].Contains(randomLetter4))
                        {
                            MyLabel15.BackgroundColor = Color.Parse("Orange");

                        }
                        resetUserGuess();
                        checkIfWinner(howManyGreen);
                        guessCounter++;
                    break;

                case 3:
                    Label MyLabel16 = this.FindByName<Label>("fourOne");
                    MyLabel16.Text = userGuessHolder[guessCounter][0];

                        if (userGuessHolder[guessCounter][0].Contains(randomLetter1))
                        {
                            MyLabel16.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][0].Contains(randomLetter2) || userGuessHolder[guessCounter][0].Contains(randomLetter3) || userGuessHolder[guessCounter][0].Contains(randomLetter4) || userGuessHolder[guessCounter][0].Contains(randomLetter5))
                        {
                            MyLabel16.BackgroundColor = Color.Parse("Orange");
                        }

                    Label MyLabel17 = this.FindByName<Label>("fourTwo");
                    MyLabel17.Text = userGuessHolder[guessCounter][1];

                        if (userGuessHolder[guessCounter][1].Contains(randomLetter2))
                        {
                            MyLabel17.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][1].Contains(randomLetter1) || userGuessHolder[guessCounter][1].Contains(randomLetter3) || userGuessHolder[guessCounter][1].Contains(randomLetter4) || userGuessHolder[guessCounter][1].Contains(randomLetter5))
                        {
                            MyLabel17.BackgroundColor = Color.Parse("Orange");

                        }

                    Label MyLabel18 = this.FindByName<Label>("fourThree");
                    MyLabel18.Text = userGuessHolder[guessCounter][2];
                        if (userGuessHolder[guessCounter][2].Contains(randomLetter3))
                        {
                            MyLabel18.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][2].Contains(randomLetter1) || userGuessHolder[guessCounter][2].Contains(randomLetter2) || userGuessHolder[guessCounter][2].Contains(randomLetter4) || userGuessHolder[guessCounter][2].Contains(randomLetter5))
                        {
                            MyLabel18.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel19 = this.FindByName<Label>("fourFour");
                    MyLabel19.Text = userGuessHolder[guessCounter][3];
                        if (userGuessHolder[guessCounter][3].Contains(randomLetter4))
                        {
                            MyLabel19.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][3].Contains(randomLetter1) || userGuessHolder[guessCounter][3].Contains(randomLetter2) || userGuessHolder[guessCounter][3].Contains(randomLetter3) || userGuessHolder[guessCounter][3].Contains(randomLetter5))
                        {
                            MyLabel19.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel20 = this.FindByName<Label>("fourFive");
                    MyLabel20.Text = userGuessHolder[guessCounter][4];
                        if (userGuessHolder[guessCounter][4].Contains(randomLetter5))
                        {
                            MyLabel20.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][4].Contains(randomLetter1) || userGuessHolder[guessCounter][4].Contains(randomLetter2) || userGuessHolder[guessCounter][4].Contains(randomLetter3) || userGuessHolder[guessCounter][4].Contains(randomLetter4))
                        {
                            MyLabel20.BackgroundColor = Color.Parse("Orange");

                        }
                        resetUserGuess();
                        checkIfWinner(howManyGreen);
                        guessCounter++;
                    break;

                case 4:
                    Label MyLabel21 = this.FindByName<Label>("fiveOne");
                    MyLabel21.Text = userGuessHolder[guessCounter][0];

                        if (userGuessHolder[guessCounter][0].Contains(randomLetter1))
                        {
                            MyLabel21.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][0].Contains(randomLetter2) || userGuessHolder[guessCounter][0].Contains(randomLetter3) || userGuessHolder[guessCounter][0].Contains(randomLetter4) || userGuessHolder[guessCounter][0].Contains(randomLetter5))
                        {
                            MyLabel21.BackgroundColor = Color.Parse("Orange");
                        }
                    Label MyLabel22 = this.FindByName<Label>("fiveTwo");
                    MyLabel22.Text = userGuessHolder[guessCounter][1];

                        if (userGuessHolder[guessCounter][1].Contains(randomLetter2))
                        {
                            MyLabel22.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][1].Contains(randomLetter1) || userGuessHolder[guessCounter][1].Contains(randomLetter3) || userGuessHolder[guessCounter][1].Contains(randomLetter4) || userGuessHolder[guessCounter][1].Contains(randomLetter5))
                        {
                            MyLabel22.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel23 = this.FindByName<Label>("fiveThree");
                    MyLabel23.Text = userGuessHolder[guessCounter][2];
                        if (userGuessHolder[guessCounter][2].Contains(randomLetter3))
                        {
                            MyLabel23.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][2].Contains(randomLetter1) || userGuessHolder[guessCounter][2].Contains(randomLetter2) || userGuessHolder[guessCounter][2].Contains(randomLetter4) || userGuessHolder[guessCounter][2].Contains(randomLetter5))
                        {
                            MyLabel23.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel24 = this.FindByName<Label>("fiveFour");
                    MyLabel24.Text = userGuessHolder[guessCounter][3];
                        if (userGuessHolder[guessCounter][3].Contains(randomLetter4))
                        {
                            MyLabel24.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][3].Contains(randomLetter1) || userGuessHolder[guessCounter][3].Contains(randomLetter2) || userGuessHolder[guessCounter][3].Contains(randomLetter3) || userGuessHolder[guessCounter][3].Contains(randomLetter5))
                        {
                            MyLabel24.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel25 = this.FindByName<Label>("fiveFive");
                    MyLabel25.Text = userGuessHolder[guessCounter][4];
                        if (userGuessHolder[guessCounter][4].Contains(randomLetter5))
                        {

                            MyLabel25.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][4].Contains(randomLetter1) || userGuessHolder[guessCounter][4].Contains(randomLetter2) || userGuessHolder[guessCounter][4].Contains(randomLetter3) || userGuessHolder[guessCounter][4].Contains(randomLetter4))
                        {
                            MyLabel25.BackgroundColor = Color.Parse("Orange");

                        }
                        resetUserGuess();
                        guessCounter++;
                        checkIfWinner(howManyGreen);
                        
                    break;

                case 5:
                    Label MyLabel26 = this.FindByName<Label>("sixOne");
                    MyLabel26.Text = userGuessHolder[guessCounter][0];

                        if (userGuessHolder[guessCounter][0].Contains(randomLetter1))
                        {
                            MyLabel26.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][0].Contains(randomLetter2) || userGuessHolder[guessCounter][0].Contains(randomLetter3) || userGuessHolder[guessCounter][0].Contains(randomLetter4) || userGuessHolder[guessCounter][0].Contains(randomLetter5))
                        {
                            MyLabel26.BackgroundColor = Color.Parse("Orange");
                        }
                    Label MyLabel27 = this.FindByName<Label>("sixTwo");
                    MyLabel27.Text = userGuessHolder[guessCounter][1];
                        if (userGuessHolder[guessCounter][1].Contains(randomLetter2))
                        {
                            MyLabel27.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][1].Contains(randomLetter1) || userGuessHolder[guessCounter][1].Contains(randomLetter3) || userGuessHolder[guessCounter][1].Contains(randomLetter4) || userGuessHolder[guessCounter][1].Contains(randomLetter5))
                        {
                            MyLabel27.BackgroundColor = Color.Parse("Orange");
                          

                        }
                        Label MyLabel28 = this.FindByName<Label>("sixThree");
                    MyLabel28.Text = userGuessHolder[guessCounter][2];
                        if (userGuessHolder[guessCounter][2].Contains(randomLetter3))
                        {
                            MyLabel28.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][2].Contains(randomLetter1) || userGuessHolder[guessCounter][2].Contains(randomLetter2) || userGuessHolder[guessCounter][2].Contains(randomLetter4) || userGuessHolder[guessCounter][2].Contains(randomLetter5))
                        {
                            MyLabel28.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel29 = this.FindByName<Label>("sixFour");
                    MyLabel29.Text = userGuessHolder[guessCounter][3];
                        if (userGuessHolder[guessCounter][3].Contains(randomLetter4))
                        {
                            MyLabel29.BackgroundColor = Color.Parse("Green");
                            howManyGreen++;

                        }
                        else if (userGuessHolder[guessCounter][3].Contains(randomLetter1) || userGuessHolder[guessCounter][3].Contains(randomLetter2) || userGuessHolder[guessCounter][3].Contains(randomLetter3) || userGuessHolder[guessCounter][3].Contains(randomLetter5))
                        {
                            MyLabel29.BackgroundColor = Color.Parse("Orange");

                        }
                    Label MyLabel30 = this.FindByName<Label>("sixFive");
                    MyLabel30.Text = userGuessHolder[guessCounter][4];
                        if (userGuessHolder[guessCounter][4].Contains(randomLetter5))
                        {
                            howManyGreen++;
                            MyLabel30.BackgroundColor = Color.Parse("Green");
                        }
                        else if (userGuessHolder[guessCounter][4].Contains(randomLetter1) || userGuessHolder[guessCounter][4].Contains(randomLetter2) || userGuessHolder[guessCounter][4].Contains(randomLetter3) || userGuessHolder[guessCounter][4].Contains(randomLetter4))
                        {
                            MyLabel30.BackgroundColor = Color.Parse("Orange");

                        }
                        resetUserGuess();
                        checkIfWinner(howManyGreen);
                    break;

                }
            }
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            //if less than 5 characters are picked allow user to continue 
            int newCounter = onKeyTappedCounter - 1;

            switch (newCounter)
            {
                case 0:
                    Label MyLabel = this.FindByName<Label>("userGuessLetter1");
                    MyLabel.Text = "";
                    userGuessHolder[guessCounter][onKeyTappedCounter] = "";

                    onKeyTappedRemoved();
                    break;

                case 1:
                    Label MyLabel2 = this.FindByName<Label>("userGuessLetter2");
                    MyLabel2.Text = "";
                    userGuessHolder[guessCounter][onKeyTappedCounter] = "";
                    onKeyTappedRemoved();
                    break;

                case 2:
                    Label MyLabel3 = this.FindByName<Label>("userGuessLetter3");
                    MyLabel3.Text = "";
                    userGuessHolder[guessCounter][onKeyTappedCounter] = "";
                    onKeyTappedRemoved();
                    break;

                case 3:
                    Label MyLabel4 = this.FindByName<Label>("userGuessLetter4");
                    MyLabel4.Text = "";
                    userGuessHolder[guessCounter][onKeyTappedCounter] = "";
                    onKeyTappedRemoved();

                    break;

                case 4:
                    Label MyLabel5 = this.FindByName<Label>("userGuessLetter5");
                    MyLabel5.Text = "";
                    userGuessHolder[guessCounter][newCounter] = "";
                    onKeyTappedRemoved();
                    break;
            }

        }

        //return user to settings
        void settingsPage(object sender, EventArgs e)
        {
            SettingPage settingPage = new SettingPage();

            Navigation.PushAsync(settingPage);
        }

        //reset guess options
        void resetUserGuess()
        {
            Label MyLabel = this.FindByName<Label>("userGuessLetter1");
            MyLabel.Text = "";

            Label MyLabel2 = this.FindByName<Label>("userGuessLetter2");
            MyLabel2.Text = "";

            Label MyLabel3 = this.FindByName<Label>("userGuessLetter3");
            MyLabel3.Text = "";

            Label MyLabel4 = this.FindByName<Label>("userGuessLetter4");
            MyLabel4.Text = "";

            Label MyLabel5 = this.FindByName<Label>("userGuessLetter5");
            MyLabel5.Text = "";

            onKeyTappedCounter = 0;

        }


        void homeButtonClicked(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            Navigation.PushAsync(homePage);
        }

        void checkIfWinner(int howManyGreen)
        {
            if(howManyGreen == 5) {

                HomePage homePage = new HomePage();
                Navigation.PushAsync(homePage);

                DisplayAlert("Congrats", "Congratulations You Win !! \n You guessed the word in "+guessCounter+" attempts", "ok");

            }
            else if(guessCounter == 6)
            {
                displayGameOver();
            }
        }

        void displayGameOver() {

            DisplayAlert("Unlucky", "Game Over you ran out of attempts! \n Returning to home", "ok");

        }
    }
} 

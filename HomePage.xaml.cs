namespace Wordle2024;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void NewGame_Button_Clicked(object sender, EventArgs e)
    {
        GamePlay gamePlay = new GamePlay(); 

        Navigation.PushAsync(gamePlay);
    }

    private void SaveGame_Button_Clicked(object sender, EventArgs e)
    {
        GamePlay gamePlay = new GamePlay();

        Navigation.PushAsync(gamePlay);
    }

    private void Settings_Button_Clicked(object sender, EventArgs e)
    {
        SettingPage settingPage = new SettingPage();

        Navigation.PushAsync(settingPage);
    }

    private void History_Button_Clicked(object sender, EventArgs e)
    {

        HistoryPage historyPage = new HistoryPage();
        Navigation.PushAsync(historyPage);
    }
}
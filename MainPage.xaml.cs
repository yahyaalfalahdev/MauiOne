using Plugin.Firebase.CloudMessaging;
using System.Diagnostics;

namespace MauiOne;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();

        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();

        await Shell.Current.DisplayAlert("FCM token", token, "OK");

        Debug.WriteLine($"FCM token: {token}");

        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);

        //var push
    }
}


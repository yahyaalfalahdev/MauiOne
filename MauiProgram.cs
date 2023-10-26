using Microsoft.Maui.LifecycleEvents;

namespace MauiOne;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.ConfigureLifecycleEvents(events => 
		{
			events.AddAndroid(android => android.OnCreate((activity, bundle) =>
			{
				Firebase.FirebaseApp.InitializeApp(activity);
			}));
		});

		return builder.Build();
	}
}

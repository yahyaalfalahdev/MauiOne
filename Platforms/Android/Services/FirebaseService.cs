using Android.App;
using AndroidX.Core.App;
using Firebase.Messaging;
using MauiOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService()
        {
        }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            if (Preferences.ContainsKey("DeviceToken"))
            {
                Preferences.Remove("DeviceToken");
            }
            Preferences.Set("DeviceToken", token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var notification = message.GetNotification();

            SendNotification(notification.Body, notification.Title, message.Data);
        }

        private void SendNotification(string msgBody, string title, IDictionary<string, string> data) 
        {
            var notificationbuilder = new NotificationCompat.Builder(this, MainActivity.Channel_ID)
                .SetContentTitle(title)
                .SetSmallIcon(MauiOne.Resource.Mipmap.appicon)
                .SetContentTitle(msgBody)
                .SetChannelId(MainActivity.Channel_ID)
                .SetPriority(2);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.Notification_ID, notificationbuilder.Build());
                
        }
    }
}

## Boer
- A signalR notification app in Xamarin. See BoerCom, BoerStuur, BoerOntvang
- FCM push notifications - [FireBase](https://console.firebase.google.com) 

## BoerCom
SignalR server - console app

## BoerStuur
Purpose - send signalr message via server on start - xamarin android app

## BoerOntvang
Purpose - receive message from from BoerStuur and display messages on start - xamarin android app

## BoerNotify
Push notification in Xamarin Android - using FireBase

Note: A keystore is used to sign the application, for deployment on the Google Play Store. Many Google Play Services require a SHA-1 entered into the Google Console for your App package

On Windows, Xamarin Archives put the keystore in C:\Users\<username>\AppData\Local\Xamarin\Mono for Android\Keystore you can find the one you just created in a subfolder maching the name of the keystore you just created.

To get the SHA-1 from a keystore you run the keytool command line tool. If it isn't in your environment PATH, it is located in the Java SDK folder. In my case C:\Program Files\Java\jdk1.8.0_102\bin lets just assume you don't have it in your environment PATH the command to get the SHA-1 would look something like

Add the directory containing keytool.exe to the PATH environment variable. Open a Command Prompt and run keytool.exe using the following command:

```
keytool.exe -list -v -keystore "%LocalAppData%\Xamarin\Mono for Android\debug.keystore" -alias androiddebugkey -storepass android -keypass android
```

## BoerMap
Just a small xamarin forms map application to. Want to grow this into also allow navigation. (Very basic code right now)

[resource](https://developer.xamarin.com/guides/xamarin-forms/user-interface/map/)

### Notification resources

[Remote Notifications with Firebase Cloud Messaging](https://developer.xamarin.com/guides/android/application_fundamentals/notifications/firebase-cloud-messaging/)

[Firebase Cloud Messaging](https://developer.xamarin.com/guides/android/application_fundamentals/notifications/remote-notifications-with-fcm/)

[more](http://blog.ostebaronen.dk/2016/11/firebase-cloud-messaging-in.html)




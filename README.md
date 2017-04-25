## Boer
- A signalR notification app in Xamarin. See BoerCom, BoerStuur, BoerOntvang
- (Also want to do some things with push notifications)

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
 
### Notification resources

see [here](https://developer.xamarin.com/guides/android/application_fundamentals/notifications/firebase-cloud-messaging/)
[here](https://developer.xamarin.com/guides/android/application_fundamentals/notifications/remote-notifications-with-fcm/)



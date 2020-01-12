using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using AndroidClient.Activities;

namespace AndroidClient
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login);

            EditText loginText = FindViewById<EditText>(Resource.Id.LoginText);
            Button loginButton = FindViewById<Button>(Resource.Id.LoginButton);

            loginText.TextChanged += (sender, e) =>
            {
                loginButton.Enabled = !string.IsNullOrWhiteSpace(loginText.Text) && !string.IsNullOrEmpty(loginText.Text);
            };
            loginButton.Click += LoginButton_Click;
        }
        
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(LobbyActivity));
        }
    }
}
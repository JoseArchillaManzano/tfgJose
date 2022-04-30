using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tfgJose.WebReference;

namespace tfgJose.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        TextInputEditText etUserName;
        EditText etPassword;
        Button bForgotPassword;
        Button bSignIn;
        Button bSignUp;
        WS_Breathing ws;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.login);
            // Create your application here
            etUserName = FindViewById<TextInputEditText>(Resource.Id.et_username);
            etPassword = FindViewById<EditText>(Resource.Id.et_password);
            bForgotPassword = FindViewById<Button>(Resource.Id.button_forgot_password);
            bSignIn = FindViewById<Button>(Resource.Id.button_signin);
            bSignUp = FindViewById<Button>(Resource.Id.button_signup);
            ws = new WS_Breathing();

            bSignIn.Click += signIn; 
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void signIn (object sender, EventArgs eventArgs)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
            if (ws.EstaRegistrado(etUserName.Text, etPassword.Text))
            {
                Toast failSignIn = Toast.MakeText(this, "texto prueba bien", ToastLength.Short);
                failSignIn.Show();
            }
            else
            {
                Toast failSignIn = Toast.MakeText(this,"texto prueba",ToastLength.Short);
                failSignIn.Show();
            }
        }
    }
}
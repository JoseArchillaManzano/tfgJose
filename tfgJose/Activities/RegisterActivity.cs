﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tfgJose.WebReference;
using System.Text.RegularExpressions;
using Android.Views.InputMethods;

namespace tfgJose.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        TextInputEditText etEmail;
        TextInputEditText etUserName;
        EditText etPassword;
        EditText etConfirmPassword;
        Button bSignUp;
        WS_Breathing ws;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.register);

            etUserName = FindViewById<TextInputEditText>(Resource.Id.et_username);
            etPassword = FindViewById<EditText>(Resource.Id.et_password);
            etConfirmPassword = FindViewById<EditText>(Resource.Id.et_confirm_password);
            etEmail = FindViewById<TextInputEditText>(Resource.Id.et_email);
            bSignUp = FindViewById<Button>(Resource.Id.button_signin);
            ws = new WS_Breathing();

            bSignUp.Click += register;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void register(object sender, EventArgs eventArgs)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }

            var textEmail = etEmail.Text;
            var textUser = etUserName.Text;
            var textPassword = etPassword.Text;
            var textConfirm = etConfirmPassword.Text;
            String message = "";
            bool fail = false;
            if(textEmail == "" || textUser == "" || textPassword == "" || textConfirm == "")
            {
                message = "Faltan campos por rellenar";
                fail = true;
            }
            else if (!textPassword.Equals(textConfirm))
            {
                message = "Las contraseñas no coinciden entre si";
                fail = true;
            }
            else if (!validEmail(textEmail))
            {
                message = "El email introducido no es valido";
                fail = true;
            }
            if(!fail)
            {
                bool result = ws.Registrar(textUser, textPassword, "usuario", textEmail);
                if (result)
                {
                    Intent intent = new Intent(this, typeof(RegisterActivity)); //:TODO TE TENDRÍA QUE LLEVAR AL CUESTIONARIO, MODIFICAR
                    StartActivity(intent);
                }
                else
                {

                }
                
            }
            
                Toast toast = Toast.MakeText(this, message, ToastLength.Short);
                toast.Show();
            
        }

        private Boolean validEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

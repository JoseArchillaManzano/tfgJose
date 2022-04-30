using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tfgJose.Models
{
    public class Question
    {
        String Title { get; set; }

        List<String> Options { get; set; }

        bool NoAnswer { get; set; }

        private void addOption(String option)
        {
            this.Options.Add(option);
        }

        public Question(String title, List<String> options, bool noAnswer)
        {
            this.Title = title;
            this.Options = new List<string>(options);
            this.NoAnswer = noAnswer;
        }
    }
}
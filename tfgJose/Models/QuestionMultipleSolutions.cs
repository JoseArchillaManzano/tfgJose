﻿using Android.App;
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
    class QuestionMultipleSolutions : Question
    {
        List<Boolean> Answers { get; set; }

        private void AddAnswer(int position, bool answer)
        {
            this.Answers[position] = answer;
        }

        public QuestionMultipleSolutions(String title, List<String> options, bool noAnswer) : base(title, options, noAnswer) { }
    }
}
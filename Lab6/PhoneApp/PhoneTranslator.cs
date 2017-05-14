using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneApp
{
    public class PhoneTranslator
    {
        private string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
         private string Numbers = "2223334445556667777888999";

        public string ToNumber(string alfanumericNumber)
        {
            var NumericPhoneNumber = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(alfanumericNumber))
            {
                alfanumericNumber = alfanumericNumber.ToUpper();

                foreach (var c in alfanumericNumber)
                {
                    if ("0123456789".Contains(c))
                    {
                        NumericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var index = Letters.IndexOf(c);
                        if (index > 0)
                        {
                            NumericPhoneNumber.Append(Numbers[index]);
                        }
                    }
                }
            }

            return NumericPhoneNumber.ToString();
        }
    }
}
﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TataApp.Models;
using TataApp.Views;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginFacebookPage), typeof(TataApp.Droid.LoginPageRenderer))]
namespace TataApp.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer()
        {
            var activity = this.Context as Android.App.Activity;

            var auth = new OAuth2Authenticator(
                clientId: "833841243449087",
                scope: "",
                authorizeUrl: new Uri("https://www.facebook.com/v2.8/dialog/oauth"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var profile = await GetFacebookProfileAsync(accessToken);
                    App.NavigateToProfile(profile);
                }
                else
                {
                    App.HideLoginView();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }

        private async Task<FacebookResponse> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl = "https://graph.facebook.com/v2.8/me/?fields=name,picture.width(999),cover,age_range,devices,email,gender,is_verified,birthday,languages,work,website,religion,location,locale,link,first_name,last_name,hometown&access_token=" + accessToken;
            var httpClient = new HttpClient();
            var userJson = await httpClient.GetStringAsync(requestUrl);
            var facebookResponse = JsonConvert.DeserializeObject<FacebookResponse>(userJson);
            return facebookResponse;
        }
    }
}
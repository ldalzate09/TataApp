﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TataApp.Models;
using TataApp.Views;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginFacebookPage), typeof(TataApp.iOS.LoginPageRenderer))]
namespace TataApp.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        bool done = false;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (done)
            {
                return;
            }

            var auth = new OAuth2Authenticator(
                clientId: "833841243449087",
                scope: "",
                authorizeUrl: new Uri("https://www.facebook.com/v2.8/dialog/oauth"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                DismissViewController(true, null);
                App.HideLoginView();

                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var profile = await GetFacebookProfileAsync(accessToken);
                    await App.NavigateToProfile(profile);
                }
                else
                {
                    await App.NavigateToProfile(null);
                }
            };

            done = true;
            PresentViewController(auth.GetUI(), true, null);
        }

        private async Task<FacebookResponse> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl = "https://graph.facebook.com/v2.7/me/?fields=name,picture,cover,age_range,devices,email,gender,is_verified,birthday,languages,work,website,religion,location,locale,link,first_name,last_name,hometown&access_token=" + accessToken;
            var httpClient = new HttpClient();
            var userJson = await httpClient.GetStringAsync(requestUrl);
            var facebookResponse = JsonConvert.DeserializeObject<FacebookResponse>(userJson);
            return facebookResponse;
        }
    }
}
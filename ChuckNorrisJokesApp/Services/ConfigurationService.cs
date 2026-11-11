using ChuckNorrisJokesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChuckNorrisJokesApp.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string ChuckNorrisApiUrl { get; }
        public string DadJokesApiUrl { get; }

        public ConfigurationService ()
        {
            ChuckNorrisApiUrl = "https://api.chucknorris.io/jokes/random";
            DadJokesApiUrl = "https://icanhazdadjoke.com/";
        }
    }
}

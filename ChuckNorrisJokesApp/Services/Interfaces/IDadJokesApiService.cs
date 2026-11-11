using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorrisJokesApp.Services.Interfaces
{
    public interface IDadJokesApiService
    {
        Task<string> GetDadJokeAsync();
    }
}

using ChuckNorrisJokesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChuckNorrisJokesApp.ViewModels
{
    public class JokesViewModel : BaseViewModel
    {
        public ICommand GetJokeCommand { get; set; }

        private string _chuckNorrisJoke;


        public string ChuckNorrisJoke
        {
            get { return _chuckNorrisJoke; }
            set { _chuckNorrisJoke = value;
                OnPropertyChanged();
            }
        }

        private string _dadJoke;

        public string DadJoke
        {
            get { return _dadJoke; }
            set { _dadJoke = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotLoading));
            }
        }

        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }


        private IChuckNorrisApiService _chuckNorrisApiService;

        private IDadJokesApiService _dadJokesApiService;
        private IPopUps _popupService;

        public JokesViewModel(IChuckNorrisApiService service, IPopUps popups, IDadJokesApiService dadJokesService)
        {
            _chuckNorrisApiService = service;
            _popupService = popups;
            _dadJokesApiService = dadJokesService;

            GetJokeCommand = new Command(FetchJoke);
        }

        private async void FetchJoke(object param)
        {

            if (IsLoading)
            {
                return;
            }

            IsLoading = true;

            await Task.Delay(3000);

            try
            {
                try
                {
                    string chuckJoke =
                        await _chuckNorrisApiService.GetJokeAsync();

                    if (string.IsNullOrWhiteSpace(chuckJoke))
                    {
                        throw new Exception("No Chuck Norris joke received.");
                    }

                    ChuckNorrisJoke = chuckJoke;
                }
                catch (Exception ex)
                {
                    await _popupService.ShowPopupAsync(
                        "Chuck Norris Error",
                        ex.Message,
                        "OK");
                }

                try
                {
                    string dadJoke =
                        await _dadJokesApiService.GetDadJokeAsync();

                    if (string.IsNullOrWhiteSpace(dadJoke))
                    {
                        throw new Exception("No Dad Joke received.");
                    }

                    DadJoke = dadJoke;
                }
                catch (Exception ex)
                {
                    await _popupService.ShowPopupAsync(
                        "Dad Joke Error",
                        ex.Message,
                        "OK");
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

# Joke App – .NET MAUI MVVM Application

## 1. Project Overview

Joke Duo is a simple .NET MAUI application developed using the Model-View-ViewModel (MVVM) architecture.

The application fetches and displays two types of jokes from external HTTP APIs:

- Chuck Norris jokes
- Dad jokes

Users can click the **Get Jokes** button to retrieve new jokes from both APIs.

The application also includes a loading indicator, button disabling during requests, and error handling.

## 2. APIs Used

### Chuck Norris API

**URL:** https://api.chucknorris.io/jokes/random

This API returns a random Chuck Norris joke in JSON format.

The application uses the `value` field from the JSON response to display the joke.

Example response:

```json
{
  "value": "Chuck Norris can divide by zero."
}
```

### Dad Joke API

**URL:** https://icanhazdadjoke.com/

This API returns a random dad joke.

The application sends an HTTP request containing the following header:

```text
Accept: application/json
```

This tells the API to return JSON instead of HTML.

The application uses the `joke` field from the JSON response.

Example response:

```json
{
  "id": "example",
  "joke": "Why don't skeletons fight each other? They don't have the guts.",
  "status": 200
}
```

## 3. MVVM Architecture

The application follows the MVVM design pattern, separating the user interface from application logic and API communication.

### Models

The models represent the JSON data received from the APIs.

- `ChuckNorrisJoke.cs` contains the joke information returned by the Chuck Norris API.
- `DadJoke.cs` contains the joke information returned by the Dad Joke API.

### View

`JokesView.xaml` defines the application's user interface.

It contains labels for displaying both jokes, a button for fetching new jokes, and a loading indicator.

Data binding connects the View to the ViewModel.

### ViewModel

`JokesViewModel.cs` manages the application logic.

Its responsibilities include:

- Storing the Chuck Norris joke and Dad Joke.
- Handling the Get Jokes button command.
- Managing the loading state.
- Preventing repeated requests while loading.
- Handling errors and updating the View.

### Services

The services handle HTTP communication with the APIs.

- `ChuckNorrisApiHttpService.cs` requests Chuck Norris jokes.
- `DadJokesApiHttpService.cs` requests dad jokes.
- `ConfigurationService.cs` provides the API URLs.

The services retrieve and deserialize JSON responses before returning the joke text to the ViewModel.

## 4. Loading and Error Handling

The application uses an `IsLoading` property to indicate when API requests are in progress.

While loading:

- An ActivityIndicator is displayed.
- A loading message appears.
- The Get Jokes button is disabled.

Once the requests finish, the loading indicator disappears and the button becomes available again.

If an API request fails, the application displays an error message. Each API request is handled separately so that a successful joke can remain visible even if the other API fails.

## 5. How to Build and Run

### Requirements

- Visual Studio with .NET MAUI development tools installed.
- .NET 10 SDK and Android workload.
- Android emulator or physical Android device.
- Internet connection for fetching jokes.

### Instructions

1. Clone or download the GitHub repository.
2. Open the solution in Visual Studio.
3. Restore the required NuGet packages.
4. Select an Android emulator or connected Android device.
5. Build and run the application.
6. Click **Get Jokes** to fetch jokes from both APIs.

## 6. Testing and Verification

The following scenarios should be tested before submission:

| Test | Expected Result |
|---|---|
| Fetch jokes with internet access | Both jokes appear on the screen. |
| Fetch jokes repeatedly | New jokes are requested. |
| Loading state | Loading indicator appears and button is disabled. |
| Network unavailable | An error message appears. |
| Chuck Norris API fails | Dad Joke API can still return a joke. |
| Dad Joke API fails | Successful Chuck Norris joke remains visible. |
| Requests complete | Loading indicator disappears and button is enabled. |

## 7. Conclusion

Joke Duo demonstrates how to build a simple .NET MAUI application using the MVVM architecture and external HTTP APIs.

The project demonstrates HTTP requests, JSON deserialization, data binding, commands, loading states, and basic error handling while keeping the application organised into separate Models, Views, ViewModels, and Services.

using UnityEngine;
using UnityEngine.UI;

using static BuildConfig;

public class LoginButton : MonoBehaviour
{

    void Start()
    {
        Button loginButton = GetComponent<Button>();
    }

    public void handleClick()
    {
      StartAuthentication();
    }

    private void StartAuthentication()
    {
        // Open a web browser or embedded web view to initiate the authentication process
        // Redirect the user to Spotify's authorization endpoint with the necessary parameters
        // Construct the authorization URL with client ID, redirect URI, scope, response type, etc.
        // Open the URL in a web view or browser
       string authorizationUrl = "https://accounts.spotify.com/authorize";
       string clientId = BuildConfig.SPOTIFY_CLIENT_ID;
       string redirectUri = BuildConfig.SPOTIFY_REDIRECT_URI;
       string scope = "user-library-read user-read-private playlist-read-private";  // Specify the desired scope(s) for your application

       // Construct the authorization URL with the necessary parameters
       string url = $"{authorizationUrl}?client_id={clientId}&redirect_uri={redirectUri}&scope={scope}&response_type=code";

       Debug.Log(url);
       // Open the URL in a web browser
       Application.OpenURL(url);

    }

}

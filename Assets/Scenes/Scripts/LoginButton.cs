using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static BuildConfig;

public class LoginButton : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string ExtractAccessCode();

    private bool receivedAuthorizationCode = false;
    private string authorizationCode = "";

    [SerializeField] private TokenRequest tokenRequest;

    [SerializeField] private TMP_Text tmpText;

    private void Start()
    {
        Button loginButton = GetComponent<Button>();
    }

    private void Update()
    {
      authorizationCode = ExtractAccessCode();
      Debug.Log("The access code is " + ExtractAccessCode());
      tmpText.text = authorizationCode;
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

       // Extract the authorization code from the redirected URL
       // authorizationCode = ExtractAuthorizationCode(Application.absoluteURL);
       // receivedAuthorizationCode = true;

       // get token
       // tokenRequest.RequestAccessToken(authorizationCode);
    }

/*
    private string ExtractAuthorizationCode(string url)
    {
        // Parse the URL to extract the authorization code
        // You can use string manipulation or regular expressions to extract the code

        // Example code using simple string manipulation:
        const string codePrefix = "?code=";
        int codeStartIndex = url.IndexOf(codePrefix);
        if (codeStartIndex >= 0)
        {
            codeStartIndex += codePrefix.Length;
            int codeEndIndex = url.IndexOf('&', codeStartIndex);
            if (codeEndIndex >= 0)
            {
                return url.Substring(codeStartIndex, codeEndIndex - codeStartIndex);
            }
            else
            {
                return url.Substring(codeStartIndex);
            }
        }

        return null;
    }
    */


}

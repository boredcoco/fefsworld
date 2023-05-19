using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using static BuildConfig;

public class TokenRequest : MonoBehaviour
{
    private const string TokenEndpoint = "https://accounts.spotify.com/api/token";
    private const string ClientId = BuildConfig.SPOTIFY_CLIENT_ID;
    private const string ClientSecret = BuildConfig.SPOTIFY_CLIENT_SECRET;
    private const string RedirectUri = BuildConfig.SPOTIFY_REDIRECT_URI;

    public void RequestAccessToken(string authorizationCode)
    {
        string grantType = "authorization_code";
        string requestBody = $"grant_type={grantType}&code={authorizationCode}&redirect_uri={RedirectUri}";

        string authString = $"{ClientId}:{ClientSecret}";
        string encodedAuthString = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authString));
        string authorizationHeader = $"Basic {encodedAuthString}";

        UnityWebRequest request = UnityWebRequest.Post(TokenEndpoint, requestBody);
        request.SetRequestHeader("Authorization", authorizationHeader);
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        StartCoroutine(SendTokenRequest(request));
    }

    private IEnumerator SendTokenRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseJson = request.downloadHandler.text;
            // Parse the response JSON to retrieve the access token
            // and any other relevant information you may need
        }
        else
        {
            Debug.LogError($"Token request failed: {request.error}");
        }
    }
}

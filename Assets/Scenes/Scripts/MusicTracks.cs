using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MusicTracks : MonoBehaviour
{
  private const string BASE_URL = "https://api.spotify.com/v1";
  private const string ACCESS_TOKEN = "BQAZhq...x0fUbA";

    // Spotify track ID for demonstration purposes
    private const string TRACK_ID = "6y0igZArWVi6Iz0rj35c1Y";

    private void Start()
    {
        StartCoroutine(GetTrackInfo());
    }

    private IEnumerator GetTrackInfo()
    {
        string endpoint = $"{BASE_URL}/tracks/{TRACK_ID}";
        UnityWebRequest request = UnityWebRequest.Get(endpoint);

        request.SetRequestHeader("Authorization", $"Bearer {ACCESS_TOKEN}");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error: {request.error}");
            yield break;
        }

        // Process the response
        string responseText = request.downloadHandler.text;
        Debug.Log(responseText);
    }

}

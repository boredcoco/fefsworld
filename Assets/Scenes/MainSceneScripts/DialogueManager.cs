using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplayed;
    [SerializeField] private GameObject panel;

    public void updateMessage(string message)
    {
        textDisplayed.text = message;
    }

    private void Update()
    {
      if (textDisplayed.text == "")
      {
        panel.SetActive(false);
      }
    }
}

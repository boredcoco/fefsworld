using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsButtonScript : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplayed;

    private Func<bool> yesFunction;
    private Func<bool> noFunction;

    public void updateTextDisplayed(string message)
    {
      textDisplayed.text = message;
    }

    public void updateFuncs(Func<bool> yesFunc, Func<bool> noFunc)
    {
      yesFunction = yesFunc;
      noFunction = noFunc;
    }

    public void yesSelected()
    {
      yesFunction();
      gameObject.SetActive(false);
    }

    public void noSelected()
    {
      noFunction();
      gameObject.SetActive(false);
    }
}

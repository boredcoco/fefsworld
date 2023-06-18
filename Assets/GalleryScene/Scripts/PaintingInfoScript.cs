using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaintingInfoScript : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    [SerializeField] private TMP_Text currentTitle;
    [SerializeField] private TMP_Text currentDate;
    [SerializeField] private TMP_Text currentDescription;
    [SerializeField] private Image currentImage;

    public void updateInfo(string nextTitle, string nextDate, string nextDescription, string pathToImage)
    {
        currentTitle.text = nextTitle;
        currentDate.text = nextDate;
        currentDescription.text = nextDescription;
        currentImage.sprite = Resources.Load<Sprite>(pathToImage);

        popUp.SetActive(true);
    }

    public void closePopUp()
    {
      popUp.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    [SerializeField] private string paintingName = "";
    [SerializeField] private string date = "";
    [SerializeField] private string description = "";
    [SerializeField] private string spritePath = "";

    private PaintingInfoScript paintingInfo;

    private void Start()
    {
      paintingInfo = GameObject.Find("DialogueManager").GetComponent<PaintingInfoScript>();
    }

    private void OnMouseDown()
    {
        paintingInfo.updateInfo(paintingName, date, description, spritePath);
    }

    private void Update()
    {

    }
}

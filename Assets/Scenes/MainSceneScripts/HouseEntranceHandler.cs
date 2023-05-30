using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEntranceHandler : MonoBehaviour
{
    [SerializeField] private string houseName = "";
    [SerializeField] private string sceneToLoad = "";

    [SerializeField] private OptionsButtonScript dialogueOptions;
    [SerializeField] private GameObject panel;
    private DialogueManager dialogueManager;

    private void Start()
    {
        GameObject gameObjectDm = GameObject.FindWithTag("DialogueManager");
        dialogueManager = gameObjectDm.GetComponent<DialogueManager>();
    }

    private void OnTriggerStay(Collider collider)
    {
      if (collider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
      {
        openDialogue();
      }
    }

    private bool openDialogue()
    {
      panel.SetActive(true);
      dialogueManager.updateMessage(houseName);
      Invoke("showOptionsButton", 1f);
      return true;
    }

    private void showOptionsButton()
    {
      dialogueOptions.gameObject.SetActive(true);
      dialogueOptions.updateTextDisplayed("Enter?");
      dialogueOptions.updateFuncs(
        () => {
          SceneManager.LoadScene(sceneToLoad);
          return true;
        },
        () => {
          dialogueManager.updateMessage("");
          return true;
        }
      );
    }

}

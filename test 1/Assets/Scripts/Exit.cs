using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public GameObject ExitMenu;
    public Button Button;

    public void OnExit(){
        ExitMenu.SetActive(true);
        Button.enabled = false;
        Button.image.color = Color.gray;

    }

    public void OnYesExit(){
        Application.Quit();
    }

    public void OnNoExit(){
        ExitMenu.SetActive(false);
        Button.enabled = true;
        Button.image.color = Color.red;
    }
}

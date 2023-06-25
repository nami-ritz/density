using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeList : MonoBehaviour{
    public GameObject Panel;
    public List<GameObject> Cubes = new List<GameObject>();
    
    public void onTogglePanel(){
        bool isActive = Panel.activeSelf;
        Panel.SetActive(!isActive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject winText; //The variable is private, but shows up in the inspector window in Unity - refernce to WinText

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false); //Set to an active state and becomes invisible
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if locked variables of the animals scripts are set to true - when they are all true the win condition is met, and the winText gameobject is set to active state to show the win text
        if (Koala.locked && Hund.locked && Bi.locked && Ule.locked && Fox.locked)
            winText.SetActive(true);
    }
}

//Code from Youtube, Alexander Zotov: https://www.youtube.com/watch?v=7HEjCEncezs and https://www.youtube.com/watch?v=p7akGCRgBLA

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPosition : MonoBehaviour
{
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject moveOnButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Piece1Behavior.locked && Piece2Behavior.locked && Piece3Behavior.locked && Piece4Behavior.locked)
        {
            winText.SetActive(true);
            moveOnButton.SetActive(true);
        }
    }

    public void SpawnMoveOnButton()
    {
        moveOnButton.SetActive(true);
    }
    
    //Code from Youtube, Alexander Zotov: https://www.youtube.com/watch?v=7HEjCEncezs and https://www.youtube.com/watch?v=p7akGCRgBLA
}

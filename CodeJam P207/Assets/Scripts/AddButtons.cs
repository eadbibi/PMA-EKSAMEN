using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    //a reference to the transform component representing the parent of the puzzle buttons
    private Transform puzzleField;

    [SerializeField]
    //a reference to the gameobject of a single puzzle button
    private GameObject btn;

    //awake is called when the script instance is being loaded
    private void Awake()
    {
        //creating 8 puzzle buttons
            for(int i = 0; i < 8; i++)
        {
            //instatiating a new puzzle button
            GameObject button = Instantiate(btn);
            //setting the name of the puzzle button to its index
            button.name = "" + i;
            //setting the parent of the puzzle button to the puzzle field transform and using its position, this is used because of the grid component.
            button.transform.SetParent(puzzleField, false);
        }
    }
}

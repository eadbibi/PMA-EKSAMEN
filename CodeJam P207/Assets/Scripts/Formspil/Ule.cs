using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ule : MonoBehaviour
{
    [SerializeField] private Transform ulePlace; //The variable is private, but shows up in the inspector window in Unity - a reference to the ulePlace gameobject

    private Vector2 initialPosition; //This variable do, that if the ule isn't drooped at the right place, it will return to it's initial position

    private Vector2 mousePosition;

    private float deltaX, deltaY; //These two variables calculate and offsets between the center of the hund gameobeject and touch position

    public static bool locked; //A boolean which comes true when the ule is dropped at the correct place (gameobject)

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; //Here the ule's initial position is marked
    }

    // Update is called once per frame
    void Update()
    {
        //The if statement says: If the input touch count is greater than 0 and if the ule is not locked already, then we initialize and design touch variable that will hold the infomation about this particular touch event.
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(2);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            //This switch statement goes through some possible touch phases
            switch (touch.phase)
            {
                //If current touch phases equals to Began then we check if the ule gameobject box collider or the posistion of our touch actually touched the ule, then we calculate an offset between touch and position and the center of the ule gameobject 
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                //if touch equals to moved, then we set the ule gameobject position to be equal to current touch position depending on that offset
                //if touch equals to the finger being released, then we check where it happens - if it happens at the moment when the center of the ule gameobject is located near enough within 0.5 units from the center of the ulePlace position, then we set the ule position to equal to the ulePlace position.
                // And locked is set to true, for not to be able to move the ule because we found the correct place it
                case TouchPhase.Moved:
                    if (Mathf.Abs(transform.position.x - ulePlace.position.x) <= 0.5f && Mathf.Abs(transform.position.y - ulePlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(ulePlace.position.x, ulePlace.position.y);
                        locked = true;
                    }

                    // else: if the center of the ule is not located within 0.5 units of the area, then it goes back to its initial position
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }

    }

    private void OnMouseDown()
    //When the left mouse button is pressed over a collider (one of the animals) and it isn't locked, then we calulated an offset with current mouse position and the center of the animal gameobject
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    //OnMouseDrag is envoked when left mouse button is being held down over an collider (one of the animals) and the mouse is moved.
    //When this happens and the animal isn't locked, then we get current mouse position and pass those on to animal gameobject according to the offset that was caluleted in the OnMouseDown method 
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    //OnMouseUp is envoked when left mouse button is released
    //If the left mouse button is released when the animal is close enough to its correct place, then it will be locked
    {
        if (Mathf.Abs(transform.position.x - ulePlace.position.x) <= 0.5f && Mathf.Abs(transform.position.y - ulePlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(ulePlace.position.x, ulePlace.position.y);
            locked = true;
        }

        //If the left mouse button is released when the animal isn't close enough to its correct place to be dropped, then the animal gameobject retrun to its initial position
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}


//Code from Youtube, Alexander Zotov: https://www.youtube.com/watch?v=7HEjCEncezs and https://www.youtube.com/watch?v=p7akGCRgBLA

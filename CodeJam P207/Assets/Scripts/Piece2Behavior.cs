using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece2Behavior : MonoBehaviour
{[SerializeField] private Transform piece2Place;

    private Vector2 initialPosition;
    
    private Vector2 mousePosition;

    private float deltaX, deltaY;

    public static bool locked;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(2);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                
                
                case TouchPhase.Moved:
                    if (Mathf.Abs(transform.position.x - piece2Place.position.x) <= 0.5f && Mathf.Abs(transform.position.y - piece2Place.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(piece2Place.position.x, piece2Place.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
            
        }
    }
    
    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x-piece2Place.position.x) <=0.5f && Mathf.Abs(transform.position.y-piece2Place.position.y) <= 0.5f)
        {
            transform.position = new Vector2(piece2Place.position.x, piece2Place.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
    
    //Code from Youtube, Alexander Zotov: https://www.youtube.com/watch?v=7HEjCEncezs and https://www.youtube.com/watch?v=p7akGCRgBLA
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public GameObject board;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch);
            if (touch.phase == TouchPhase.Began)
                board.GetComponent<BoardScript>().setDirection(touch.position.x > Screen.width / 2 ? 1 : -1);
            else if (touch.phase == TouchPhase.Ended)
                board.GetComponent<BoardScript>().setDirection(0);
        }
    }
}

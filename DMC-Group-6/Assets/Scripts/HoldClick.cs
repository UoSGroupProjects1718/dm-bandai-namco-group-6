using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClick : MonoBehaviour
{
    private GameObject Gameman;
    private ObjectHold OBJhold;

    void Start ()
    {
        Gameman = GameObject.Find("Game_Manager");
        OBJhold = Gameman.GetComponent<ObjectHold>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (this.gameObject.tag == "Player1")
            {
                OBJhold.IncrementP1 = true;
            }
            else if (this.gameObject.tag == "Player2")
            {
                OBJhold.IncrementP2 = true;
            }
            else if (this.gameObject.tag == "Player3")
            {
                OBJhold.IncrementP3 = true;
            }
            else if (this.gameObject.tag == "Player4")
            {
                OBJhold.IncrementP4 = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            OBJhold.IncrementP1 = false;
            OBJhold.IncrementP2 = false;
            OBJhold.IncrementP3 = false;
            OBJhold.IncrementP4 = false;
            OBJhold.Coroutinerunning = false;

            Destroy(this.gameObject);
        }
    }
}

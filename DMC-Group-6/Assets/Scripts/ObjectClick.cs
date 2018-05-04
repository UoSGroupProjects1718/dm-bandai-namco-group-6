using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    //public GameObject Player;
    private GameMan Gamemanager;
    private GameObject Gameman;

	void Start ()
    {
        Gameman = GameObject.Find("Game_Manager");
        Gamemanager = Gameman.GetComponent<GameMan>();
	}

	void Awake ()
    {
        StartCoroutine(Death());
	}

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    void OnMouseOver ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (this.gameObject.tag == "Player1")
            {
                Destroy(this.gameObject);
                Gamemanager.Player1Score++;
            }
            else if (this.gameObject.tag == "Player2")
            {
                Destroy(this.gameObject);
                Gamemanager.Player2Score++;
            }
            else if (this.gameObject.tag == "Player3")
            {
                Destroy(this.gameObject);
                Gamemanager.Player3Score++;
            }
            else if (this.gameObject.tag == "Player4")
            {
                Destroy(this.gameObject);
                Gamemanager.Player4Score++;
            }
        }
    }
}

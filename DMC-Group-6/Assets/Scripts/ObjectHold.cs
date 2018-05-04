using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    private int Selector;

    private int Identifier;

    public bool Canspawn = false;

    public bool IncrementP1 = false;
    public bool IncrementP2 = false;
    public bool IncrementP3 = false;
    public bool IncrementP4 = false;

    public bool Coroutinerunning = false;

    private GameObject Gameman;
    private GameMan Gamemanager;
    private HoldClick Clickreference;

    void Start ()
    {
        Selector = Random.Range(0, 3);

        Gamemanager = this.gameObject.GetComponent<GameMan>();
	}
	
	void Update ()
    {
		if (Canspawn)
        {
            SpawnHoldOBJ();
        }

        if (IncrementP1 && !Coroutinerunning)
        {
            StartCoroutine(ScoreIncrease(Gamemanager.Player1Score, IncrementP1));
            Identifier = 1;
            Coroutinerunning = true;
        }
        else if (IncrementP2 && !Coroutinerunning)
        {
            StartCoroutine(ScoreIncrease(Gamemanager.Player2Score, IncrementP2));
            Identifier = 2;
            Coroutinerunning = true;
        }
        else if (IncrementP3 && !Coroutinerunning)
        {
            StartCoroutine(ScoreIncrease(Gamemanager.Player3Score, IncrementP3));
            Identifier = 3;
            Coroutinerunning = true;
        }
        else if (IncrementP4 && !Coroutinerunning)
        {
            StartCoroutine(ScoreIncrease(Gamemanager.Player4Score, IncrementP4));
            Identifier = 4;
            Coroutinerunning = true;
        }

    }

    IEnumerator ScoreIncrease(int Score, bool Player)
    {
        while(Player)
        {
            Score ++;
            yield return new WaitForSeconds(1);

            switch(Identifier)
            {
                case 1:
                    Gamemanager.Player1Score = Score;
                    break;
                case 2:
                    Gamemanager.Player2Score = Score;
                    break;
                case 3:
                    Gamemanager.Player3Score = Score;
                    break;
                case 4:
                    Gamemanager.Player4Score = Score;
                    break;
            }       
        }
    }

    void SpawnHoldOBJ()
    {
        Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

        switch (Selector)
        {
            case 0:
                Instantiate(Player1, ScreenPosition, Quaternion.identity);
                Canspawn = false;
                StartCoroutine(HoldWait());
                break;
            case 1:
                Instantiate(Player2, ScreenPosition, Quaternion.identity);
                Canspawn = false;
                StartCoroutine(HoldWait());
                break;
            case 2:
                Instantiate(Player3, ScreenPosition, Quaternion.identity);
                Canspawn = false;
                StartCoroutine(HoldWait());
                break;
            case 3:
                Instantiate(Player4, ScreenPosition, Quaternion.identity);
                StartCoroutine(HoldWait());
                break;
        }
    }

    IEnumerator HoldWait()
    {
        Canspawn = false;
        yield return new WaitForSeconds(8);
        Selector = Random.Range(0, 3);
        Canspawn = true;
    }
}

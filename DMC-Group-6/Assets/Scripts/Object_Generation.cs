using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Generation : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    private bool StartSpawning = false;
    private bool CanSpawnNew = false;

    public Text StartCountdown;
    private float SCdown = 2.0f;

    private ObjectHold OBJhold;

    void Start ()
    {
        OBJhold = this.gameObject.GetComponent<ObjectHold>();
    }

	void Update ()
    {
		if (!StartSpawning)
        {
            SCdown -= Time.deltaTime;
            StartCountdown.text = "" + Mathf.Round(SCdown);

            if (SCdown <= 0)
            {
                StartSpawning = true;
                StartCountdown.enabled = false;
                CanSpawnNew = true;
                OBJhold.Canspawn = true;
            }
        }

        if (CanSpawnNew)
        {
            SpawnPlayersObj();
        }
	}

    void SpawnPlayersObj()
    {
        StartCoroutine(DownTime());

        Vector3 ScreenPosition1 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Vector3 ScreenPosition2 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Vector3 ScreenPosition3 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Vector3 ScreenPosition4 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

        Instantiate(Player1, ScreenPosition1, Quaternion.identity);
        Instantiate(Player2, ScreenPosition2, Quaternion.identity);
        Instantiate(Player3, ScreenPosition3, Quaternion.identity);
        Instantiate(Player4, ScreenPosition4, Quaternion.identity);

        CanSpawnNew = false;
    }

    IEnumerator DownTime()
    {
        yield return new WaitForSeconds(2);

        CanSpawnNew = true;
    }
}

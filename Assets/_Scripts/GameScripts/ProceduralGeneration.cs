using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject prefab;  // set in the Inspector

    private GameObject player;
    private float prefabHalfHeight;
    private List<GameObject> streets = new List<GameObject>();  // list to store the generated prefabs

    void Start()
    {
        player = GameObject.Find("Player");
        prefabHalfHeight = prefab.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        GenerateInitialStreets();
    }

    void Update()
    {

    }

    private void GenerateInitialStreets()
    {
        GameObject center = Instantiate(prefab, new Vector2(0, 0), Quaternion.identity);
        GameObject above = Instantiate(prefab, new Vector2(0, 7.29f), Quaternion.identity);
        GameObject below = Instantiate(prefab, new Vector2(0, -7.29f), Quaternion.identity);
        streets.Add(above);
        streets.Add(center);
        streets.Add(below);
    } 

    private void ProcedurallyGenerateStreets()
    {
        if(Player.Instance.transform.position.y > streets[1].transform.position.y + prefabHalfHeight)
        {
            streets[2].transform.position = new Vector2(0, streets[0].transform.position.y + 7.29f); 
            GameObject temp = streets[0];
            streets.RemoveAt(0);
            streets.Add(temp);

        }
        else if(Player.Instance.transform.position.y < streets[2].transform.position.y - prefabHalfHeight)
        {
            streets[2].transform.position = new Vector2(0, streets[0].transform.position.y - prefabHalfHeight * 2);
            streets.Insert(0, streets[2]);
            streets.RemoveAt(3);
        }
    }
}
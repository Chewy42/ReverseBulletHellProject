/* ¸ */using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject Street;
    public GameObject Environment;

    private List<GameObject> Streets = new List<GameObject>();
 
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        //Create 3 initial streets. The first spawns with the player in the center, the second is above and the third is below and make thier parent Environment
        GameObject center_street = Instantiate(Street, Vector2.zero, Quaternion.identity);
        center_street.name = "Street1";
        center_street.transform.parent = Environment.transform;
        center_street.transform.localScale = new Vector2(2, 2);
        //make street below the starting street
        GameObject street_above = Instantiate(Street, (Vector2)center_street.transform.position + new Vector2(0, 7.28f), Quaternion.Euler(0, 0, 0));
        street_above.name = "Street2";
        street_above.transform.parent = Environment.transform;
        street_above.transform.localScale = new Vector2(2, 2);
        //make street below the starting street
        GameObject street_below = Instantiate(Street, (Vector2)center_street.transform.position - new Vector2(0, 7.28f), Quaternion.Euler(0, 0, 0));
        street_below.name = "Street3";
        street_below.transform.parent = Environment.transform;
        street_below.transform.localScale = new Vector2(2, 2);
        Streets.Add(center_street);
        Streets.Add(street_above);
        Streets.Add(street_below);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerAboveStreet())
        {
            print("above street");
            Streets[0].transform.position = (Vector2)Streets[0].transform.position + new Vector2(0, 7.28f);
            Streets[1].transform.position = (Vector2)Streets[1].transform.position + new Vector2(0, 7.28f);
            Streets[2].transform.position = (Vector2)Streets[2].transform.position + new Vector2(0, 7.28f);
        }else if(IsPlayerBelowStreet())
        {
            print("below street");
            Streets[0].transform.position = (Vector2)Streets[0].transform.position - new Vector2(0, 7.28f);
            Streets[1].transform.position = (Vector2)Streets[1].transform.position - new Vector2(0, 7.28f);
            Streets[2].transform.position = (Vector2)Streets[2].transform.position - new Vector2(0, 7.28f);
        }


    }

    //is player above the center street
    private bool IsPlayerAboveStreet()
    {
        return false;
        // if(Player.Instance.GetParent().transform.position == Streets[0].transform.position + new Vector3(0, 7.28f, 0))
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
    }

    private bool IsPlayerBelowStreet()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.position == Streets[0].transform.position - new Vector3(0, 7.28f, 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


//dont code past this
}

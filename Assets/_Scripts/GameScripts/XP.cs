using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    //Initialize XP amount in sub classes
    protected int xpAmount;

    public int GetXP(){
        return xpAmount;
    }
}

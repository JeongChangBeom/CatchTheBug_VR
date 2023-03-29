using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timeUp : MonoBehaviour, IItem
{
    public void Use()
    {
        GameManager.instance.setTime += 10;
    }
}

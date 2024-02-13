using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour, IITem
{
    public static event Action<int> OnBreadCollect;
    public int worth = 10;

    public void Collect()
    {
        OnBreadCollect(worth); // Other scripts can subscribe to this call
        Destroy(gameObject);
    }

}

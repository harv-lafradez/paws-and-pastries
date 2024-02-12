using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour, IITem
{
    public static event Action<int> OnBreadCollect;
    public int worth = 20;

    public void Collect()
    {
        OnBreadCollect(worth); // Other scripts can subscribe to this call
        Destroy(gameObject);
    }

}

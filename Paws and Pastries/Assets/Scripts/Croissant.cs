using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour, IITem
{
    public static event Action<int> OnCroissantCollect;
    public int worth = 20;

    public void Collect()
    {
        // Let PlayerMovement script know
        OnCroissantCollect(worth);
        Destroy(gameObject);
    }
}

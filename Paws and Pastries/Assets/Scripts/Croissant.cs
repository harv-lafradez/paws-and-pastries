using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour, IITem
{
    public static event Action<bool> OnCroissantCollected;

    public void Collect()
    {
        // Let PlayerMovement script know
        OnCroissantCollected.Invoke(true);
        Destroy(gameObject);
    }
}

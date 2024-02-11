using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour, IITem
{
    public void Collect()
    {
        Destroy(gameObject);
    }

}

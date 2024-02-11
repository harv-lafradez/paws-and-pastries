using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IITem item = collision.GetComponent<IITem>();
        if (item != null)
        {
            item.Collect();
        }
    }
}

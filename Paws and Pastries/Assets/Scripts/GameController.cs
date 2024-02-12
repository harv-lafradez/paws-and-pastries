using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider; 

    // Start is called before the first frame update
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Bread.OnBreadCollect += IncreaseProgressAmount; // Assigning the method reference to the event to call it whenever it is raised
    }

    void IncreaseProgressAmount(int amount)
    {
        // Debug.Log("Amount passed in:" + amount);
        progressAmount += amount;
        progressSlider.value = progressAmount;
        // Debug.Log("Progress amount:" + progressAmount);

        if (progressAmount >= 100)
        {
            // Level is complete
            Debug.Log("Level Complete");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

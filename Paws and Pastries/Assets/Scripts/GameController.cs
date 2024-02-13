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

    public GameObject player;
    public GameObject LoadCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Bread.OnBreadCollect += IncreaseProgressAmount; // Assigning the method reference to the event to call it whenever it is raised
        Croissant.OnCroissantCollect += IncreaseProgressAmount; 

        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;
        LoadCanvas.SetActive(false);
    }

    void IncreaseProgressAmount(int amount)
    {
        // Debug.Log("Amount passed in:" + amount);
        progressAmount += amount;
        // Debug.Log("Progress amount:" + progressAmount);
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            // Level is complete
            LoadCanvas.SetActive(true);
            Debug.Log("Level Complete");
        }
    }

    void LoadNextLevel()
    {
        int nextLevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex + 1;

        LoadCanvas.SetActive(false);

        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[nextLevelIndex].gameObject.SetActive(true);

        player.transform.position = new Vector3(-0.54f, -2f, 0);
        currentLevelIndex = nextLevelIndex;
        progressAmount = 0;
        progressSlider.value = 0;
    }
}

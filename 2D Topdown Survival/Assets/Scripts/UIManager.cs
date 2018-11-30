using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    InventoryManager IM;

    public Text foodCounter;
    public Text stoneCounter;
    public Text treeCounter;

    public GameObject pauseMenu;

    public Slider healthBar;
    public Slider energyBar;

    public bool isPaused;

	void Start ()
    {
        isPaused = false;
        IM = FindObjectOfType<InventoryManager>();
        healthBar.value = 1;
        energyBar.value = 10;
    }
	

	void Update ()
    {
        foodCounter.text = "" + IM.foodCount;
        stoneCounter.text =  "" + IM.stoneCount;
        treeCounter.text = "" + IM.treeCount;

        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
            Debug.Log("Paused");
        }
        /*if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            Debug.Log("Unpaused");
        }*/
	}

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void exitApplication()
    {
            Application.Quit();
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(1);
    }

}

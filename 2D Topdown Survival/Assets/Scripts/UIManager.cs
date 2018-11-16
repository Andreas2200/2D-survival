using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    InventoryManager IM;

    public Text stoneCounter;
    public Text treeCounter;

	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>();
	}
	

	void Update ()
    {
        stoneCounter.text = "Stones: " + IM.stoneCount;
        treeCounter.text = "Trees: " + IM.treeCount;
	}
}

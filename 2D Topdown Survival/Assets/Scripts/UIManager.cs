using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    InventoryManager IM;

    public Text foodCounter;
    public Text stoneCounter;
    public Text treeCounter;

	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>();
	}
	

	void Update ()
    {
        foodCounter.text = "" + IM.foodCount;
        stoneCounter.text =  "" + IM.stoneCount;
        treeCounter.text = "" + IM.treeCount;
	}
}

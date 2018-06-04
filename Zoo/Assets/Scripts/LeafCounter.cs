using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafCounter : MonoBehaviour
{
    public int leafCount;
    AudioSource[] Audio;
    Text text;

    void Start()
    {
        EventHandler.GameOver += resetLeaf;
        EventHandler.LeafObjectPickedUp += increaseLeafCount;
        leafCount = 0;
        text = this.GetComponent<Text>();
        updateLeafText();
        Audio = GetComponents<AudioSource>();
        
    }

    public void decreaseLeafCount()
    {
        leafCount--;
        Audio[0].Play();
        updateLeafText();
        
    }

    public void increaseLeafCount()
    {
        leafCount++;
        Audio[1].Play();
        updateLeafText();
    }

    public void updateLeafText()
    {
        text.text = "x" + leafCount;
    }

    private void resetLeaf()
    {
        this.leafCount = 0;
        updateLeafText();
    }
}

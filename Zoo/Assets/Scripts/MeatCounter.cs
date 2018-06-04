using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatCounter : MonoBehaviour
{
    public int meatCount;
    Text text;
    AudioSource[] Audio;

    void Start()
    {
        EventHandler.GameOver += resetMeat;
        EventHandler.MeatObjectPickedUp += increaseMeat;
        meatCount = 0;
        text = this.GetComponent<Text>();
        updateMeatText();
        Audio = GetComponents<AudioSource>();
    }

    public void decreaseMeat()
    {
        meatCount--;
        updateMeatText();
        Audio[0].Play();
    }

    public void increaseMeat()
    {
        meatCount++;
        Audio[1].Play();
        updateMeatText();
    }

    public void updateMeatText()
    {
        text.text = "x" + meatCount;
    }

    private void resetMeat()
    {
        this.meatCount = 0;
        updateMeatText();
    }

}

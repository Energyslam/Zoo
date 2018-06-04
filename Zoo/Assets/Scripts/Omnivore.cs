using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Omnivore : Animal
{


    public Omnivore(string helloText, string meatText, string leafText, bool doesTrick)
    {
        this.helloText = helloText;
        this.meatText = meatText;
        this.leafText = leafText;
        this.doesTrick = doesTrick;
    }

    public override void Start()
    {
        base.Start();
        EventHandler.MeatButtonPressed += EatMeat;
        EventHandler.LeafButtonPressed += EatLeaves;
        spawner.carnivores++;
        spawner.herbivores++;
    }



}

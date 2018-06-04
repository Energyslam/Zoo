using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zoo;

public class Carnivore : Animal
{

    public Carnivore(string helloText, string meatText, bool doesTrick)
    {
        this.helloText = helloText;
        this.meatText = meatText;
        this.doesTrick = doesTrick;
    }

    public override void Start()
    {
        base.Start();
        spawner.carnivores++;
        EventHandler.MeatButtonPressed += EatMeat;
    }
}

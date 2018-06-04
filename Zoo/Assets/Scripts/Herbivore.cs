using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zoo;

public class Herbivore : Animal
{

    public Herbivore(string helloText, string leafText, bool doesTrick)
    {
        this.helloText = helloText;
        this.leafText = leafText;
        this.doesTrick = doesTrick;
    }

    public override void Start()
    {
        base.Start();
        spawner.herbivores++;
        EventHandler.LeafButtonPressed += EatLeaves;
    }
}

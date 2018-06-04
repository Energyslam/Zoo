//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zoo;
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject lion, hippo, pig, tiger, zebra, dog, panda, eventHandler;
    [SerializeField]
    private Text meatText, leafText;
    public GameObject meat;
    public GameObject leaf;
    public GameObject gameOver;
    public GameObject retryButton;
    public int carnivores;
    public int herbivores;
    public int animals;
    public int gameScore;
    public GameObject objectCollector;
    public GameObject animalCollector;
    public Text score;

    public void Start()
    {
        Screen.SetResolution(600, 550, false);
        EventHandler.ResetGame += hideGameOver;
        EventHandler.GameOver += GameOver;
        gameScore = 0;

        Lion henk = Instantiate(lion, animalCollector.transform).GetComponent<Lion>();
        henk.name = "henk";
        Hippo elsa = Instantiate(hippo, animalCollector.transform).GetComponent<Hippo>();
        elsa.name = "elsa";
        Pig dora = Instantiate(pig, animalCollector.transform).GetComponent<Pig>();
        dora.name = "dora";
        Tiger wally = Instantiate(tiger, animalCollector.transform).GetComponent<Tiger>();
        wally.name = "wally";
        Zebra marty = Instantiate(zebra, animalCollector.transform).GetComponent<Zebra>();
        marty.name = "marty";
        Zebra mario = Instantiate(zebra, animalCollector.transform).GetComponent<Zebra>();
        mario.name = "mario";
        Dog lena = Instantiate(dog, animalCollector.transform).GetComponent<Dog>();
        lena.name = "lena";
        Panda wilco = Instantiate(panda, animalCollector.transform).GetComponent<Panda>();
        wilco.name = "wilco";

        StartCoroutine(foodSpawner());
        StartCoroutine(giveScore());
    }

    IEnumerator foodSpawner()
    {
        yield return new WaitForSeconds(1.5f);
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            Instantiate(meat, objectCollector.transform).GetComponent<Meat>();
        }
        if (i == 1) { Instantiate(leaf, objectCollector.transform).GetComponent<Leaf>(); }
        StartCoroutine(foodSpawner());
    }

    IEnumerator giveScore()
    {       
        score.text = "Score: " + gameScore;
        yield return new WaitForSeconds(5f);
        gameScore += animals;
        StartCoroutine(giveScore());

    }

    public void hideGameOver()
    {
        gameOver.SetActive(false);
        retryButton.SetActive(false);
        StartCoroutine(foodSpawner());
        StartCoroutine(giveScore());

    }
    public void resetObjectCollector()
    {

        foreach (Leaf leaf in objectCollector.GetComponentsInChildren<Leaf>())
        {
            leaf.DestroyOnClick();
        }

        foreach (Meat meat in objectCollector.GetComponentsInChildren<Meat>())
        {
            meat.DestroyOnClick();
        }

        foreach (var animal in animalCollector.GetComponentsInChildren<Animal>())
        {
            animal.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        resetObjectCollector();
        gameOver.SetActive(true);
        retryButton.SetActive(true);
        StopAllCoroutines();
        gameScore = 0;
        animals = 0;
        score.text = "Score: " + gameScore;
    }


}




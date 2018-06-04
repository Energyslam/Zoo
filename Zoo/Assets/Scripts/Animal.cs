using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoo;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{

    [SerializeField]
    protected GameObject Balloon;
    [SerializeField]
    protected Text text;
    protected string helloText;
    public string name;
    protected bool doesTrick;
    protected InputField helloField;
    protected float currentHealth;
    protected float maxHealth;
    protected float healValue;
    protected float dangerHealth;
    public float minDamage;
    public float maxDamage;
    public float takeDamageTimer;
    public Text nameText;

    public int herbivores;
    public int carnivores;
    public int omnivores;
    protected Spawner spawner;
    public LeafCounter leafCounter;
    public MeatCounter meatCounter;

    protected string meatText;
    protected string leafText;

    public Slider healthSlider;


    public virtual void Start()
    {
        EventHandler.HelloButtonPressed += SayHello;
        EventHandler.TrickButtonPressed += PerformTrick;
        nameText.text = this.name;
        helloField = GameObject.Find("InputField").GetComponent<InputField>();
        spawner = GameObject.Find("GameCanvas").GetComponent<Spawner>();
        leafCounter = GameObject.Find("LeafText").GetComponent<LeafCounter>();
        meatCounter = GameObject.Find("MeatyText").GetComponent<MeatCounter>();

        spawner.animals++;
        maxHealth = 100f;
        dangerHealth = 10f;
        healValue = 10f;
        minDamage = 5f;
        maxDamage = 12f;
        takeDamageTimer = 10f;
        currentHealth = maxHealth;
        StartCoroutine(takeDamage());
        EventHandler.ResetGame += resetAnimal;
    }


    public void SayHello()
    {
        if (helloField.text == "" || helloField.text == name)
        {
            Balloon.SetActive(true);
            text.text = helloText;
        }
    }

    public void PerformTrick()
    {
        if (doesTrick)
        {
            StartCoroutine(DoTrick());
        }
    }

    IEnumerator DoTrick()
    {
        for (int i = 0; i < 360; i++)
        {
            transform.localRotation = Quaternion.Euler(i, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator takeDamage()
    {
        yield return new WaitForSeconds(takeDamageTimer);
        currentHealth -= Random.Range(minDamage, maxDamage);
        healthSlider.value = currentHealth / maxHealth;
        if (currentHealth < dangerHealth)
        {
            Balloon.SetActive(true);
            text.text = "I'm so hungry, please feed me";
        }

        if (currentHealth <= 0)
        {
            spawner.animals--;
            if (spawner.animals <= 0) GameOver();
            Debug.Log("Animals remaining: " + spawner.animals);
            this.gameObject.SetActive(false);
        }
        if (currentHealth > 0) StartCoroutine(takeDamage());
    }

    public void EatLeaves()
    {
        if (this.isActiveAndEnabled && leafCounter.leafCount - 1 >= 0 && currentHealth < maxHealth)
        {
            Balloon.SetActive(true);
            text.text = leafText;
            currentHealth += healValue;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            healthSlider.value = currentHealth / maxHealth;
            leafCounter.decreaseLeafCount();
        }
    }

    public void EatMeat()
    {
        if (this.isActiveAndEnabled && meatCounter.meatCount - 1 >= 0 && currentHealth < maxHealth)
        {
            Balloon.SetActive(true);
            text.text = meatText;
            currentHealth += healValue;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            healthSlider.value = currentHealth / maxHealth;
            meatCounter.decreaseMeat();
        }
    }

    public void GameOver()
    {
        meatCounter.meatCount = 0;
        meatCounter.updateMeatText();
        leafCounter.leafCount = 0;
        leafCounter.updateLeafText();
        StopAllCoroutines();
    }

    public void resetAnimal()
    {
        this.gameObject.SetActive(true);
        spawner.animals++;
        this.transform.position = new Vector3(300, 300, 0);
        StartCoroutine(takeDamage());
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        currentHealth = maxHealth;
        healthSlider.value = currentHealth / maxHealth;
        Balloon.SetActive(false);
    }

    public void SetHealth(int value) { this.currentHealth = value; }
}

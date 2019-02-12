using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour

{
    public Text main;

    int playerHealth = 0;
    int startingHealth = 10;
    int damage = -2;

    void doDamage()
    {
        playerHealth += damage;
    }

    void addHealth()
    {
        playerHealth -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = startingHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

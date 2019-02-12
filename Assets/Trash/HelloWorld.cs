using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelloWorld : MonoBehaviour
{
    public Text story;

    [Header("Testing stuff")]
    public string nameOne = "string";

    [Space]

    [Tooltip("This is where the number of days goes")]
    [Range(0, 365)]
    public int days;

    [Tooltip("Loop example")]
    public int loop = 10;
  

    [Space]
    [Tooltip("Health")]
    [Range(0, 10)]
    public float Health;

    [Space]
    [SerializeField]
    [Tooltip("The truthness")]
    private bool result = true;

    [Space]
    [Tooltip("Description")]
    [TextArea]
    public string stuff;

    [Space]
  
    public List<string> names = new List<string> { "vi", "Eli", "Hyunwoo", "Gio" };


    void printMe(int x)
    {
        print($"loop {x}"  );
    }

    string message(int x){
        if (x % 2 == 0)
        {
            return "The engine rumbles";
        }

        else
        {
            return "The crowd cheers!";
        }
    }

    void final(string x)
    {
        print(x);
    }

    void loopThis(int x)
    {
        printMe(x);
        final(message(x));
    }





    // Start is called before the first frame update
    void Start()
    { 
        string info = "Hello! My name is " + nameOne  + "";
        print(info);
        names.RemoveAt(0);
        names.Add("Millie");

        while (loop != 0)
        {
            loopThis(loop);
            loop--;
        }
        print("Lift off!");

        story.text = names[0];

    }

    // Update is called once per frame
    void Update()
    {
        bool life = true;

        if (life == false) print("You died!");

        if (Health == 0) life = (false);
        else if (Health <= 3) print("Low health");
        else print("Your fine!");

        
        
    }
}

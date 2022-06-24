using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int i = 1;
    public Light myLight;
    [SerializeField] private int a = 5;
    public int b = 6;
    public float d = 10.6f;
    public string c= "I love my game!";
    public bool e = true;

    // Start is called before the first frame update
    void Start()
    {
        var myVar = TestFunction(5,3);
        print(myVar);
        print("Hello, guys!");
    }

    int TestFunction(int var1, int var2)
    {
        //var f = b + d +a;
        //print(f);
        int var3 = var1 + var2;
        return var3;
    }

    // Runs 1rst of all
    private void Awake()
    {
        print("My game is awesome");
    }

    // Update is called once per frame
    //  depends on the time it takes to render the frame
    void Update()
    {
        print(i);
        i += 1;
    }

    // Update is called at a fixed rate
    void FixedUpdate() 
    {
        
    }
}

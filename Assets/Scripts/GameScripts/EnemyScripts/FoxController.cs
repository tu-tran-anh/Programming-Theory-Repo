using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : Animal
{
    private int hp = 2;
    private int speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        base.Start(hp,speed);
    }
    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
}

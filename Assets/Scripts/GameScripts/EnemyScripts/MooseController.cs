using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseController : Animal
{
    private int hp = 3;
    private int speed = 4;
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

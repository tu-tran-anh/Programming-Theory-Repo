using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] Animal animal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            
            Destroy(other.gameObject);
            animal.FeedAnimal();
            if(animal.currentHp >= animal.b_hp)
            {
                MenuManager.Instance.currentScore+= animal.b_hp;
                Destroy(gameObject);
            } 
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] Slider hungerSlider;
    public int b_hp = 1;
    public int currentHp = 0;
    public float b_speed = 9;
    public void MoveForward()
    {
        if (!MenuManager.Instance.gameOver)
        {
            transform.Translate(Vector3.forward * b_speed * Time.deltaTime);
        }
    }
    public void FeedAnimal()
    {
        currentHp ++;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentHp;
    }
    public void Start()
    {       
        setSlider();
    }
    public void Start(int hp, float speed)
    {
        b_hp = hp;
        b_speed = speed;
        setSlider();
    }
    void setSlider()
    {
        hungerSlider.maxValue = b_hp;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
    }
}

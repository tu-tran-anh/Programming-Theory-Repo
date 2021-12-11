using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            MenuManager.Instance.gameOver = true;
            playerAnimator.SetBool("Death_b", true);
        }
    }
}

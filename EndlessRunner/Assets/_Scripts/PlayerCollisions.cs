using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
            //connect this to Game Manager and trigger GameOver
        }
    }
}

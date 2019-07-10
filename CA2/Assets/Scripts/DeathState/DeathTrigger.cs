using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private Transform player, boundTopLeft, boundBottomRight;
    [SerializeField] DeathScreen screen;

    // Checks if dead
    private void Update()
    {
        if (CheckDead())
        {
            KillPlayer();
            this.enabled = false;
        }
    }

    // Disables player gameobject
    private void KillPlayer()
    {

        player.gameObject.SetActive(false);
        screen.Show();
        screen.SetScore((int)Time.realtimeSinceStartup);
    }

    // Checks if player falls out of camera
    private bool CheckDead()
    {
        if (player.position.y > boundTopLeft.position.y)
        {
            return true;
        }

        if (player.position.x < boundTopLeft.position.x)
        {
            return true;
        }

        if (player.position.y < boundBottomRight.position.y)
        {
            return true;
        }

        if (player.position.x > boundBottomRight.position.x)
        {
            return true;
        }

        return false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] DeathScreen screen;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // if collides with a player, disables the player gameobject and shows the
    // the death screen. Passes in the player's time alive to display as score
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerController>())
        {
            collision.collider.gameObject.SetActive(false);
            screen.Show();

            screen.SetScore((int)Time.realtimeSinceStartup);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.tag == "Player";

        if (isPlayer)
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.AddCoins();

            }

            Destroy(gameObject);
        }
    }
}

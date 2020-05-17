using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 1.5f;

    private string _movingTowards = "right";

    // Update is called once per frame
    void FixedUpdate()
    {
        bool atTargetA = transform.position == _targetA.position;
        bool atTargetB = transform.position == _targetB.position;

        if (atTargetA)
        {
            _movingTowards = "right";
        } else if (atTargetB)
        {
            _movingTowards = "left";
        }

        if (_movingTowards == "right")
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        } else if (_movingTowards == "left")
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.tag == "Player";

        if (isPlayer)
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.transform.parent = this.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool isPlayer = other.tag == "Player";

        if (isPlayer)
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.transform.parent = null;
            }
        }
    }
}

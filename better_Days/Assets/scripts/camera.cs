using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform player_one_transform;
    [SerializeField] private Transform player_two_transform;
    void Update()
    {
        transform.position = new Vector3((player_one_transform.position.x+player_two_transform.position.x)/2,transform.position.y, -10);
    }
}

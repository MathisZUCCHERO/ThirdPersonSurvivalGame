using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayerIcon : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -player.eulerAngles.y);
    }
}


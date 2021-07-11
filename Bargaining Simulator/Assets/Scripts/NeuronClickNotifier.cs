using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronClickNotifier : MonoBehaviour
{
    public PoolStick poolStick;
    
    private void OnMouseUp()
    {
        poolStick.ObjectClickNotification(GetComponent<Rigidbody2D>());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    List<Collider> collidersInRange = new List<Collider>();
    public bool isSlashing;

    void OnTriggerEnter(Collider collider)
    {
        collidersInRange.Add(collider);
    }

    void OnTriggerExit(Collider collider)
    {
        collidersInRange.Remove(collider);
    }

    void Update()
    {
        if (!isSlashing)
        {
            foreach (Collider c in collidersInRange)
            {
                if (c == null) collidersInRange.Remove(c);
            }
        }
    }

    public void Swing()
    {
        isSlashing = true;
        foreach (Collider c in collidersInRange)
        {
            Debug.Log("Slashed " + c.name);
        }
        isSlashing = false;
    }
}

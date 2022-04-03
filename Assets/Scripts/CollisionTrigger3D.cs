using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger3D : MonoBehaviour
{
    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerStay;
    public UnityEvent<Collider> onTriggerExit;
    public string optionalTag = "";

    public HashSet<Collider> colliders = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other) {
        if(other.tag == optionalTag || optionalTag == "") onTriggerEnter.Invoke(other);

        if (!colliders.Contains(other)) { colliders.Add(other); }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == optionalTag || optionalTag == "") onTriggerExit.Invoke(other);

        colliders.Remove(other);
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == optionalTag || optionalTag == "") onTriggerStay.Invoke(other);
    }
}

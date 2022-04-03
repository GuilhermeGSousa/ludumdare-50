using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiner : MonoBehaviour
{
    [SerializeField] CollisionTrigger3D box;
    [SerializeField] GameObject refinedUranium;
    public void Refine()
    {
        // OverlapBox doesnt work :(
        var hits = box.colliders;
        var toRefine = new List<Collider>();
        foreach (var hit in hits)
        {
            if(hit.tag == "Rock"){
                toRefine.Add(hit);
            }
        }

        foreach (var rock in toRefine)
        {
            Vector3 rockPosition = rock.gameObject.transform.position;
            Quaternion rockRotation = rock.gameObject.transform.rotation;

            hits.Remove(rock);
            Destroy(rock.gameObject);
            Instantiate(refinedUranium, rockPosition, rockRotation);
        }
    }
}

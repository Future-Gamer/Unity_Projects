using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [Header("Player Punch Variable")]
    public Camera cam;
    public float giveDamageOf = 10f;
    public float punchingRange = 5f;


    public void Punch()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, punchingRange))
        {
            Debug.Log(hitInfo.transform.name);

            Object_to_hit object_To_Hit = hitInfo.transform.GetComponent<Object_to_hit>();
            Zombie1 zombie1 = hitInfo.transform.GetComponent<Zombie1>();
            Zombie2 zombie2 = hitInfo.transform.GetComponent<Zombie2>();
            if (object_To_Hit != null)
            {
                object_To_Hit.ObjectHitDamage(giveDamageOf);
                
            }
            else if (zombie1 != null)
            {
                zombie1.ZombieHitDamage(giveDamageOf);
            }
            else if (zombie2 != null)
            {
                zombie1.ZombieHitDamage(giveDamageOf);
            }

        }
    }


}

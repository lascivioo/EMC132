using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour
{
    public float boostCooldown = 5f;
     public float boostDuration = 2f;
     private float speedIncrease = 3;
 
     private bool hasCooldown;
     private Vector3 normalMovementVector = Vector3.forward;
     private Vector3 currentMovementVector;
 
     void Start()
     {
         currentMovementVector = normalMovementVector;
         StartCoroutine(ActivateCooldown());
     }
     
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.Space) && !hasCooldown)
         {
             currentMovementVector += Vector3.forward * speedIncrease;
             StartCoroutine(ActivateCooldown());
             StartCoroutine(ResetMovementVector());
         }
         transform.Translate(currentMovementVector * Time.deltaTime);
     }
 
     IEnumerator ResetMovementVector()
     {
         yield return new WaitForSeconds(boostDuration);
         currentMovementVector = normalMovementVector;
         Debug.Log("boost ended");
     }
 
     IEnumerator ActivateCooldown()
     {
         hasCooldown = true;
         yield return new WaitForSeconds(boostCooldown);
         hasCooldown = false;
         Debug.Log("boost ready");
     }
}
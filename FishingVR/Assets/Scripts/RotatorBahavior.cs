using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
[RequireComponent(typeof(Interactable))]
public class RotatorBahavior : MonoBehaviour
{
    Hand playerHand;
    [SerializeField] Rigidbody dial;
    // Use this for initialization
    void Start()
    {
    }

    private void HandAttachedUpdate()
    {
        dial.MoveRotation(Quaternion.Euler(0, 0, -playerHand.transform.rotation.z * transform.localScale.z));
    }

    protected virtual void OnAttachedToHand(Hand hand)
    {
        playerHand = hand;
    }
}
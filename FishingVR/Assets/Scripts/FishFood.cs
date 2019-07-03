using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFood : MonoBehaviour
{
    public int foodSize = 1;
    public bool isAttachedToPlayerLure;
    public Lure attachedPlayerLure;

    public bool bite()
    {
        if (this.foodSize <= 0)
        {
            return false;
        }
        this.foodSize--;
        return true;
    }

    private void FixedUpdate()
    {
        if (this.foodSize == 0)
        {
            Destroy(base.gameObject);
        }
    }
}
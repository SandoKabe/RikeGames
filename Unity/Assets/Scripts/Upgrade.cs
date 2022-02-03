using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // A SUP
    public enum UpgradeType
    {
        CLICK,
        AUTO
    }

    public int[] UpLevel;

    private void Awake()
    {
        UpLevel = new int[10];
    }
}

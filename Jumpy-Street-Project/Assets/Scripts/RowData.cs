using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a scriptable object to hold the row's data
[CreateAssetMenu(fileName = "Row Data", menuName = "Row Data")]
public class RowData : ScriptableObject
{
    public GameObject row;
    public int maxInSuccession;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string itemName;
    public int itemId;
    public int itemCount;
    public bool isStack;
    [Multiline(5)]
    public string descriptionItem;
    public string pathIcon;
    public string pathPrefab;
}

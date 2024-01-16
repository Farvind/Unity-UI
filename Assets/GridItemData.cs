using UnityEngine;

[CreateAssetMenu(fileName = "NewGridItemData", menuName = "GridItemData")]
public class GridItemData : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    // Add any other data you need for each grid item
}

using UnityEngine;
using UnityEngine.UI;

public class GridItemController : MonoBehaviour
{
    public Image iconImage;
    public Text itemNameText;

    public void SetData(GridItemData data)
    {
        // Set data to UI elements
        iconImage.sprite = data.icon;
        itemNameText.text = data.itemName;
        // Add any other data setting logic as needed
    }
}

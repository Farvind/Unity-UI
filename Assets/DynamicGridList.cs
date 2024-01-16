using UnityEngine;
using UnityEngine.UI;

public class DynamicGridList : MonoBehaviour
{
    public RectTransform gridContainer;
    public GameObject gridItemPrefab;
    public GridItemData[] gridItemDataArray;
    public int gridSizeX = 3;
    public int gridSizeY = 3;
    public float spacing = 10f;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        int index = 0;

        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                if (index < gridItemDataArray.Length)
                {
                    // Calculate position for each grid item
                    Vector3 position = new Vector3(x * (spacing + gridItemPrefab.GetComponent<RectTransform>().sizeDelta.x),
                                                  -y * (spacing + gridItemPrefab.GetComponent<RectTransform>().sizeDelta.y),
                                                  0f);

                    // Instantiate and parent the grid item
                    GameObject gridItem = Instantiate(gridItemPrefab, position, Quaternion.identity);
                    gridItem.transform.SetParent(gridContainer, false);

                    // Set data from Scriptable Object
                    GridItemController gridItemController = gridItem.GetComponent<GridItemController>();
                    gridItemController.SetData(gridItemDataArray[index]);

                    index++;
                }
            }
        }

        // Set the size of the grid container based on the grid size
        float contentWidth = gridSizeX * (spacing + gridItemPrefab.GetComponent<RectTransform>().sizeDelta.x);
        float contentHeight = gridSizeY * (spacing + gridItemPrefab.GetComponent<RectTransform>().sizeDelta.y);

        // Set the size of the grid container based on the grid size
        gridContainer.sizeDelta = new Vector2(contentWidth, contentHeight);

        // Set the size of the ScrollRect content
        RectTransform contentRectTransform = gridContainer.GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = new Vector2(contentWidth, contentHeight);
    }
}

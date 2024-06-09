// using UnityEngine;
// using TMPro;
//
// public class VerticalTextScroll : MonoBehaviour
// {
//     public TextMeshProUGUI textMeshPro;
//     public float scrollSpeed = 30f; // Speed at which the text scrolls
//     public float resetPositionY = -500f; // Y position at which the text resets to the top
//     public float startPositionY = 500f; // Y position where the text starts from
//
//     private RectTransform rectTransform;
//
//     void Start()
//     {
//         rectTransform = textMeshPro.GetComponent<RectTransform>();
//         rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, startPositionY);
//     }
//
//     void Update()
//     {
//         // Move the text up
//         rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
//
//         // Check if the text has reached the reset position
//         if (rectTransform.anchoredPosition.y >= resetPositionY)
//         {
//             // Reset the text to the start position
//             rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, startPositionY);
//         }
//     }
// }

using UnityEngine;
using TMPro;

public class SeamlessVerticalTextScroll : MonoBehaviour
{
    public TextMeshProUGUI originalTextMeshPro;
    public TextMeshProUGUI duplicateTextMeshPro;
    public float scrollSpeed = 30f;

    private RectTransform originalRectTransform;
    private RectTransform duplicateRectTransform;

    private float textHeight;

    void Start()
    {
        // Initialize the RectTransforms
        originalRectTransform = originalTextMeshPro.GetComponent<RectTransform>();
        duplicateRectTransform = duplicateTextMeshPro.GetComponent<RectTransform>();

        // Ensure the duplicate text has the same content
        duplicateTextMeshPro.text = originalTextMeshPro.text;

        // Calculate the height of the text
        textHeight = originalTextMeshPro.preferredHeight;

        // Set the initial positions
        duplicateRectTransform.anchoredPosition = new Vector2(originalRectTransform.anchoredPosition.x, originalRectTransform.anchoredPosition.y - textHeight);
    }

    void Update()
    {
        // Move both texts up
        originalRectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        duplicateRectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

        // Check if the original text has moved out of view
        if (originalRectTransform.anchoredPosition.y >= textHeight)
        {
            // Move it below the duplicate
            originalRectTransform.anchoredPosition = new Vector2(originalRectTransform.anchoredPosition.x, duplicateRectTransform.anchoredPosition.y - textHeight);
        }

        // Check if the duplicate text has moved out of view
        if (duplicateRectTransform.anchoredPosition.y >= textHeight)
        {
            // Move it below the original
            duplicateRectTransform.anchoredPosition = new Vector2(duplicateRectTransform.anchoredPosition.x, originalRectTransform.anchoredPosition.y - textHeight);
        }
    }
}
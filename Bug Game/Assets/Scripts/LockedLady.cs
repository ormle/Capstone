using UnityEngine;

public class LockedLady : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToTransform;

    // Public function to set initial coordinates, make active, and then inactive after 3 seconds
    public void SetInitialCoordinatesAndToggleActivity()
    {
        // Check if the objectToTransform is assigned
        if (objectToTransform != null)
        {
            // Get the RectTransform component
            RectTransform rectTransform = objectToTransform.GetComponent<RectTransform>();

            // Check if RectTransform component is present
            if (rectTransform != null)
            {
                // Set the initial coordinates using anchoredPosition
                rectTransform.anchoredPosition = new Vector3(-971f, 63f, 0f);

                // Make the object active
                objectToTransform.SetActive(true);

                // Invoke a method to make the object inactive after 3 seconds
                Invoke("DeactivateAfterDelay", 3f);
            }
            else
            {
                Debug.LogError("The assigned GameObject does not have a RectTransform component.");
            }
        }
        else
        {
            Debug.LogError("Please assign a GameObject to objectToTransform in the Inspector.");
        }
    }

    // Method to make the object inactive
    private void DeactivateAfterDelay()
    {
        if (objectToTransform != null)
        {
            objectToTransform.SetActive(false);
        }
    }
}

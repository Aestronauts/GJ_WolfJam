using UnityEngine;

public class BumpAnim : MonoBehaviour
{
    // Start and end values
    public float startValue = 0f;
    public float endValue = 10f;

    // Duration for the lerp to go from start to end
    public float duration = 2f;

    private float currentLerpTime;
    private bool isLerping;
    private bool isReversing;

    public Camera mainCam;

    public GameObject circle;

    public string ignoreTag;

    public AK.Wwise.Event wallBumpSFX;

    void Update()
    {
        // // Check for key press to start lerping
        // if (Input.GetKeyDown(KeyCode.Space) && !isLerping)
        // {
        //     isLerping = true;
        //     isReversing = false;
        //     currentLerpTime = 0f;
        // }

        // Perform the lerp if lerping is active
        if (isLerping)
        {
            currentLerpTime += Time.deltaTime;

            // Calculate the lerp factor
            float t = currentLerpTime / duration;
            if (t > 1f) t = 1f;

            // Lerp the value
            float currentValue = Mathf.Lerp(startValue, endValue, t);
            //Debug.Log("Current Value: " + currentValue);

            // Check if we need to reverse the direction
            if (!isReversing && currentLerpTime >= duration)
            {
                isReversing = true;
                currentLerpTime = 0f;
            }
            else if (isReversing)
            {
                // Calculate the reverse lerp factor
                float reverseT = currentLerpTime / duration;
                if (reverseT > 1f) reverseT = 1f;

                // Reverse lerp the value
                currentValue = Mathf.Lerp(endValue, startValue, reverseT);
                //Debug.Log("Current Value: " + currentValue);

                // Check if the reverse lerp is complete
                if (currentLerpTime >= duration)
                {
                    isLerping = false;
                }
            }

            circle.transform.localScale = new Vector3(currentValue,currentValue,0.2f);
        }

        // if (!isLerping)
        // {
        //     this.transform.localScale = new Vector3(0,0,0);
        // }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Ignore the collider if it has the specified tag
        if (other.CompareTag(ignoreTag))
        {
            return;
        }
        
        if (!isLerping)
        {
            wallBumpSFX.Post(gameObject);
            isLerping = true;
            isReversing = false;
            currentLerpTime = 0f;
        }
    }
}
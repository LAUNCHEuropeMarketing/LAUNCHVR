using UnityEngine;

public class LookDetector : MonoBehaviour
{
    public float lookDistance = 20f;
    public float lookTime = 1f;

    private float timer;
    private HoverOnLook currentHover;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, lookDistance))
        {
            HoverOnLook hover = hit.collider.GetComponentInParent<HoverOnLook>();

            if (hover != null)
            {
                if (hover == currentHover)
                {
                    timer += Time.deltaTime;

                    if (timer >= lookTime)
                    {
                        hover.SetLooking(true);
                    }
                }
                else
                {
                    if (currentHover != null)
                        currentHover.SetLooking(false);

                    currentHover = hover;
                    timer = 0;
                }

                return;
            }
        }

        if (currentHover != null)
            currentHover.SetLooking(false);

        currentHover = null;
        timer = 0;
    }
}
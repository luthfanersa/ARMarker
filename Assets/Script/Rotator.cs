using System.Collections;

using UnityEngine;


public class Rotator : MonoBehaviour
{
	private Touch touch;
	private Vector2 touchPosition;
	private Quaternion rotationY;
	private float rotationSpeedModifier = 0.1f;


	private Vector2 first_touch;
	private Vector2 second_touch;
	private float distance_current;
	private float distance_previous;
	private bool first_pinch = true;

	void Update()
	{
        if (Input.touchCount > 0)
        {
			touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
				rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotationSpeedModifier, 0f);
				transform.rotation = rotationY * transform.rotation;
            }
        }

        if (Input.touchCount > 1 )
        {
            first_touch = Input.GetTouch(0).position;
            second_touch = Input.GetTouch(1).position;
            distance_current = second_touch.magnitude - first_touch.magnitude;
            if (first_pinch)
            {
                distance_previous = distance_current;
                first_pinch = false;
            }
            if (distance_current != distance_previous)
            {
                Vector3 scale_value = transform.localScale * (distance_current / distance_previous);
                transform.localScale = scale_value;
                distance_previous = distance_current;
            }
        }
        else
        {
            first_pinch = true;
        }
    }

}
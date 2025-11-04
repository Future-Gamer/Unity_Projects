using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleGrabObject : MonoBehaviour
{
    public InputActionProperty grabAction;
    public Transform handTransform; // Where the object will be held

    private GameObject heldObject = null;
    private bool isHolding = false;

    private void OnEnable()
    {
        grabAction.action.performed += OnGrabPressed;
    }

    private void OnDisable()
    {
        grabAction.action.performed -= OnGrabPressed;
    }

    private void OnGrabPressed(InputAction.CallbackContext context)
    {
        if (!isHolding)
        {
            Debug.Log("Grab button pressed, isHolding: " + isHolding);

            // Try to grab an object
            Collider[] colliders = Physics.OverlapSphere(handTransform.position, 0.2f);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Grabbable"))
                {
                    heldObject = collider.gameObject;
                    heldObject.transform.SetParent(handTransform);
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    isHolding = true;
                    break;
                }
            }
        }
        else
        {
            // Release the object
            if (heldObject != null)
            {
                heldObject.transform.SetParent(null);
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject = null;
            }
            isHolding = false;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class GunGrabAndFire : MonoBehaviour
{
    public InputActionProperty grabAction;
    public InputActionProperty triggerAction;
    public Transform handTransform;
    public Animator handAnimator;

    private GameObject heldObject = null;
    private bool isHolding = false;
    private bool isGun = false;

    private void OnEnable()
    {
        grabAction.action.performed += OnGrabPressed;
        grabAction.action.canceled += OnGrabReleased;
        triggerAction.action.performed += OnTriggerPressed;
    }

    private void OnDisable()
    {
        grabAction.action.performed -= OnGrabPressed;
        grabAction.action.canceled -= OnGrabReleased;
        triggerAction.action.performed -= OnTriggerPressed;
    }

    private void Update()
    {
        // Only animate hand trigger if not holding a gun
        if (!isGun)
        {
            float triggerValue = triggerAction.action.ReadValue<float>();
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0f);
        }

        // Keep gun aligned with hand while holding
        if (isHolding && isGun && heldObject != null)
        {
            heldObject.transform.rotation = handTransform.rotation;
        }
    }


    private void OnGrabPressed(InputAction.CallbackContext context)
    {
        if (!isHolding)
        {
            Collider[] colliders = Physics.OverlapSphere(handTransform.position, 0.2f);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Gun"))
                {
                    heldObject = collider.gameObject;
                    heldObject.transform.SetParent(handTransform);
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    isHolding = true;
                    isGun = true;
                    break;
                }
                else if (collider.CompareTag("Grabbable"))
                {
                    heldObject = collider.gameObject;
                    heldObject.transform.SetParent(handTransform);
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    isHolding = true;
                    isGun = false;
                    break;
                }
            }
        }
    }

    private void OnGrabReleased(InputAction.CallbackContext context)
    {
        if (isHolding && heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
        }
        isHolding = false;
        isGun = false;
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        if (isHolding && isGun && heldObject != null)
        {
            var fireScript = heldObject.GetComponent<FireBulletOnActivate>();
            if (fireScript != null)
            {
                fireScript.Fire();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class ObjectAction : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference xAction;
    [SerializeField] private InputActionReference yAction;

    [Header("Events")]
    [SerializeField] private UnityEvent onXPressed;
    [SerializeField] private UnityEvent onYPressed;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (xAction != null)
            xAction.action.performed += OnXPerformed;

        if (yAction != null)
            yAction.action.performed += OnYPerformed;
    }

    private void OnDisable()
    {
        if (xAction != null)
            xAction.action.performed -= OnXPerformed;

        if (yAction != null)
            yAction.action.performed -= OnYPerformed;
    }

    private void OnXPerformed(InputAction.CallbackContext context)
    {
        if (!IsGrabbed())
            return;

        onXPressed?.Invoke();
    }

    private void OnYPerformed(InputAction.CallbackContext context)
    {
        if (!IsGrabbed())
            return;

        onYPressed?.Invoke();
    }

    private bool IsGrabbed()
    {
        return grabInteractable != null &&
               grabInteractable.isSelected;
    }
}
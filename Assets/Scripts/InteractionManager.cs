using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    [Header("Interaction Settings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactableLayer;

    private Interactable currentInteractable;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
        {
            currentInteractable = hit.collider.GetComponent<Interactable>();

            if (currentInteractable != null)
            {
                UIController.Instance.ShowInteractText(currentInteractable.GetInteractText());
                return;
            }
        }
        currentInteractable = null;
        UIController.Instance.HideInteractText();
    }

    public void TryInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        else
        {
            Debug.Log("No interactable in range");
        }
    }
}
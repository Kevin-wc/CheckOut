using UnityEngine;

public class ShelfTaskInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private string interactText = "Restock shelves";
    [SerializeField] private bool taskCompleted;

    [Header("Shelf Materials")]
    [SerializeField] private Renderer shelfRenderer;
    [SerializeField] private Material grayMaterial;
    [SerializeField] private Material normalMaterial;
    void Start()
    {
        Material[] materials = shelfRenderer.materials;

        normalMaterial = materials[1];

        materials[1] = grayMaterial;
        shelfRenderer.materials = materials;
    }

    public void Interact()
    {
        if (taskCompleted)
        {
            return;
        }

        taskCompleted = true;

        Material[] materials = shelfRenderer.materials;
        materials[1] = normalMaterial;
        shelfRenderer.materials = materials;

        TaskManager.Instance.restockedBooks = true;
        TaskManager.Instance.UpdateTaskUI();
        TaskManager.Instance.CompleteTask();
    }

    // Update is called once per frame
    public string GetInteractText()
    {
        return interactText;
    }
}

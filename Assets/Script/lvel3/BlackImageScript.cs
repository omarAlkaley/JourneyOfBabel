using UnityEngine;

public class BlackImageScript : MonoBehaviour
{
    public Transform[] specificSlots1;
    public Transform[] specificSlots2;
    public Transform[] specificSlots3;

    public GameObject Items;


    private Transform[] currentSlots;

    public Vector3 newSize = new Vector3(1f, 1f, 0f);

    private void Start()
    {
        currentSlots = GetRandomSlotGroup();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveItemToVisibleSlot();
        }
    }

    private Transform[] GetRandomSlotGroup()
    {
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                return specificSlots1;
            case 1:
                return specificSlots2;
            case 2:
                return specificSlots3;
            default:
                Debug.LogError("Invalid random index!");
                return specificSlots1;
        }
    }

    private void MoveItemToVisibleSlot()
    {
        foreach (Transform slot in currentSlots)
        {
            Renderer slotRenderer = slot.GetComponent<Renderer>();
            if (slot.childCount == 0 && (slotRenderer == null || slotRenderer.isVisible))
            {
                MoveObjectToSlot(slot);
                return;
            }
        }
    }

    private void MoveObjectToSlot(Transform slot)
    {
        transform.SetParent(slot);
        transform.SetAsLastSibling();
        transform.localPosition = Vector3.zero;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = 7;
        }

        transform.localScale = newSize;

        currentSlots = GetRandomSlotGroup();
    }
}

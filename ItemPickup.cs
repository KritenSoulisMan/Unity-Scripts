
using UnityEngine;
using Photon.Pun;

public class ItemPickup : MonoBehaviourPunCallbacks
{
    public Transform itemInHand;
    private bool isHolding = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if there is an item in the player's line of sight
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Transform item = hit.collider.transform;
                if (item.CompareTag("Item"))
                {
                    // If the item is found and it is an item, pick it up
                    if (!isHolding)
                    {
                        itemInHand = item;
                        itemInHand.SetParent(transform);
                        itemInHand.localPosition = Vector3.zero;
                        itemInHand.gameObject.SetActive(false);
                        isHolding = true;

                        // Send the item pickup event to other players
                        photonView.RPC("PickupItem", RpcTarget.All, itemInHand.GetComponent<PhotonView>().ViewID);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Check if there is an item in hand and return it to its original position
            if (isHolding && itemInHand != null)
            {
                itemInHand.SetParent(null);
                itemInHand.gameObject.SetActive(true);
                itemInHand.position = transform.position + transform.forward * 2f; // Place the item in front of the player
                itemInHand.rotation = Quaternion.LookRotation(transform.forward); // Align the item with the player's direction
                itemInHand = null;
                isHolding = false;

                // Send the item drop event to other players
                photonView.RPC("DropItem", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void PickupItem(int itemID)
    {
        // Find the item by its ID and pick it up
        PhotonView itemPhotonView = PhotonView.Find(itemID);
        if (itemPhotonView != null)
        {
            itemInHand = itemPhotonView.transform;
            itemInHand.SetParent(transform);
            itemInHand.localPosition = Vector3.zero;
            itemInHand.gameObject.SetActive(false);
            isHolding = true;
        }
    }

    [PunRPC]
    void DropItem()
    {
        // Return the item to its original position
        if (isHolding && itemInHand != null)
        {
            itemInHand.SetParent(null);
            itemInHand.gameObject.SetActive(true);
            itemInHand.position = transform.position + transform.forward * 2f; // Place the item in front of the player
            itemInHand.rotation = Quaternion.LookRotation(transform.forward); // Align the item with the player's direction
            itemInHand = null;
            isHolding = false;
        }
    }
}

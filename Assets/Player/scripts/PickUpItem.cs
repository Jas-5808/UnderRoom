using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float rangeInPickUp = 1f;
    public float pickUpRange = 5f; // ������������ ���������� ��� ������� ��������
    public Transform holdParent; // �����, ���� ����� ������������ �������� ������
    public Camera playerCamera; // ������ ������
    private GameObject heldObj; // ������� �������� ������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                // ������� ������� ������
                RaycastHit hit;
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ItemPick") && hit.collider.gameObject.GetComponent<Rigidbody>())
                    {
                        heldObj = hit.collider.gameObject;
                        PickUp();
                    }
                }
            }
            else
            {
                // ��������� ������
                Drop();
            }
        }

    }

    void PickUp()
    {
        Rigidbody rb = heldObj.GetComponent<Rigidbody>();
        rb.isKinematic = true; // ��������� ������ ��� ������������� �������, ����� �� �� �����
                               // ������ ����� ������� �� 1 ������� ������� �� holdParent � ����������� ������� ������
        Vector3 newPosition = holdParent.position + playerCamera.transform.forward * rangeInPickUp;
        heldObj.transform.parent = holdParent; // ������ ������ �������� � ����� ���������, ����� �� �������� �� �������
    }


    void Drop()
    {
        Rigidbody rb = heldObj.GetComponent<Rigidbody>();
        rb.isKinematic = false; // �������� ������ �������
        heldObj.transform.parent = null; // ������� ������ �� �������� ���������, ����� �� ������ �� �������� �� �������
        heldObj = null; // ������� ������ �� �������� ������
    }

    
}

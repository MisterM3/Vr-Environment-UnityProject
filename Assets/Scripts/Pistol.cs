using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{

    [SerializeField] Magazine mag;

    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireSpeed = 20;

    [SerializeField] Animator animator;
    [SerializeField] GameObject bulletHole;


    [SerializeField] XRSocketInteractor socket;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        socket.selectEntered.AddListener(AddMag);

        AddMag(socket.interactablesSelected);

        CheckMag();
    }


    public void AddMag(SelectEnterEventArgs arg)
    {

        if (arg.interactableObject.transform.CompareTag("Magazine"))
        {
            mag = arg.interactableObject.transform.gameObject.GetComponent<Magazine>();
            if (mag.HasAmmo()) animator.SetBool("Empty", false); 
            else animator.SetBool("Empty", true);
        }
    }

    public void AddMag(List<IXRSelectInteractable> test)
    {
        foreach(IXRSelectInteractable t in test)
        {
            if (t.transform.CompareTag("Magazine"))
            {
                mag = t.transform.gameObject.GetComponent<Magazine>();
                if (mag.HasAmmo()) animator.SetBool("Empty", false);
                else animator.SetBool("Empty", true);
            }
        }
    }


    public void FireBullet(ActivateEventArgs arg)
    {
      

        if (mag == null) return;
        if (!mag.HasAmmo()) return;



        Ray bulletRay = new Ray(spawnPoint.position, spawnPoint.forward);
        animator.SetTrigger("Shot");


        mag.TryUseAmmo();

        if (mag.HasAmmo()) animator.SetBool("Empty", false);
        else animator.SetBool("Empty", true);

        if (Physics.Raycast(bulletRay, out RaycastHit hitInfo))
        {
            GameObject spawnedBulletHole = Instantiate(bulletHole, hitInfo.point, Quaternion.identity);
            Destroy(spawnedBulletHole, 5f);
        }

        CheckMag();

    }


    public void CheckMag()
    {
        if (socket.interactablesSelected.Count == 0)
        {
            mag = null;
            animator.SetBool("Empty", true);
        }
    }


}

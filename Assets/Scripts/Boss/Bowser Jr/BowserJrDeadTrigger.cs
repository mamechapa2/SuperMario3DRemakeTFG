using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserJrDeadTrigger : MonoBehaviour
{
    public GameObject switchOn;
    public GameObject switchOff;

    public GameObject explosionPrefab;
    public GameObject bossModelObject;

    public GameObject[] ground;
    public GameObject endBarrier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(wait());
        }
    }
    private IEnumerator wait()
    {
        //Cambiar el switch a activado
        switchOn.SetActive(false);
        switchOff.SetActive(true);

        //Eliminar el suelo bajo el jefe
        for (int i = 0; i < ground.Length; i++)
        {
            ground[i].SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        
        //Activar la nueva animacion y desactivar el salto
        transform.parent.GetComponentInChildren<BowserJrCharacterController>().enabled = false;
        transform.parent.GetComponentInChildren<Animator>().SetBool("jump", false);
        transform.parent.GetComponentInChildren<Animator>().SetBool("defeat", true);

        yield return new WaitForSeconds(2.4f);

        //Activa la explosion y elimina el modelo del jefe
        explosionPrefab.SetActive(true);
        bossModelObject.SetActive(false);

        //Abre la barrera del final
        endBarrier.SetActive(false);
    }
}

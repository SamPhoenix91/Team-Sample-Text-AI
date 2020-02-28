using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    bool baseHit = false;
    private ParticleSystem destroyPart;
    private GameObject modelGO;

    private void Start()
    {
        destroyPart = transform.Find("DestroyParticle").GetComponent<ParticleSystem>();
        modelGO = transform.Find("Model").gameObject;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile" && baseHit == false)
        {
            print("Base has been hit!");
            baseHit = true;
            StartCoroutine(BaseDestroyed());
            modelGO.SetActive(false);
        }
    }

    IEnumerator BaseDestroyed()
    {
        destroyPart.Play();
        yield return new WaitForSeconds(0.75f);
        Destroy(this.gameObject);
    }
}

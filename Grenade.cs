using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : ThrowableBaseClass
{
    public float damage = 20f;
    public LayerMask mask;
    public float explosiveRadius = 6;
    float t;
    public GameObject effectParticle;
    void Start()
    {
        Initiation();
        ThrowAndDie();
        t = Time.time + fuseTime;
    }
    private void Update()
    {
        if (Time.time > t)
        {
            Instantiate(effectParticle, transform.position, Quaternion.identity);
            if (Physics.OverlapSphere(transform.position, explosiveRadius, mask).Length > 0)
            {
                foreach (Collider c in Physics.OverlapSphere(transform.position, explosiveRadius, mask))
                {
                    c.gameObject.GetComponent<LivingEntity>().damageHealth += damage;
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);
        Gizmos.color = Color.red;
    }
}

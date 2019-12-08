using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LivingEntity : NetworkBehaviour
{
    public float maxHealth;
    public float damageHealth;
    public float speed;
    public float jumpForce;
    protected Rigidbody rigid;
    protected Animator anim;

    public void Move(float x, float z, float speed)
    {
        Vector3 direction = new Vector3(x, 0, z);
        Vector3 velocity = direction * speed + rigid.velocity.y * Vector3.up;
        rigid.velocity = velocity;
    }
    public void Move(Vector3 direction, float speed)
    {
        direction.y = 0;
        direction = direction.normalized;
        Vector3 velocity = direction * speed + rigid.velocity.y * Vector3.up;
        rigid.velocity = velocity;
    }
    public void AddForceEak(Vector3 direction, float force)
    {
        rigid.AddForce(direction * force * 81f);
    }
    public virtual void Initialization()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggScript : MonoBehaviour
{
    public GameObject spawn;
    public GameObject spot1;
    public GameObject spot2;
    public GameObject spot3;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            transform.position = Vector3.MoveTowards(transform.position, spot1.transform.position, 0.1f);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("yell"))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, spot2.transform.position - transform.position, 0.01f, 0.0f));
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("run_0"))
        {
            transform.position = Vector3.MoveTowards(transform.position, spot2.transform.position, 0.1f);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("run_1"))
        {
            transform.position = Vector3.MoveTowards(transform.position, spot3.transform.position, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == spot1)
        {
            animator.SetBool("yellOn", true);
        }
        else if (other.gameObject == spot2)
        {
            animator.SetBool("danceOn", true);
        }
        else if (other.gameObject == spot3)
        {
            this.gameObject.SetActive(false);
        }
    }
}

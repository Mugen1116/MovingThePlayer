
using UnityEngine;

public class PlayerStabing : MonoBehaviour {


    public int damagePerStab = 10;
    public float timeBetweenStabs = 0.5f;
    //No necesita rango
    public float impactForce = 10f;
    public Animator anim;
    //No se necesita camara
    public GameObject hitParticles;

    Collider knife;
    bool stabing = false;
    float range = 5f;

    /*
    public bool ihavethepower = false;
    public float powerTime = 5.0f;
    */

    //AudioSource stabAudio;

    float timer;

    private void Awake()
    {
        knife = GetComponent<CapsuleCollider>();
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if ( Input.GetButtonDown("Fire2") && timer >= timeBetweenStabs ){
            Stab();
        }
	}

    void Stab() {
        timer = 0f;

        //Este no tiene turning para dejar mayor libertad al combate Melee
        stabing = true;
        anim.SetTrigger("Stab");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && stabing)
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerStab);
                PlayEffects();
            }
            stabing = false;
        }
    }

    public void PlayEffects() {
        /*
        RaycastHit stabHit;
        Physics.Raycast(transform.position, transform.forward, out stabHit, range);
        if (stabHit.rigidbody != null){
            stabHit.rigidbody.AddForce(-stabHit.normal * impactForce);
        }
        GameObject impactGO = Instantiate(hitParticles, stabHit.point, Quaternion.LookRotation(stabHit.normal));
        Destroy(impactGO, 2f);
        */
    }
}

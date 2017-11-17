using UnityEngine;

public class PlayerShooting : MonoBehaviour {


    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.25f;
    public float range = 100f;
    public float impactForce = 30f;
    public Animator anim;
    public Camera cam;
    public ParticleSystem gunParticles;

    public GameObject player;

    //Particulas al colisionar (Colision normal)
    public GameObject hitParticles;
    //Particula si choca con un enemigo (Sangre)
    public GameObject bloodHitParticles;


    public bool ihavethepower = false;
    public float powerTime = 5.0f;
    //AudioSource gunAudio;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;

  


    //LineRenderer gunLine;
    //Light gunLight;
    //float effectsDisplayTime = 0.2f;



    private void Awake()
    {
       // gunParticles = GetComponent<ParticleSystem>();
       // gunLine = GetComponent<LineRenderer>();
       // gunAudio = GetComponent<AudioSource>();

       // gunLight = GetComponent<Light>();
        
    }

	
	
	void Update () {
        //Añadir comprobador del powerUp
        timer += Time.deltaTime;
        //Si se pulsa el botón 
        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && System.Math.Abs(Time.timeScale) > 0)
        {
            Shoot();
        }
	}


    void Shoot() {
        
        //Arrancamos el temporizador
        timer = 0f;

        //gunLight.enabled = true;
        //gunLine.enabled = true;
        //gunLine.SetPosition(0, transform.position);

        //Girar el player hacia el objetivo
        Turning();
        anim.SetTrigger("Shoot");
    }//End SHoot

    void Turning() {
      
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out floorHit, range))
        {
            
            Vector3 playerToMouse = floorHit.point - transform.position ;
            playerToMouse.y = 0f; //Evitar ponerse boca abao
        
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.MoveRotation(newRotation);

           
            //Extra rotation
            // player.transform.Rotate(new Vector3(0f, 90f, 0f));
           
        }
    }

    public void PlayEffects(){

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out shootHit, range))
        {
            EnemyHealth enemyHealth = shootHit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot);
            }

            if (shootHit.rigidbody != null)
            {
                shootHit.rigidbody.AddForce(-shootHit.normal * impactForce);
            }
        }

        //gunAudio.Play();
        gunParticles.Stop();
        gunParticles.Play();
        GameObject impactGO = Instantiate(hitParticles, shootHit.point, Quaternion.LookRotation(shootHit.normal));
        Destroy(impactGO, 2f);
    }


}

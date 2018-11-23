using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorPlayer : Orbitor
{
    public AudioClip hit;
    public AudioClip death;
    public AudioClip[] shoot;

    private float speed = 3.0f;
    public int jc_ind = 0;
    public Vector2 startingPosition;
    public GameObject missilePrefab;

    public GameObject mySpaceship;
    public GameObject hitAnim;

    public int life = 5;
    public float shootingCD = 1.0f;

    private List<Joycon> joycons = new List<Joycon>();
    private Joycon joycon;
    private Rigidbody rb;
    [HideInInspector]
    public Vector2 tempInput = Vector2.zero;
    private bool canShoot = true;

    public int currentLivingMissile = 0;
    private int nbMaxMissile = 1;


    protected override void Start()
    {
		base.Start();
		
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }
        joycon = joycons[jc_ind];

        circleX = startingPosition.x;
        circleY = startingPosition.y;

        rb = GetComponent<Rigidbody>();

        nbMaxMissile = ParametersMgr.instance.GetParameterInt("cartridge");
        shootingCD = ParametersMgr.instance.GetParameterFloat("cdShoot");
		speed = ParametersMgr.instance.GetParameterFloat("shipSpeed");
		life = ParametersMgr.instance.GetParameterInt("shipHealth");
    }

    protected override void Update()
    {
        base.Update();
        Vector2 input = new Vector2(joycon.GetStick()[0], joycon.GetStick()[1]);
        if (input != Vector2.zero)
        {
            tempInput = input;
        }

        if (ParametersMgr.instance.GetParameterBool("shipMoveContinually"))
        {
			tempInput = tempInput.normalized;
            Move(-tempInput.y, tempInput.x, speed);
        }
        else
        {
            Move(-input.y, input.x, speed);
        }

        if (joycon.GetButtonDown(Joycon.Button.SHOULDER_1) && canShoot && currentLivingMissile < nbMaxMissile)
        {
            Shoot(tempInput);
        }
    }

    private void Shoot(Vector2 input)
    {
        SoundManager2D.instance.MultiSound(shoot, 0.25f);
        canShoot = false;
        currentLivingMissile++;
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<OrbitorMissile>().SetInput(-input);
        missile.GetComponent<OrbitorMissile>().SetInitialPosition(circleX, circleY);
        missile.GetComponent<OrbitorMissile>().myShooterParent = gameObject;
        StartCoroutine(ShootCD());
    }

    private IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(shootingCD);
        canShoot = true;
    }

    public void Hit()
    {
        SoundManager2D.instance.PlayClip(hit);
        life--;
        if (life <= 0)
        {

            //instancier le texte et réduire la planète

            canShoot = false;
            GameObject h = hitAnim;
            h.transform.forward = transform.position.normalized;
            h.transform.localScale = new Vector3(15, 15, 15);
            Instantiate(h, transform);
            h.transform.localScale = new Vector3(20, 20, 20);
            Instantiate(h, transform);
            Invoke("DestroySpaceship", 2f);
            mySpaceship.GetComponent<MeshRenderer>().enabled = false;

        }
        else
        {
            //disable collider et invoke la réctiovation 2s plus tard
            GetComponent<CapsuleCollider>().enabled = false;
            Invoke("ReactiveCapsuleCollider", 2f);
            mySpaceship.GetComponent<Animator>().SetTrigger("Hit");
            GameObject h = hitAnim;
            h.transform.forward = transform.position.normalized;
            h.transform.localScale = new Vector3(10, 10, 10);
            Instantiate(h, transform);
        }
    }

    private void DestroySpaceship()
    {
        SoundManager2D.instance.PlayClip(death);
        Destroy(this.gameObject);
    }

    private void ReactiveCapsuleCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
    }

    public void IncreaseNbMaxMissile()
    {
        nbMaxMissile++;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Deplacement : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private Rigidbody rigidbody;

    public float vit;
    private float Vitesse;
    private float Sprint;
    private float Vertical;
    private float Horizontal;
    private float nextFire;

    public GameObject auSol;// sert a bien verifier a modifier la taille du raycast qui detecte si ya bien le sol
    public float puissanceSaut;

    private float Saut;



    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Sprint = 2;
    }
        // Update is called once per frame
    void Update()
    {
        float Spinteur = 1;
    
        // modifier si on veut pouvoir changer la vitesse
        Vitesse = vit;
        // deplacement
        if (InputMAnageur.instance.GetKey(3))
        {
            HorizontalInput = Spinteur * Vitesse *Time.deltaTime; // permet de detecter les touche avancer et reculer on le multiplie par la vitesse qui permette de la regler sa nous donne la vitesse ou il va.
            Horizontal = HorizontalInput;
        }
        else if (InputMAnageur.instance.GetKey(2))
        {
            HorizontalInput = -Spinteur * Vitesse * Time.deltaTime;
            Horizontal = HorizontalInput;
        }
        else
        {
            HorizontalInput = 0;
        }


        if (InputMAnageur.instance.GetKey(1))
        {
            VerticalInput = -Spinteur * Vitesse * Time.deltaTime; //permet de detecter l'input on le multiplie par la vitesse qui permette de la regler sa nous donne la vitesse ou il va
            Vertical = VerticalInput;                                   
        }
        else if (InputMAnageur.instance.GetKey(0))
        {
            VerticalInput = Spinteur * Vitesse * Time.deltaTime;
            Vertical = VerticalInput;
        }
        else
        {
            VerticalInput = 0;
        }

        // on verifie que l'on va uniquement horizontalement
        if (HorizontalInput != 0 && VerticalInput == 0)
        {
            // fait deplacer notre personage horizontalement
            transform.Translate(HorizontalInput, 0, 0);
            Vertical = 0;
        }
        // on verifie que l'on va uniquement Verticalment
        else if (VerticalInput != 0 && HorizontalInput == 0)
        {
            // fait verifier notre peronage verticalment
            transform.Translate(0, 0, VerticalInput);
            Horizontal = 0;
        }
        else
        {
            // si il se deplace en diagonale permet de se deplacer
            transform.Translate(HorizontalInput * 2 / 3, 0, VerticalInput * 2 / 3);
        }

        if (InputMAnageur.instance.GetKey(4))
        {
            Saut = 1;
        }
        else
        {
            Saut = 0;
        }
    }



    private void FixedUpdate()
    {
        
            // donne une force qui vien du bas quand saut != 0 on verifie qu il soit au sol
            if (AuSol()) { rigidbody.AddForce(0, puissanceSaut * Saut, 0, ForceMode.VelocityChange); }
        

    }


    public bool AuSol()
    {
        return auSol.GetComponent<AuSol>().auSol;
    }

    private void OnGameStateChanged(GameState newgameState)
    {
        enabled = newgameState == GameState.Gameplay;
    }
}



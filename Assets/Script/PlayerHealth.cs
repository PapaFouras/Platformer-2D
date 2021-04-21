
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvicible = false;

    public SpriteRenderer graphics;

    public HealthBar healthBar;

    public float invicibilityTimeAfterHit = 0.3f;
    public float invicibilityFlashDelay = 0.2f;

    public AudioClip hitSound;

    public static PlayerHealth instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de PLayerHealth dans la scène");
            return;
        }
        instance = this;
    
    }

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage){

        if(!isInvicible){
       
            AudioManager.instance.PlayClipAt(hitSound,transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            // vérifier si le joueur est tjrs vivant

        if (currentHealth <= 0 )
        {
            Die();
            return;

        }

            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }

 
    }

    public void Die()
    {
        //bloquer les mouvements
        PlayerMovement.instance.enabled = false;

        //jouer l'animation de mort
        PlayerMovement.instance.animator.SetTrigger("Die");
        //empecher les interactions physiques avec les autres objets de la scene
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;

        GameOverManager.instance.OnPlayerDeath();




    }

    public void Respawn(){

        //bloquer les mouvements
        PlayerMovement.instance.enabled = true;

        //jouer l'animation de mort
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        //empecher les interactions physiques avec les autres objets de la scene
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);


    }

    public void HealPlayer(int ammount){

        if((currentHealth + ammount)> maxHealth){
            currentHealth = maxHealth;        
        }else{
            currentHealth += ammount;
        }
        
        healthBar.SetHealth(currentHealth);

    }

    public IEnumerator InvicibilityFlash(){
        while(isInvicible){
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);

        }
    }

    public IEnumerator HandleInvicibilityDelay(){
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}

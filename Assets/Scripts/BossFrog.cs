using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFrog : MonoBehaviour
{
    private Rigidbody2D rbody;

    public Sprite inAir;
    public Sprite notInAir;
    public GroundChecker GroundChecker;
    public float jumpLength = 2;
    public float jumpHight = 5;
    public int frogHP = 3;
    private float timer = 0;
    private float timesJumped = 0;
    private bool left = true;
    public float damageTimer = 0;

    //hämtar Rigidbody componenten från objektet som scriptet ligger på
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        //om Bossen är grounded(på marken) skall timer variabel öka med 1 per real sekund
        if (GroundChecker.isGrounded == 1)
            timer += Time.deltaTime;

        //om bossen har hoppat 4 gånger skall left inte vara left bli false, times jumped skall också ändras till 0
        if (timesJumped == 4)
        {
            left = !left;
            timesJumped = 0;
        }

        //om grodan är grounded och om timer variabeln är högre än 2 och om left är lika med true sakll följande hända
        if (GroundChecker.isGrounded == 1 && timer > 2 && left == true)
        {
            //timern skall bli 0
            timer = 0;
            //en force skall adderas till rbodyn från vänster håll (så att objektet åker till vänster i x axeln) hår långt den skall åka multiplicerar med jumplengt. den skall få force beroende på sin massa
            rbody.AddForce((-Vector2.right) * jumpLength, ForceMode2D.Impulse);
            //samma sak som ovan men istället för från vänster kommer kraften nerifrån så att objektet puttas uppåt. dessa i kombination för den snett framåt. Vi multiplicerar också med jumpHight istället för jumplength så att vi kan ändra de 2 värdena för att få en bra hopplängd och höjd som passar bra ihop
            rbody.AddForce((Vector2.up) * jumpHight, ForceMode2D.Impulse);
            //times jumped skall öka med 1
            timesJumped += 1;
            //scalen på objektet skall ändras till positiv så om scalen är negativ så skall objektet flippas så att hitboxen följer med
            transform.localScale = new Vector3(5, 5, 5);
        }

        //hoppar åt höger
        if (GroundChecker.isGrounded == 1 && timer > 2 && left == false)
        {
            //samma som ovan fast åt andra hålet
            timer = 0; 
            rbody.AddForce((Vector2.right) * jumpLength, ForceMode2D.Impulse);
            rbody.AddForce((Vector2.up) * jumpHight, ForceMode2D.Impulse);
            timesJumped += 1;
            transform.localScale = new Vector3(-5, 5, 5);
        }

        //om objektet är när marken skall den få spriten utav en groda som står still och den däremot inte är när marken ska den få spriten av en groda som är i luften 
        if (GroundChecker.isGrounded == 1)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = notInAir;
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = inAir;

        //variabeln damagetimer ökar med 1 varje realsekund, jag har sedan denna på sword scriptet så att jag bara kan skada grodan var 2 sekund eftersom att annars tar groddan damage varje milisekund svärdets trigger är inuti groddan
        damageTimer += Time.deltaTime;

        //om grodans HP är lika med 0 skall den tas bort från scenen (förstöras)
        if (frogHP == 0)
        {
            Destroy(gameObject);
        }

    }

    //om grodans trigger hitbox kolliderar med något som har tagen player skall scen 2 laddas om
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
        }

        //om damagetimer är större än 2 och objektet som koliderar med grodan har tagen Weapon skall FrogHP reduceras med 1 och damage timmer skal resetas till 0
        if (collision.tag == "Weapon" && damageTimer > 2)
        {
            frogHP -= 1;
            damageTimer = 0;
        }
        //om frog HP och Coin score är lika med 0 skall score från coin scriptet gå upp med ett, jag la till score kriteriet så att inte player points adderades med ett varje sekund direkt groddan dödades
        if (frogHP == 0 && Coin.score == 0)
        {
            Coin.score++;
        }
        
    }

}

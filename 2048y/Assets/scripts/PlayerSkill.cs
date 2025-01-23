using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public GameObject skillText;
    public GameObject can;

    public Image skillH;
    public Image skillB;

    public Text skillHT;
    public Text skillBT;

    float Htime;
    float Btime;

    int Bquantity = 2;
    int Hquantity = 3;

    public float r;

    private void Start()
    {
        Htime = 5;
        Btime = 10;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.C))
        { 
            if (Btime >= 10 && Bquantity > 0)
            {
                Collider2D[] collider = Physics2D.OverlapCircleAll(Vector3.zero, r);
                foreach (Collider2D col in collider)
                {
                    if (col.CompareTag("Enemy"))
                    {
                        Destroy(col.gameObject);
                    }
                    if (col.CompareTag("Boss"))
                    {
                        for(int i = 0; i < 10; i++)
                        {
                            gameObject.GetComponent<PlayerState>().DMG = 100;
                            Instantiate(gameObject.GetComponent<PlayerAttack>().bullet, col.transform.position, Quaternion.identity);
                            if(PowerUpItem.count == 3)
                                gameObject.GetComponent<PlayerState>().DMG = 500;
                        }
                    }
                }
                Bquantity -= 1;
                Btime = 0;
            }
            else
            {
                StartCoroutine(uper("아직 사용할 수 없습니다."));
            }
        }
        else
            Btime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.K))
        {
            if (Htime >= 5 && Hquantity > 0)
            {
                gameObject.GetComponent<PlayerState>().HP += 1;
                Hquantity -= 1;
                Htime = 0;
            }
            else
            {
                StartCoroutine(uper("아직 사용할 수 없습니다."));
            }
        }
        else
            Htime += Time.deltaTime;
        skillB.fillAmount = Btime/10; 
        skillH.fillAmount = Htime/5;
        skillBT.text = Bquantity.ToString();
        skillHT.text = Hquantity.ToString();
    }
    IEnumerator uper(string text)
    {
        GameObject clone = Instantiate(skillText,can.transform);
        Text skill = clone.GetComponent<Text>();
        skill.color = Color.white;
        float one = 0;
        skill.text = text;
        while(one < 1)
        {
            yield return new WaitForSeconds(0.02f);
            skill.color = Color.Lerp(Color.white, Color.black, Time.deltaTime);
            skill.rectTransform.position = Vector3.Lerp(skill.rectTransform.position, new Vector3(skill.rectTransform.position.x, skill.rectTransform.position.y + 100, 0), Time.deltaTime);
            one += Time.deltaTime;
        }
        Destroy(clone);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector3.zero, r);
    }
}

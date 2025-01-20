using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public GameObject skillText;
    public GameObject can;

    float Htime;
    float Btime;

    int Bquantity = 0;
    int Hquantity = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.C))
        { 
            if (Btime >= 10 && Bquantity < 2)
            {
                Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5);
                foreach (Collider2D col in collider)
                {
                    if (col.CompareTag("Enemy"))
                    {
                        //col.GetComponent<State>().HP -= 1000;
                    }
                }
                Bquantity += 1;
                Btime = 0;
            }
            else
            {
                if (Bquantity < 2)
                    StartCoroutine(uper("��ź�� �����ϴ� �� �Դϴ�"));
                else
                    StartCoroutine(uper("��ź�� �޾ƿ��� �� ������ ������ϴ�"));
            }
        }
        else
            Btime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.K))
        {
            if (Htime >= 5 && Hquantity < 3)
            {
                gameObject.GetComponent<PlayerState>().HP += 1;
                Hquantity += 1;
                Htime = 0;
            }
            else
            {
                if (Hquantity < 3)
                {
                    StartCoroutine(uper("������ �޴� �� �Դϴ�"));
                }
                else
                    StartCoroutine(uper("��â�� �� ���������ϴ�"));
            }
        }
        else
            Htime += Time.deltaTime;
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
}

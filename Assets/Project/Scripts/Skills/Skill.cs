using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] public float cooldown;
    [SerializeField]  protected string skillName;
    [SerializeField]  protected string skillExplanation;
    [SerializeField]  protected Sprite skillSprite;
    // Start is called before the first frame update


    public void ClickSkill()
    {
        StartCoroutine("SetCoolDown");
    }
    public abstract void StartSkill();

    public IEnumerator SetCoolDown()
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(cooldown);
        GetComponent<Button>().interactable = true;
    }
}

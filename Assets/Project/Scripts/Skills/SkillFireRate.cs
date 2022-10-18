using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFireRate : Skill
{
    // Start is called before the first frame update
    private DefaultAttack _defaultAttack;
    [SerializeField] private float coolDownRate = 0.1f;
    void Awake()
    {
        _defaultAttack = FindObjectOfType<DefaultAttack>();
    }

    // Update is called once per frame
   

    public override void StartSkill()
    {
        
        if ( _defaultAttack.cooldown>0.25f)
            _defaultAttack.cooldown -= coolDownRate;
       
    
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController
{
    private Skill currentSkill;
    private SkillObject currentSkillObject;
    private playercontroler Playercontroler;
    private Dictionary<SkillType, Skill> skills;
    public int remainCount = 0;
    public float coolDown = 0f;
    public event Action<SkillObject> OnSkillChanged;
    public event Action<SkillObject> OnSkillUsed;

    public SkillController(playercontroler playercontroler)
    {
        currentSkill = null;
        currentSkillObject = null;
        this.Playercontroler = playercontroler;
        skills = new Dictionary<SkillType, Skill>()
        {
            {SkillType.Jump, new JumpSkill(playercontroler)},
            {SkillType.Dash, new DashSkill(playercontroler)},
            {SkillType.Bomb, new BombSkill(playercontroler)}
        };
    }
    
    public void UseSkill()
    {
        OnSkillUsed?.Invoke(currentSkillObject);
        if (remainCount <= 0)
        {
            DeleteSkill();
            return;
        }
        currentSkill?.Tick();
        remainCount--;
    }

    public void ChangeSkill(SkillObject skillObject)
    {
        if(skillObject == null) return;
        currentSkillObject = skillObject;

        OnSkillChanged?.Invoke(currentSkillObject);
        
        coolDown = currentSkillObject.coolDown;
        remainCount = currentSkillObject.amount;
        if (skills[currentSkillObject.type] == null) return;
        currentSkill = skills[currentSkillObject.type];
    }

    public void DeleteSkill()
    {
        currentSkill = null;
    }
}

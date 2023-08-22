using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBot : PlayerAbility
{
    [SerializeField] private GameObject _followBotObject;
    private int _availableFollowBots = 1;
    private int _currentFollowBot = 1;

    private void Update()
    {
        
    }

    protected override void Activate()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    #region  PositionByAnimation

    [SerializeField] private Animator animatorPuller, animatorLocker;
    [Range(0,1)]
    [SerializeField] private float _pull;
    [SerializeField] private bool test;

    private float save;
    OnTargetReached onTargetReached;

    private void Start()
    {
        onTargetReached = GetComponent<OnTargetReached>();
    }
    
    public void posActivate()
    {
        PositionByAnimation("Pull", "Lock", 1);
        save = 1;
    }
    public void PositionByAnimation(string Var1, string Var2, float pos)
    {
        save = pos;
        animatorPuller.SetFloat(Var1, pos); animatorPuller.SetFloat(Var2, pos);
        animatorLocker.SetFloat(Var1, pos); animatorLocker.SetFloat(Var2, pos);
    }

    public void OnEnable()
    {
        posActivate();
    }

    private void Update()
    {
        if(!test) {return;}
        onTargetReached.test = test;
        PositionByAnimation("Pull", "Lock", _pull);
    }
    
    public void SetAnimation()
    {
        PositionByAnimation("Pull", "Lock", save);
    }

    #endregion    
}

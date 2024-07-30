
using Game.Field;
using Game.Item;
using UnityEngine;

public class FrogEffectsController : MonoBehaviour
{
    private const string _animationParameter = "isWalk";
    [SerializeField] private Animator _animator;
    [SerializeField] private FrogMoveController _frogMoveController;

    void Awake()
    {
        _frogMoveController.InitOnWalkActions(SetWalkAnimation, SetIdleAnimation);
    }

    public void SetIdleAnimation()
    {
        _animator.SetBool(_animationParameter, false);
    }

    public void SetWalkAnimation()
    {
        _animator.SetBool(_animationParameter, true);
    }

    
}

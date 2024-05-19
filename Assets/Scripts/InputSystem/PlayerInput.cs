using System;
using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
   private InputSystem _inputSystem;
   private IControllable _iControllable;
   
   [Inject]
   private void Construct(IControllable iControllable)
   {
      _iControllable = iControllable;
   }
   
   private void Awake()
   {
      _inputSystem = new();
      _inputSystem.Enable();
   }

   private void Update()
   {
      _iControllable.Move(ReadMoveValue());
   }

   private Vector2 ReadMoveValue()
   {
      return _inputSystem.Game.Movement.ReadValue<Vector2>();
   }
}

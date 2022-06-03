using UnityEngine;

namespace PlayerCommand
{
    public interface IPlayerCommand
    {
        // void AdjustGravity();
 
        void Execute(GameObject gameObject);
    }
}

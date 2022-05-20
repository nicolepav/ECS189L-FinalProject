using UnityEngine;

namespace PlayerCommand
{
    public interface IPlayerCommand
    {
        void Execute(GameObject gameObject);
        void MoveHorizontally(GameObject gameObject, int[] gravityDir);
        void Jump(GameObject gameObject, int[] gravityDir);
    }
}

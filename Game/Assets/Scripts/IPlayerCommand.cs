using UnityEngine;

namespace PlayerCommand
{
    public interface IPlayerCommand
    {
        void Execute(GameObject gameObject);
    }
}

using UnityEngine;

namespace _Project.CodeBase.Services.InputService
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis => InputAxis();
    }
}
using UnityEngine;

namespace _Project.CodeBase.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis => InputAxis();
    }
}
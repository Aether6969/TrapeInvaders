﻿using GameEngine;

namespace GDD_Eksamen
{
    internal sealed class WFInputController : IInputManager
    {
        public float Vertical => throw new NotImplementedException();

        public float Horizontal => -1;

        public bool GetKeyShoot()
        {
            return true;
        }
    }
}

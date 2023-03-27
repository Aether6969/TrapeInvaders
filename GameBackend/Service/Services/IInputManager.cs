using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    public interface IInputManager
    {
        public float Vertical { get; }
        public float Horizontal { get; }

        public bool GetKeyShoot();
    }
}

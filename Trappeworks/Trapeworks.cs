using GameEngine;

namespace Trappeworks
{
    public sealed class Trapeworks : Game
    {
        public Trapeworks(IInputManager inputManager, IRenderTarget renderTarget) : base(inputManager, renderTarget)
        {
            //AddObjectToScene(
            //    FireWorksManager.Create(this));

            AddObjectToScene(EmptyGameObj.Create(this, 0, funnynamespace.Textures.image));
        }
    }
}
﻿using GameEngine;

namespace TrapeInvaders
{
    public sealed class Player : GameObj
    {
        public GameState GameState { get; }
        private Player(Transform transform, Game game, GameState gameState) 
            : base(game, transform, Textures.Player) 
        { 
            this.GameState = gameState;
        }

        public static Player Create(Vec2 pos, Game game, GameState gameState)
        {
            return new Player(
                new Transform(pos, new Vec2(7, 5)), 
                game,
                gameState);
        }

        public override void Update()
        {
            if (!Game.OnecePerFrames(2)) return;

            IInputManager input = Game.InputManager;

            int x = Transform.Pos.x + (int)input.Horizontal;
            if (x < 0 || x + Texture!.Width > 50)
            {
                x = Transform.Pos.x;
            }

            Transform.Pos = new Vec2(x, Transform.Pos.y);

            if (input.GetKeyShoot())
            {
                Shoot();
            }
        }

        public void Shoot()
        {

        }
    }
}

using GameEngine;

namespace TrapeInvaders
{
    internal sealed class Hud : GameObj
    {
        private MonoColTexture _Score;
        private SegmentDisplay _SegmentDisplay;

        private MonoColTexture _Heart;
        private DigitTexture _HealthDigit;

        private MonoColTexture _ButtomStrip;

        public Hud(Game game) 
            : base(game, new Transform(new Vec2(0, 93), new Vec2(50, 7)), null)
        {
            this._Score = Textures.Score;
            game.AddObjectToScene(
                EmptyGameObj.Create(
                    game,
                    new Vec2(0, 95),
                    _Score));

            this._SegmentDisplay = SegmentDisplay.Create(5, game, new Vec2(21, 95));
            game.AddObjectToScene(_SegmentDisplay);

            this._Heart = Textures.Heart;
            game.AddObjectToScene(
                EmptyGameObj.Create(
                    game,
                    new Vec2(41, 95),
                    _Heart));

            this._HealthDigit = new DigitTexture(3);
            _HealthDigit.Color = Pixel.HeartRed;
            game.AddObjectToScene(
                EmptyGameObj.Create(
                    game,
                    new Vec2(47, 95),
                    _HealthDigit));

            this._ButtomStrip = Textures.BottomStrip;
            game.AddObjectToScene(
                EmptyGameObj.Create(
                    game,
                    new Vec2(0, 93),
                    _ButtomStrip));
        }

        public static Hud Create(Game game)
        { 
            return new Hud(game); 
        }
    }
}

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

        public Hud(Game game, Transform transform) 
            : base(game, transform, null)
        {
            this._Score = Textures.Score;
            game.Instantiate(
                EmptyGameObj.Create(
                    game,
                    new Vec2(0, 95),
                    _Score));

            this._SegmentDisplay = SegmentDisplay.Create(5, game, new Vec2(22, 95));
            game.Instantiate(_SegmentDisplay);

            this._Heart = Textures.Heart;
            game.Instantiate(
                EmptyGameObj.Create(
                    game,
                    new Vec2(41, 95),
                    _Heart));

            this._HealthDigit = new DigitTexture(3, 5, 3);
            game.Instantiate(
                EmptyGameObj.Create(
                    game,
                    new Vec2(47, 95),
                    _HealthDigit));

            this._ButtomStrip = Textures.BottomStrip;
            game.Instantiate(
                EmptyGameObj.Create(
                    game,
                    new Vec2(0, 93),
                    _ButtomStrip));
        }
    }
}

namespace UI.Type
{
    public class EventType
    {
        public enum ButtonEventType
        {
            Undo,
            Active,
            Exit,
            EnterBrush, //빗 미니게임 진입
            TalkDebtCollector, //전투.
        }
        public enum ActivePenelType
        {
            Setting,
            BrushMiniGame,
        }
    }
}
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
            TalkDebtCollector, //전투 전 대화
        }
        public enum ActivePenelType
        {
            Setting,
            BrushMiniGame,
            DebtTalkPenel,
            ChooseFight, //사채업자와 싸울지 결정
        }
    }
}
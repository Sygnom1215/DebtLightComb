namespace UI.Type
{
    public class EventType
    {
        public enum ButtonEventType
        {
            Undo,
            Active,
            Exit,
            EnterBrush, //�� �̴ϰ��� ����
            TalkDebtCollector, //���� �� ��ȭ
        }
        public enum ActivePenelType
        {
            Setting,
            BrushMiniGame,
            DebtTalkPenel,
            ChooseFight, //��ä���ڿ� �ο��� ����
            PayDebt, //�� ���� �г�
            Fight, //����
        }
    }
}
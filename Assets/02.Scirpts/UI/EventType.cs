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
            VerifiNum, //���� �� �Է� Ȯ��
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
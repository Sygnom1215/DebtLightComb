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
            ComeDebt, //��ä���� ã�ƿ�
            TalkDebtCollector, //���� �� ��ȭ
            VerifiNum, //���� �� �Է� Ȯ��
        }
        public enum ActivePenelType
        {
            Setting,
            BrushMiniGame,
            DebtTalkPenel,
            EnterDebt,
            ChooseFight, //��ä���ڿ� �ο��� ����
            PayDebt, //�� ���� �г�
            Fight, //����
        }
    }
}
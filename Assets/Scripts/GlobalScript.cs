using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GlobalScript : MonoBehaviour
{
    public int questNumber = -1, questType = -1;
    [SerializeField] private Text textHead, textQuestion, textNumber, textCode, textCodeNumber, passwordText;
    [SerializeField] private Text[] textAnswer;
    [SerializeField] private GameObject fallObject, winObject, levelmenu;

    public string[,] questions =
    {
        {
            "�1 ���� � ���� ���������� ������� ���������� i��� 2022",
            "1. � ��� ���� ���� �������� ����� �������� ���� 2022?",
            "2. ���� ������� �� ��������� ���������� ����.",
            "3. �� �� �������� ����� ���� ����� �������� ����?"
        },
        {
            "�2 ������ ����",
            "1. ���� ����������� ����������� ��������� ���� �������?",
            "2. ������� ��������� ���� �������.",
            "3. �� �������� ������?"
        },
        {
            "�3 �������� ����",
            "1. ��� ����� ����� ������ � 2018, ��� �� ����� � 2022?",
            "2. � ������� ���� ������� ������ ����� 4 ������ ������ � ��� ��������� ��������� ��䳿?",
            "3. �� ������ ����� ����� � ���������� ���������, ��� �� ����� � 2018?"
        },
        {
            "�4 ���� ������, ��������� �� ������� �������",
            "1. ������ ���� ������ �������� �� ��������?",
            "2. ������ � ���� ��������� �������� 7 ���� ������?",
            "3. ������ �� ������-2022 � ���� ���� �������� ��������� �������?"
        },
        {
            "�5 ����� �� �������",
            "1. � ������� ��������� ����� ������ �������-2022?",
            "2. ���������� ��������� ������� ���������� ���� 2022 ����?",
            "3. �� ����������� ����������� ����� ��������� ����� � ����?"
        }
    };
    public string[,,] questionsAnswers =
    {
        {
            {
                "�����",
                "���������",
                "���������"
            },
            {
                "3 ������ - 1 �������",
                "8 ������� - 25 �������",
                "4 ������ - 20 ������"
            },
            {
                "24",
                "22",
                "25"
            }
        },
        {
            {
                "17 ������� 2021",
                "19 ������� 2021",
                "10 ������ 2020"
            },
            {
                "����� � ������ �� �����������",
                "����� ������ �������� �����������",
                "����� � ������ ������ �������� �����������"
            },
            {
                "������ ������� ������ ���� ��������� ����� � ��'� �����������",
                "���� �� ��������, �� ������� �� ������� �����������",
                "������ ������� � ������ ��������� ����� � ��'� �����������"
            }
        },
        {
            {
                "ϳ����� �����",
                "�����",
                "˳���������"
            },
            {
                "89",
                "95",
                "100"
            },
            {
                "�������� �� �����",
                "˳���, ������ �� �����",
                "��� �� ����"
            }
        },
        {
            {
                "5",
                "9",
                "7"
            },
            {
                "12",
                "15",
                "14"
            },
            {
                "95",
                "109",
                "87"
            }
        },
        {
            {
                "5",
                "2",
                "3"
            },
            {
                "������������ ������������� ������",
                "���������� ����� ���e���",
                "������� ��i�-e�� �����"
            },
            {
                "������",
                "������������ ����� ������������� ������",
                "����������"
            }
        }
    };
    public int[,] rightAnswer =
    {
        {0,2,0},
        {0,1,0},
        {0,1,2},
        {2,1,1},
        {2,2,1}
    };

    private int[] codeForSafe = { 8, 9, 5, 6, 3 };
    public string password = "";

    public void UpdatePassword()
    {
        passwordText.text = password;
    }
    public void UpdateAnswer(int id, int number)
    {
        questType = id;
        questNumber = number;
        if(questType != -1)
        {
            textHead.text = questions[questType, 0];
            textQuestion.text = "";
            textQuestion.DOText(questions[questType, questNumber+1], 1f);
            textNumber.text = "������� " + (questNumber + 1) + "/3";

            for (int i = 0; i < 3; i++)
            {
                textAnswer[i].text = "";
                textAnswer[i].DOText(questionsAnswers[questType, questNumber, i], 0.5f);
            }
        }
    }

    public void GiveAnswer(int id)
    {
        if (id == rightAnswer[questType, questNumber])
        {
            if (++questNumber > 2)
            {
                levelmenu.SetActive(false);
                winObject.SetActive(true);
                textCode.text = "" + codeForSafe[questType];
                switch(questType)
                {
                    case 0:
                        textCodeNumber.DOText("���� ����� �����:", 1);
                        break;
                    case 1:
                        textCodeNumber.DOText("���� ����� �����:", 1);
                        break;
                    case 2:
                        textCodeNumber.DOText("���� ���Ҫ �����:", 1);
                        break;
                    case 3:
                        textCodeNumber.DOText("���� �������� �����:", 1);
                        break;
                    case 4:
                        textCodeNumber.DOText("���� �'��� �����:", 1);
                        break;
                }
            }
            else
            {
                UpdateAnswer(questType, questNumber);
            }
        }
        else
        {
            levelmenu.SetActive(false);
            fallObject.SetActive(true);
        }
    }
    /*fillimage.DOFade(1, 0.5f).OnComplete(() =>
        {
            fillimage.DOFade(0, 0.5f);
        }); */
}

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
            "№1 Дата і місце проведення зимових олімпійських iгор 2022",
            "1. У якій країні світу пройдуть зимові олімпійські ігри 2022?",
            "2. Дата початку та закінчення проведення ігор.",
            "3. Які за рахунком цього року зимові олімпійські ігри?"
        },
        {
            "№2 Слоган теми",
            "1. Коли організатори представили офіційний девіз змагань?",
            "2. Виберіть офіційний девіз змагань.",
            "3. Що відображає слоган?"
        },
        {
            "№3 Учасники ігор",
            "1. Яка країна брала участь у 2018, але не взяла у 2022?",
            "2. З скількох країн візьмуть участь понад 4 тисячі атлетів у цій найбільшій спортивній події?",
            "3. Які страни взяли учать у цьогорічних змаганнях, але не брали у 2018?"
        },
        {
            "№4 Види спорту, дисципліни та кількість медалей",
            "1. Скільки видів спорту включено до програми?",
            "2. Скільки в себе включають дисциплін 7 видів спорту?",
            "3. Скільки на Олімпіаді-2022 у Пекіні буде розіграно комплектів медалей?"
        },
        {
            "№5 Арени та стадіони",
            "1. У скількох кластерах Пекіну пройде Олімпіада-2022?",
            "2. Найцікавіша спортивна споруда Олімпійських ігор 2022 року?",
            "3. Де розташована гірськолижна траса найвищого класу у Китаї?"
        }
    };
    public string[,,] questionsAnswers =
    {
        {
            {
                "Китай",
                "Португалія",
                "Казахстан"
            },
            {
                "3 лютого - 1 березня",
                "8 березня - 25 березня",
                "4 лютого - 20 лютого"
            },
            {
                "24",
                "22",
                "25"
            }
        },
        {
            {
                "17 вересня 2021",
                "19 березня 2021",
                "10 серпня 2020"
            },
            {
                "Разом з рідними до майбутнього",
                "Разом заради спільного майбутнього",
                "Разом з нацією заради спільного майбутнього"
            },
            {
                "Спільне бажання всього світу працювати разом в ім'я майбутнього",
                "Жагу до перемоги, що приведе до кращого майбутнього",
                "Спільне бажання з нацією працювати разом в ім'я майбутнього"
            }
        },
        {
            {
                "Північна Корея",
                "Чехія",
                "Ліхтенштейн"
            },
            {
                "89",
                "95",
                "100"
            },
            {
                "Швейцарія та Латвія",
                "Ліван, Канада та Болівія",
                "Гаїті та Перу"
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
                "Національний ковзанярський стадіон",
                "Спортивний центр «Укeсон»",
                "Трамплін «Бiг-eйр Шоген»"
            },
            {
                "Яньцин",
                "Національний центр гірськолижного спорту",
                "Чжанцзякоу"
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
            textNumber.text = "Питання " + (questNumber + 1) + "/3";

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
                        textCodeNumber.DOText("ВАШЕ ПЕРШЕ ЧИСЛО:", 1);
                        break;
                    case 1:
                        textCodeNumber.DOText("ВАШЕ ДРУГЕ ЧИСЛО:", 1);
                        break;
                    case 2:
                        textCodeNumber.DOText("ВАШЕ ТРЕТЄ ЧИСЛО:", 1);
                        break;
                    case 3:
                        textCodeNumber.DOText("ВАШЕ ЧЕТВЕРТЕ ЧИСЛО:", 1);
                        break;
                    case 4:
                        textCodeNumber.DOText("ВАШЕ П'ЯТЕ ЧИСЛО:", 1);
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

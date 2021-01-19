using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour
    // Главный скрипт отвечающий если не за всё, то почти за всё.
{
    public GameObject KnifeObj;

    int NumberApple;

    public GameObject AppleObj;
    [SerializeField]
    GameObject animationZone;


    //Канвас выводимый при лузе
    public Canvas LoseCanvas;

    // Был вариант сделать рандомную генерацию кинжалов в дереве, но тогда пришлось бы запариться с координатами. Потому я просто сделал префабы
    // балок из которых буду выбирать
    public List<GameObject> Balks;
    public GameObject ThisBalk;

    //Тексты для вывода данных
    [SerializeField]
    Text currentResult, Trecord, knife, apple;

    // Количество ножей выдаваемое игроку, а так же их максимальное и минимальное колчество
    // Я знаю про инкапсуляцию, но в данном случае я не вижу причин прописывать её
    public int KnifeNumber;
    public int MinKnife, MaxKnife;
    [SerializeField]
    int result;
    [SerializeField]
    int record;

    //тут происходит стартовая настройка
    private void Start()
    {
        NumberApple = PlayerPrefs.GetInt("Apple");
        apple.text = System.Convert.ToString(NumberApple);
        record = PlayerPrefs.GetInt("Record");
        Trecord.text = System.Convert.ToString(record);

        GameObject obj = KnifeObj;
        Instantiate(obj, new Vector3(0, -3.42f), Quaternion.Euler(0, 0, -90));
        

        StartKnife();
        CreateBalk();
    }

    private void OnEnable()
    {
        Vibration.Init();
        GameObject obj = KnifeObj;
        Knife.OtherKnife += () =>
        {
            KnifeNumber--;
            if (KnifeNumber == 0)
            {
                result++;
                ThisBalk.transform.parent = Instantiate(animationZone, new Vector3(0, 2.15f), new Quaternion()).transform;
                animationZone.GetComponent<Animation>().Play();
                Vibration.VibratePeek();
                currentResult.text = System.Convert.ToString(result);
            }
            else
            {
                Instantiate(obj, new Vector3(0, -3.42f), Quaternion.Euler(0, 0, -90));
            }
            knife.text = System.Convert.ToString(KnifeNumber);
        };
        Knife.KnifesLose += () =>
        {
            LoseCanvas.enabled = true;
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Apple", NumberApple);
            if (result > record)
            {
                PlayerPrefs.SetInt("Record", result);
            }
            PlayerPrefs.Save();
        };
        Knife.PlusApple += () =>
        {
            NumberApple++;
            apple.text = System.Convert.ToString(NumberApple);
        };
    }

    // Скрипт стартовой настройки балки
    public void CreateBalk ()
    {
        Apple a = new Apple();
        System.Random r = new System.Random();
        ThisBalk = Instantiate(Balks[r.Next(Balks.Count)], new Vector3(0, 2.22f), new Quaternion());
    }


    public void StartKnife ()
    {
            if (MaxKnife > 0 && MinKnife > 0)
            {
                System.Random random = new System.Random();
                KnifeNumber = random.Next(MinKnife, MaxKnife);
            }
            else
            {
                System.Random random = new System.Random();
                KnifeNumber = random.Next(5, 8);
            }
    }
}

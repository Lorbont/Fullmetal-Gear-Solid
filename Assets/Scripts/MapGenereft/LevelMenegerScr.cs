using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelMenegerScr : MonoBehaviour
{
    public int fieldWidth, fieldHeight; // переменые ширены и длины поля
    public GameObject[] CellPrefs; // клетки которые нужно создавать

    public Transform setParent; // Обьект под ктороым будем создавать клетки поля 
    public Transform CreationPoint;

    public Sprite[] tileSpr = new Sprite[5];

    Sprite spr;


    void Start()
    {
        CreateLevel();
    }

    void CreateLevel()
    {
        Vector3 worldVec = CreationPoint.transform.position;

        for (int i = 0; i < fieldHeight; i++) //проходим по длине
            for (int k = 0; k < fieldWidth; k++) // проходим по ширене
            {
                Sprite spr;

                int sprIndex = int.Parse(LoadLevelText(1)[i].ToCharArray()[k].ToString());
                if (sprIndex != 0)
                {                                     
                    spr = tileSpr[0];            
                }
                else
                {
                    spr = tileSpr[UnityEngine.Random.Range(1, tileSpr.Length)]; 
                }



                CreateCell(spr, k, i, worldVec); // записываем в каординаты и запускаем метод создания
            }


    }

    void CreateCell(Sprite spr, int x, int y, Vector3 wV)
    {
        int selectedCell = UnityEngine.Random.Range(0, CellPrefs.Length); // рандомно выбираем какую клетку поля будем создавать
        
        GameObject tmplCell = Instantiate(CellPrefs[selectedCell]); // создаем выбранные клетки поля
        tmplCell.transform.SetParent(setParent, false); // для того чтобы клетки поля создавались под обьектом Cell

        tmplCell.GetComponent<SpriteRenderer>().sprite = spr;

        float sprSizeX = tmplCell.GetComponent<SpriteRenderer>().bounds.size.x; // берем размер спрайта (клетки поля) по x
        float sprSizeY = tmplCell.GetComponent<SpriteRenderer>().bounds.size.y; // берем размер спрайта (клетки поля) по y

        tmplCell.transform.position = new Vector3(wV.x + (sprSizeX * x), wV.y + (sprSizeY * -y));
    }

    string[] LoadLevelText(int i)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>("Level" + i + "Ground");

        string tmpStr = tmpTxt.text.Replace(Environment.NewLine, string.Empty);

        return tmpStr.Split('!');
    }

}


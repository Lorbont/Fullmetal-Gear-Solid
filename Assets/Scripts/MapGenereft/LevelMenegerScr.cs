using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelMenegerScr : MonoBehaviour
{
    public int fieldWidth, fieldHeight; // ��������� ������ � ����� ����
    public GameObject[] CellPrefs; // ������ ������� ����� ���������

    public Transform setParentCreationPoint; // ������ ��� ������� ����� ��������� ������ ���� 

   

    void Start()
    {
        CreateLevel();
    }

    void CreateLevel()
    {
        Vector3 worldVec = setParentCreationPoint.transform.position;

        for (int i = 0; i < fieldHeight; i++) //�������� �� �����
            for (int k = 0; k < fieldWidth; k++) // �������� �� ������
            {
                GameObject spr;

                int sprIndex = int.Parse(LoadLevelText(1)[i].ToCharArray()[k].ToString());
                if (sprIndex == 0)
                {
                    spr = CellPrefs[sprIndex];
                }
                else
                {
                    spr = CellPrefs[UnityEngine.Random.Range(1, CellPrefs.Length)];
                }



                CreateCell(spr, k, i, worldVec); // ���������� � ���������� � ��������� ����� ��������
            }


    }

    void CreateCell(GameObject spr, int x, int y, Vector3 wV)
    {

        GameObject tmplCell = Instantiate(spr); // ������� ��������� ������ ����
        tmplCell.transform.SetParent(setParentCreationPoint, false); // ��� ���� ����� ������ ���� ����������� ��� �������� Cell

        float sprSizeX = tmplCell.GetComponent<SpriteRenderer>().bounds.size.x; // ����� ������ ������� (������ ����) �� x
        float sprSizeY = tmplCell.GetComponent<SpriteRenderer>().bounds.size.y; // ����� ������ ������� (������ ����) �� y

        tmplCell.transform.position = new Vector3(wV.x + (sprSizeX * x), wV.y + (sprSizeY * -y));
    }

    string[] LoadLevelText(int i)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>("Level" + i + "Ground");

        string tmpStr = tmpTxt.text.Replace(Environment.NewLine, string.Empty);

        return tmpStr.Split('!');
    }

}

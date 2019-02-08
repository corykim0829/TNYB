﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomManager : MonoBehaviour
{
    public GameObject[] tile = new GameObject[4];// 0: yellow, 1: green, 2: blue, 3: gray
    public GameObject[] bed = new GameObject[3]; //0: red, 1: blue, 2: purple
    public GameObject[] table = new GameObject[5]; //0: pc-table_gray 1: pc-table_red 2: pc-table_blue 3: table_2 4: tv-table;
    public GameObject[] sofa = new GameObject[6]; // 0: sofa_red, 1:sofa_blue 2: sofa_green 3: sofa2_red, 4: sofa2_blue, 5: sofa2_green;
    public GameObject[] chair = new GameObject[3]; //0: chair_gray, 1: chair_red, 2:chair_blue
    public GameObject[] picture = new GameObject[3]; //0: picture_yellow, 1:picture_red, 2:picture_blue
    public GameObject[] appliance = new GameObject[3]; //0: computer, 1:tv, 2:lamp
    public GameObject[] etc = new GameObject[2]; //0: trashcan 1: rug
    public GameObject[] furniture = new GameObject[2]; //0: closet, 1: library
    public GameObject door; //문 포함 32개

    private bool[] tile_bool = new bool[4]; // 0: yellow, 1: green, 2: blue, 3: gray
    private bool[] bed_bool = new bool[3]; // 0: red, 1: blue, 2: purple
    private bool[] table_bool = new bool[5]; //0: pc-table_gray 1: pc-table_blue 2: pc-table_red 3: table_2 4: tv-table;
    private bool[] sofa_bool = new bool[6]; // 0: sofa_red, 1:sofa_blue 2: sofa_green 3: sofa2_red, 4: sofa2_blue, 5: sofa2_green;
    private bool[] chair_bool = new bool[3]; //0: chair_gray, 1: chair_red, 2:chair_blue
    private bool[] picture_bool = new bool[3];//0: picture_yellow, 1:picture_red, 2:picture_blue
    private bool[] appliance_bool = new bool[3];//0: computer, 1:tv, 2:lamp
    private bool[] furniture_bool = new bool[2];
    private bool[] etc_bool = new bool[2]; //0:trashcan 1: rug



    public GameObject ItemInventory;
    public GameObject ButtonPanel;
    public GameObject SelectGamePanel;
    public GameObject RankingPanel;
    public GameObject PurchasePanel;
    public int gameMoney = 10000;

    private void Start()
    {
        //PurchasePanel.SetActive(false);
        door.SetActive(true);
    }
    public void OpenRankingPanel()
    {
        RankingPanel.SetActive(true);
        ButtonPanel.SetActive(false);
    }
    public void CloseRankingPanel()
    {
        RankingPanel.SetActive(false);
        ButtonPanel.SetActive(true);
    }
    public void OpendSelectGame()
    {
        SelectGamePanel.SetActive(true);
        ButtonPanel.SetActive(false);

    }
    public void CloseSlelectGame()
    {
        SelectGamePanel.SetActive(false);
        ButtonPanel.SetActive(true);
    }

    public void OpenInventory()
    {
        ItemInventory.SetActive(true);
        ButtonPanel.SetActive(false);
    }
    public void CloseInventory()
    {
        ItemInventory.SetActive(false);
        ButtonPanel.SetActive(true);
    }
    public void ItemPurchase()
    {
         
         //table.SetActive(true);
    }
    public void OpenPurchasePanel()
    {
        PurchasePanel.SetActive(true);
    }
    public void ClosePurchasePanel()
    {
        PurchasePanel.SetActive(false);
    }
    //=========================================
    //타일 설정 함수
    void SetTile(int a)
    {
        for (int i = 0; i < tile.Length; i++)
            tile[i].SetActive(false);
        tile[a].SetActive(true);
    }
    void UnSetTile(int a){tile[a].SetActive(false);}

    //침대 설정 함수
    void SetBed(int a)
    {
        for (int i = 0; i < bed.Length; i++)
            bed[i].SetActive(false);
        bed[a].SetActive(true);
    }
    void UnSetBed(int a){bed[a].SetActive(false);}

    //table 설정 함수
    void SetTable(int a)
    {
        if (a < 3)
        {
            for (int i = 0; i < 3; i++)
                table[i].SetActive(false);
            table[a].SetActive(true);
        }
        else
        {
            table[a].SetActive(true);
        }
    }
    void UnSetTable(int a){table[a].SetActive(false);}

    // 소파 설정 함수
    void SetSofa(int a)
    {
        if (a < 3)
        {
            for (int i = 0; i < 3; i++)
                sofa[i].SetActive(false);
            sofa[a].SetActive(true);
        }
        else
        {
            for (int i = 3; i < sofa.Length; i++)
                sofa[i].SetActive(false);
            sofa[a].SetActive(true);
        }


    }
    void UnSetSofa(int a){sofa[a].SetActive(false);}

    //의자 설정 함수
    void SetChair(int a)
    {
        for (int i = 0; i < chair.Length; i++)
            chair[i].SetActive(false);
        chair[a].SetActive(true);
    }
    void UnSetChair(int a){chair[a].SetActive(false);}

    //액자 설정 함수
    void SetPicture(int a)
    {
        for (int i = 0; i < picture.Length; i++)
            picture[i].SetActive(false);
        picture[a].SetActive(true);
    }
    void UnSetPicture(int a) { picture[a].SetActive(false); }

    //전자기기 설정 함수
    void SetAppliance(int a){appliance[a].SetActive(true);}
    void UnSetAppliance(int a) { appliance[a].SetActive(false); }

    //가구 설정 함수
    void SetFurniture(int a){furniture[a].SetActive(true);}
    void UnSetFurniture(int a) { furniture[a].SetActive(false); }

    //기타 설정 함수
    void SetEtc(int a){etc[a].SetActive(true);}
    void UnSetEtc(int a) { etc[a].SetActive(false); }

    //==================================================
    //클릭 함수
    public void ClickButton_Tile()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (tile_bool[a])
        {
            tile_bool[a] = false;
            UnSetTile(a);
        }
        else
        {
            SetTile(a);
            tile_bool = new bool[4];
            tile_bool[a] = true;
        }
        RealtimeDatabase.Instance.SetMyRoomData("tile_bool", tile_bool);
    }
    public void ClickButton_Bed()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (bed_bool[a])
        {
            bed_bool[a] = false;
            UnSetBed(a);
        }
        else
        {
            bed_bool = new bool[3];
            bed_bool[a] = true;
            SetBed(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("bed_bool", bed_bool);
    }
    public void ClickButton_Table()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (table_bool[a])
        {
            table_bool[a] = false;
            UnSetTable(a);
        }
        else
        {
            if (a < 3)
                for (int i = 0; i < 3; i++)
                    table_bool[i] = false;

            table_bool[a] = true;

            SetTable(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("table_bool", table_bool);
    }
    public void ClickButton_Sofa()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name[0]);
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (sofa_bool[a])
        {
            sofa_bool[a] = false;
            UnSetSofa(a);
        }
        else
        {
            if(a<3)
            {
                for (int i = 0; i < 3; i++)
                    sofa_bool[i] = false;
            }
            else
            {
                for (int i = 3; i < 6; i++)
                    sofa_bool[i] = false;
            }
            sofa_bool[a] = true;
            SetSofa(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("sofa_bool", sofa_bool);
    }
    public void ClickButton_Chair()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (chair_bool[a])
        {
            chair_bool[a] = false;
            UnSetChair(a);
        }
        else
        {
            chair_bool = new bool[3];
            chair_bool[a] = true;
            SetChair(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("chair_bool", chair_bool);
    }
    public void ClickButton_Picture()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (picture_bool[a])
        {
            picture_bool[a] = false;
            UnSetPicture(a);
        }
        else
        {
            picture_bool = new bool[3];
            picture_bool[a] = true;
            SetPicture(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("picture_bool", picture_bool);
    }
    public void ClickButton_Appliance()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (appliance_bool[a])
        {
            appliance_bool[a] = false;
            UnSetAppliance(a);
        }
        else
        {
            appliance_bool[a] = true;
            SetAppliance(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("appliance_bool", appliance_bool);
    }
    public void ClickButton_Furniture()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (furniture_bool[a])
        {
            furniture_bool[a] = false;
            UnSetFurniture(a);
        }
        else
        {
            furniture_bool[a] = true;
            SetFurniture(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("furniture_bool", furniture_bool);
    }
    public void ClickButton_Etc()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (etc_bool[a])
        {
            etc_bool[a] = false;
            UnSetEtc(a);
        }
        else
        {
            etc_bool[a] = true;
            SetEtc(a);
        }
        RealtimeDatabase.Instance.SetMyRoomData("etc_bool", etc_bool);
    }
    //=======================================================
}

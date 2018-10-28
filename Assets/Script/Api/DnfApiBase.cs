using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//서버 정보
public enum Server
{
    anton,
    bakal,
    cain,
    casillas,
    diregie,
    hillder,
    prey,
    siroco
};

/// <summary>
/// Api기본 클래스
/// </summary>
public abstract class DnfApiBase : MonoBehaviour {

    /// <summary>
    /// 동일단어
    /// 앞단어
    /// 전문
    /// </summary>
    public enum WorldType
    {
        macth,
        front,
        full
    };

    /// <summary>
    /// 아이템 슬롯 이름
    /// </summary>
    public List<string> _SlotName = new List<string> { "무기", "칭호","머리어깨", "상의", "하의", "허리", "신발", "팔찌", "목걸이", "반지", "보조장비", "마법석", "귀걸이", "보조무기" };
    /// <summary>
    /// 능력치 이름
    /// </summary>
    public List<string> _Ability = new List<string> {"HP", "MP","힘","지능","체력","정신력","물리 공격","마법 공격","독립 공격","물리 방어", "마법 방어", "물리 크리티컬", "마법 크리티컬",
        "공격 속도", "캐스팅 속도", "이동 속도", "항마", "적중률", "회피율", "HP 회복량", "MP 회복량", "경직도", "히트리커버리", "화속성 강화", "화속성 저항", "수속성 강화", "수속성 저항", "명속성 강화", "명속성 저항", "암속성 강화", "암속성 저항" };

    /// <summary>
    /// 아바타 슬롯 이름
    /// </summary>
    public List<string> _Avatar = new List<string> {"모자 아바타", "머리 아바타", "얼굴 아바타", "상의 아바타", "하의 아바타", "신발 아바타", "목가슴 아바타", "허리 아바타", "오라 아바타", "피부 아바타", "무기 아바타" };

    public WorldType _WorldType;
    protected Server _Server;
    /// <summary>
    /// Api키
    /// </summary>
    protected string ApiKey = "kY6CeAILmIU4TKUufr1yaX4MNElGRMEh";

    protected abstract IEnumerator SearchData();

    public string GetServer(Server server)
    {
        string s = "";

        switch (server)
        {
            case Server.anton:
                s = "안톤";
                break;
            case Server.bakal:
                s = "바칼";
                break;
            case Server.cain:
                s = "카인";
                break;
            case Server.casillas:
                s = "카시야스";
                break;
            case Server.diregie:
                s = "디레지에";
                break;
            case Server.hillder:
                s = "힐러";
                break;
            case Server.prey:
                s = "프레이";
                break;
            case Server.siroco:
                s = "시로코";
                break;
        }

        return s;
    }
}

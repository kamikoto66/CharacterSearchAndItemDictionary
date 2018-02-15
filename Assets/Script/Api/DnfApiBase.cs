using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


public abstract class DnfApiBase : MonoBehaviour {

    public enum WorldType
    {
        macth,
        front,
        full
    };

    public List<string> _SlotName = new List<string> { "무기", "칭호","머리어깨", "상의", "하의", "허리", "신발", "팔찌", "목걸이", "반지", "보조장비", "마법석", "귀걸이", "보조무기" };
    public List<string> _Ability = new List<string> {"HP", "MP","힘","지능","체력","정신력","물리 공격","마법 공격","독립 공격","물리 방어", "마법 방어", "물리 크리티컬", "마법 크리티컬",
        "공격 속도", "캐스팅 속도", "이동 속도", "항마", "적중률", "회피율", "HP 회복량", "MP 회복량", "경직도", "히트리커버리", "화속성 강화", "화속성 저항", "수속성 강화", "수속성 저항", "명속성 강화", "명속성 저항", "암속성 강화", "암속성 저항" };


    public WorldType _WorldType;
    protected Server _Server;
    protected string ApiKey = "kY6CeAILmIU4TKUufr1yaX4MNElGRMEh";

    protected abstract IEnumerator SearchData();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MyLCard", menuName = "MyLCard")]
[System.Serializable]
public class MyLCard : ScriptableObject
{
    public string mylCardName;
    public string desc;

    public Sprite art;

    public int goldCost;
    public int attack;
    
    [Flags]
    public enum firstHalfProperties
    {
        Accelerate = 1,
        GroupUp = 2,
        Feed = 4,
        Nullify = 8,
        Shuffle = 16,
        BonusForce = 32,
        Searcher = 64,
        NegateAttack = 128,
        NegateHability = 256,
        Gnaw = 512,
        AllyControl = 1024,
        CementeryControl = 2048,
        GoldControl = 4096,
        TotemControl = 8192,
        AdditionalCost = 16384,
        AlternativeCost = 32768,
        DamageByBanish = 65536,
        DirectDamage = 131072,
        Discrad = 262144,
        DeleteHability = 524288,
        Ambush = 1048576,
        InResponse = 2097152,
        Spectral = 4194304,
        Spy = 8388608,
        Exhume = 16777216,
        Fury = 33554432,
        Guardian = 67108864,
        Ilusion = 134217728,
        Unblockeable = 268435456,
        Unbanish = 536870912,
        Indestructible = 1073741824,
    }

    [Flags]
    public enum secondHalfProperties
    {
        Unbanish            =1,
        Indestructible      =2,
        Light               =4,
        Mercenary           =8,
        Sort                =16,
        VirtualGold         =32,
        Darkness            =64,
        Purify              =128,
        Reanimate           =256,
        Recruit             =512,
        Resource            =1024,
        Redirection         =2048,
        DecreaseCost        =4096,
        DecreaseAttack      =8192,
        DecreaseForce       =16384,
        Removal             =32768,
        RestrictionAttack   =65536,
        RestrictionBlock    =131072,
        RestrictionSearch   =262144,
        RestrictionPlay     =524288,
        Return              =1048576,
        Draw                =2097152,
        GoldBreaker         =4194304,
        Tribute             =8388608,
        Unique              =16777216,
        Unblockeable        =33554432,
        Absorsion           =67108864,
    }

    [EnumFlags]
    public firstHalfProperties firstCardProperties;
    [EnumFlags]
    public secondHalfProperties SecondcardProperties;
}

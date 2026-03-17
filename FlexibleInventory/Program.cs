using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

List<Item> items = new()
{
    new Item("불꽃 검", "무기", "전설"),
    new Item("철 갑옷", "방어구", "일반"),
    new Item("체력 물약", "소비", "일반"),
    new Item("얼음 단검", "무기", "희귀"),
    new Item("미스릴 방패", "방어구", "희귀"),
};

Console.WriteLine("=== 타입별 그룹핑 ===");

// 배고픔

foreach (Item item in items)
{

}

class Item
{
    public string Name;
    public string Type;
    public string Grade;

    public Item(string name, string type, string grade)
    {
        Name = name;
        Type = type;
        Grade = grade;
    }

    public override string ToString() => $"- {Name} ({Grade})";
}

class ItemTypeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        return x.Type == y.Type;
    }

    public override int GetHashCode(Item obj)
    {
        return HashCode.Combine(obj.Name, obj.Type, obj.Grade);
    }
}

class ItemGradeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        return x.Grade == y.Grade;
    }

    public override int GetHashCode(Item obj)
    {
        return HashCode.Combine(obj.Name, obj.Type, obj.Grade);
    }
}
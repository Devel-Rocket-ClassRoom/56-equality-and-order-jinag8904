using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;

// 1.
{
    string s1 = "hello";
    string s2 = "hello";
    string s3 = new string("hello".ToCharArray());

    Console.WriteLine(s1 == s2);
    Console.WriteLine(s1 == s3);
    Console.WriteLine(ReferenceEquals(s1, s2));
    Console.WriteLine(ReferenceEquals(s1, s3));
}
Console.WriteLine();

// 2.
{
    Player p1 = new("이름", 1);
    Player p2 = new("이름", 1);
    Player p3 = p1;

    Console.WriteLine(p1 == p2);
    Console.WriteLine(p1 == p3);
    Console.WriteLine(p1.Equals(p2));
    Console.WriteLine(p1.Equals(p3));
}
Console.WriteLine();

// 3.
{
    Position pos1 = new(10, 20);
    Position pos2 = new(10, 20);
    Position pos3 = new(30, 40);

    Console.WriteLine(pos1.Equals(pos2));
    Console.WriteLine(pos1.Equals(pos3));
}
Console.WriteLine();

// 4.
{
    Item item1 = new Item("Sword", 1);
    Item item2 = new Item("Sword", 1);
    Item item3 = new Item("Shield", 2);

    Console.WriteLine(item1.Equals(item2));
    Console.WriteLine(item1.Equals(item3));

    HashSet<Item> inventory = new HashSet<Item>();
    inventory.Add(item1);
    Console.WriteLine(inventory.Contains(item2));
}
Console.WriteLine();

// 5.
{
    BadItem b1 = new("이름");
    BadItem b2 = new("이름");

    Console.WriteLine(b1.Equals(b2));

    Dictionary<BadItem, int> stock = new();
    stock.Add(b1, 1);
    Console.WriteLine(stock.ContainsKey(b2));
}
Console.WriteLine();

// 6.
{
    Monster[] monsters =
    {
        new Monster("Goblin", 30),
        new Monster("Dragon", 100),
        new Monster("Slime", 10),
        new Monster("Orc", 50)
    };

    Console.WriteLine("정렬 전:");
    foreach (Monster monster in monsters)
    {
        Console.WriteLine($"{monster}");
    }

    Array.Sort(monsters);

    Console.WriteLine("\n정렬 후:");
    foreach (Monster monster in monsters)
    {
        Console.WriteLine($"{monster}");
    }
}
Console.WriteLine();

// 7.
{
    Student[] students =
    {
        new Student("김철수", 2, 85),
        new Student("이영희", 1, 92),
        new Student("박민수", 2, 85),
        new Student("정수진", 1, 88),
        new Student("최동훈", 2, 90)
    };

    Array.Sort(students);

    Console.WriteLine("정렬 결과:");
    foreach (Student student in students)
    {
        Console.WriteLine($"{student}");
    }
}
Console.WriteLine();

// 8.
{
    Customer c1 = new Customer("Kim", "Cheolsu");
    Customer c2 = new Customer("Kim", "Cheolsu");

    // 기본 Dictionary - 참조 비교
    Dictionary<Customer, string> dict1 = new Dictionary<Customer, string>();
    dict1[c1] = "VIP";
    Console.WriteLine($"기본 Dictionary - c2 검색: {dict1.ContainsKey(c2)}");

    // 커스텀 비교기 사용 Dictionary - 값 비교
    Dictionary<Customer, string> dict2 = new Dictionary<Customer, string>(new CustomerNameComparer());
    dict2[c1] = "VIP";
    Console.WriteLine($"커스텀 Dictionary - c2 검색: {dict2.ContainsKey(c2)}");
}
Console.WriteLine();

// 9.
{
    Dictionary<string, int> caseInsensitive =
    new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    caseInsensitive["Apple"] = 100;
    caseInsensitive["BANANA"] = 200;

    Console.WriteLine(caseInsensitive["apple"]);
    Console.WriteLine(caseInsensitive["Banana"]);

    Dictionary<string, int> caseSensitive = new Dictionary<string, int>();
    caseSensitive["Apple"] = 100;

    Console.WriteLine(caseSensitive.ContainsKey("apple"));
}
Console.WriteLine();

// 10.
{
    List<Quest> quests = new List<Quest>
    {
        new Quest("드래곤 처치", 1, 10000),
        new Quest("보물 찾기", 2, 3000),
        new Quest("약초 수집", 3, 100),
        new Quest("마을 방어", 2, 500)
    };

    Console.WriteLine("우선순위 기준:");
    quests.Sort(new QuestPriorityComparer());
    foreach (Quest quest in quests)
    {
        Console.WriteLine(quest);
    }

    Console.WriteLine("\n보상 기준 (내림):");
    quests.Sort(new QuestRewardComparer());
    foreach (Quest quest in quests)
    {
        Console.WriteLine(quest);
    }
}
Console.WriteLine();

// 11.
{
    List<string> strings = new() { "apple", "Banana", "CHERRY", "date", "Elderberry" };
    
    strings.Sort(StringComparer.Ordinal);
    Console.WriteLine($"{string.Join(", ", strings)}");

    strings.Sort(StringComparer.OrdinalIgnoreCase);
    Console.WriteLine($"{string.Join(", ", strings)}");
}
Console.WriteLine();

// 12.
{
    List<Product> products = new()
    {
        new Product("마우스", 30000),
        new Product("모니터", 300000),
        new Product("헤드셋", 80000),
        new Product("키보드", 50000)
    };

    Console.WriteLine("가격 오름차순:");
    Comparer<Product> priceAsc = Comparer<Product>.Create(
    (x, y) => x.Price.CompareTo(y.Price)
    );
    products.Sort(priceAsc);
    foreach (var p in products)
    {
        Console.WriteLine(p);
    }

    Console.WriteLine("\n이름 내림차순:");
    Comparer<Product> nameDesc = Comparer<Product>.Create(
    (x, y) => y.Name.CompareTo(x.Name)
    );
    products.Sort(nameDesc);
    foreach (var p in products)
    {
        Console.WriteLine(p);
    }
}
Console.WriteLine();

// 13.
{
    SortedDictionary<int, string> scoreBoard = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

    scoreBoard[85] = "Kim";
    scoreBoard[92] = "Lee";
    scoreBoard[78] = "Park";
    scoreBoard[92] = "Choi";

    Console.WriteLine("점수 순위표:");
    int rank = 1;
    foreach (var s in scoreBoard)
    {
        Console.WriteLine($"{rank}위: {s.Value} ({s.Key}점)");
        rank++;
    }
}
Console.WriteLine();

// 14.
{
    HashSet<Equipment> equips = new(new EquipmentTypeComparer());
    equips.Add(new Equipment("불꽃 검", "무기"));
    equips.Add(new Equipment("철 갑옷", "방어구"));
    equips.Add(new Equipment("얼음 검", "무기"));
    equips.Add(new Equipment("가죽 장갑", "장갑"));

    foreach (var e in equips)
    {
        Console.WriteLine($"{e.type}: {e.name}");
    }
}
Console.WriteLine();

// 15.
{
    int[] numbers = { 1, 2, 3, 4, 5 };
    string[] words = { "apple", "banana", "cherry" };

    Console.WriteLine($"numbers에 3 포함: {Contains(numbers, 3)}");
    Console.WriteLine($"numbers에 10 포함: {Contains(numbers, 10)}");
    Console.WriteLine($"words에 'banana' 포함: {Contains(words, "banana")}");
    Console.WriteLine($"words에 'grape' 포함: {Contains(words, "grape")}");

    static bool Contains<T>(T[] array, T Target)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        foreach (var item in array)
        {
            if (comparer.Equals(item, Target)) return true;
        }

        return false;
    }
}

// 14.
class Equipment
{
    public string name;
    public string type;

    public Equipment(string n, string t)
    {
        name = n;
        type = t;
    }
}

class EquipmentTypeComparer : EqualityComparer<Equipment>
{
    public override bool Equals(Equipment x, Equipment y)
    {
        return x.type == y.type;
    }

    public override int GetHashCode(Equipment obj)
    {
        return obj?.type?.GetHashCode() ?? 0;
    }
}

// 12.
class Product
{
    public string Name;
    public int Price;

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString() => $"{Name}: {Price}원";
}

// 10.
class Quest
{
    public string Name;
    public int Priority;
    public int Reward;

    public Quest(string name, int priority, int reward)
    {
        Name = name;
        Priority = priority;
        Reward = reward;
    }

    public override string ToString()
    {
        return $"[우선순위{Priority}] {Name} (보상: {Reward}G)";
    }
}

class QuestPriorityComparer : Comparer<Quest>
{
    public override int Compare(Quest x, Quest y)
    {
        return x.Priority.CompareTo(y.Priority);
    }
}

class QuestRewardComparer : Comparer<Quest>
{
    public override int Compare(Quest x, Quest y)
    {
        return y.Reward.CompareTo(x.Reward);
    }
}

// 8.
class Customer
{
    public string LastName;
    public string FirstName;

    public Customer(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }
}

class CustomerNameComparer : EqualityComparer<Customer>
{
    public override bool Equals(Customer x, Customer y)
    {
        return x.LastName == y.LastName && x.FirstName == y.FirstName;
    }

    public override int GetHashCode(Customer obj)
    {
        return HashCode.Combine(obj.LastName, obj.FirstName);
    }
}

// 7.
class Student : IComparable<Student>
{
    string Name;
    int Grade;
    int Score;

    public Student(string name, int grade, int score)
    {
        Name = name;
        Grade = grade;
        Score = score;
    }

    public int CompareTo(Student other)
    {
        if (other == null) return 1;
        
        int result = Grade.CompareTo(other.Grade);  // 1차 비교
        if (result != 0) return result; // 0이 아님: 같지 않으면 그대로 리턴

        result = other.Score.CompareTo(Score); // 2차 비교 (내림차순)
        if (result != 0) return result; // 0이 아님: 같지 않으면 그대로 리턴

        return Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return $"{Grade}학년 {Name} ({Score}점)";
    }
}

// 6.
class Monster : IComparable<Monster>
{
    string Name;
    int Power;

    public Monster(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public int CompareTo(Monster other)
    {
        if (other == null) return 1;
        
        return Power.CompareTo(other.Power);
    }

    public override string ToString() => $"{Name}\t(전투력: {Power})";        
}

// 5.
class BadItem
{
    string Name;

    public BadItem(string name)
    {
        Name = name;
    }

    public override bool Equals(object obj)
    {
        BadItem other = obj as BadItem;

        if (other == null) return false;

        return Name == other.Name;
    }    
}

// 4.
class Item : IEquatable<Item>
{
    string Name;
    int Id;

    public Item(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public bool Equals(Item other)
    {
        if (other == null) return false;

        return Id == other.Id && Name == other.Name;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Item);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id);
    }
}

// 3.
struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x; 
        Y = y;
    }
}

// 2.
class Player
{
    string Name;
    int Level;

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
    }
}
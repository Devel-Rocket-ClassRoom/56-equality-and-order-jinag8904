using System;
using System.Collections.Generic;

{
    List<AuctionItem> items = new()
    {
        new AuctionItem("회복 물약", 5000, 3, "소비"),
        new AuctionItem("미스릴 갑옷", 35000, 8, "방어구"),
        new AuctionItem("전설의 검", 50000, 12, "무기"),
        new AuctionItem("불꽃 반지", 28000, 15, "장신구"),
        new AuctionItem("만능 물약", 5000, 20, "소비")
    };

    items.Sort(new BidComparer());
    Console.WriteLine("=== 입찰가 기준 정렬 ===");
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }    

    var comparer = Comparer<AuctionItem>.Create((x, y) => y.BidCount.CompareTo(x.BidCount));
    items.Sort(comparer);
    Console.WriteLine("\n=== 입찰 횟수 기준 정렬 ===");
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

class AuctionItem
{
    public string Name;
    public int CurrentBid;
    public int BidCount = 0;
    public string Category;

    public AuctionItem(string name, int currentBid, int bidCount, string category)
    {
        Name = name;
        CurrentBid = currentBid;
        BidCount = bidCount;
        Category = category;
    }

    public override string ToString() => $"{Name} [{Category}] - 입찰가: {CurrentBid}G (입찰 {BidCount}회)";
}

class BidComparer : Comparer<AuctionItem>
{
    public override int Compare(AuctionItem x, AuctionItem y)
    {
        int result = y.CurrentBid.CompareTo(x.CurrentBid);

        if (result != 0) return result;

        return x.Name.CompareTo(y.Name);
    }
}
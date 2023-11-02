//var arr = new int[] {1, 2, 3};
var arr = Enumerable.Range(0,10).ToArray();
Console.WriteLine(string.Join(" ", arr));

var myQuery =
    from v in arr
    select $"_{v}";

Console.WriteLine(string.Join(" ", myQuery));
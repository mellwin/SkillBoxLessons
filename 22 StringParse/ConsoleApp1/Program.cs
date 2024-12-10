double s = GetDoubleFromString("123.hy456");

Console.WriteLine(s);

static double GetDoubleFromString(string input)
{
    var i = input.Length - 1;
    double num;
    int rank = 0;
    double result = 0;
    do
    {
        try
        {
            num = GetNum(input[i]);
        }
        catch (Exception e) when (e.Message == "разделитель")
        {
            result = result * Math.Pow(10, -rank);
            rank = 0;
            i--;
            continue;
        }
        catch (Exception e) when (e.Message == "лишнее")
        {
            i--;
            continue;
        };

        result += num * Math.Pow(10, rank);

        i--;
        rank++;
    }
    while (i >= 0);

    return result;
}

static int GetNum(char input)
{
    switch (input)
    {
        case '0':
            return 0;
        case '1':
            return 1;
        case '2':
            return 2;
        case '3':
            return 3;
        case '4':
            return 4;
        case '5':
            return 5;
        case '6':
            return 6;
        case '7':
            return 7;
        case '8':
            return 8;
        case '9':
            return 9;
        case '.':
            throw new Exception("разделитель");
        case ',':
            throw new Exception("разделитель");
        default: throw new Exception("лишнее");
    }
}
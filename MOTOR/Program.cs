// See https://aka.ms/new-console-template for more information




string[] cards = new string[] { "AS", "KS", "QS", "JS", "TS", "9S", "8S", "7S", "6S", "5S", "4S", "3S", "2S",
                                "AH", "KH", "QH", "JH", "TH", "9H", "8H", "7H", "6H", "5H", "4H", "3H", "2H",
                                "AD", "KD", "QD", "JD", "TD", "9D", "8D", "7D", "6D", "5D", "4D", "3D", "2D",
                                "AC", "KC", "QC", "JC", "TC", "9C", "8C", "7C", "6C", "5C", "4C", "3C", "2C"};

string[] bidSeq = new string[] {"1C", "1D", "1H", "1S", "1NT", "2C", "2D", "2H", "2S", "2NT" , "3C", "3D", "3H", "3S", "3NT",
                                "4C", "4D", "4H", "4S", "4NT", "5C", "5D", "5H", "5S", "5NT", "6C", "6D", "6H", "6S", "6NT",
                                "7C", "7D", "7H", "7S", "7NT"};

char[] suitOrder = new char[] { 'S', 'H', 'D', 'C' };

int[][] bidPos = new int[][]
{
    new int[] {32, 7},
    new int[] {38, 15},
    new int[] {20, 17},
    new int[] {14, 9},
    new int[] {26, 7},
    new int[] {38, 13},
    new int[] {26, 17},
    new int[] {14, 11},
    new int[] {20, 7},
    new int[] {38, 11},
    new int[] {32, 17},
    new int[] {14, 13},
    new int[] {32, 5},
    new int[] {38, 9},
    new int[] {20, 19},
    new int[] {14, 15},
    new int[] {26, 5},
    new int[] {44, 15},
    new int[] {26, 19},
    new int[] {8, 9},
    new int[] {20, 5},
    new int[] {44, 13},
    new int[] {32, 19},
    new int[] {8, 11},
};

Dictionary<string, Dictionary<string, string>[]> MOTOR = new Dictionary<string, Dictionary<string, string>[]>();

MOTOR.Add("relay1C", new Dictionary<string, string>[5]);
MOTOR["relay1C"][0] = new Dictionary<string, string>() { { "1S", "H [1]" }, { "1NT", "S [2]" }, { "2C", "Balanced [bal1C]" }, { "2D", "C [3]" }, { "2H", "D [singleSuit1C]" }, { "2S+", "C+D [twoSuit1C]" } };
MOTOR["relay1C"][1] = new Dictionary<string, string>() { { "2C", "S [4]" }, { "2D", "C [twoSuit1C]" }, { "2H", "D [twoSuit1C]" }, { "2S", "D reverser [twoSuit1C]" },{ "2NT+", "[singleSuit1C]" } };
MOTOR["relay1C"][2] = new Dictionary<string, string>() { { "2D", "C [twoSuit1C]" }, { "2H", "D [twoSuit1C]" }, { "2S", "D reverser [twoSuit1C]" }, { "2NT+", "[singleSuit1C]" } };
MOTOR["relay1C"][3] = new Dictionary<string, string>() { { "2S", "Three suit minor [threeSuitMinor1C]" }, { "2NT+", "[singleSuit1C]" } };
MOTOR["relay1C"][4] = new Dictionary<string, string>() { { "2H", "Three suit major [threeSuitMajor1C]" }, { "2S+", "[twoSuit1C]" } };

MOTOR.Add("twoSuit1C", new Dictionary<string, string>[4]);
MOTOR["twoSuit1C"][0] = new Dictionary<string, string>() { { "2S", "Reverser" }, { "2NT", "Long legged [2]" }, { "3C", "High shortage" }, { "3D", "5422" }, { "3H", "64 [1]" }, { "3S", "5431" } };
MOTOR["twoSuit1C"][1] = new Dictionary<string, string>() { { "3NT", "6421" }, { "4C", "6430" } };
MOTOR["twoSuit1C"][2] = new Dictionary<string, string>() { { "3D", "High shortage" }, { "3H", "Even shortage [3]" }, { "3S", "5521" }, { "3NT", "5530" }, { "4C", "(56)20" }, { "4D", "(65)20" } };
MOTOR["twoSuit1C"][3] = new Dictionary<string, string>() { { "3NT", "(56)11" }, { "4C", "(65)11" } };

MOTOR.Add("singleSuit1C", new Dictionary<string, string>[3]);
MOTOR["singleSuit1C"][0] = new Dictionary<string, string>() { { "2NT", "High shortage or even shortage" }, { "3C", "Mid shortage" }, { "3D", "Even shortage [1]" }, { "3H", "Singleton [2]" }, { "3S", "5332" } };
MOTOR["singleSuit1C"][1] = new Dictionary<string, string>() { { "3S", "7222/6223" }, { "3NT", "6322/6232" } };
MOTOR["singleSuit1C"][2] = new Dictionary<string, string>() { { "3NT", "6331" }, { "4C", "7(23)1" }, { "4D", "7(32)1" } };

MOTOR.Add("bal1C", new Dictionary<string, string>[2]);
MOTOR["bal1C"][0] = new Dictionary<string, string>() { { "2H", "Colour or 33(43)" }, { "2S", "Rank" }, { "2NT", "(43)33 [1]" }, { "3C", "short C" }, { "3D", "short D" }, { "3H", "short H" }, { "3S", "short S" } };
MOTOR["bal1C"][1] = new Dictionary<string, string>() { { "3D", "34" }, { "3H", "43" } };

MOTOR.Add("threeSuitMinor1C", new Dictionary<string, string>[2]);
MOTOR["threeSuitMinor1C"][0] = new Dictionary<string, string>() { { "3C", "High shortage [1]" }, { "3D", "4144" }, { "3H", "4045" }, { "3S", "4054" }, { "3NT", "5044" } };
MOTOR["threeSuitMinor1C"][1] = new Dictionary<string, string>() { { "3H", "1444" }, { "3S", "0445" }, { "3NT", "0454" }, { "4C", "0544" } };

MOTOR.Add("threeSuitMajor1C", new Dictionary<string, string>[2]);
MOTOR["threeSuitMajor1C"][0] = new Dictionary<string, string>() { { "2NT", "High shortage [1]" }, { "3C", "4441" }, { "3D", "4450" }, { "3H", "4540" }, { "3S", "5440" } };
MOTOR["threeSuitMajor1C"][1] = new Dictionary<string, string>() { { "3D", "4414" }, { "3H", "4405" }, { "3S", "4504" }, { "3NT", "5404" } };

List<string> deck;

string[] biddingSheetFile = File.ReadAllLines("bidding_sheet.txt");

string[] biddingSheet = new string[25];

for (int i = 0; i < 25; i++)
{
    biddingSheet[i] = biddingSheetFile[i];
}

foreach (string line in biddingSheet)
{
    Console.WriteLine(line);
}

Random random = new Random();
//List<int> used = new List<int>();
string[] north = new string[13];
string[] south = new string[13];
string[] east = new string[13];
string[] west = new string[13];

while (HCP(north) < 15 || HCP(south) < 9)
{
    deck = new List<string>(cards);

    for (int i = 0; i < 13; i++)
    {
        int r = random.Next(0, deck.Count - 1);
        north[i] = deck[r];
        deck.RemoveAt(r);

        r = random.Next(deck.Count - 1);
        south[i] = deck[r];
        deck.RemoveAt(r);

        r = random.Next(deck.Count - 1);
        east[i] = deck[r];
        deck.RemoveAt(r);

        r = random.Next(deck.Count - 1);
        west[i] = deck[r];
        deck.RemoveAt(r);
    }
}

Hand N = new Hand(north);
Hand S = new Hand(south);
Hand E = new Hand(east);
Hand W = new Hand(west);

S.Print();

char[] positions = new char[] { 'N', 'E', 'S', 'W' };
int bidPosOffset = 0;
int bid = -1;
int passes = 0;
Dictionary<char, List<string>> bids = new Dictionary<char, List<string>>();
bids.Add('N', new List<string>());
bids.Add('E', new List<string>());
bids.Add('S', new List<string>());
bids.Add('W', new List<string>());

/*switch (random.Next(0, 3))
{
    case 0:
        bidPosOffset = 0;
        break;
    case 1:
        bidPosOffset = 1;
        break;
    case 2:
        bidPosOffset = 2;
        break;
    case 3:
        bidPosOffset = 3;
        break;
}*/

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (passes < 3)
{
    switch(positions[bidPosOffset % 4])
    {
        case 'N':

            if (bids['S'].Count == 0 || bids['S'].Last() == "/")
            {
                bids['N'].Add("1C");
            }
            else
            {
                bids['N'].Add(bidSeq[Array.IndexOf(bidSeq, bids['S'].Last()) + 1]);
                passes = 0;
            }

            break;
        case 'S':
            Console.SetCursorPosition(bidPos[bidPosOffset][0], bidPos[bidPosOffset][1]);

            bool validBid = false;
            string bidInput = "";
            while (!validBid)
            {
                bidInput = Console.ReadLine();

                if(bidInput == "/" || Array.IndexOf(bidSeq, bidInput) > Array.IndexOf(bidSeq, bids['N'].Last()))
                {
                    validBid = true;
                }
                else
                {
                    Console.SetCursorPosition(bidPos[bidPosOffset][0], bidPos[bidPosOffset][1]);
                    Console.Write("   ");
                    Console.SetCursorPosition(bidPos[bidPosOffset][0], bidPos[bidPosOffset][1]);
                }
            }

            if(bidInput == "/" || bidInput.ToLower() == "pass")
            {
                passes++;
                bids['S'].Add("/");
            }
            else
            {
                bids['S'].Add(bidInput);
                passes = 0;
            }

            break;
        case 'E':
            if (bids['N'].Count + bids['S'].Count + bids['W'].Count + bids['W'].Count > 0)
            {
                passes++;
            }
            bids['E'].Add("/");
            break;
        case 'W':
            if (bids['N'].Count + bids['S'].Count + bids['W'].Count + bids['W'].Count > 0)
            {
                passes++;
            }
            bids['W'].Add("/");
            break;
    }

    printBid(bidPos[bidPosOffset], bids[positions[bidPosOffset % 4]].Last());

    bidPosOffset++;
}

void printBid(int[] coord, string bid)
{
    switch (bid)
    {
        case "/":
            Console.SetCursorPosition(coord[0], coord[1] + 1);
            Console.Write("╱");
            Console.SetCursorPosition(coord[0], coord[1]);
            Console.Write(" ╱");
            Console.SetCursorPosition(coord[0] + 2, coord[1] - 1);
            Console.Write("╱");

            break;
        case "X":

            break;
        case "XX":

            break;
        default:
            Console.SetCursorPosition(coord[0], coord[1]);
            Console.Write(bid);
            break;
    }
}



/*for(int i = 0; i < bidPos.Length; i++)
{
    Console.SetCursorPosition(bidPos[i][0], bidPos[i][1]);
    Console.Write(i);
}*/










//string[] bids = input.Split(',');
string topLayer = "relay1C";
int subLayer = 0;
List<string> descriptors = new List<string>();

for(int i = 0; i < bids['S'].Count;)
{
    if(bids['S'][i] == "/")
    {
        i++;
        continue;
    }
    // check if bid is above (run on if there's a +) or below (input error) the sequence of bids in the chosen layer.
    int lowBid = Array.IndexOf(bidSeq, MOTOR[topLayer][subLayer].First().Key);
    string highBidString = MOTOR[topLayer][subLayer].Last().Key;
    bool plus = false;
    if(highBidString.Last() == '+')
    {
        highBidString = highBidString.Substring(0, highBidString.Length - 1);
        plus = true;
    }
    int highBid = Array.IndexOf(bidSeq, highBidString);
    int bidIndex = Array.IndexOf(bidSeq, bids['S'][i]);

    if (bidIndex < lowBid || (bidIndex > highBid && !plus))
    {
        Console.WriteLine("Invalid bid");
        Console.ReadKey();
        break;
    }
    else if (bidIndex > highBid || (bidIndex == highBid && plus))
    {
        string command = MOTOR[topLayer][subLayer].Last().Value;
        int startIndex = command.IndexOf('['), endIndex = command.IndexOf(']');

        string newLayer = command.Substring(startIndex + 1, endIndex - startIndex - 1);

        if (newLayer.Length == 1)
        {
            subLayer = int.Parse(newLayer);
        }
        else
        {
            topLayer = newLayer;
            subLayer = 0;
        }

        if (startIndex > 0)
        {
            descriptors.Add(command.Substring(0, startIndex - 1));
        }
    }
    else
    {
        string command = MOTOR[topLayer][subLayer][bids['S'][i]];
        int startIndex = command.IndexOf('['), endIndex = command.IndexOf(']');

        if (startIndex != -1)
        {
            string newLayer = command.Substring(startIndex + 1, endIndex - startIndex - 1);

            if (newLayer.Length == 1)
            {
                subLayer = int.Parse(newLayer);
            }
            else
            {
                topLayer = newLayer;
                subLayer = 0;
            }

            descriptors.Add(command.Substring(0, startIndex - 1));
        }
        else
        {
            descriptors.Add(command);
        }

        i++;
    }
}

/*foreach(string descriptor in descriptors)
{
    Console.WriteLine(descriptor);
}

Console.WriteLine();*/

// Now to interpret the descriptors
// They can be grouped:
// * Suits
// * Reverser / long legged / non-reverser
// * Shortage: high, even, low
// * Shape

bool reverser = false, slowEven = false, threeSuit = false;
string shortage = "low", fourfour = "odd";
string shape = descriptors.Last().Replace("(", "").Replace(")", "");
List<char> longSuits = new List<char>();
List<char> shortSuits = new List<char>();

foreach(string desc in descriptors)
{
    if(desc.Length == 1)
    {
        longSuits.Add(desc[0]);
    }

    if(desc == "C+D")
    {
        longSuits.Add('C');
        longSuits.Add('D');
    }

    if(desc == "D reverser")
    {
        longSuits.Add('D');
    }

    if (desc.Contains("Colour"))
    {
        fourfour = "colour";
    }

    if (desc.Contains("Rank"))
    {
        fourfour = "rank";
    }

    if(desc.Contains("reverser") || desc.Contains("Reverser"))
    {
        reverser = true;
    }

    if(desc.Contains("Three suit major") || desc.Contains("Three suit minor"))
    {
        threeSuit = true;
    }

    if (desc.Contains("(56)"))
    {
        reverser = true;
        shape = string.Concat(shape[1], shape[0], shape.Substring(2));
    }

    if(desc.Contains("High shortage or even shortage"))
    {
        slowEven = true;
    }

    if(desc.Contains("High shortage"))
    {
        shortage = "high";
    }

    if(desc.Contains("Mid shortage"))
    {
        shortage = "mid";
    }

    if(desc.Contains("even shortage") || desc.Contains("Even shortage"))
    {
        shortage = "even";
    }
}

foreach(char suit in suitOrder)
{
    if (!longSuits.Contains(suit))
    {
        shortSuits.Add(suit);
    }
}

longSuits = longSuits.OrderBy(x => Array.IndexOf(suitOrder, x)).ToList();

Dictionary<char, int> hand = new Dictionary<char, int>() { { 'S', 0 }, { 'H', 0 }, { 'D', 0 }, { 'C', 0 } };

if (threeSuit)
{
    hand['S'] = descriptors.Last()[0] - 48;
    hand['H'] = descriptors.Last()[1] - 48;
    hand['D'] = descriptors.Last()[2] - 48;
    hand['C'] = descriptors.Last()[3] - 48;
}
else if (longSuits.Count == 2)
{
    if (reverser)
    {
        hand[longSuits[0]] = shape[1] - 48;
        hand[longSuits[1]] = shape[0] - 48;
    }
    else
    {
        hand[longSuits[0]] = shape[0] - 48;
        hand[longSuits[1]] = shape[1] - 48;
    }

    if (shortage == "high")
    {
        hand[shortSuits[0]] = shape[3] - 48;
        hand[shortSuits[1]] = shape[2] - 48;
    }
    else
    {
        hand[shortSuits[0]] = shape[2] - 48;
        hand[shortSuits[1]] = shape[3] - 48;
    }
}
else if (longSuits.Count == 1)
{
    hand[longSuits[0]] = shape[0] - 48;

    switch (shortage)
    {
        case "high":
            hand[shortSuits[0]] = shape[3] - 48;

            int index = descriptors.Last().IndexOf("(");

            if(index == -1)
            {
                hand[shortSuits[1]] = shape[2] - 48;
                hand[shortSuits[2]] = shape[2] - 48;
            }
            else
            {
                if(descriptors.Last()[index + 1] == '2')
                {
                    hand[shortSuits[1]] = 2;
                    hand[shortSuits[2]] = 3;
                }
                else
                {
                    hand[shortSuits[1]] = 3;
                    hand[shortSuits[2]] = 2;
                }
            }

            break;
        case "mid":
            hand[shortSuits[1]] = shape[3] - 48;

            index = descriptors.Last().IndexOf("(");

            if (index == -1)
            {
                hand[shortSuits[0]] = shape[2] - 48;
                hand[shortSuits[2]] = shape[2] - 48;
            }
            else
            {
                if (descriptors.Last()[index + 1] == '2')
                {
                    hand[shortSuits[0]] = 2;
                    hand[shortSuits[2]] = 3;
                }
                else
                {
                    hand[shortSuits[0]] = 3;
                    hand[shortSuits[2]] = 2;
                }
            }

            break;
        case "even":

            string[] evenOptions = descriptors.Last().Split('/');

            if (slowEven)
            {
                if(evenOptions[1] == "6223")
                {
                    hand[longSuits[0]] = 6;
                    hand[shortSuits[0]] = 2;
                    hand[shortSuits[1]] = 2;
                    hand[shortSuits[2]] = 3;
                }
                else
                {
                    // 6232
                    hand[longSuits[0]] = 6;
                    hand[shortSuits[0]] = 2;
                    hand[shortSuits[1]] = 3;
                    hand[shortSuits[2]] = 2;
                }
            }
            else
            {
                if(evenOptions[0] == "7222")
                {
                    hand[longSuits[0]] = 7;
                    hand[shortSuits[0]] = 2;
                    hand[shortSuits[1]] = 2;
                    hand[shortSuits[2]] = 2;
                }
                else
                {
                    // 6322
                    hand[longSuits[0]] = 6;
                    hand[shortSuits[0]] = 3;
                    hand[shortSuits[1]] = 2;
                    hand[shortSuits[2]] = 2;
                }
            }

            break;
        default: // (i.e. "low")
            hand[shortSuits[2]] = shape[3] - 48;

            index = descriptors.Last().IndexOf("(");

            if (index == -1)
            {
                hand[shortSuits[0]] = shape[2] - 48;
                hand[shortSuits[1]] = shape[2] - 48;
            }
            else
            {
                if (descriptors.Last()[index + 1] == '2')
                {
                    hand[shortSuits[0]] = 2;
                    hand[shortSuits[1]] = 3;
                }
                else
                {
                    hand[shortSuits[0]] = 3;
                    hand[shortSuits[1]] = 2;
                }
            }

            break;
    }
}
else if(descriptors[0] == "Balanced")
{
    if(descriptors.Last() == "43")
    {
        if (descriptors[1].Contains("Colour"))
        {
            hand['C'] = 3;
            hand['D'] = 4;
            hand['H'] = 3;
            hand['S'] = 3;
        }
        else
        {
            hand['C'] = 3;
            hand['D'] = 3;
            hand['H'] = 3;
            hand['S'] = 4;
        }
    }
    else if (descriptors.Last() == "34")
    {
        if (descriptors[1].Contains("Colour"))
        {
            hand['C'] = 4;
            hand['D'] = 3;
            hand['H'] = 3;
            hand['S'] = 3;
        }
        else
        {
            hand['C'] = 3;
            hand['D'] = 3;
            hand['H'] = 4;
            hand['S'] = 3;
        }
    }
    else
    {
        switch (fourfour)
        {
            case "colour":
                switch (descriptors.Last())
                {
                    case "short C":
                        hand['C'] = 2;
                        hand['D'] = 4;
                        hand['H'] = 4;
                        hand['S'] = 3;
                        break;
                    case "short D":
                        hand['C'] = 4;
                        hand['D'] = 2;
                        hand['H'] = 3;
                        hand['S'] = 4;
                        break;
                    case "short H":
                        hand['C'] = 4;
                        hand['D'] = 3;
                        hand['H'] = 2;
                        hand['S'] = 4;
                        break;
                    case "short S":
                        hand['C'] = 3;
                        hand['D'] = 4;
                        hand['H'] = 4;
                        hand['S'] = 2;
                        break;
                }
                break;
            case "rank":
                switch (descriptors.Last())
                {
                    case "short C":
                        hand['C'] = 2;
                        hand['D'] = 3;
                        hand['H'] = 4;
                        hand['S'] = 4;
                        break;
                    case "short D":
                        hand['C'] = 3;
                        hand['D'] = 2;
                        hand['H'] = 4;
                        hand['S'] = 4;
                        break;
                    case "short H":
                        hand['C'] = 4;
                        hand['D'] = 4;
                        hand['H'] = 2;
                        hand['S'] = 4;
                        break;
                    case "short S":
                        hand['C'] = 4;
                        hand['D'] = 4;
                        hand['H'] = 3;
                        hand['S'] = 2;
                        break;
                }
                break;
            default: // i.e. odd
                switch (descriptors.Last())
                {
                    case "short C":
                        hand['C'] = 2;
                        hand['D'] = 4;
                        hand['H'] = 3;
                        hand['S'] = 4;
                        break;
                    case "short D":
                        hand['C'] = 4;
                        hand['D'] = 2;
                        hand['H'] = 4;
                        hand['S'] = 3;
                        break;
                    case "short H":
                        hand['C'] = 3;
                        hand['D'] = 4;
                        hand['H'] = 2;
                        hand['S'] = 4;
                        break;
                    case "short S":
                        hand['C'] = 4;
                        hand['D'] = 3;
                        hand['H'] = 4;
                        hand['S'] = 2;
                        break;
                }
                break;
        }
    }
}

foreach (int length in hand.Values)
{
    Console.Write(length);
}

Console.ReadKey();






// balanced, 3-suited, 2-suited, single suited

//Console.WriteLine("North: {0}, South: {1}", HCP(north), HCP(south));

Console.ReadKey();

static int HCP(string[] hand)
{
    if(hand[0] == null)
    {
        return -1;
    }

    int pts = 0;
    foreach(string card in hand)
    {
        switch (card[0])
        {
            case 'A':
                pts += 4;
                break;
            case 'K':
                pts += 3;
                break;
            case 'Q':
                pts += 2;
                break;
            case 'J':
                pts += 1;
                break;
            default:

                break;
        }
    }

    return pts;
}


public class Hand
{
    public List<string> S;
    public List<string> H;
    public List<string> D;
    public List<string> C;

    public List<string>[] Cards;

    private string[] cards = new string[] { "AS", "KS", "QS", "JS", "TS", "9S", "8S", "7S", "6S", "5S", "4S", "3S", "2S",
                                            "AH", "KH", "QH", "JH", "TH", "9H", "8H", "7H", "6H", "5H", "4H", "3H", "2H",
                                            "AD", "KD", "QD", "JD", "TD", "9D", "8D", "7D", "6D", "5D", "4D", "3D", "2D",
                                            "AC", "KC", "QC", "JC", "TC", "9C", "8C", "7C", "6C", "5C", "4C", "3C", "2C"};

    public Hand(string[] cards)
    {
        S = new List<string>();
        H = new List<string>();
        D = new List<string>();
        C = new List<string>();

        Cards = new List<string>[4];
        for(int i = 0; i < 4; i++)
        {
            Cards[i] = new List<string>();
        }

        cards = sort(cards);

        int c = 0;
        while (c < 13 && cards[c][1] == 'S')
        {
            S.Add(cards[c]);
            Cards[0].Add(cards[c]);
            c++;
        }
        while (c < 13 && cards[c][1] == 'H')
        {
            H.Add(cards[c]);
            Cards[1].Add(cards[c]);
            c++;
        }
        while (c < 13 && cards[c][1] == 'D')
        {
            D.Add(cards[c]);
            Cards[2].Add(cards[c]);
            c++;
        }
        while (c < 13 && cards[c][1] == 'C')
        {
            C.Add(cards[c]);
            Cards[3].Add(cards[c]);
            c++;
        }
    }

    public void Print()
    {
        Console.Write("S: ");
        if (S.Count > 0)
        {
            for (int i = 0; i < S.Count - 1; i++)
            {
                Console.Write(S[i][0] + ", ");
            }
            Console.WriteLine(S.Last()[0]);
        }

        Console.Write("H: ");
        if (H.Count > 0)
        {
            for (int i = 0; i < H.Count - 1; i++)
            {
                Console.Write(H[i][0] + ", ");
            }
            Console.WriteLine(H.Last()[0]);
        }

        Console.Write("D: ");
        if (D.Count > 0)
        {
            for (int i = 0; i < D.Count - 1; i++)
            {
                Console.Write(D[i][0] + ", ");
            }
            Console.WriteLine(D.Last()[0]);
        }

        Console.Write("C: ");
        if (C.Count > 0)
        {
            for (int i = 0; i < C.Count - 1; i++)
            {
                Console.Write(C[i][0] + ", ");
            }
            Console.WriteLine(C.Last()[0]);
        }
    }

    public string GetHandType()
    {
        int[] suitLengths = new int[] { S.Count, H.Count, D.Count, C.Count };

        Array.Sort(suitLengths);

        if(suitLengths[0] >=2 && suitLengths[1] >= 3)
        {
            return "balanced";
        }
        else if(suitLengths[1] == 4)
        {
            return "3-suiter";
        }
        else if(suitLengths[2] <= 3)
        {
            return "single suiter";
        }
        else
        {
            return "2-suiter";
        }
    }

    private string[] sort(string[] hand)
    {
        int[] keys = new int[13];

        for (int i = 0; i < 13; i++)
        {
            keys[i] = Array.IndexOf(cards, hand[i]);
        }

        Array.Sort(keys, hand);

        return hand;
    }
}
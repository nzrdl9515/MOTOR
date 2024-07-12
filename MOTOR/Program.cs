using System.Data;

internal class Program
{
    public static Dictionary<string, Dictionary<string, string>[]> MOTOR = new Dictionary<string, Dictionary<string, string>[]>();

    private static void Main(string[] args)
    {
        string[] cards = new string[] { "AS", "KS", "QS", "JS", "TS", "9S", "8S", "7S", "6S", "5S", "4S", "3S", "2S",
                                "AH", "KH", "QH", "JH", "TH", "9H", "8H", "7H", "6H", "5H", "4H", "3H", "2H",
                                "AD", "KD", "QD", "JD", "TD", "9D", "8D", "7D", "6D", "5D", "4D", "3D", "2D",
                                "AC", "KC", "QC", "JC", "TC", "9C", "8C", "7C", "6C", "5C", "4C", "3C", "2C"};

        string[] bidSeq = new string[] {"1C", "1D", "1H", "1S", "1NT", "2C", "2D", "2H", "2S", "2NT" , "3C", "3D", "3H", "3S", "3NT",
                                "4C", "4D", "4H", "4S", "4NT", "5C", "5D", "5H", "5S", "5NT", "6C", "6D", "6H", "6S", "6NT",
                                "7C", "7D", "7H", "7S", "7NT"};

        char[] suitOrder = new char[] { 'S', 'H', 'D', 'C' };

        int[][] bidPosN = new int[][]
        {
            new int[] {32, 7},
            new int[] {26, 7},
            new int[] {20, 7},
            new int[] {32, 5},
            new int[] {26, 5},
            new int[] {20, 5},
        };

        int[][] bidPosE = new int[][]
        {
            new int[] {38, 15},
            new int[] {38, 13},
            new int[] {38, 11},
            new int[] {38, 9},
            new int[] {44, 15},
            new int[] {44, 13},
        };

        int[][] bidPosS = new int[][]
        {
            new int[] {20, 17},
            new int[] {26, 17},
            new int[] {32, 17},
            new int[] {20, 19},
            new int[] {26, 19},
            new int[] {32, 19},
        };

        int[][] bidPosW = new int[][]
        {
            new int[] {14, 9},
            new int[] {14, 11},
            new int[] {14, 13},
            new int[] {14, 15},
            new int[] {8, 9},
            new int[] {8, 11},
        };

        MOTOR.Add("relay1C", new Dictionary<string, string>[5]);
        MOTOR["relay1C"][0] = new Dictionary<string, string>() { { "1S", "H [1]" }, { "1NT", "S [2]" }, { "2C", "Balanced [bal1C]" }, { "2D", "C [3]" }, { "2H", "D [singleSuit1C]" }, { "2S+", "C+D [twoSuit1C]" } };
        MOTOR["relay1C"][1] = new Dictionary<string, string>() { { "2C", "S [4]" }, { "2D", "C [twoSuit1C]" }, { "2H", "D [twoSuit1C]" }, { "2S", "D reverser [twoSuit1C]" }, { "2NT+", "[singleSuit1C]" } };
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

        Random random = new Random();

        int bidPosOffset = random.Next(0, 3);
        int dealerLastRound = bidPosOffset;

        // Loop for each hand
        while (true)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            foreach (string line in biddingSheet)
            {
                Console.WriteLine(line);
            }

            dealerLastRound++;
            if (dealerLastRound == 4)
            {
                dealerLastRound = 0;
            }
            bidPosOffset = dealerLastRound;

            /*for (int i = 0; i < bidPosE.Length; i++)
            {
                Console.SetCursorPosition(bidPosE[i][0], bidPosE[i][1]);
                Console.Write((char)(65 + i));
            }
            Console.ReadKey();*/

            //List<int> used = new List<int>();
            string[] north = new string[13];
            string[] south = new string[13];
            string[] east = new string[13];
            string[] west = new string[13];

            // Deal a hand that meets the requirements for someone N-S to relay
            while (((bidPosOffset == 0 || bidPosOffset == 3) && (HCP(south) < 18 || HCP(north) < 15) && isExtreme(north))
                || ((bidPosOffset == 1 || bidPosOffset == 2) && (HCP(south) < 15 || HCP(north) < 18 && isExtreme(north))))
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
            Hand E = new Hand(east);
            Hand S = new Hand(south);
            Hand W = new Hand(west);

            List<string> northBids = calculateNorthBids(N);

            S.Print();

            char[] positions = new char[] { 'N', 'E', 'S', 'W' };

            //int bid = -1;
            int passes = -1; // Starts negative to allow 3 passes at the beginning
            Dictionary<char, List<string>> bids = new Dictionary<char, List<string>>();
            bids.Add('N', new List<string>());
            bids.Add('E', new List<string>());
            bids.Add('S', new List<string>());
            bids.Add('W', new List<string>());

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // By this stage, the hands have been dealt and the dealer is chosen.
            // Now the bidding begins
            // E-W will continually pass
            // If S passes, or has not bid yet, N will check whether they can open 1C
            // If N opens 1C, they will continue to relay until S passes
            // If S opens 1C, N will respond until they have completed described their hand

            int northRelayIndex = 0;
            int northState = -1;
            // 0 = 1/2 relay
            // 1 = 3/4 relay
            // 2 = 1/2 showing
            // 3 = 3/4 showing

            while (passes < 3)
            {
                switch (positions[bidPosOffset % 4])
                {
                    case 'N':
                        switch (northState)
                        {
                            case -1:
                                if (bids['S'].Count == 0)
                                {
                                    if (HCP(north) >= 15)
                                    {
                                        northState = 0;
                                        bids['N'].Add("1C");
                                        passes = 0;
                                    }
                                    else
                                    {
                                        northState = 2;
                                        bids['N'].Add("/");
                                        passes++;
                                    }
                                }
                                else
                                {
                                    if (bids['S'][0] == "/" && HCP(north) >= 18)
                                    {
                                        northState = 1;
                                        bids['N'].Add("1C");
                                        passes = 0;
                                    }
                                    else
                                    {
                                        northState = 3;
                                        passes = 0;
                                        // Bid calculation needs to be peformed
                                        bids['N'].Add(northBids[northRelayIndex]);
                                        northRelayIndex++;
                                    }
                                }
                                break;
                            case 0:
                            case 1:
                                // Bid one up each round
                                bids['N'].Add(bidSeq[Array.IndexOf(bidSeq, bids['S'].Last()) + 1]);
                                break;
                            case 2:
                                // Showing hand after 1C in 1/2
                                if (northRelayIndex == northBids.Count)
                                {
                                    bids['N'].Add("/");
                                    passes++;
                                }
                                else
                                {
                                    bids['N'].Add(northBids[northRelayIndex]);
                                    northRelayIndex++;
                                    passes = 0;
                                }
                                break;
                            case 3:
                                // Showing hand after 1C in 3/4
                                if (northRelayIndex == northBids.Count)
                                {
                                    bids['N'].Add("/");
                                    passes++;
                                }
                                else
                                {
                                    bids['N'].Add(northBids[northRelayIndex]);
                                    northRelayIndex++;
                                    passes = 0;
                                }
                                break;
                        }

                        printBid(bidPosN[bids['N'].Count - 1], bids['N'].Last());

                        break;
                    case 'S':
                        Console.SetCursorPosition(bidPosS[bids['S'].Count][0], bidPosS[bids['S'].Count][1]);

                        bool validBid = false;
                        string bidInput = "";
                        while (!validBid)
                        {
                            bidInput = Console.ReadLine();

                            if (bidInput == "/" || bids['N'].Count == 0 || Array.IndexOf(bidSeq, bidInput) > Array.IndexOf(bidSeq, bids['N'].Last()))
                            {
                                validBid = true;
                            }
                            else
                            {
                                Console.SetCursorPosition(bidPosS[bids['S'].Count][0], bidPosS[bids['S'].Count][1]);
                                Console.Write("   ");
                                Console.SetCursorPosition(bidPosS[bids['S'].Count][0], bidPosS[bids['S'].Count][1]);
                            }
                        }

                        if (bidInput == "/" || bidInput.ToLower() == "pass")
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
                        /*if (bids['N'].Count + bids['S'].Count + bids['W'].Count + bids['W'].Count > 0)
                        {
                            passes++;
                        }*/
                        passes++;
                        bids['E'].Add("/");

                        printBid(bidPosE[bids['E'].Count - 1], bids['E'].Last());

                        break;
                    case 'W':
                        /*if (bids['N'].Count + bids['S'].Count + bids['W'].Count + bids['W'].Count > 0)
                        {
                            passes++;
                        }*/
                        passes++;
                        bids['W'].Add("/");

                        printBid(bidPosW[bids['W'].Count - 1], bids['W'].Last());

                        break;
                }

                //printBid(bidPos[bidPosOffset], bids[positions[bidPosOffset % 4]].Last());

                bidPosOffset++;
            }

            if (northState >= 2)
            {
                // North has been showing their hand
                Console.Write("Press [ANY KEY] to view North's shape");
                Console.ReadKey();
                Console.Write(": " + N.GetShape());
            }
            else
            {
                //South has been showing their hand

                //string[] bids = input.Split(',');
                string topLayer = "relay1C";
                int subLayer = 0;
                List<string> descriptors = new List<string>();

                for (int i = 0; i < bids['S'].Count;)
                {
                    if (bids['S'][i] == "/")
                    {
                        i++;
                        continue;
                    }
                    // check if bid is above (run on if there's a +) or below (input error) the sequence of bids in the chosen layer.
                    int lowBid = Array.IndexOf(bidSeq, MOTOR[topLayer][subLayer].First().Key);
                    string highBidString = MOTOR[topLayer][subLayer].Last().Key;
                    bool plus = false;
                    if (highBidString.Last() == '+')
                    {
                        highBidString = highBidString.Substring(0, highBidString.Length - 1);
                        plus = true;
                    }
                    int highBid = Array.IndexOf(bidSeq, highBidString);
                    int bidIndex = Array.IndexOf(bidSeq, bids['S'][i]);

                    if (bidIndex < lowBid || bidIndex > highBid && !plus)
                    {
                        Console.WriteLine("Invalid bid");
                        Console.ReadKey();
                        break;
                    }
                    else if (bidIndex > highBid || bidIndex == highBid && plus)
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

                foreach (string desc in descriptors)
                {
                    if (desc.Length == 1)
                    {
                        longSuits.Add(desc[0]);
                    }

                    if (desc == "C+D")
                    {
                        longSuits.Add('C');
                        longSuits.Add('D');
                    }

                    if (desc == "D reverser")
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

                    if (desc.Contains("reverser") || desc.Contains("Reverser"))
                    {
                        reverser = true;
                    }

                    if (desc.Contains("Three suit major") || desc.Contains("Three suit minor"))
                    {
                        threeSuit = true;
                    }

                    if (desc.Contains("(56)"))
                    {
                        reverser = true;
                        shape = string.Concat(shape[1], shape[0], shape.Substring(2));
                    }

                    if (desc.Contains("High shortage or even shortage"))
                    {
                        slowEven = true;
                    }

                    if (desc.Contains("High shortage"))
                    {
                        shortage = "high";
                    }

                    if (desc.Contains("Mid shortage"))
                    {
                        shortage = "mid";
                    }

                    if (/*desc.Contains("even shortage") || */desc.Contains("Even shortage"))
                    {
                        shortage = "even";
                    }
                }

                foreach (char suit in suitOrder)
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

                            if (index == -1)
                            {
                                hand[shortSuits[1]] = shape[2] - 48;
                                hand[shortSuits[2]] = shape[2] - 48;
                            }
                            else
                            {
                                if (descriptors.Last()[index + 1] == '2')
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
                                if (evenOptions[1] == "6223")
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
                                if (evenOptions[0] == "7222")
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
                else if (descriptors[0] == "Balanced")
                {
                    if (descriptors.Last() == "43")
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
                                        hand['S'] = 3;
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
            }

            Console.ReadKey();
        }






        // balanced, 3-suited, 2-suited, single suited

        //Console.WriteLine("North: {0}, South: {1}", HCP(north), HCP(south));

        //Console.ReadKey();
    }

    static List<string> calculateNorthBids(Hand hand1)
    {
        string hand = hand1.GetShape();
        string level = "relay1C";
        int sublevel = 0;
        List<string> bids = new List<string>();

        List<char> tempOrderedHand = new List<char>(hand.ToCharArray());
        tempOrderedHand.Sort();
        tempOrderedHand.Reverse();
        string orderedHand = "";
        foreach(char i in tempOrderedHand)
        {
            orderedHand += i;
        }

        if(orderedHand == "4333")
        {
            // Balanced 4333
            bids.Add("2C");

            string rankOrder;

            if(hand.Substring(0, 2) == "33")
            {
                // 4 card minor
                bids.Add("2H");
                bids.Add("2NT");
                rankOrder = hand.Substring(2, 2);
            }
            else
            {
                // 4 card major
                bids.Add("2NT");
                rankOrder = hand.Substring(0, 2);
            }

            if(rankOrder == "34")
            {
                bids.Add("3D");
            }
            else
            {
                bids.Add("3H");
            }
        }
        else if(orderedHand == "4432")
        {
            // Balanced 4432
            bids.Add("2C");

            if ((hand[0] == '4' && hand[3] == '4') || (hand[1] == '4' && hand[2] == '4'))
            {
                // Colour
                bids.Add("2H");
            }
            else if ((hand[0] == '4' && hand[1] == '4') || (hand[2] == '4' && hand[3] == '4'))
            {
                // Rank
                bids.Add("2S");
            }
            // else Odd

            switch (hand.IndexOf('2'))
            {
                case 0:
                    bids.Add("3S");
                    break;
                case 1:
                    bids.Add("3H");
                    break;
                case 2:
                    bids.Add("3D");
                    break;
                case 3:
                    bids.Add("3C");
                    break;
            }
        }
        else if(orderedHand == "4441" || orderedHand == "5440")
        {
            // Three suited
            switch (hand.IndexOfAny("01".ToCharArray()))
            {
                case 0:
                    // Short S
                    bids.Add("2D");
                    bids.Add("2S");
                    bids.Add("3C");
                    level = "threeSuitMinor1C";
                    sublevel = 1;
                    break;
                case 1:
                    // Short H
                    bids.Add("2D");
                    bids.Add("2S");
                    level = "threeSuitMinor1C";
                    sublevel = 0;
                    break;
                case 2:
                    // Short D
                    bids.Add("1S");
                    bids.Add("2C");
                    bids.Add("2H");
                    bids.Add("2NT");
                    level = "threeSuitMajor1C";
                    sublevel = 0;
                    break;
                case 3:
                    // Short C
                    bids.Add("1S");
                    bids.Add("2C");
                    bids.Add("2H");
                    level = "threeSuitMajor1C";
                    sublevel = 1;
                    break;
            }

            foreach (KeyValuePair<string, string> bid in MOTOR[level][sublevel])
            {
                if(hand == bid.Value)
                {
                    bids.Add(bid.Key);
                    break;
                }
            }
        }
        else if (orderedHand[1] - 48 >= 4)
        {
            // Two suited
            int longIndex1 = hand.IndexOfAny("456".ToCharArray());
            int longIndex2 = hand.IndexOfAny("456".ToCharArray(), longIndex1 + 1);

            string longSuits = hand[longIndex1].ToString() + hand[longIndex2].ToString();
            string shortSuits = hand.Remove(longIndex2, 1).Remove(longIndex1, 1);

            switch (longIndex1)
            {
                case 0:
                    // S + H/D/C
                    switch (longIndex2)
                    {
                        case 1:
                            // S + H
                            bids.Add("1S");
                            bids.Add("2C");
                            break;
                        case 2:
                            // S + D
                            bids.Add("1NT");
                            if (longSuits[0] < longSuits[1])
                            {
                                // Reverser - bid will be added later
                            }
                            else
                            {
                                bids.Add("2H");
                            }
                            break;
                        case 3:
                            // S + C
                            bids.Add("1NT");
                            bids.Add("2D");
                            break;
                    }
                    break;
                case 1:
                    // H + D/C
                    switch (longIndex2)
                    {
                        case 2:
                            // H + D
                            bids.Add("1S");
                            if (longSuits[0] < longSuits[1])
                            {
                                // Reverser - bid will be added later
                            }
                            else
                            {
                                bids.Add("2H");
                            }
                            break;
                        case 3:
                            // H + C
                            bids.Add("1S");
                            bids.Add("2D");
                            break;
                    }
                    break;

                    // case 2: C+D => no bid required
            }

            if (orderedHand[1] - 48 >= 5)
            {
                // Long legged
                bids.Add("2NT");

                if(shortSuits == "11")
                {
                    bids.Add("3H");
                    if(longSuits == "56")
                    {
                        bids.Add("3NT");
                    }
                    else
                    {
                        bids.Add("4C");
                    }
                }
                else
                {
                    if (shortSuits[0] < shortSuits[1])
                    {
                        // High shortage
                        bids.Add("3D");
                    }
                    // else Low shortage

                    switch (orderedHand)
                    {
                        case "5521":
                            bids.Add("3S");
                            break;
                        case "5530":
                            bids.Add("3NT");
                            break;
                        case "6520":
                            if(longSuits == "56")
                            {
                                bids.Add("4C");
                            }
                            else
                            {
                                bids.Add("4D");
                            }
                            break;
                    }
                }
            }
            else
            {
                // Short legged
                if (longSuits[0] < longSuits[1])
                {
                    // Reverser
                    bids.Add("2S");
                }

                if(orderedHand == "5422")
                {
                    bids.Add("3D");
                    return bids;
                }

                if (shortSuits[0] < shortSuits[1])
                {
                    // High shortage
                    bids.Add("3C");
                }

                if(longSuits == "64" || longSuits == "46")
                {
                    bids.Add("3H");

                    if(orderedHand == "6421")
                    {
                        bids.Add("3NT");
                    }
                    else
                    {
                        // 6430
                        bids.Add("4C");
                    }
                }
                else
                {
                    // 5431
                    bids.Add("3S");
                }
            }
        }
        else
        {
            // Single suited
            int suitIndex = hand.IndexOfAny("56789".ToCharArray());
            switch (suitIndex)
            {
                case 0:
                    // S
                    bids.Add("1NT");
                    break;
                case 1:
                    // H
                    bids.Add("1S");
                    break;
                case 2:
                    // D
                    bids.Add("2H");
                    break;
                case 3:
                    // C
                    bids.Add("2D");
                    break;
            }

            // If even shortage, will return here, otherwise run on to the next section
            switch (hand)
            {
                case "6223":
                    bids.Add("2NT");
                    bids.Add("3D");
                    bids.Add("3S");
                    return bids;
                case "6232":
                    bids.Add("2NT");
                    bids.Add("3D");
                    bids.Add("3NT");
                    return bids;
                case "6322":
                    bids.Add("3D");
                    bids.Add("3NT");
                    return bids;
                case "7222":
                    bids.Add("3D");
                    bids.Add("3S");
                    return bids;
            }

            string shortHand = hand.Remove(suitIndex, 1);
            int shortIndex = shortHand.IndexOfAny("12".ToCharArray());

            switch (shortIndex)
            {
                case 0:
                    // High shortage
                    bids.Add("2NT");
                    break;
                case 1:
                    // Mid shortage
                    bids.Add("3C");
                    break;
            }
            // else Low shortage

            if (hand.Contains('1'))
            {
                bids.Add("3H");
                if(orderedHand == "6331")
                {
                    bids.Add("3NT");
                }
                else
                {
                    string shortShortHand = shortHand.Remove(shortIndex, 1);
                    if(shortShortHand == "23")
                    {
                        bids.Add("4C");
                    }
                    else
                    {
                        bids.Add("4D");
                    }
                }
            }
            else
            {
                // 5332
                bids.Add("3S");
            }
        }

        return bids;
    }

    static bool isExtreme(string[] hand)
    {
        if (hand[0] is null)
        {
            return true;
        }

        List<char> tempOrderedHand = new List<char>(getShape(hand).ToCharArray());
        tempOrderedHand.Sort();
        string orderedHand = "";
        foreach (char i in tempOrderedHand)
        {
            orderedHand += i;
        }

        if (!(orderedHand == "5332"
            || orderedHand == "5422"
            || orderedHand == "5431"
            || orderedHand == "5521"
            || orderedHand == "5440"
            || orderedHand == "4333"
            || orderedHand == "4432"
            || orderedHand == "6520"
            || orderedHand == "6322"
            || orderedHand == "6430"
            || orderedHand == "6511"
            || orderedHand == "7321"
            || orderedHand == "7222"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static string getShape(string[] hand)
    {
        int[] cards = new int[4] { 0, 0, 0, 0 };

        for(int i = 0;i < hand.Length; i++)
        {
            switch (hand[i][1])
            {
                case 'S':
                    cards[0]++;
                    break;
                case 'H':
                    cards[1]++;
                    break;
                case 'D':
                    cards[2]++;
                    break;
                case 'C':
                    cards[3]++;
                    break;
            }
        }

        return string.Format("{0}{1}{2}{3}", cards[0], cards[1], cards[2], cards[3]);
    }

    static void printBid(int[] coord, string bid)
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


    static int HCP(string[] hand)
    {
        if (hand[0] == null)
        {
            return -1;
        }

        int pts = 0;
        foreach (string card in hand)
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
        for (int i = 0; i < 4; i++)
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

    public string GetShape()
    {
        return string.Format("{0}{1}{2}{3}", Cards[0].Count, Cards[1].Count, Cards[2].Count, Cards[3].Count);
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
            Console.Write(S.Last()[0]);
        }
        Console.Write('\n');

        Console.Write("H: ");
        if (H.Count > 0)
        {
            for (int i = 0; i < H.Count - 1; i++)
            {
                Console.Write(H[i][0] + ", ");
            }
            Console.Write(H.Last()[0]);
        }
        Console.Write('\n');

        Console.Write("D: ");
        if (D.Count > 0)
        {
            for (int i = 0; i < D.Count - 1; i++)
            {
                Console.Write(D[i][0] + ", ");
            }
            Console.Write(D.Last()[0]);
        }
        Console.Write('\n');

        Console.Write("C: ");
        if (C.Count > 0)
        {
            for (int i = 0; i < C.Count - 1; i++)
            {
                Console.Write(C[i][0] + ", ");
            }
            Console.Write(C.Last()[0]);
        }
    }

    public string GetHandType()
    {
        int[] suitLengths = new int[] { S.Count, H.Count, D.Count, C.Count };

        Array.Sort(suitLengths);

        if (suitLengths[0] >= 2 && suitLengths[1] >= 3)
        {
            return "balanced";
        }
        else if (suitLengths[1] == 4)
        {
            return "3-suiter";
        }
        else if (suitLengths[2] <= 3)
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
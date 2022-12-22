int dice1 = 0, dice2 = 0, dice3 = 0, dice4 = 0, dice5 = 0;
bool fixed1 = false, fixed2 = false, fixed3 = false, fixed4 = false, fixed5 = false;
int round = 1;

Console.Clear();
for (; round < 4; round++)
{
    RollDice();
    sortDice();
    bool goOn = PrintDice(round);
    if (goOn)
    {
        FixDice();
    }
}


void RollDice()
{
    if (!fixed1) { dice1 = Random.Shared.Next(1, 7); }
    if (!fixed2) { dice2 = Random.Shared.Next(1, 7); }
    if (!fixed3) { dice3 = Random.Shared.Next(1, 7); }
    if (!fixed4) { dice4 = Random.Shared.Next(1, 7); }
    if (!fixed5) { dice5 = Random.Shared.Next(1, 7); }
}
bool PrintDice(int round)
{
    Console.WriteLine($"Dice Roll #{round} (out of 3): {dice1}, {dice2}, {dice3}, {dice4}, {dice5}");
    if (round == 3) { AnalyzeAndPrintResult(); return false; }
    else { return true; }
}
void FixDice()
{
    fixed1 = false; fixed2 = false; fixed3 = false; fixed4 = false; fixed5 = false;
    string input = "";
    while (input != "r")
    {
        Console.Write("Which dice do you want to fix/unfix? (1-5, or 'r' to roll the dice): ");
        input = Console.ReadLine()!;
        if (input != "r")
        {
            switch (int.Parse(input))
            {
                case 1:
                    if (fixed1) { fixed1 = false; }
                    else { fixed1 = true; }
                    break;
                case 2:
                    if (fixed2) { fixed2 = false; }
                    else { fixed2 = true; }
                    break;
                case 3:
                    if (fixed3) { fixed3 = false; }
                    else { fixed3 = true; }
                    break;
                case 4:
                    if (fixed4) { fixed4 = false; }
                    else { fixed4 = true; }
                    break;
                case 5:
                    if (fixed5) { fixed5 = false; }
                    else { fixed5 = true; }
                    break;
                default:
                    Console.WriteLine("No valid input.");
                    break;
            }
            Console.Write("Fixed Dices: ");
            Console.Write(fixed1 ? "1, " : "");
            Console.Write(fixed2 ? "2, " : "");
            Console.Write(fixed3 ? "3, " : "");
            Console.Write(fixed4 ? "4, " : "");
            Console.WriteLine(fixed5 ? "5" : "");
        }
        else
        {
            Console.WriteLine("--------------------");
        }
    }
}
void sortDice()
{
    for (int i = 0; i < 5; i++)
    {
        if (dice1 > dice2)
        {
            int tmp = dice1;
            dice1 = dice2;
            dice2 = tmp;
        }
        if (dice2 > dice3)
        {
            int tmp = dice2;
            dice2 = dice3;
            dice3 = tmp;
        }
        if (dice3 > dice4)
        {
            int tmp = dice3;
            dice3 = dice4;
            dice4 = tmp;
        }
        if (dice4 > dice5)
        {
            int tmp = dice4;
            dice4 = dice5;
            dice5 = tmp;
        }
    }
}
void AnalyzeAndPrintResult()
{
    if (dice1 == dice5) {Console.WriteLine("Five of a kind");}
    else if (dice1 == dice4  || dice2 == dice5) { Console.WriteLine("Four of a kind");}
    else if ((dice1 == dice3 && dice4 == dice5) || (dice3 == dice5 && dice1 == dice2)) { Console.WriteLine("Full House");}
    else if (dice2 == dice4) { Console.WriteLine("Three of a kind");}
    else if ((dice1 == dice2 && (dice3 == dice4 || dice4 == dice5)) || (dice2 == dice3 && dice4 == dice5)) { Console.WriteLine("Two Pairs");}
    else if (dice1 == dice2 || dice2 == dice3 || dice3 == dice4 || dice4 == dice5) { Console.WriteLine("One pair");}
    else if ((dice1 == 1 && dice2 == 2 && dice3 == 3 && dice4 == 4 && dice5 == 5) || (dice1 == 2 && dice2 == 3 && dice3 == 4 && dice4 == 5 && dice5 == 6)) { Console.WriteLine("Straight");}
    else { Console.WriteLine("Bust");}
}
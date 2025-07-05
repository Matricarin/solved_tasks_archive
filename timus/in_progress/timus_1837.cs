/*
    Владислав Исенбаев — двукратный чемпион Урала по программированию, вице-чемпион TopCoder Open 2009, абсолютный чемпион ACM ICPC 2009. За то время, которое вы потратите на чтение этого условия, Владислав уже решил бы одну задачу. А может, и две…
    Поскольку Владислав Исенбаев — выпускник СУНЦ УрГУ, неудивительно, что многие из бывших и действующих олимпиадников УрГУ знакомы с ним уже много лет. Некоторые из них с гордостью заявляют, что играли с Владиславом в одной команде. Или играли в команде с бывшими однокомандниками Владислава…
    Определим число Исенбаева следующим образом. У самого Владислава это число равняется нулю. У тех, кто играл с ним в одной команде, оно равняется единице. У тех, кто играл вместе с однокомандниками Владислава, но не играл с ним самим, это число равняется двум, и так далее. Помогите автоматизировать процесс вычисления чисел Исенбаева, чтобы каждый олимпиадник в УрГУ мог знать, насколько близок он к чемпиону ACM ICPC.
Исходные данные
    В первой строке записано целое число n — количество команд (1 ≤ n ≤ 100). В каждой из следующих n строк записаны составы этих команд в виде фамилий трёх участников. Фамилия каждого участника — непустая строка, состоящая из английских букв, длиной не более 20 символов. Первая буква фамилии — заглавная, все остальные — строчные. Фамилия Владислава — «Isenbaev».
Результат
    Для каждого участника, представленного во входных данных, выведите в отдельной строке через пробел его фамилию и число Исенбаева. Если это число не определено, выведите вместо него «undefined». Участники должны быть упорядочены по фамилии в лексикографическом порядке. 
*/


using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public const string BestPlayer = "Isenbaev";
    public static TextReader? reader;
    public static TextWriter? writer;

    public static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture;

        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var commandsAmount = ReadInt();
        var commands = new List<string[]>();
        for (int i = 0; i < commandsAmount; i++)
        {
            commands.Add(ReadStringArray());
        }

        var raiting = new Dictionary<string, int>();
        var graph = new Dictionary<string, List<string>>();

        CreateGraph(commands, raiting, graph);

        var visited = new List<string>();

        Dfs(BestPlayer, graph, raiting, visited);

        PrintRaiting(raiting);

        reader.Close();
        writer.Close();
    }

    public static int ReadInt() => int.Parse(reader.ReadLine());

    public static string[] ReadStringArray() => reader.ReadLine().Split(' ');

    public static void PrintRaiting(Dictionary<string, int> raiting)
    {
        var ordered = raiting.OrderBy(p => p.Key);
        foreach (var player in ordered)
        {
            var personalRaiting = player.Value == 0 ? "undefined" : player.Value.ToString();
            writer.WriteLine($"{player.Key} {personalRaiting}");
        }
    }

    public static void Dfs(string lastName, Dictionary<string, List<string>> graph, Dictionary<string, int> raiting, List<string> visited)
    {
        visited.Add(lastName);
        var players = graph[lastName];
        foreach (var player in players)
        {
            if (!visited.Contains(player))
            {
                if (lastName == BestPlayer)
                {
                    raiting[player]++;
                }
                else
                {
                    if (raiting[lastName] != raiting[player] && player != BestPlayer)
                    {
                        raiting[player] = raiting[lastName] + 1;
                    }
                }
                Dfs(player, graph, raiting,visited);
            }
        }
    }

    public static void CreateGraph(List<string[]> commands, Dictionary<string, int> raiting, Dictionary<string, List<string>> graph)
    {
        foreach (var command in commands)
        {
            foreach (var player in command)
            {
                if (!raiting.ContainsKey(player))
                {
                    if (player == BestPlayer)
                    {
                        raiting.Add(player, -1);
                    }
                    else
                    {
                        raiting.Add(player, 0);
                    }
                }

                var mates = command.Where(p => p != player).ToList();

                if (!graph.TryAdd(player, mates))
                {
                    var currentMates = graph[player];
                    var newMates = mates.Union(currentMates).ToList();
                    graph[player] = newMates;
                }
            }
        }
    }
}
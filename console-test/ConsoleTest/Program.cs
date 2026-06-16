namespace ConsoleTest;

class Program
{
    private static TextReader? _reader;
    private static TextWriter? _writer;

    public static void Main(string[] args)
    {
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        _reader = new StreamReader(Console.OpenStandardInput());
        _writer = new StreamWriter(Console.OpenStandardOutput());

        var fa = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var array = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var size = fa[0];
        var requests = fa[1];

        for (int i = 0; i < requests; i++)
        {
            var request = int.Parse(_reader.ReadLine());
            var index = Array.IndexOf(array, request);
            _writer.WriteLine(index == -1 ? -1 : index + 1);
        }

        _reader.Close();
        _writer.Close();
    }   
}

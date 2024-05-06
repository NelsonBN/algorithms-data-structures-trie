using static System.Console;

var trie = new Trie();

trie.Insert("hello");
trie.Insert("helium");
trie.Insert("helicopters");
trie.Insert("help");
trie.Insert("hero");
trie.Insert("cat");
trie.Insert("category");
trie.Insert("dog");
trie.Insert("player");
trie.Insert("play");


WriteLine("############ Search results ############");
WriteLine($"helicopter: {trie.Search("helicopter")}"); // False
WriteLine($"helicopters: {trie.Search("helicopters")}"); // True
WriteLine($"hel: {trie.Search("hel")}"); // False
WriteLine($"help: {trie.Search("help")}"); // True
WriteLine($"player: {trie.Search("player")}"); // True


WriteLine("############ StartsWith results ############");
WriteLine($"helicopter: {trie.StartsWith("helicopter")}"); // True
WriteLine($"helicopters: {trie.StartsWith("helicopters")}"); // True
WriteLine($"hel: {trie.StartsWith("hel")}"); // True
WriteLine($"help: {trie.StartsWith("hy")}"); // False
WriteLine($"pl: {trie.StartsWith("pl")}"); // True


WriteLine("############ Delete ############");
WriteLine($"player: {trie.Search("player")}"); // True
WriteLine($"play: {trie.Search("play")}"); // True
trie.Delete("play");
WriteLine($"play: {trie.Search("play")}"); // False
WriteLine($"player: {trie.Search("player")}"); // True





class Node
{
    private const int ALPHABET_SIZE = 26;

    public Dictionary<char, Node> Children = new(ALPHABET_SIZE);
    public bool IsEndOfWord { get; set; } = false;
}


class Trie
{
    private readonly Node root = new();

    public void Insert(string word)
    {
        var node = root;
        for(int i = 0; i < word.Length; i++)
        {
            var ch = word[i];
            if (!node.Children.ContainsKey(ch))
            {
                node.Children[ch] = new();
            }
            node = node.Children[ch];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = root;
        for(int i = 0; i < word.Length; i++)
        {
            var ch = word[i];
            if (!node.Children.ContainsKey(ch))
            {
                return false;
            }
            node = node.Children[ch];
        }

        return node.IsEndOfWord; // Only return true if it's actually the end of a word
    }

    public bool StartsWith(string prefix)
    {
        var node = root;
        for(int i = 0; i < prefix.Length; i++)
        {
            var ch = prefix[i];
            if (!node.Children.ContainsKey(ch))
            {
                return false;
            }
            node = node.Children[ch];
        }

        return true;  // If all chars in the prefix are found, return true
    }

    public void Delete(string word)
    {
        var node = root;
        for(int i = 0; i < word.Length; i++)
        {
            var ch = word[i];
            if (!node.Children.ContainsKey(ch))
            {
                return;
            }
            node = node.Children[ch];
        }
        node.IsEndOfWord = false;
    }
}

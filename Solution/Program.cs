static void Main()
{
    string[] words = { "programming", "hangman", "computer", "science", "challenge",  "apple", "banana", "cherry", "grape", "lemon", "mango", "orange", "peach", "pear", "plum",
    "apricot", "blueberry", "coconut", "fig", "guava", "kiwi", "lime", "lychee", "melon", "papaya",
    "pineapple", "raspberry", "strawberry", "watermelon", "avocado", "cabbage", "carrot", "celery",
    "cucumber", "garlic", "lettuce", "onion", "potato", "pumpkin", "radish", "spinach", "tomato",
    "turnip", "broccoli", "cauliflower", "zucchini", "pepper", "squash", "kale", "eggplant",
    "asparagus", "artichoke", "beet", "brussels", "chard", "corn", "pea", "bean", "okra", "parsnip",
    "rhubarb", "yam", "basil", "thyme", "rosemary", "oregano", "sage", "dill", "parsley", "cilantro",
    "chive", "tarragon", "mint", "lavender", "lemongrass", "ginger", "turmeric", "cinnamon", "clove",
    "nutmeg", "peppermint", "sagebrush", "saffron", "bay", "bamboo", "cacao", "carob", "coriander",
    "fennel", "fenugreek", "juniper", "lavender", "lotus", "mace", "olive", "paprika", "sesame",
    "tamarind", "vanilla", "wasabi", "wild", "thyme", "zest", "arugula", "ginseng", "marjoram" };
    List<char> guessedLetters = new List<char>();
    string selectedWord;

    while (true)
{
     Console.Clear();
     DrawHeader("WELCOME TO HANGMAN");
     DisplayMainMenu();
     string choice = Console.ReadLine();

     switch (choice)
     {
         case "1":
             selectedWord = SelectWord(words);
             int attempts = SelectDifficulty();
             PlayGame(selectedWord, attempts, guessedLetters);
             break;
         case "2":
             ChangeSettings();
             break;
         case "3":
             Console.WriteLine("Thank you for playing! Goodbye!");
             return;
default:
                Console.WriteLine("Invalid choice. Press any key to try again.");
                Console.ReadKey();
                break;
        }
    }
}

static void DrawHeader(string title)
{
    Console.WriteLine(new string('=', 40));
    Console.WriteLine($"          {title}");
    Console.WriteLine(new string('=', 40));
}

static void DisplayMainMenu()
{
    Console.WriteLine("=== HANGMAN GAME ===");
    Console.WriteLine("1. Play Game");
    Console.WriteLine("2. Settings");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");
}
static string SelectWord(string[] words)
{
    Random random = new Random();
    return words[random.Next(words.Length)];
}

static int SelectDifficulty()
{
    Console.Clear();
    DrawHeader("SELECT DIFFICULTY");
    Console.WriteLine("╔══════════════════════════════════╗");
    Console.WriteLine("║          DIFFICULTY LEVEL       ║");
    Console.WriteLine("╠══════════════════════════════════╣");
    Console.WriteLine("║  1. Easy    (10 attempts)       ║");
    Console.WriteLine("║  2. Medium  (6 attempts)        ║");
    Console.WriteLine("║  3. Hard    (4 attempts)        ║");
    Console.WriteLine("╚══════════════════════════════════╝");
    Console.Write("Choose a difficulty (1-3): ");
string choice = Console.ReadLine();
    int attempts;

    switch (choice)
    {
        case "1":
            attempts = 10;
            break;
        case "2":
            attempts = 6;
            break;
        case "3":
            attempts = 4;
            break;
        default:
            Console.WriteLine("Invalid choice. Defaulting to Medium difficulty.");
            attempts = 6;
            break;
    }
    return attempts;
}

static void PlayGame(string selectedWord, int attempts, List<char> guessedLetters)
{
    int initialAttempts = attempts;

    while (attempts > 0)
    {
        Console.Clear();
        DrawHeader("HANGMAN GAME");
        DisplayHangman(initialAttempts - attempts);
        DisplayWord(selectedWord, guessedLetters);
        Console.WriteLine($"Attempts left: {attempts}");
        Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
        Console.Write("Enter a letter: ");
string input = Console.ReadLine();
 if (!string.IsNullOrEmpty(input))
 {
     char guess = char.ToLower(input[0]);

     switch (guessedLetters.Contains(guess))
     {
         case false:
             guessedLetters.Add(guess);
             if (!selectedWord.Contains(guess))
             {
                 attempts--;
             }
             break;
         case true:
             Console.WriteLine("You already guessed that letter. Try again.");
             break;
     }
if (IsWordGuessed(selectedWord, guessedLetters))
        {
            Console.Clear();
            DrawHeader("CONGRATULATIONS!");
            Console.WriteLine($"You've guessed the word: {selectedWord}");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            return;
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid letter.");
    }
}

Console.Clear();
DrawHeader("GAME OVER");
Console.WriteLine($"The word was: {selectedWord}");
Console.WriteLine("Press any key to return to the main menu...");
Console.ReadKey();
}

static void DisplayHangman(int stage)
{
    string[] hangmanStages = {
@"





            ",
            @"




             |
            ",
            @"
             
             |
             |
             |
             |
            ",
            @"
             
             |  |
             |
             |
             |
            ",
            @"
             
             |  |
             |  O
             |
             |
            ",
            @"
             
             |  |
             |  O
             |  |
             |
            ",
            @"
             
             |  |
             |  O
             | /|
             |
            ",
            @"
             
             |  |
             |  O
             | /|\
             |
            ",
            @"
             
             |  |
             |  O
             | /|\
             | / 
            ",
            @"
             
             |  |
             |  O
             | /|\
             | / \
            "
        };

    Console.WriteLine(hangmanStages[stage]);
}

static void DisplayWord(string word, List<char> guessedLetters)
{
foreach (char letter in word)
    {
        if (guessedLetters.Contains(letter))
            Console.Write(letter + " ");
        else
            Console.Write("_ ");
    }
    Console.WriteLine();
}

static bool IsWordGuessed(string word, List<char> guessedLetters)
{
    foreach (char letter in word)
    {
        if (!guessedLetters.Contains(letter))
            return false;
    }
    return true;
}
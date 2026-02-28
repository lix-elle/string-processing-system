using StringProcessingApp.Services;

namespace StringProcessingApp.Views
{
    public class StringView
    {
        private readonly StringService _service = new StringService();

        public void Run()
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        EnterText();
                        break;
                    case "2":
                        ViewCurrentText();
                        break;
                    case "3":
                        ConvertToUpper();
                        break;
                    case "4":
                        ConvertToLower();
                        break;
                    case "5":
                        CountCharacters();
                        break;
                    case "6":
                        CheckContains();
                        break;
                    case "7":
                        ReplaceWord();
                        break;
                    case "8":
                        ExtractSubstring();
                        break;
                    case "9":
                        TrimSpaces();
                        break;
                    case "10":
                        ResetText();
                        break;
                    case "11":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("   STRING PROCESSING SYSTEM  ");
            Console.WriteLine("=============================");
            Console.WriteLine("1.  Enter Text");
            Console.WriteLine("2.  View Current Text");
            Console.WriteLine("3.  Convert to UPPERCASE");
            Console.WriteLine("4.  Convert to lowercase");
            Console.WriteLine("5.  Count Characters");
            Console.WriteLine("6.  Check if Contains Word");
            Console.WriteLine("7.  Replace Word");
            Console.WriteLine("8.  Extract Substring");
            Console.WriteLine("9.  Trim Spaces");
            Console.WriteLine("10. Reset Text");
            Console.WriteLine("11. Exit");
            Console.WriteLine("=============================");
        }

        private void EnterText()
        {
            Console.Write("Enter your text: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                _service.SetText(input);
                Console.WriteLine("Text saved successfully!");
            }
            else
            {
                Console.WriteLine("No text entered.");
            }
        }

        private void ViewCurrentText()
        {
            if (!_service.HasText())
                Console.WriteLine("No text entered yet.");
            else
                Console.WriteLine($"Current Text: \"{_service.GetCurrentText()}\"");
        }

        private void ConvertToUpper()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.WriteLine($"UPPERCASE: \"{_service.ToUpperCase()}\"");
        }

        private void ConvertToLower()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.WriteLine($"lowercase: \"{_service.ToLowerCase()}\"");
        }

        private void CountCharacters()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.WriteLine($"Character Count: {_service.CountCharacters()}");
        }

        private void CheckContains()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.Write("Enter word to search: ");
            string? word = Console.ReadLine();
            if (string.IsNullOrEmpty(word)) { Console.WriteLine("No word entered."); return; }
            bool found = _service.ContainsWord(word);
            Console.WriteLine(found
                ? $"✓ The text contains \"{word}\"."
                : $"✗ The text does NOT contain \"{word}\".");
        }

        private void ReplaceWord()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.Write("Enter word to replace: ");
            string? oldWord = Console.ReadLine();
            Console.Write("Enter new word: ");
            string? newWord = Console.ReadLine();
            if (string.IsNullOrEmpty(oldWord) || newWord == null) { Console.WriteLine("Invalid input."); return; }
            Console.WriteLine($"Result: \"{_service.ReplaceWord(oldWord, newWord)}\"");
        }

        private void ExtractSubstring()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.WriteLine($"Current Text: \"{_service.GetCurrentText()}\" (Length: {_service.CountCharacters()})");
            Console.Write("Enter start index: ");
            if (!int.TryParse(Console.ReadLine(), out int start)) { Console.WriteLine("Invalid index."); return; }
            Console.Write("Enter length: ");
            if (!int.TryParse(Console.ReadLine(), out int length)) { Console.WriteLine("Invalid length."); return; }

            try
            {
                Console.WriteLine($"Substring: \"{_service.ExtractSubstring(start, length)}\"");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error: Index or length is out of range.");
            }
        }

        private void TrimSpaces()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.WriteLine($"Trimmed: \"{_service.TrimSpaces()}\"");
        }

        private void ResetText()
        {
            if (!_service.HasText()) { Console.WriteLine("Please enter text first."); return; }
            Console.WriteLine($"Text reset to: \"{_service.ResetText()}\"");
        }
    }
}

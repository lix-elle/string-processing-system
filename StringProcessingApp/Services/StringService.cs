namespace StringProcessingApp.Services
{
    public class StringService
    {
        private string originalText = "";
        private string currentText = "";

        public void SetText(string text)
        {
            originalText = text;
            currentText = text;
        }

        public string GetCurrentText() => currentText;

        public string ToUpperCase() => currentText = currentText.ToUpper();

        public string ToLowerCase() => currentText = currentText.ToLower();

        public int CountCharacters() => currentText.Length;

        public bool ContainsWord(string word) => currentText.Contains(word);

        public string ReplaceWord(string oldWord, string newWord)
            => currentText = currentText.Replace(oldWord, newWord);

        public string ExtractSubstring(int startIndex, int length)
            => currentText.Substring(startIndex, length);

        public string TrimSpaces() => currentText = currentText.Trim();

        public string ResetText()
        {
            currentText = originalText;
            return currentText;
        }

        public bool HasText() => !string.IsNullOrEmpty(currentText);
    }
}

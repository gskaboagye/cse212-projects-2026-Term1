using System;
using System.Collections.Generic;

public class TranslatorSolution
{
    public static void Run()
    {
        // Create a new translator dictionary
        var englishToGerman = new TranslatorSolution();

        // Add translations
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        // Test translations
        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }

    // Dictionary to store translations
    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// For example, in an English to German dictionary:
    /// my_translator.AddWord("book", "buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    public void AddWord(string fromWord, string toWord)
    {
        // Add or update the translation in the dictionary
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the 'fromWord' into the word stored in the dictionary
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        // Use TryGetValue for efficiency and clarity
        if (_words.TryGetValue(fromWord, out var translation))
        {
            return translation;
        }

        // Return ??? if translation not found
        return "???";
    }
}

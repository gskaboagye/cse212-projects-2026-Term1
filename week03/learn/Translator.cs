using System;
using System.Collections.Generic;

public class Translator 
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// For example, in a english to german dictionary:
    /// 
    /// my_translator.AddWord("book","buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    public void AddWord(string fromWord, string toWord)
    {
        // Only add if the word is not already in the dictionary
        if (!_words.ContainsKey(fromWord))
        {
            _words[fromWord] = toWord;
        }
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        // Return translation if found, otherwise "???"
        if (_words.TryGetValue(fromWord, out var translation))
        {
            return translation;
        }
        return "???";
    }
}

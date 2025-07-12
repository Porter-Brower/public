using System;

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string result = "";
            foreach (char c in _text)
            {
                result += Char.IsLetter(c) ? "_" : c; // so this blocks out the words when correct but leasves commas and stuff and would leave if you got it correct ___;
            }
            return result;
        }
        else
        {
            return _text;
        }
    }
}

using System;
public class MenuItem
{
    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            if (value == null) throw new Exception("MenuItem must have a title");
            _title = value;
        }
    }

    public MenuItem(string title)
    {
        Title = title;
    }
}
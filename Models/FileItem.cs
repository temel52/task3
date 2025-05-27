using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace File.Models;

public enum FileCategory
{
    File,
    Folder
}

public partial class FileItem : ObservableObject
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private FileCategory _category;

    [ObservableProperty]
    private long _size;

    [ObservableProperty]
    private string _location;

    public FileItem(string name, FileCategory category, long size, string location)
    {
        if (category == FileCategory.Folder && size != 0)
        {
            throw new ArgumentException("Folder size must be 0");
        }

        _name = name;
        _category = category;
        _size = size;
        _location = location;
    }

    public FileItem CopyTo(string newLocation)
    {
        return new FileItem(Name, Category, Size, newLocation);
    }

    public void MoveTo(string newLocation)
    {
        Location = newLocation;
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    public override string ToString()
    {
        return $"{Name} ({Category}) - {Size} bytes at {Location}";
    }
}
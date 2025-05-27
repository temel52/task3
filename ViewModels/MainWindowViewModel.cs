using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using File.Models;

namespace File.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? _selectedLocation;

    [ObservableProperty]
    private string? _newName;

    [ObservableProperty]
    private FileItem? _selectedFile;

    public ObservableCollection<FileItem> Files { get; } = new();

    public MainWindowViewModel()
    {
        // Инициализация тестовыми данными
        Files.Add(new FileItem("Document.txt", FileCategory.File, 1024, "C:\\Files"));
        Files.Add(new FileItem("Images", FileCategory.Folder, 0, "C:\\Files"));
        Files.Add(new FileItem("Report.pdf", FileCategory.File, 2048, "D:\\Documents"));
    }

    [RelayCommand]
    private void CopyFile()
    {
        if (SelectedFile == null || string.IsNullOrWhiteSpace(SelectedLocation))
            return;

        var newFile = SelectedFile.CopyTo(SelectedLocation);
        Files.Add(newFile);
    }

    [RelayCommand]
    private void MoveFile()
    {
        if (SelectedFile == null || string.IsNullOrWhiteSpace(SelectedLocation))
            return;

        SelectedFile.MoveTo(SelectedLocation);
    }

    [RelayCommand]
    private void RenameFile()
    {
        if (SelectedFile == null || string.IsNullOrWhiteSpace(NewName))
            return;

        SelectedFile.Rename(NewName);
        NewName = string.Empty;
    }
}
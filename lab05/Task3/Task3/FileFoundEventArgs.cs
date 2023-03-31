namespace Task3;

class FileFoundEventArgs : EventArgs
{
    public string FileName { get; }

    public FileFoundEventArgs(string fileName)
    {
        this.FileName = fileName;
    }
}
public class Option<T>
    where T : Enum
{
    public T EOption { get; init; }
    public string Label { get; init; }

    public Option(T option, string label)
    {
        EOption = option;
        Label = label;
    }
}

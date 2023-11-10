public class Field<T> : IField
{
    public string Label { get; init; }
    public string Value { get; set; }
    public T ParsedValue
    {
        get => Parser(Value);
    }
    object IField.ParsedValue => ParsedValue; // Explicit interface implementation

    private Func<string, T> Parser;

    public Field(string label, Func<string, T> parser)
    {
        Label = label;
        Value = "";
        Parser = parser;
    }
}

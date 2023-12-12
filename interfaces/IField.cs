public interface IField
{
    string Label { get; }
    string Value { get; set; }
    object ParsedValue { get; }
}

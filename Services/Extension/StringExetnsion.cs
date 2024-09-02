public static class StringExtension
{
    public static bool IsNullOrWithSpaceOrEmpty(this string? text) 
    {
        return String.IsNullOrEmpty(text) || String.IsNullOrWhiteSpace(text);
    }
}
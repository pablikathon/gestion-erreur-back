using System.Reflection;

public static class FunctionExpression {
    public static MethodInfo ContainMethod = typeof(string).GetMethod("Contains", new[] { typeof(string)});

}
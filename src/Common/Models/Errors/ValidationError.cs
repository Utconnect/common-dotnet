namespace Common.Models.Errors;

public class ValidationError(string property, string message) : Error(property, message);
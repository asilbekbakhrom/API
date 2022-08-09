namespace quizz.Models.Topic.Exceptions;

public class TopicNotFoundException : Exception
{
    public TopicNotFoundException()
        : base("No topics found in the system.") { }
}

public class TopicServiceValidationException : Exception
{
    public TopicServiceValidationException()
        : base("Topic service validation failed.") { }

    public TopicServiceValidationException(string propertyName)
        : base($"Invalid {propertyName}.") { }
}

public class TopicServiceDependencyException : Exception
{
    public TopicServiceDependencyException()
        : base("Error occured in Topic Service. Contact support.") { }

    public TopicServiceDependencyException(string message, Exception inner)
        : base(message, inner) { }
}
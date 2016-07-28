using System.Linq;

namespace exercism.bob
{
    public interface IResponse
    {
        string Respond();
    }

    public class ShoutingResponse : IResponse
    {
        public string Respond()
        {
            return "Whoa, chill out!";
        }
    }

    public class QuestionResponse : IResponse
    {
        public string Respond()
        {
            return "Sure.";
        }
    }

    public class SilenceResponse : IResponse
    {
        public string Respond()
        {
            return "Fine. Be that way!";
        }
    }

    public class DefaultResponse : IResponse
    {
        public string Respond()
        {
            return "Whatever.";
        }
    }

    public class Bob
    {
        public static string Hey(string statement)
        {
            return BuildResponse(statement).Respond();
        }

        private static IResponse BuildResponse(string statement)
        {
            if (statement.ToUpper() == statement && statement.Any(char.IsLetter))
                return new ShoutingResponse();
            var trim = statement.Trim();
            if (trim.EndsWith("?"))
                return new QuestionResponse();
            return trim == string.Empty ? (IResponse) new SilenceResponse() : new DefaultResponse();
        }
    }
}
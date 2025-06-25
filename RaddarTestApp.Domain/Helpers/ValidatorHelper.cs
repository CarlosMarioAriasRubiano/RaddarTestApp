using RaddarTestApp.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace RaddarTestApp.Domain.Helpers
{
    public static class ValidatorHelper
    {
        public static void ValidateNullObject<T>([NotNull] this T obj)
            where T : class
        {
            if (obj is null)
            {
                throw new AppException(string.Format(MessagesExceptions.ObjectNull, nameof(obj)));
            }
        }

        public static void ValidateInvalidId(this int value)
        {
            if (value < 0)
            {
                throw new AppException(MessagesExceptions.InvalidId);
            }
        }

        public static void ValidateIsNullOrEmpty(this string value, string field)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new AppException(string.Format(MessagesExceptions.FieldEmpty, field));
            }
        }
    }
}

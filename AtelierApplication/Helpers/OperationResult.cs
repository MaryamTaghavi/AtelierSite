namespace Atelier.Application.Helpers
{
    public class OperationResult
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSucceed = false;
        }

        public OperationResult Succeed(string message = OperationResultMessage.Success)
        {
            IsSucceed = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSucceed = false;
            Message = message;
            return this;
        }
    }
    public static class OperationResultMessage
    {
        public const string FileNotSelected = "فایل انتخاب نشده است";
        public const string ExcelFileNotSelected = "فایل اکسل انتخاب نشده است";
        public const string Success = "عملیات با موفقیت انجام شد";
        public const string FailNoBankAccount = "حساب بانک در سیستم یافت نشد";

    }
}
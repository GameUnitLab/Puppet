﻿
namespace DriverContracts
{
    public static class Contracts
    {
        public static class Methods
        {
            public const string CreateSession = "createsession";
            public const string KillSession = "killsession";
            public const string Click = "click";
            public const string SendKeys = "sendkeys";
            public const string Exist = "exist";
            public const string Active = "active";
            public const string StartPlayMode = "startplaymode";
            public const string StopPlayMode = "stopplaymode";
            public const string TakeScreenshot = "takescreenshot";
        }

        public static class Parameters
        {
            public const string Method = "method";
            public const string StatusCode = "statuscode";
            public const string ErrorMessage = "errormessage";
            public const string Result = "result";
            public const string Session = "session";
            public const string Value = "value";
            public const string Name = "name";
            public const string Parent = "parent";
            public const string Path = "path";
        }

        public static class ErrorCodes
        {
            public const int Success = 0;
            public const int MethodNotSupported = 5;
            public const int MethodNodeIsNotPresent = 11;
        }

        public static class ActionResults
        {
            public const string Success = "success";
            public const string Fail = "fail";
        }
    }
}
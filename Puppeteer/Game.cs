﻿using System.IO;
using Puppetry.Puppeteer.Conditions.Game;
using Puppetry.Puppeteer.Exceptions;
using Puppetry.Puppeteer.Utils;

namespace Puppetry.Puppeteer
{
    public static class Game
    {
        public static void MakeScreenshot(string fileName, string folderName)
        {
            var path = Path.Combine(Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), folderName)).FullName, fileName);

            PuppetryDriver.Instance.TakeScreenshot(path);
        }

        public static void MakeScreenshot(string fullPath)
        {
            PuppetryDriver.Instance.TakeScreenshot(fullPath);
        }

        public static void DeletePlayerPref(string key)
        {
            PuppetryDriver.Instance.DeletePlayerPref(key);
        }
        
        public static void DeleteAllPlayerPrefs()
        {
            PuppetryDriver.Instance.DeleteAllPlayerPrefs();
        }

        public static float GetFloatPlayerPref(string key)
        {
            var stringResult = PuppetryDriver.Instance.GetFloatPlayerPref(key);
            if (float.TryParse(stringResult, out var result))
                return result;

            throw new PuppetryException(stringResult);
        }

        public static int GetIntPlayerPref(string key)
        {
            var stringResult = PuppetryDriver.Instance.GetIntPlayerPref(key);
            if (int.TryParse(stringResult, out var result))
                return result;

            throw new PuppetryException(stringResult);
        }

        public static string GetStringPlayerPref(string key)
        {
            return PuppetryDriver.Instance.GetStringPlayerPref(key);
        }

        public static void SetFloatPlayerPref(string key, float value)
        {
            PuppetryDriver.Instance.SetFloatPlayerPref(key, value.ToString());
        }

        public static void SetIntPlayerPref(string key, int value)
        {
            PuppetryDriver.Instance.SetIntPlayerPref(key, value.ToString());
        }

        public static void SetStringPlayerPref(string key, string value)
        {
            PuppetryDriver.Instance.SetStringPlayerPref(key, value);
        }

        public static bool PlayerPrefHasKey(string key)
        {
            var stringResult = PuppetryDriver.Instance.PlayerPrefHasKey(key);
            if (bool.TryParse(stringResult, out var result))
                return result;

            throw new PuppetryException(stringResult);
        }

        public static string GetSceneName()
        {
            return PuppetryDriver.Instance.GetSceneName();
        }

        public static void OpenScene(string scene)
        {
            PuppetryDriver.Instance.OpenScene(scene);
        }

        public static void SetTimeScale(float timeScale)
        {
            PuppetryDriver.Instance.SetTimeScale(timeScale);
        }

        public static void ExecuteCustomMethod(string method, string value = null)
        {
            PuppetryDriver.Instance.GameCustomMethod(method, value);
        }

        public static void Should(Condition condition, int timeoutMs)
        {
            Wait.For(() => condition.Invoke(),
                () =>
                    $"Timed out after {timeoutMs / 1000} seconds while waiting for Condition: {condition}",
                timeoutMs);
        }

        public static void Should(Condition condition)
        {
            Should(condition, Configuration.TimeoutMs);
        }

        public static void ShouldNot(Condition condition, int timeoutMs)
        {
            Wait.For(() => !condition.Invoke(),
                () =>
                    $"Timed out after {timeoutMs / 1000} seconds while waiting for Condition Not fulfilled: {condition}",
                timeoutMs);
        }

        public static void ShouldNot(Condition condition)
        {
            ShouldNot(condition, Configuration.TimeoutMs);
        }
    }
}